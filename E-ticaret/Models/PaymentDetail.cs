using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_ticaret.Models
{
    public class PaymentDetail
    {
            [Required(ErrorMessage = "Kart numarası giriniz!")]
            [RegularExpression(@"(.{10})")]
            public string CartNumber { get; set; }

            [Required(ErrorMessage = "Son kullanma tarihi giriniz!")]
            public string CartExperionDate { get; set; }

            [Required(ErrorMessage = "Güvenlik kodunu giriniz!")]
            public string CV2 { get; set; }
    }
}