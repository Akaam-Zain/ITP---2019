using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login.Models;
using Login.Controllers;

namespace Login.Controllers
{
    public class LoginController : Controller
    {


        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(Models.login userModel ) {

            using (DbModels dbModel = new DbModels())
            {
                var userDetails = dbModel.users.Where(x => x.email == userModel.username && x.password_ == userModel.password_).FirstOrDefault();
                if(userDetails == null)
                {
                    userModel.status_ = "Invalid User Credentials.";

                    return View("Login", userModel);

                }

                else
                if(userDetails.email.Equals("dilki@gmail.com") && userDetails.password_.Equals("123"))
                {
                  
                    return View("~/Views/Search/Index.cshtml");
                }

                else
                {
                    Session["userID"] = userDetails.regId;
                    Session["user"] = userDetails.fname;
                    return View("Welcome");
                }

            }

  
        }

        public ActionResult LogOut()
        {

            int userId = (int)Session["userID"];
            Session.Abandon();
            return View("Login");


        }


    }
}