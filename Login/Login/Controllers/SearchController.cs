﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login.Models;

namespace Login.Controllers
{
    public class SearchController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

   
        public ActionResult getUsers()
        {
            using(DbModels dbModel = new DbModels())
            {
                var users = dbModel.users.OrderBy(model => model.fname).ToList();

                return Json(new { data = users }, JsonRequestBehavior.AllowGet);
            }

        }
        

        public ActionResult viewUser(int id) {

            using (DbModels dbModel = new DbModels())
            {
                var usr = dbModel.users.Where(a => a.regId == id).FirstOrDefault();
                if (usr != null)
                {
                    return View(usr);

                }
                else
                {
                    return HttpNotFound();
                }
            }

        }

        [HttpPost]
        [ActionName("viewUser")]
        public ActionResult deleteUser(int id) {

            bool status = false;

            using (DbModels dbModel = new DbModels()) {

                var usr = dbModel.users.Where(a => a.regId == id).FirstOrDefault();
                if(usr != null)
                {
                    dbModel.users.Remove(usr);
                    dbModel.SaveChanges();
                    status = true;
 

                }

                return RedirectToAction("Index");

            }

            

        }

    }
}