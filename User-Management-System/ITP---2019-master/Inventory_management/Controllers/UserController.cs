﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;

namespace Inventory_management.Controllers
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
            

            using (inventorymgtEntities dbModel = new inventorymgtEntities())
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

                attendance atnModel = new attendance();


                var initialUser = dbModel.users.Where(x => x.email == userModel.email).FirstOrDefault();



                atnModel.user_ = initialUser.regId;
                atnModel.no_of_days = 0;
                atnModel.status_ = "false";
                atnModel.date_ = DateTime.Now.Date.ToString();
                //atnModel.date_ = DateTime.Now.ToString("MM-dd-yyyy");

                dbModel.attendances.Add(atnModel);
                dbModel.SaveChanges();
            }
            
            ViewBag.SuccessMessage = "Registration Successful.";
            ModelState.Clear();
            user user = new user();

            return View("addOrEdit", user);

        }

    }
}