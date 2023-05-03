//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using UserManagement.MVC.Models;

//namespace UserManagement.MVC.Controllers
//{
//    public class AuthController
//    {
//        [Route("")]
//        public void SubmitOrder(UserRolesViewModel user)
//        {
//            var newUser = new ApplicationUser();
//            newUser.IsActive = false;
//            DataContext.Users.Add();
//        }

//        public void CreateUser(ApplicationUser user)
//        {
//            user.IsActive = true;
//            return user.PasswordHash;
//        }
//    }
//}
