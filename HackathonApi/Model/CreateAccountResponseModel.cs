using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Model
{
    public class CreateAccountResponseModel
    {
        public bool IsSuccess { get; set; }
        public string UserId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
