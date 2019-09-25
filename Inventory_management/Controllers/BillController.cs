using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using Inventory_management.Models;
using System.IO;

namespace Inventory_management.Controllers
{
    public class BillController : Controller
    {
       inventorymgtEntities dbmodel = new inventorymgtEntities();

        // GET: Bill
        public ActionResult Index()
        {

            

            using (inventorymgtEntities dbmodel = new inventorymgtEntities())
            {
                List<bill> lst = new List<bill>();
                lst = dbmodel.bills.ToList();
                return View(lst);
            }
            
        }


        public ActionResult ExportBillListing()
        {

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report/BillReport/bill.rpt")));
            rd.SetDataSource(dbmodel.bills.ToList());

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream str = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            str.Seek(0, SeekOrigin.Begin);
            String savedFileName = string.Format("OrderListing_{0}",DateTime.Now);
            return File(str,"application/pdf",savedFileName);
            

        }

        // GET: Bill/Details/5
        public ActionResult Details(int id)
        {
            using(inventorymgtEntities dbModel = new inventorymgtEntities())
            {
                return View(dbModel.bills.Where(x=> x.billId == id).FirstOrDefault());
            }
            
        }

        // GET: Bill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bill/Create to database
        [HttpPost]
        public ActionResult Create(bill Bill)
        {
            using (DBModel dBModel = new DBModel())
            {
                dbmodel.bills.Add(Bill);
                dbmodel.SaveChanges();
            }
            return RedirectToAction("Index"); 
        }

        // GET: Bill/Edit/5
        public ActionResult Edit(int id)
        {
            using (inventorymgtEntities dbModel = new inventorymgtEntities())
            {
                return View(dbModel.bills.Where(x => x.billId == id).FirstOrDefault());
            }
        }

        // POST: Bill/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, bill Bill)
        {
            try
            {

                using(inventorymgtEntities dbmodel = new inventorymgtEntities())
                {
                    dbmodel.Entry(Bill).State = EntityState.Modified;
                    dbmodel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bill/Delete/5
        public ActionResult Delete(int id)
        {
            using (inventorymgtEntities dbModel = new inventorymgtEntities())
            {
                return View(dbModel.bills.Where(x => x.billId == id).FirstOrDefault());
            }
        }

        // POST: Bill/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (inventorymgtEntities dbmodel = new inventorymgtEntities()) {

                    bill Bill = dbmodel.bills.Where(x => x.billId == id).FirstOrDefault();
                    dbmodel.bills.Remove(Bill);
                    dbmodel.SaveChanges();
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
