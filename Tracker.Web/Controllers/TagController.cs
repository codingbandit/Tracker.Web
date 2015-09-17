using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Web.Models;

namespace Tracker.Web.Controllers
{
    public class TagController : Controller
    {
        // GET: Tag
        public ActionResult Index()
        {
            TagRepository repo = new TagRepository();
            List<Tag> model = repo.GetAllTags();
            return View(model);
        }

        // GET: Tag/Create
        public ActionResult Create()
        {
            Tag model = new Tag();
            return View(model);
        }

        // POST: Tag/Create
        [HttpPost]
        public ActionResult Create(Tag model)
        {
            try
            {
                TagRepository repo = new TagRepository();
                repo.AddTag(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Tag/Edit/5
        public ActionResult Edit(int id)
        {
            TagRepository repo = new TagRepository();
            var model = repo.GetTagById(id);
            return View(model);
        }

        // POST: Tag/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Tag model)
        {
            try
            {
                TagRepository repo = new TagRepository();
                repo.UpdateTag(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

    
    }
}
