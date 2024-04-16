using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SamCommerce.Platform.Core.ChangeLog;
using SamCommerce.Platform.Core.Common;
using SamCommerce.Platform.Core.Events;
using SamCommerce.Platform.Data.Common;
using SamCommerce.Platform.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPlatformServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddOptions<CrudOptions>().Bind(configuration.GetSection("Crud"));

            //services.AddTransient<IPlatformRepository, PlatformRepository>();
            //services.AddTransient<Func<IPlatformRepository>>(provider => () => provider.CreateScope().ServiceProvider.GetService<IPlatformRepository>());

            //services.AddSettings();
            //services.AddLocalization();
            //services.AddDynamicProperties();

            //services.AddSingleton<InProcessBus>();
            //services.AddSingleton<IEventHandlerRegistrar>(x => x.GetRequiredService<InProcessBus>());
            //services.AddSingleton<IHandlerRegistrar>(x => x.GetRequiredService<InProcessBus>());
            //services.AddSingleton<IEventPublisher>(x => x.GetRequiredService<InProcessBus>());
            //services.AddTransient<IChangeLogService, ChangeLogService>();
            //services.AddTransient<ILastModifiedDateTime, ChangeLogService>();
            //services.AddTransient<ILastChangesService, LastChangesService>();

            //services.AddTransient<IChangeLogSearchService, ChangeLogSearchService>();

            services.AddCaching(configuration);

            //services.AddScoped<IPlatformExportImportManager, PlatformExportImportManager>();
            //services.AddSingleton<ITransactionFileManager, TransactionFileManager.TransactionFileManager>();

            //services.AddTransient<IEmailSender, DefaultEmailSender>();


            //Register dependencies for translation
            //services.AddSingleton<ITranslationDataProvider, PlatformTranslationDataProvider>();
            //services.AddSingleton<ITranslationDataProvider, ModulesTranslationDataProvider>();
            //services.AddSingleton<ITranslationService, TranslationService>();

            services.AddSingleton<ICountriesService, FileSystemCountriesService>();
            //services.AddSingleton<IFileSystem, FileSystem>();
            //services.AddTransient<IZipFileWrapper, ZipFileWrapper>();

            return services;
        }
    }
}
