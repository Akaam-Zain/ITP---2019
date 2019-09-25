using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using Inventory_management.Models;

namespace connection.Controllers
{
    public class LeaveController : Controller
    {

        inventorymgtEntities inventorymgtEntities = new inventorymgtEntities();
        // GET: Leave
        public ActionResult Index()
        {
            using (inventorymgtEntities inventorymgtEntities = new inventorymgtEntities())
            {
                return View(inventorymgtEntities.leaves.ToList());
            }
        }


        //Report generation 

        public ActionResult ExportLeaveListing()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/Leave/Leave.rpt")));
            rd.SetDataSource(inventorymgtEntities.leaves.ToList());

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream str = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            str.Seek(0, SeekOrigin.Begin);
            String savedFileName = string.Format("LeaveListing_{0}", DateTime.Now);
            return File(str, "application/pdf", savedFileName);

        }
        // GET: Leave/Details/5
        public ActionResult Details(int id)
        {
            using (inventorymgtEntities inventorymgtEntities = new inventorymgtEntities())
            {

                return View(inventorymgtEntities.leaves.Where(x => x.empId == id).FirstOrDefault());
            }
        }

        // GET: Leave/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Leave/Create
        [HttpPost]
        public ActionResult Create(leave leave)
        {
            try
            {

                using (inventorymgtEntities inventorymgtEntities = new inventorymgtEntities())
                {
                    inventorymgtEntities.leaves.Add(leave);
                    inventorymgtEntities.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Leave/Edit/5
        public ActionResult Edit(int id)
        {
            using (inventorymgtEntities inventorymgtEntities = new inventorymgtEntities())
            {

                return View(inventorymgtEntities.leaves.Where(x => x.empId == id).FirstOrDefault());
            }
        }

        // POST: Leave/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, leave leave)
        {
            try
            {
                using (inventorymgtEntities inventorymgtEntities = new inventorymgtEntities())
                {
                    inventorymgtEntities.Entry(leave).State = System.Data.Entity.EntityState.Modified;
                    inventorymgtEntities.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Leave/Delete/5
        public ActionResult Delete(int id)
        {
            using (inventorymgtEntities inventorymgtEntities = new inventorymgtEntities())
            {

                return View(inventorymgtEntities.leaves.Where(x => x.empId == id).FirstOrDefault());
            }
        }

        // POST: Leave/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (inventorymgtEntities inventorymgtEntities = new inventorymgtEntities())
                {
                    leave leave1 = inventorymgtEntities.leaves.Where(x => x.empId == id).FirstOrDefault();
                    inventorymgtEntities.leaves.Remove(leave1);
                    inventorymgtEntities.SaveChanges();
                }
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
