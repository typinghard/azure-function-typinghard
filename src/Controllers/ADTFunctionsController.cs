using AzureDevopsTracker.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace FuncAzureTypingHard.Controllers
{
    internal class ADTFunctionsController
    {
        private readonly IChangeLogService _changeLogService;

        public ADTFunctionsController(IChangeLogService changeLogService)
        {
            _changeLogService = changeLogService;
        }

        [FunctionName("pending-changelog-items")]
        public IActionResult GetChangelogItemsPending(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        ILogger log)
        {
            try
            {
                //adtService.GenerateBadgeData();

                //Consultar ChangeLogItems sem release
                /*https://shields.io/endpoint*/
                /*
                 {
                   "schemaVersion": 1,
                   "label": "hello",
                   "message": "sweet world",
                   "color": "orange"
                 }
                 */
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }

            return new OkObjectResult(HttpStatusCode.OK);
        }

        [FunctionName("release-changelog")]
        public IActionResult ReleaseChangelog(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        ILogger log)
        {
            var changeLog = _changeLogService.Release();
            if (changeLog is null) return new OkObjectResult("There's no WorkItems waiting for a ChangeLog");

            var message = _changeLogService.SendToMessengers(changeLog);
            return new OkObjectResult(message);
        }
    }
}