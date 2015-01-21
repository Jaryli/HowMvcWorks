using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
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
        public ViewResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_desc" : "";
            ViewBag.LastNameSortParm = sortOrder == "last" ? "last_desc" : "last";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var db = _order.GetList();
            var workers = from w in db
                          select w;
            if (!string.IsNullOrEmpty(searchString))
            {
                workers = workers.Where(w => w.OrderRemark.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "first_desc":
                    workers = workers.OrderByDescending(w => w.OrderMoney);
                    break;
                case "last_desc":
                    workers = workers.OrderByDescending(w => w.OrderNum);
                    break;
                case "last":
                    workers = workers.OrderBy(w => w.OrderMoney);
                    break;
                default:
                    workers = workers.OrderBy(w => w.OrderNum);
                    break;
            }
            int pageSize = 3;//可定制显示条数
            int pageNumber = (page ?? 1);
            return View(workers.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]  //post表单，进行多条件查询。从而得到干净的Url
        public ViewResult Index(string sortOrder, string searchString, string currentFilter, int? page,FormCollection fc)
        {
            string fcc = fc["SearchString"].ToString();//TODO:Exception Handle
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "first_desc" : "";
            ViewBag.LastNameSortParm = sortOrder == "last" ? "last_desc" : "last";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = fcc;
            }
            ViewBag.CurrentFilter = searchString;
            var db = _order.GetList();
            var workers = from w in db
                          select w;
            if (!string.IsNullOrEmpty(searchString))
            {
                workers = workers.Where(w => w.OrderRemark.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "first_desc":
                    workers = workers.OrderByDescending(w => w.OrderMoney);
                    break;
                case "last_desc":
                    workers = workers.OrderByDescending(w => w.OrderNum);
                    break;
                case "last":
                    workers = workers.OrderBy(w => w.OrderMoney);
                    break;
                default:
                    workers = workers.OrderBy(w => w.OrderNum);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(workers.ToPagedList(pageNumber, pageSize));
        }
        //
        // GET: /Customer/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Customer/Create

        public ActionResult Add()
        {
            return View();
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Add(FormCollection collection)
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
