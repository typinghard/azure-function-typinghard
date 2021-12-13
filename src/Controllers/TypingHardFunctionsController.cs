using AzureDevopsTracker.Services;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Linq;

namespace FuncAzureTypingHard.Controllers
{
    internal class TypingHardFunctionsController
    {
        private readonly ChangeLogService _changeLogService;

        public TypingHardFunctionsController(ChangeLogService changeLogService)
        {
            _changeLogService = changeLogService;
        }

        [FunctionName("count-items-for-release")]
        public IActionResult CountItemsForRelease(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        ILogger log)
        {
            try
            {
                var count = _changeLogService.CountItemsForRelease();

                var returnText = new StringBuilder();
                if (count == 0 || count == 1)
                    returnText.Append($"{count} Item");
                else
                    returnText.Append($"{count} Items");

                return new OkObjectResult(new { data = returnText.ToString() });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new { data = ex.Message });
            }
        }

        [FunctionName("ping")]
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
            return new OkObjectResult(new { data = "Azure Functions TypingHard - Ok - Ping" });
        }

    }
}