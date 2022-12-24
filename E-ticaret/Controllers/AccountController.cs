using E_ticaret.Entity;
using E_ticaret.Identity;
using E_ticaret.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {           
            var userStore=new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore=new RoleStore<ApplicationRole>(new IdentityDataContext());    
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders
                .Where(i => i.Username == username)
                .Select(i => new UserOrderModel()
                {
                    Id=i.Id,
                    OrderNumber=i.OrderNumber,
                    OrderDate=i.OrderDate,
                    OrderState=i.OrderState,
                    Total=i.Total
                }).OrderByDescending(i => i.OrderDate).ToList();
            return View(orders);
        }

        [Authorize(Roles = "user")]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AdresBasligi = i.AdresBasligi,
                    Adres = i.Adres,
                    Sehir = i.Sehir,
                    Semt = i.Semt,
                    Mahalle = i.Mahalle,
                    PostaKodu = i.PostaKodu,
                    OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                    {
                        ProductId= a.ProductId,
                        ProductName=a.Product.Name,
                        Image=a.Product.Image ?? "nophoto.jpg",
                        Quantity=a.Quantity,
                        Price=a.Price
                    }).ToList()
                }).FirstOrDefault();
            return View(entity);
        }

        // Kayıt İşlemleri
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                // Kayıt işlemleri
                var user=new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.SurName;
                user.UserName = model.UserName;
                user.Email = model.Email;

                IdentityResult result=UserManager.Create(user,model.Password);

                if (result.Succeeded)
                {
                    // Kullanıcı oluştu ve kullanıcıyı bir role atayabilirsiniz
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError","Kullanıcı oluşturma hatası");
                }
            }
            return View(model);
        }


        // Giriş İşlemleri
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                // Giriş işlemleri
                var user = UserManager.Find(model.UserName,model.Password);
                if(user != null)
                {
                    // Varolan kullanıcı sisteme dahil et
                    //ApplicationCookie oluşturup sisteme bırak

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var ıdentityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, ıdentityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index","Home");               
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok!");
                }
            }
            return View(model);
        }


        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index","Home");
        }

       [Authorize]
       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Update() 
        {
            /*var userId = this.User.Identity.GetUserId();
            var user = db.Set<ApplicationUser>().Find(userId);
            user.UserName = "New value";
            user.Name = ;
            user.Surname = ;
            user.Email = ;*/
            db.SaveChanges();
            return View();
        }

    }
}