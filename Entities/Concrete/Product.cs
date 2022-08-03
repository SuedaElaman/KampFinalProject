
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product: IEntity
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public byte UnitsInStock{ get; set; }
        public byte UnitsOnOrder{ get; set; }
        public byte ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        
        public Category Category { get; set; }

    }

}
