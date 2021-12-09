using AzureDevopsTracker.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text;

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
            return new OkObjectResult(new { data = "Azure Functions TypingHard - Ok - Ping" });
        }

    }
}