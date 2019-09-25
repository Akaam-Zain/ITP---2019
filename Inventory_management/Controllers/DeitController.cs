﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;

using System.Data.Entity;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace T3.Controllers
{
    public class DeitController : Controller
    {
        inventorymgtEntities db1 = new inventorymgtEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View(db1.diet_planing.ToList());
        }

        // GET: Deit/Details/5
        public ActionResult Details(int id)
        {
            return View(db1.diet_planing.Where(x => x.dietID == id).FirstOrDefault());
        }

        // GET: Deit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deit/Create
        [HttpPost]
        public ActionResult Create(diet_planing diet)
        {
            try
            {
                using (inventorymgtEntities db1 = new inventorymgtEntities())
                {
                    db1.diet_planing.Add(diet);
                    db1.SaveChanges();
                }
    
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ExportDietPlan()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/Diet Plans/DietPlan.rpt")));
            rd.SetDataSource(db1.diet_planing.ToList());

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream str = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            str.Seek(0, SeekOrigin.Begin);
            string savedFilename = string.Format("DietPlan_{0}", DateTime.Now);
            return File(str, "application/pdf", savedFilename);
        }


        // GET: Deit/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db1.diet_planing.Where(x => x.dietID == id).FirstOrDefault());
        }

        // POST: Deit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, diet_planing diet)
        {
            try
            {
                using (inventorymgtEntities st = new inventorymgtEntities()) {
                    st.Entry(diet).State = EntityState.Modified;
                    st.SaveChanges();
                    
                }
                       // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deit/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db1.diet_planing.Where(x => x.dietID == id).FirstOrDefault()); 
        }

        // POST: Deit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                diet_planing diet = db1.diet_planing.Where(x => x.dietID == id).FirstOrDefault();
                db1.diet_planing.Remove(diet);
                db1.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
