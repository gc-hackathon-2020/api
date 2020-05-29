using HackathonApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonApi.Model
{
    public class LoginResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public User User { get; set; }

    }
}
