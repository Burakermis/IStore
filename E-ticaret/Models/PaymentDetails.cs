using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_ticaret.Models
{
    public class PaymentDetails
    {
        [Required(ErrorMessage = "Kart numarası giriniz!")]
        //[StringLength(maximumLength: 16, ErrorMessage = "En fazla 20 karakter girebilirsiniz!"),]
        [RegularExpression(@"(.{10})")]
        public string CartNumber { get; set; }

        [Required(ErrorMessage = "Son kullanma tarihi için ay giriniz!")]
        public string CartMonth { get; set; }

        [Required(ErrorMessage = "Son kullanma tarihi için yıl giriniz!")]
        public string CartYear { get; set; }

    }
}