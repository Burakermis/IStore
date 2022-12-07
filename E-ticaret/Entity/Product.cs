using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_ticaret.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        //[StringLength(maximumLength: 20, ErrorMessage = "En fazla 20 karakter girebilirsiniz!"),]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Name { get; set; }

        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }

        [DisplayName("Ürün Fiyatı")]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Range(0, float.MaxValue, ErrorMessage = "Lütfen 0'dan büyük bir sayı giriniz!")]
        public double Price { get; set; }

        [DisplayName("Ürün Stoğu")]
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Range(0,int.MaxValue, ErrorMessage = "Lütfen 0'dan büyük bir sayı giriniz!")]
        public int Stock { get; set; }

        [DisplayName("Ürün Fotoğrafı")]
        public string Image { get; set; }

        [DisplayName("Yönetici Onaylı")]
        public bool IsApproved { get; set; }

        [DisplayName("Anasayfada Görünürlük")]
        public bool IsHome { get; set; }

        [DisplayName("Kategori Türü")]
        public int CategoryId { get; set; }//foreign key(connect to category ıd)
        public Category Category { get; set; }
    }
}