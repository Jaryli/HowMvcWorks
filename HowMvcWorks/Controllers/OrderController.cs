using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPOI.HSSF.UserModel;

namespace HowMvcWorks.Controllers
{
    public class OrderController : Controller
    {

        private CRM.IDao.IRepository _order;
        public OrderController(CRM.IDao.IRepository order)
        {
            this._order = order;
        }
        //
        // GET: /Order/

        public ActionResult Index()
        {
            List<CRM.Model.CollumnInfo> list = CRM.Model.CollumnInfo.getColumnList(new CRM.Model.OrderItem());
            return View(list);
        }

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Order/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Order/Create

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
        // GET: /Order/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Order/Edit/5

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
        // GET: /Order/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Order/Delete/5

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

        /// <summary>
        /// 获取Object的所有标记Comment的列
        /// </summary>
        /// <returns></returns>
        public ActionResult getColumnList()
        {
            var res = new JsonResult();
            res.Data = CRM.Model.CollumnInfo.getColumnList(new CRM.Model.OrderItem());
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return res;
        }

        /// <summary>
        /// 导出Excel 
        /// TODO：Post方式目前还存在问题。
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportXls()
        {
            string columnCodes = System.Web.HttpContext.Current.Request.Form["columnCodes"];
            string columnNames = System.Web.HttpContext.Current.Request.Form["columnNames"];
            List<CRM.Model.OrderItem> items = _order.GetList();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            if (!string.IsNullOrEmpty(columnNames))
            {
                HSSFWorkbook workbook = CRM.Common.ExcelHelper.generateHSSF<CRM.Model.OrderItem>("导出事例", items, columnNames.Split(','), columnCodes.Split(','));
                workbook.Write(ms);
                ms.Seek(0, SeekOrigin.Begin);
            }
            return File(ms, "application/vnd.ms-excel", "导出事例.xls");
        }
    }
}
