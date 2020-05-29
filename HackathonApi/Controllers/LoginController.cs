using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackathonApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HackathonApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public LoginResponseModel Post(LoginRequestModel model)
        {
            LoginResponseModel response = null;
            try
            {

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Server error: Failed to login";
                _logger.LogError(ex.ToString());
            }

            return response;
        }
    }
}