using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackathonApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrivateMessageController : ControllerBase
    {
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