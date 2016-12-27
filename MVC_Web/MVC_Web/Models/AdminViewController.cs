using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Web.Models
{
    public class AdminViewController : Controller
    {
        // GET: AdminView
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminView/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminView/Create
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

        // GET: AdminView/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminView/Edit/5
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

        // GET: AdminView/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminView/Delete/5
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
