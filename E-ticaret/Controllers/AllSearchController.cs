using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_ticaret.Connector;
using E_ticaret.Entity;
using E_ticaret.Models;

namespace E_ticaret.Controllers
{
    public class AllSearchController : Controller
    {
        private DataContext db = new DataContext();
        public ActionResult Index(string searchString)
        {
            var products = from m in db.Products
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }

            return View(products);
        }
    }
}