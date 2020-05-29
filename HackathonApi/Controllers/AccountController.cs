using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HackathonApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;

namespace HackathonApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;
        private CreateAccountRequestModel createAccountRequestModel { get; set; }

        public AccountController(ILogger<AccountController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

          
        }

        [HttpPost]
        public CreateAccountResponseModel Post(CreateAccountRequestModel model)
        {
            CreateAccountResponseModel responseModel = null;
           
            try
            {
              

                string token = _configuration.GetSection("Auth0").GetSection("Token").Value;
                string url = _configuration.GetSection("Auth0").GetSection("Url").Value;
                url += "users";
                using (var client = new ManagementApiClient(token, new Uri(url)))
                {
                    var response = client.Users.CreateAsync(new UserCreateRequest
                    {
                        Connection = "Username-Password-Authentication",
                        Email = model.Email,
                        Password = model.Password,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                    }).Result;
 
                }
            }
            catch (Exception ex)
            {
                responseModel.IsSuccess = false;
                responseModel.ErrorMessage = "Failed to create new account";
                _logger.LogError(ex.ToString());
            }

            return responseModel;
        }
    }
}