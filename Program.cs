using System;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace AzureSdkTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Task.Run(async () =>
            {
                var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal("", "", "", AzureEnvironment.AzureGlobalCloud);

                var azure = Azure
                        .Configure()
                        .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                        .Authenticate(credentials)
                        .WithDefaultSubscription();


                var app = await azure.AppServices.FunctionApps.GetByIdAsync("/subscriptions/f60f76fe-50f5-49ad-a468-4d15f804a081/resourceGroups/Mmu/providers/Microsoft.Web/sites/TestSdk1234");
                var appSettings = await app.GetAppSettingsAsync();

            });

            Console.ReadKey();
        }
    }
}
