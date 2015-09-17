using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Web.Models;

namespace Tracker.Web.Controllers
{
    public class MonitorController : Controller
    {
        // GET: Monitor
        public ActionResult Index()
        {
            MonitorRepository repo = new MonitorRepository();
            List<Monitor> model = repo.GetAllMonitors();
            return View(model);
        }


        // GET: Monitor/Create
        public ActionResult Create()
        {
            Monitor model = new Monitor();
            return View(model);
        }

        // POST: Monitor/Create
        [HttpPost]
        public ActionResult Create(Monitor model)
        {
            try
            {
                MonitorRepository repo = new MonitorRepository();
                repo.AddMonitor(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Monitor/Edit/5
        public ActionResult Edit(int id)
        {
            MonitorRepository repo = new MonitorRepository();
            Monitor model = repo.GetMonitorById(id);
            return View(model);
        }

        // POST: Monitor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Monitor model)
        {
            try
            {
                MonitorRepository repo = new MonitorRepository();
                repo.UpdateMonitor(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

 
    }
}
