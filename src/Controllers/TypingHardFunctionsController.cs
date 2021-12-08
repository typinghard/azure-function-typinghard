using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace FuncAzureTypingHard.Controllers
{
    internal class TypingHardFunctionsController
    {

        [FunctionName("ping")]
        public IActionResult Ping(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        ILogger log)
        {
            return new OkObjectResult(new { data = "Azure Functions TypingHard - Ok - Ping" });
        }

    }
}