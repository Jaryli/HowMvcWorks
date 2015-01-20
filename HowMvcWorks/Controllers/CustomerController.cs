using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace HowMvcWorks.Controllers
{
    public class CustomerController : Controller
    {
        private CRM.IDao.IRepository _order;
        public CustomerController(CRM.IDao.IRepository order)
        {
            this._order = order;
        }
        //
        // GET: /Customer/
        public ActionResult Index()
        {
            CRM.Model.OrderItem item = new CRM.Model.OrderItem();
            item.OrderMoney = 960;
            item.OrderNum = 100;
            item.OrderRemark = "dddd";
            item.OrderTime = System.DateTime.Now;
            _order.Add(item);
            var list = _order.GetList();
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
