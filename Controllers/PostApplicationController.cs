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
        [HttpGet("/auth-form")]
        public async Task<ActionResult<string>> GetApplication([FromQuery]
                                                                string ApplicationId)
        {
            if(!string.IsNullOrEmpty(ApplicationId))
            {
                var userApplication = await applicationService.Get(ApplicationId);
                return Ok(JsonUtils.SerializeResults<ApplicationData>(userApplication));
            }

            return Ok();
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
                    userApplication.Submitted = userApplication.Step == 8;
                    var hasUpdated = await applicationService.Update(userApplication.UserToken, userApplication);
                    AuthMessageSender authMessageSender = new AuthMessageSender(Configuration);
                    await authMessageSender.SendEmailAsync(userApplication.UserEmail, "Application Submitted", "Your bursary application has been submitted.");
                    string religiousLeaderUrl = string.Format("http://localhost:3000/auth-form?id={0}&level={1}", userApplication.UserToken, "verification1");
                    string chiefUrl = string.Format("http://localhost:3000/auth-form?id={0}&level={1}", userApplication.UserToken, "verification2");
                    await authMessageSender.SendEmailAsync(userApplication.ReligiousLeaderEmail, "Application to Verify - Religious Leader for "+ userApplication?.Name, religiousLeaderUrl);
                    await authMessageSender.SendEmailAsync(userApplication.ChiefEmail, "Application to Verify - Chief/ Sub-chief" + userApplication?.Name, chiefUrl);
                    if (hasUpdated)
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
            var userApplicationString = HttpUtils.GetRequestBody(Request.Body);
            if (!string.IsNullOrEmpty(userApplicationString))
            {
                var userApplication = JsonUtils.ParseApiData<ApplicationData>(userApplicationString);
                if (userApplication != null && userApplication.IsAuthenticated 
                    && userApplication.Submitted
                    && !string.IsNullOrEmpty(userApplication.UserEmail))
                {
                    var hasUpdated = await applicationService.Update(userApplication.UserToken, userApplication);
                    if (userApplication.Verification1)
                    {
                        AuthMessageSender authMessageSender = new AuthMessageSender(Configuration);
                        await authMessageSender.SendEmailAsync(userApplication.UserEmail, "Application Submitted", "Your bursary application has been submitted.");
                    }
                    if (hasUpdated)
                    {
                        return Ok();
                    }
                }
            }

            return NotFound();
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
