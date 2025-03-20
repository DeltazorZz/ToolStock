using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolStock.Data.Models
{
    public class Tool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? LastMaintenance { get; set; }
        public Category Category { get; set; }
    }
}
