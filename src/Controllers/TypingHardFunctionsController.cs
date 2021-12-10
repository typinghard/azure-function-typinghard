using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace FuncAzureTypingHard.Controllers
{
    internal class TypingHardFunctionsController
    {
        [FunctionName("completed-pr")]
        public IActionResult Ping(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        ILogger log)
        {
            //try
            //{
            //    var credential = new ClientSecretCredential("490026e7-1121-4a1e-8020-635db5d04440", "3ad47de1-9c9e-4f6b-a3ba-0fbda762d8ae", "GP47Q~7DurWOqMZHUzzeETvOixRib9hire4WK");

            //    var armClient = new ArmClient(credential);
            //    string rgName = "rg-radt-16";
            //    Subscription subscription = armClient.GetDefaultSubscription();
                
            //    var rgs = subscription.GetResourceGroups();
            //    var rgsl = subscription.GetResourceGroups().GetAll().ToList();
            //    ResourceGroup rg = subscription.GetResourceGroups().Get(rgName);
            //    rg.Delete();
            //}
            //catch (Exception e)
            //{
                
            //}
            return new OkObjectResult("Azure Functions TypingHard - Ok - Ping");
        }

    }
}