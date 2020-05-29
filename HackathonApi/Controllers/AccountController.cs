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
    [Route("api/[controller]")]
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
        public async Task<CreateAccountResponseModel> Post(CreateAccountRequestModel model)
        {
            CreateAccountResponseModel responseModel = new CreateAccountResponseModel();

            try
            {

                string token = _configuration.GetSection("Auth0").GetSection("Token").Value;
                string url = _configuration.GetSection("Auth0").GetSection("Url").Value;
                Dictionary<string, string> metadata = new Dictionary<string, string>();
                metadata.Add("DeviceID", model.DeviceId);

                using var client = new ManagementApiClient(token, new Uri(url));
                var response = await client.Users.CreateAsync(new UserCreateRequest
                {
                    Connection = "Username-Password-Authentication",
                    Email = model.Email,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserMetadata = metadata
                });

                if (!String.IsNullOrEmpty(response.UserId))
                {
                    responseModel.IsSuccess = true;
                    responseModel.ErrorMessage = string.Empty;
                    responseModel.UserId = response.UserId;

                }
                else
                {
                    responseModel.ErrorMessage = "Failed to create new user";
                }
            }
            catch (Exception ex)
            {
                responseModel.IsSuccess = false;
                responseModel.ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                _logger.LogError(ex.ToString());
            }

            return responseModel;
        }
    }
}