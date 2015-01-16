using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace HowMvcWorks.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        private CRM.Bussiness.CustomerBll cbll = new CRM.Bussiness.CustomerBll();
        public ActionResult Index()
        {
            CRM.Model.Customer cs = new CRM.Model.Customer();
            cs.CustomerName = "李四1231";
            cs.Birthday = "98-09";
            cs.JoinDate = System.DateTime.Now;
            cs.Remark = "我是备注123123";
            cbll.Add(cs);
            List<CRM.Model.Customer> list = cbll.getAll();
            return View(list);
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customer/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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
