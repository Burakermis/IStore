using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_ticaret.Entity;
using E_ticaret.Models;

namespace E_ticaret.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        DataContext _context = new DataContext();
        public ActionResult Index()
        {
            var products =_context.Products
                .Where(p => p.IsHome && p.IsApproved)
                .Select(p => new ProductModel()
                {
                    Id=p.Id,
                    Name= p.Name.Length > 50 ? p.Name.Substring(0, 47) + "..." : p.Name,
                    Description =p.Description.Length> 50 ? p.Description.Substring(0,47)+"..." : p.Description,
                    Price=p.Price,
                    Stock= p.Stock,
                    Image= p.Image ?? "nophoto.jpg",
                    CategoryId =p.CategoryId
                }).ToList();

            return View(products);
        }
        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i => i.Id==id).FirstOrDefault());
        }
        public ActionResult List(int? id)
        {
            var products = _context.Products
                .Where(p => p.IsApproved)
                .Select(p => new ProductModel()
                {
                    Id = p.Id,
                    Name = p.Name.Length > 50 ? p.Name.Substring(0, 47) + "..." : p.Name,
                    Description = p.Description.Length > 50 ? p.Description.Substring(0, 47) + "..." : p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    Image = p.Image ?? "nophoto.jpg",
                    CategoryId = p.CategoryId
                }).AsQueryable();

            if (id != null)
            {
                products = products.Where(p => p.CategoryId == id);
            }

            return View(products.ToList()); 
        }

        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }
    }
}