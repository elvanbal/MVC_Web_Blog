using MVC_Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class ArticleController : Controller
    {
        private MVC_BlogEntities db = new MVC_BlogEntities();

        // GET: Article
        [AllowAnonymous ]
        public ActionResult ArticleList()
        {
            var entities = new MVC_Web.Models.MVC_BlogEntities();

            return View(entities.Articles.ToList());
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Article/Create
        [ValidateInput(false)]
        public ActionResult CreateArticle()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateArticle(Models.Article _article)
        {
            try
            {
                _article.CreatedDate = DateTime.Now;
                _article.UpdateDate = DateTime.Now;

                db.Articles.Add(_article);
                db.SaveChanges();


                return RedirectToAction("ArticleList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Edit/5
        public ActionResult EditArticle(int id)
        {

            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVC_Web.Models.Article arc = db.Articles.Find(id);
            if (arc == null)
            {
                return HttpNotFound();
            }
            var art = new Models.ArticleViewController();
            art.IND = arc.IND;
            art.Title = arc.Title;
            art.Content = arc.Content;
            art.CreatedDate = arc.CreatedDate;
            art.UpdateDate  = arc.UpdateDate;

            return View(art);

        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult EditArticle(int id, Models.Article collection)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Entry(collection).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ArticleList");
                }
                return View();
            }
            catch
            {
                return View();
            }

        }

        // GET: Article/Delete/5
        public ActionResult DeleteArticle(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article art = db.Articles.Find(id);
            if (art == null)
            {
                return HttpNotFound();
            }
            return View(art);
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult DeleteArticle(int id, FormCollection collection)
        {
            try
            {
                Article art = db.Articles.Find(id);
                db.Articles.Remove(art);
                db.SaveChanges();
                return RedirectToAction("ArticleList");
            }
            catch
            {
                return View();
            }
        }
    }


}
