using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_ticaret.Entity
{
    public enum EnumOrderState
    {
        OnayBekliyor,
        KargoyaVerildi,
        Onaylandı,
        TeslimEdildi
    }
}