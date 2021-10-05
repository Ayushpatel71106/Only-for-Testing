using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApIAngular.model;

namespace WebApIAngular.contract.response
{
    public class LoginResult
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public Users Data { get; set; }
        public string Token { get; set; }
    }
}
