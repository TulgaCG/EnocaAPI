using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Stock { get; set; }
        public double Price { get; set; }
    }
}
