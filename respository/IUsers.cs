using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApIAngular.contract.request;
using WebApIAngular.model;

namespace WebApIAngular.respository
{
    public interface IUsers
    {
        Users SignUp(Users user);
        Users SignIn(LoginModel user);
        string ImageUpload(IFormFile file);
    }
}
