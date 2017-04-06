using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        public int Number { get; set; }
        public DateTime DateOrder { get; set; }
        public long CustomerID { get; set; }
        public DateTime DateDelivery { get; set; }
        public string DeliveredBy { get; set; }
        public string WorkType { get; set; }
        public string Computer { get; set; }
        public bool Iron { get; set; }
        public bool Paper { get; set; }
        public string Quantity { get; set; }
        public string Ink { get; set; }
		public string Sheets { get; set; }
        public string Trait1 { get; set; }
        public string Trait2 { get; set; }
        public string Trait3 { get; set; }
        public string Trait4 { get; set; }
        public string Trait5 { get; set; }
        public string Trait6 { get; set; }
        public string Size { get; set; }
        public bool Glued { get; set; }
        public bool Perforated { get; set; }
		public bool Changes { get; set; }
        public bool Holes { get; set; }
        public int InitialNum { get; set; }
        public int EndNum { get; set; }
        public string Observations { get; set; }
        public Byte[] Design { get; set; }
        public string NameDesign { get; set; }
        public float Price { get; set; }
        public float Payment { get; set; }
        public float Balance { get; set; }

    }
}
