using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SamCommerce.Platform.Core.Common;
using SamCommerce.Platform.Core.Domain;
using SamCommerce.Platform.Core.Extensions;
using SamCommerce.Platform.Core.Security.Search;
using SamCommerce.Platform.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Security.Services
{
    public class UserSearchService : IUserSearchService
    {
        private readonly Func<UserManager<ApplicationUser>> _userManagerFactory;
        private readonly Func<RoleManager<Role>> _roleManagerFactory;

        public UserSearchService(Func<UserManager<ApplicationUser>> userManager, Func<RoleManager<Role>> roleManagerFactory)
        {
            _userManagerFactory = userManager;
            _roleManagerFactory = roleManagerFactory;
        }

        public async Task<UserSearchResult> SearchUsersAsync(UserSearchCriteria criteria)
        {
            using var userManager = _userManagerFactory();
            using var roleManager = _roleManagerFactory();

            if (criteria == null)
            {
                throw new ArgumentNullException(nameof(criteria));
            }
            if (!userManager.SupportsQueryableUsers)
            {
                throw new NotSupportedException();
            }

            var result = AbstractTypeFactory<UserSearchResult>.TryCreateInstance();
            var query = userManager.Users.Include(x => x.UserRoles) as IQueryable<ApplicationUser>;

            if (criteria.Keyword != null)
            {
                query = query.Where(x => x.UserName.Contains(criteria.Keyword));
            }

            if (!string.IsNullOrEmpty(criteria.MemberId))
            {
                query = query.Where(x => x.MemberId == criteria.MemberId);
            }

            if (!criteria.MemberIds.IsNullOrEmpty())
            {
                query = query.Where(x => criteria.MemberIds.Contains(x.MemberId));
            }

            if (criteria.ModifiedSinceDate != null && criteria.ModifiedSinceDate != default(DateTime))
            {
                query = query.Where(x => x.ModifiedDate > criteria.ModifiedSinceDate);
            }

            if (!criteria.Roles.IsNullOrEmpty())
            {
                if (!roleManager.SupportsQueryableRoles)
                {
                    throw new NotSupportedException();
                }
                var rolesIds = await roleManager.Roles.Where(x => criteria.Roles.Contains(x.Name)).Select(x => x.Id).Distinct().ToArrayAsync();

                query = query.Where(x => x.UserRoles.Any(r => rolesIds.Contains(r.RoleId)));
            }

            if (criteria.LasLoginDate != null && criteria.LasLoginDate != default(DateTime))
            {
                query = query.Where(x => x.LastLoginDate != null && x.LastLoginDate <= criteria.LasLoginDate);
            }

            if (criteria.OnlyUnlocked)
            {
                query = query.Where(x => x.LockoutEnabled && (x.LockoutEnd == null || x.LockoutEnd <= DateTime.UtcNow));
            }

            result.TotalCount = await query.CountAsync();

            var sortInfos = criteria.SortInfos;
            if (sortInfos.IsNullOrEmpty())
            {
                sortInfos = new[] { new SortInfo { SortColumn = ReflectionUtility.GetPropertyName<ApplicationUser>(x => x.UserName), SortDirection = SortDirection.Descending } };
            }
            result.Results = await query.OrderBySortInfos(sortInfos).Skip(criteria.Skip).Take(criteria.Take).ToArrayAsync();

            foreach (var user in result.Results)
            {
                user.Roles = await roleManager.Roles.Where(x => user.UserRoles.Select(y => y.RoleId).Contains(x.Id)).ToListAsync();
            }

            return result;
        }
    }
}