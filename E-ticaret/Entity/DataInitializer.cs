using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace E_ticaret.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var categories = new List<Category>()
            {
                new Category(){Name="Telefon",Description="Telefon Ürünleri"},
            };

            foreach (var categorie in categories)
            {
                context.Categories.Add(categorie);
            }
            context.SaveChanges();

            List<Product> products = new List<Product>()
            {
                new Product(){Name="Iphone 11",Description="iPhone 11 de önü ve arkası sağlam camlarla kaplı. Ancak Apple, iPhone 11 Pro ve 11 Pro Max’in arkasında olduğu gibi mat yüzey yerine parlak yüzey kullanmayı tercih etmiş. Sol üst köşedeki kamera modülünün cam yüzeyi ise mat. Bu açıdan kardeşleriyle tezat oluşturuyor. Parlak cam yüzey yeterli sürtünmeye sahip ve kılıfsız kullanırken telefon elinizden kayıp gitmiyor. Yine de, biz iPhone 11’i deneyimlediğimiz süre boyunca bu telefona özel şeffaf kılıfla kullandık. Şeffaf kılıf telefonun ağırlığını ve kalınlığını biraz artırsa da, kullanım konusunda herhangi bir sıkıntı çıkarmıyor.",CategoryId=3,Price=1000.0,Stock=50,IsApproved=true,IsHome=true,Image="1.jpg"},
            };

            foreach(var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}