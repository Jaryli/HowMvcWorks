using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HowMvcWorks.Controllers
{
    public class EmailController : Controller
    {
        //
        // GET: /Email/
        log4net.ILog log = log4net.LogManager.GetLogger("logerror");
        log4net.ILog log1 = log4net.LogManager.GetLogger("logdebug");
        log4net.ILog log2 = log4net.LogManager.GetLogger("loginfo");
        
        public ActionResult Index()
        {
            log1.Debug("我是调式信息");
            log.Error("需要发邮件吗？");//配置发邮件
            log2.Info("我是调式信息");
            log2.Info("我是调式信息");
            return View();
        }

        //
        // GET: /Email/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Email/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Email/Create

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
        // GET: /Email/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Email/Edit/5

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
        // GET: /Email/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Email/Delete/5

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
