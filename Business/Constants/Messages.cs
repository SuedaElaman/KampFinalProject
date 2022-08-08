using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages  //static yaptığımız zaman new lemiyoruz. 
    {
        public static string ProductAdded = "Ürün eklendi.";  // publicte değişenler büyük harfle yazılır.
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string MaintenanceTime="Sistem bakımda";
        public static string ProductsListed="Ürünler listelendi.";

    }
}
