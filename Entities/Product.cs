using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        private string code;
        private string name;
        private string description;
        private float price;
        private bool numerable;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public bool  Numerable
        {
            get { return numerable; }
            set { numerable = value; }
        }
    }
}
