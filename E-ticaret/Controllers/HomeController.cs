using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_ticaret.Entity;
using E_ticaret.Models;
using System.Xml;
using E_ticaret.Connector;

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
        public ActionResult About()
        {
            return View();
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
        
        [HttpGet]
        public ActionResult SearchProducts(string SearchString) //Ürün arama
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

            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(s => s.Name.Contains(SearchString));
            }

            return View(products.ToList());
        }

        [HttpGet]
        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }

        [HttpGet]
        public ActionResult GetCurrency()
        {
            XmlDocument xml = new XmlDocument(); // yeni bir XML dökümü oluşturuyoruz.
            xml.Load("http://www.tcmb.gov.tr/kurlar/today.xml"); // bağlantı kuruyoruz.
            var Tarih_Date_Nodes = xml.SelectSingleNode("//Tarih_Date"); // Count değerini olmak için ana boğumu seçiyoruz.
            var CurrencyNodes = Tarih_Date_Nodes.SelectNodes("//Currency"); // ana boğum altındaki kur boğumunu seçiyoruz.
            int CurrencyLength = CurrencyNodes.Count; // toplam kur boğumu sayısını elde ediyor ve for döngüsünde kullanıyoruz.

            List<Currency> dovizler = new List<Currency>(); // Aşağıda oluşturduğum public class ile bir List oluşturuyoruz.
            for (int i = 0; i < CurrencyLength; i++) // for u çalıştırıyoruz.
            {
                var cn = CurrencyNodes[i]; // kur boğumunu alıyoruz.
                // Listeye kur bilgirini ekliyoruz.
                dovizler.Add(new Currency
                {
                    Kod = cn.Attributes["Kod"].Value,
                    CrossOrder = cn.Attributes["CrossOrder"].Value,
                    CurrencyCode = cn.Attributes["CurrencyCode"].Value,
                    Unit = cn.ChildNodes[0].InnerXml,
                    Isim = cn.ChildNodes[1].InnerXml,
                    CurrencyName = cn.ChildNodes[2].InnerXml,
                    ForexBuying = cn.ChildNodes[3].InnerXml,
                    ForexSelling = cn.ChildNodes[4].InnerXml,
                    BanknoteBuying = cn.ChildNodes[5].InnerXml,
                    BanknoteSelling = cn.ChildNodes[6].InnerXml,
                    CrossRateOther = cn.ChildNodes[8].InnerXml,
                    CrossRateUSD = cn.ChildNodes[7].InnerXml,
                });
            }

            ViewData["dovizler"] = dovizler; // dovizler List değerini data ya atıyoruz ön tarafta viewbag ile çekeceğiz.
            return View();
        }
    }
}