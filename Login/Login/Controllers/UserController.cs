using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login.Models;

namespace Login.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult addOrEdit(int id = 0)
        {
            user userModel = new user();
            return View(userModel);

        }

        [HttpPost]
        public ActionResult addOrEdit(user userModel)
        {
            

            using (DbModels dbModel = new DbModels())
            {
                if (dbModel.users.Any(x => x.email == userModel.email)) {

                    ViewBag.DuplicateMsg = "Your Email is already exist.";
                    return View("addOrEdit", userModel);
                }
                
                if(userModel.gender == "Male")
                {
                    userModel.img_path = "~/image/male.png";

                }else if(userModel.gender == "Female")
                {
                    userModel.img_path = "~/image/female.png";
                }

                dbModel.users.Add(userModel);
                dbModel.SaveChanges();

            }
            
            ViewBag.SuccessMessage = "Registration Successful.";
            ModelState.Clear();
            return View("addOrEdit", new user());

        }

    }
}