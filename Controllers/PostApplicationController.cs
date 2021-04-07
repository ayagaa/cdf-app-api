using CDF.API.DataAccess;
using CDF.API.Models;
using CDF.API.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDF.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PostApplicationController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly AuthMessageSender authMessageSender;
        private readonly ApplicationDatabase applicationService;

        public PostApplicationController(ApplicationDatabase applicationDatabase, IConfiguration configuration)
        {
            applicationService = applicationDatabase;
            Configuration = configuration;
            authMessageSender = new AuthMessageSender(Configuration);
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<ActionResult<string>> PostApplication()
        {
            var userApplicationString = HttpUtils.GetRequestBody(Request.Body);
            if(!string.IsNullOrEmpty(userApplicationString))
            {
                var userApplication = JsonUtils.ParseApiData<ApplicationData>(userApplicationString);
                if(userApplication != null && userApplication.IsAuthenticated && !string.IsNullOrEmpty(userApplication.UserEmail))
                {
                    var hasUpdated = await applicationService.Update(userApplication.UserToken, userApplication);

                    if(hasUpdated)
                    {
                        return Ok();
                    }
                }
            }

            return NotFound();
        }


        [AllowAnonymous]
        [HttpPost("/religion")]
        public async Task<ActionResult<string>> ReligiousVerifier()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("/admin")]
        public async Task<ActionResult<string>> AdministratorVerifier()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("/pollingstation")]
        public async Task<ActionResult<string>> PollingStationApproval()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("/cdfcommittee")]
        public async Task<ActionResult<string>> CommitteeApproval()
        {
            return Ok();
        }
    }
}
