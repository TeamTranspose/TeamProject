using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("ListCategories");
        }

        public ActionResult ListCategories()
        {
            using (var database = new BlogDbContext())
            {
                var categories = database.Categories.Include(c => c.Articles).OrderBy(c => c.Name).ToList();

                return View(categories);
            }
        }

        public ActionResult ListArticles(int? categoryId)
        {
            if (categoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                var articles = database.Articles.Where(a => a.CategoryId == categoryId).Include(a => a.Author).Include(a => a.Tags).ToList();

                return View(articles);
            }
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            var path = "";
            if (file!=null)
            {
                if (file.ContentLength > 0)
                {
                    if (Path.GetExtension(file.FileName).ToLower()==".jpg"
                        || Path.GetExtension(file.FileName).ToLower() == ".png"
                        || Path.GetExtension(file.FileName).ToLower() == ".gif"
                        || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                    {
                        path = Path.Combine(Server.MapPath("~/Content/Images"), file.FileName);
                        file.SaveAs(path);
                        ViewBag.UploadSuccess = true;
                    }
                }
            }
            return RedirectToAction("ListCategories");
        }
    }
}