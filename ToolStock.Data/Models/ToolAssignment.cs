using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolStock.Data.Models
{
    public class ToolAssignment
    {
        public int Id { get; set; }
        public int ToolId { get; set; }
        public int UserId { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime? DateIn { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdated { get; set; }
        public Tool Tool { get; set; }
        public User User { get; set; }
    }
}
