using E_ticaret.Entity;
using E_ticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Specialized;

namespace E_ticaret.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        [Authorize]
        public ActionResult AddToCart(int? Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }
        public ActionResult CartClear() //Sepeti temizleme
        {
            var cart = GetCart();
            cart.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }


        [Authorize]
        public ActionResult Checkpayment(PaymentDetail model)
        {
            // Cart'ı(sepeti) sıfırla)
            var cart = GetCart();
            cart.Clear();

            /*Options options = new Options();
            options.ApiKey = "sandbox-......"; //Iyzico Tarafından Sağlanan Api Key
            options.SecretKey = "sandbox-..."; //Iyzico Tarafından Sağlanan Secret Key
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = "123456789";
            request.Price = "1";
            request.PaidPrice = "1.2";
            request.Currency = Currency.TRY.ToString();
            request.BasketId = "B67832";
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.CallbackUrl = "https://www.merchant.com/callback";

            List<int> enabledInstallments = new List<int>();
            enabledInstallments.Add(2);
            enabledInstallments.Add(3);
            enabledInstallments.Add(6);
            enabledInstallments.Add(9);
            request.EnabledInstallments = enabledInstallments;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = "John";
            buyer.Surname = "Doe";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem();
            firstBasketItem.Id = "BI101";
            firstBasketItem.Name = "Binocular";
            firstBasketItem.Category1 = "Collectibles";
            firstBasketItem.Category2 = "Accessories";
            firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            firstBasketItem.Price = "0.3";
            basketItems.Add(firstBasketItem);

            BasketItem secondBasketItem = new BasketItem();
            secondBasketItem.Id = "BI102";
            secondBasketItem.Name = "Game code";
            secondBasketItem.Category1 = "Game";
            secondBasketItem.Category2 = "Online Game Items";
            secondBasketItem.ItemType = BasketItemType.VIRTUAL.ToString();
            secondBasketItem.Price = "0.5";
            basketItems.Add(secondBasketItem);

            BasketItem thirdBasketItem = new BasketItem();
            thirdBasketItem.Id = "BI103";
            thirdBasketItem.Name = "Usb";
            thirdBasketItem.Category1 = "Electronics";
            thirdBasketItem.Category2 = "Usb / Cable";
            thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            thirdBasketItem.Price = "0.2";
            basketItems.Add(thirdBasketItem);
            request.BasketItems = basketItems;

            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);
            ViewBag.Iyzico = checkoutFormInitialize.CheckoutFormContent;
            //View Dönüş yapılan yer, Burada farklı yöntemler ile View gönderim yapabilirsiniz.
            return View();*/
            return View("Success");
        }

        /*public ActionResult ResultPay(RetrieveCheckoutFormRequest model)
        {
            string data = "";
            Options options = new Options();
            options.ApiKey = "sandbox-......"; //Iyzico Tarafından Sağlanan Api Key
            options.SecretKey = "sandbox-...."; //Iyzico Tarafından Sağlanan Secret Key
            options.BaseUrl = "https://sandbox-api.iyzipay.com";
            data = model.Token;
            RetrieveCheckoutFormRequest request = new RetrieveCheckoutFormRequest();
            request.Token = data;
            CheckoutForm checkoutForm = CheckoutForm.Retrieve(request, options);
            if (checkoutForm.PaymentStatus == "SUCCESS")
            {
                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Unsuccess");
            }
        }*/
        /*public ActionResult Success()
        {
            return View();
        }

        public ActionResult UnSuccess()
        {
            return View();
        }*/

        [Authorize]
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        [Authorize]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("NoProductError", "Sepetinizde ürün bulunmamaktadır!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    // Siparişi veritabanına kaydet                   
                    //SaveOrder(cart, entity);  //veritabanına sepeti kaydediyor                 
                    return View("Checkpayment");
                }
                else
                {
                    return View(entity);
                }
            }
            return View();
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();
            order.OrderNumber = (new Random()).Next(111111, 999999).ToString();
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.OnayBekliyor;

            order.Username = User.Identity.Name;
            order.FullName = entity.FullName;
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;

            order.OrderLines = new List<OrderLine>();
            foreach (var pr in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price = pr.Quantity * pr.Product.Price;
                orderline.ProductId = pr.Product.Id;

                order.OrderLines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}