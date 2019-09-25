using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using Inventory_management.Models;

namespace Inventory_management.Controllers
{
    public class EmployeeController : Controller
    {

        inventorymgtEntities employeeModels = new inventorymgtEntities();

        // GET: Employee
        public ActionResult Index()
        {
            using (inventorymgtEntities employeeModels = new inventorymgtEntities())
            {
                return View(employeeModels.employees.ToList());
            }
        }



        //Report generation 

        public ActionResult ExportEmployeeListing()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/Employee/Employee.rpt")));
            rd.SetDataSource(employeeModels.employees.ToList());

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream str = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            str.Seek(0,SeekOrigin.Begin);
            String savedFileName = string.Format("EmployeeListing_{0}",DateTime.Now);
            return File(str,"application/pdf",savedFileName);

        }







        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            using (inventorymgtEntities employeeModels = new inventorymgtEntities())
            {

                return View(employeeModels.employees.Where(x => x.empId == id).FirstOrDefault());
            }
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(employee employee)
        {
            try
            {

                using (inventorymgtEntities empModel = new inventorymgtEntities())
                {
                    empModel.employees.Add(employee);
                    empModel.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            using (inventorymgtEntities empModel = new inventorymgtEntities())
            {

                return View(empModel.employees.Where(x => x.empId == id).FirstOrDefault());
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, employee employee)
        {
            try
            {
                using (inventorymgtEntities empModel = new inventorymgtEntities())
                {
                    empModel.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                    empModel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            using (inventorymgtEntities empModel = new inventorymgtEntities())
            {

                return View(empModel.employees.Where(x => x.empId == id).FirstOrDefault());
            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (inventorymgtEntities empModel = new inventorymgtEntities())
                {
                    employee employee1 = empModel.employees.Where(x => x.empId == id).FirstOrDefault();
                    empModel.employees.Remove(employee1);
                    empModel.SaveChanges();
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
