using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Web.Models;

namespace Tracker.Web.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            InventoryRepository repo = new InventoryRepository();
            var model = repo.GetCurrentInventory();
            return View(model);
        }
    }
}