using Microsoft.EntityFrameworkCore;
using SamCommerce.Platform.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Data.Infrastructure
{
    public class DbContextUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets the database context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        public DbContext DbContext { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextUnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public DbContextUnitOfWork(DbContext context)
        {
            DbContext = context;
        }

        /// <summary>
        /// Commits all changes made in this context
        /// </summary>
        /// <returns></returns>
        public virtual int Commit()
        {
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// Commits all changes made in this context
        /// </summary>
        /// <returns></returns>
        public virtual Task<int> CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }
    }
}