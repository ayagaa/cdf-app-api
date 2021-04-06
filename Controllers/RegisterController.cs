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
    public class RegisterController : ControllerBase
    {
        private readonly ApplicationDatabase applicationService;

        public RegisterController(ApplicationDatabase applicationDatabase)
        {
            applicationService = applicationDatabase;
        }

        [AllowAnonymous]
        [HttpPost("createaccount")]
        public async Task<ActionResult<string>> CreateAccount()
        {
            string newUser = HttpUtils.GetRequestBody(Request.Body);

            if(!string.IsNullOrEmpty(newUser))
            {
                var application = JsonUtils.ParseApiData<ApplicationData>(newUser);
                if(application != null && !string.IsNullOrEmpty(application.UserEmail))
                {
                    var existingApplicants = await applicationService.Get();

                    if(existingApplicants?.Count > 0)
                    {
                        var checkApplicant = existingApplicants.Find(app => app.UserEmail.ToLower() == application.UserEmail.ToLower());

                        if(checkApplicant != null)
                        {
                            var result = new RegisterStatus()
                            {
                                IsSuccessfull = false,
                                Message = "User already exists"
                            };
                            return Unauthorized(JsonUtils.SerializeResults<RegisterStatus>(result));
                        }
                        else
                        {
                            var isSuccessfull = await applicationService.Add(application);

                            if(isSuccessfull)
                            {
                                return Ok(JsonUtils.SerializeResults<RegisterStatus>(new RegisterStatus() { IsSuccessfull = true, Message = "Successfully registered" }));
                            }
                        }
                    }
                    else
                    {
                        var isSuccessfull = await applicationService.Add(application);

                        if (isSuccessfull)
                        {
                            return Ok(JsonUtils.SerializeResults<RegisterStatus>(new RegisterStatus() { IsSuccessfull = true, Message = "Successfully registered" }));
                        }
                    }
                }
            }
            return Unauthorized(JsonUtils.SerializeResults<RegisterStatus>(new RegisterStatus() { IsSuccessfull = false, Message = "Failed to register. Please try again." }));
        }
    }
}
