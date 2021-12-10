using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using FuncAzureTypingHard.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;

namespace FuncAzureTypingHard.Controllers
{
    internal class GitHubRepositoriesFunctionsController
    {

        [FunctionName("pr-completed")]
        public IActionResult PrCompleted(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
        {
            try
            {
                var gitHubWebhook = JsonSerializer.Deserialize<GitHubWebhook>(req.ReadAsStringAsync().Result);

                var armClient = new ArmClient(new DefaultAzureCredential());
                string rgName = "rg-radt-16";
                Subscription subscription = armClient.GetDefaultSubscription();
                ResourceGroup rg = subscription.GetResourceGroups().Get(rgName);
                rg.Delete();
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }

            return new OkObjectResult(HttpStatusCode.OK);
        }
    }
}