using CDF.API.DataAccess;
using CDF.API.Models;
using CDF.API.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDF.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDatabase applicationService;

        public LoginController(ApplicationDatabase applicationDatabase)
        {
            applicationService = applicationDatabase;
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<ActionResult<string>> Login()
        {
            string loginUser = HttpUtils.GetRequestBody(Request.Body);

            if (!string.IsNullOrEmpty(loginUser))
            {
                var application = JsonUtils.ParseApiData<ApplicationData>(loginUser);

                if(application != null && !string.IsNullOrEmpty(application.UserEmail))
                {
                    var applications = await applicationService.Get();

                    if(applications.Count > 0)
                    {
                        var userApplication = applications.Find(app => app.UserEmail.ToLower() == application.UserEmail.ToLower() && app.UserPassword == application.UserPassword);

                        if(userApplication != null)
                        {
                            userApplication.UserToken = userApplication.Id;
                            userApplication.IsAuthenticated = true;
                            return Ok(JsonUtils.SerializeResults<ApplicationData>(userApplication));
                        }
                        else
                        {
                            return Unauthorized(JsonUtils.SerializeResults<ApplicationData>(new ApplicationData() { IsAuthenticated = false, UserToken = "Wrong username/ password" }));
                        }
                    }
                }
            }
            return NotFound(JsonUtils.SerializeResults<ApplicationData>(new ApplicationData() { IsAuthenticated = false, UserToken = "Wrong username/ password" }));
        }
    }
}
