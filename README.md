# 🛒 IStore - E-Commerce Web Application

IStore, modern bir online alışveriş deneyimi sunmak için geliştirilmiş, kapsamlı bir e-ticaret web uygulamasıdır. Kullanıcılar için akıcı bir alışveriş süreci, yöneticiler için ise gelişmiş bir yönetim paneli sunar.
![flow](https://github.com/user-attachments/assets/297e9281-3852-4956-a13a-dce2f0eead9c)

## 🚀 Özellikler

### 👤 Kullanıcı Özellikleri
* **Kimlik Doğrulama:** Güvenli kayıt olma ve giriş yapma süreçleri.
* **Ürün Keşfi:** Detaylı ürün bilgileri ve kategori bazlı listeleme.
* **Sepet Yönetimi:** Ürün ekleme, adet güncelleme ve sepetten çıkarma.
* **Sipariş Süreci:** Hızlı sipariş oluşturma ve geçmiş siparişleri görüntüleme.
* **Rol Erişimi:** Kullanıcı yetkilerine göre dinamik içerik.

### 🛠️ Admin (Yönetim) Özellikleri
* **Ürün Yönetimi:** Ürün ekleme, silme ve güncelleme (CRUD).
* **Kategori Yönetimi:** Ürün kategorilerini organize etme.
* **Sipariş Yönetimi:** Gelen siparişleri görüntüleme ve durum güncelleme.
* **Kullanıcı Yönetimi:** Kullanıcı rolleri ve hesap yönetimi.

---

## 🔐 Güvenlik ve Yetkilendirme

Uygulama, güvenliği ön planda tutan **ASP.NET Identity** altyapısını kullanır:

* **Cookie-Based Authentication:** Güvenli oturum yönetimi.
* **Role-Based Access Control (RBAC):** `User` ve `Admin` rolleriyle yetki sınırlandırması.
* **Protected Routes:** Admin paneli ve kritik fonksiyonlar yalnızca yetkili kullanıcılara açıktır.

---

## 🧱 Uygulama Mimarisi

Proje, **Separation of Concerns (Sorumlulukların Ayrılması)** prensibine uygun olarak inşa edilmiştir:

* **Pattern:** MVC (Model-View-Controller) tasarım deseni.
* **Yapı:** Bakımı kolay, modüler ve ölçeklenebilir kod mimarisi.
* **İş Akışı:** Kullanıcı talepleri Controller üzerinden işlenerek ilgili Model ve View katmanlarına aktarılır.

---

## 🧰 Teknoloji Yığını

| Bileşen | Teknoloji |
| :--- | :--- |
| **Backend** | C# / ASP.NET MVC |
| **Frontend** | HTML5, CSS3, JavaScript |
| **Veritabanı** | SQL Server |
| **ORM** | Entity Framework |
| **Kimlik Doğrulama** | ASP.NET Identity |

---

## ⚙️ Kurulum ve Çalıştırma

### Gereksinimler
* Visual Studio 2022 veya üzeri
* .NET Framework / .NET SDK
* SQL Server (LocalDB veya Express)

### Adımlar

1.  **Depoyu Klonlayın:**
    ```bash
    git clone [https://github.com/Burakermis/IStore.git](https://github.com/Burakermis/IStore.git)
    ```

2.  **Projeyi Yapılandırın:**
    * `.sln` dosyasını Visual Studio ile açın.
    * NuGet paketlerini geri yükleyin.

3.  **Veritabanı Ayarları:**
    * `Web.config` veya `appsettings.json` dosyasındaki **ConnectionString** bölümünü kendi SQL Server bilgilerinize göre güncelleyin.
    * Gerekiyorsa `Update-Database` komutu ile tabloları oluşturun.

4.  **Çalıştırın:**
    * `F5` tuşuna basarak uygulamayı yerel sunucuda başlatın.
    * Tarayıcıda: `https://localhost:xxxx`
