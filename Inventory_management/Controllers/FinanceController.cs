using Inventory_management.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Web;
using System.Web.Mvc;

namespace Inventory_management.Controllers
{
    public class FinanceController : Controller
    {

        DBModel db = new DBModel();

        // GET: Finance
        [HttpGet]
        public ActionResult income()
        {
            return View(db.incomeData());
        }

        [HttpGet]
        public ActionResult daily()
        {
            return View(db.dailyData());
        }

        [HttpGet]
        public ActionResult statement()
        {
            return View(db.incomeData());
        }

        [HttpPost]
        public ActionResult statementData(String year, String month)
        {
            Session["year"] = year;
            Session["month"] = month;

            return View(db.statementData(year, month));

        }

        [HttpPost]
        public ActionResult savePdf(String year, String month)
        {
            try
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                Paragraph Text = new Paragraph("!-------------Statement-------------!");
                pdfDoc.Add(Text);

                foreach (var statement in db.statementData(year, month))
                {
                    Paragraph Text1 = new Paragraph("Income             :   " + (statement.incomes).ToString());
                    Paragraph Text2 = new Paragraph("Expenses Total     :   " + (statement.dailys).ToString());
                    Paragraph Text3 = new Paragraph("Profit / Lost      :   " + (statement.total).ToString());

                    pdfDoc.Add(Text1);
                    pdfDoc.Add(Text2);
                    pdfDoc.Add(Text3);
                }

                Paragraph Text4 = new Paragraph("Year : " + year + "    Month : " + month);
                pdfDoc.Add(Text4);
                pdfWriter.CloseStream = false;
                pdfDoc.Close();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Example.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            catch (Exception ex)
            { Response.Write(ex.Message); }

            return View(db.statementData(year, month));

        }

        [HttpPost]
        public ActionResult InsertData(String date, String category, String cash, String pos, String amount)
        {

            if (date != "" && category != "" && cash != "" && pos != "" && amount != "")
            {
                income income = new income();

                income.date = date;
                income.category = category;
                income.cash = Double.Parse(cash);
                income.pos = Double.Parse(pos);
                income.total = Double.Parse(amount);

                db.incomeInsert(income);

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult editIncome(String id, String date, String category, String cash, String pos, String amount)
        {

            if (id != "" && date != "" && category != "" && cash != "" && pos != "" && amount != "")
            {
                income income = new income();

                income.id = int.Parse(id);
                income.date = date;
                income.category = category;
                income.cash = Double.Parse(cash);
                income.pos = Double.Parse(pos);
                income.total = Double.Parse(amount);

                db.incomeEdit(income);

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult incomeDelete(String id)
        {

            if (id != "")
            {
                income income = new income();

                income.id = int.Parse(id);

                db.deleteIncome(income);

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult InsertDailyData(String date, String savings, String category, String amount)
        {

            if (date != "" && category != "" && savings != "" && amount != "")
            {
                daily daily = new daily();

                daily.date = date;
                daily.category = category;
                daily.savings = Double.Parse(savings);
                daily.amount = Double.Parse(amount);

                db.dailyInsert(daily);

                Session["success"] = 1;

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult editDaily(String id, String date, String category, String savings, String amount)
        {

            if (id != "" && date != "" && category != "" && savings != "" && amount != "")
            {
                daily daily = new daily();

                daily.id = int.Parse(id);
                daily.date = date;
                daily.category = category;
                daily.savings = Double.Parse(savings);
                daily.amount = Double.Parse(amount);

                db.editDaily(daily);

                Session["success"] = 2;

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public ActionResult dailyDelete(String id)
        {

            if (id != "")
            {
                daily daily = new daily();

                daily.id = int.Parse(id);

                db.deleteDaily(daily);

                Session["success"] = 3;

                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

    }

}