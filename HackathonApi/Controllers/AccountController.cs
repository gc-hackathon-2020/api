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
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public CreateAccountResponseModel Post(CreateAccountRequestModel model)
        {
            CreateAccountResponseModel response = null;
            try
            {

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Failed to create new account";
                _logger.LogError(ex.ToString());
            }

            return response;
        }
    }
}