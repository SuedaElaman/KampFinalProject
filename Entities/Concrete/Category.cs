//using Core.Abstract; //Entities yazıyo

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //Çıplak class kalmasın
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


        public virtual ICollection<Product> Products { get; set; }
        // sonra yazdık

    }
}
