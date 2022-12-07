using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_ticaret.Models
{
    public class ShippingDetails
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ad ve soyad giriniz!")]
        public string FullName { get; set; }

        [Required(ErrorMessage="Adres tanımını giriniz!")]
        public string AdresBasligi { get; set; }

        [Required(ErrorMessage = "Açık adres giriniz!")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Şehir giriniz!")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Semt giriniz!")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Mahalle giriniz!")]
        public string Mahalle { get; set; }

        [Required(ErrorMessage = "Posta kodu giriniz!")]
        public string PostaKodu { get; set; }
    }
}