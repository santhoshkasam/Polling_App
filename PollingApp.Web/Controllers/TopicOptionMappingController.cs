using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PollingApp.Web.Controllers
{
    public class TopicOptionMappingController : Controller
    {
        // GET: TopicOptionMapping
        public ActionResult Index()
        {
            return View();
        }

        // GET: TopicOptionMapping/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TopicOptionMapping/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TopicOptionMapping/Create
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

        // GET: TopicOptionMapping/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TopicOptionMapping/Edit/5
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

        // GET: TopicOptionMapping/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TopicOptionMapping/Delete/5
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
