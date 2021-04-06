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
    public class PostApplicationController : ControllerBase
    {
        private readonly ApplicationDatabase applicationService;

        public PostApplicationController(ApplicationDatabase applicationDatabase)
        {
            applicationService = applicationDatabase;
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<ActionResult<string>> PostApplication()
        {
            var userApplicationString = HttpUtils.GetRequestBody(Request.Body);
            Console.WriteLine(userApplicationString);
            if(!string.IsNullOrEmpty(userApplicationString))
            {
                Console.WriteLine("Is not Null String");
                var userApplication = JsonUtils.ParseApiData<ApplicationData>(userApplicationString);
                Console.WriteLine("Completed Parsing");
                if(userApplication != null && userApplication.IsAuthenticated && !string.IsNullOrEmpty(userApplication.UserEmail))
                {
                    Console.WriteLine("Passed validity tests");
                    var hasUpdated = await applicationService.Update(userApplication.UserToken, userApplication);

                    if(hasUpdated)
                    {
                        return Ok();
                    }
                }
            }

            return NotFound();
        }
    }
}
