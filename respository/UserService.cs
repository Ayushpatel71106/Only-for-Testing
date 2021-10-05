using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApIAngular.contract.request;
using WebApIAngular.model;

namespace WebApIAngular.respository
{
    public class UserService: IUsers
    {
    
        private ApplicationContext context;
        public UserService()
        {
            context = new ApplicationContext();
        }
        public string ImageUpload(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Users SignIn(LoginModel user)
        {
            if (context.Users.Any(e => e.Email == user.Email && e.Password == user.Password))
            {
                var userdata = context.Users.SingleOrDefault(e => e.Email == user.Email && e.Password == user.Password);
                return userdata;

            }
            else
            {
                return null;
            }
        }

        public Users SignUp(Users user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }
    }
}
