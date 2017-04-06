using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Telephone1 { get; set; }
        public int Telephone2 { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
