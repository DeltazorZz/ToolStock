using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolStock.Data.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal PricePerUnit { get; set; }
        public int MinStockLevel { get; set; }
        public DateTime LastUpdated { get; set; }

        public Category Category { get; set; }

    }
}
