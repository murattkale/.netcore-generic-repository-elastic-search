using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DataModels
{

    public enum RType
    {
        OK = 1,
        Error = 2,
        Warning = 3
    }

    public enum LoginErrorType
    {
        Error = -1,
        Success = 0,
        Page = 1,
        Permission = 2,
        Role = 3,
        User = 4,
    }
    public enum SortType
    {
        [Description("Fiyat (Küçük &gt; Büyük)")]
        sortpriceasc = 1,
        [Description("Fiyat (Büyük &gt; Küçük)")]
        sortpricedesc = 2,
        [Description("Ürün Adı (A - Z)")]
        sortnameasc = 3,
        [Description("Ürün Adı (Z - A)")]
        sortnamedesc = 4,
    }

    public enum ListTypeEnum
    {
        [Description("slider")]
        Slider = 1,
        [Description("new")]
        newProduct = 2,
        [Description("discount")]
        discount = 3,
        [Description("best")]
        best = 4,
    }


}