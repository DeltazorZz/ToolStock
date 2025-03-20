using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolStock.Data.Models
{
    public class Doc
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public string Document { get; set; }
        public string DocType { get; set; }
        public DateTime LastUpdated { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
    }
}
