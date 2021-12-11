using AzureDevopsTracker.Configurations;
using AzureDevopsTracker.Data;
using AzureDevopsTracker.Services;
using FuncAzureTypingHard;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace FuncAzureTypingHard
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;

            builder.Services.AddScoped<ChangeLogService>();

            builder.Services.AddAzureDevopsTracker(new DataBaseConfig(configuration["ConnectionStrings:DefaultConnection"]));
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            builder.ConfigurationBuilder
                   .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                   .AddEnvironmentVariables()
                   .Build();
        }
    }
}
