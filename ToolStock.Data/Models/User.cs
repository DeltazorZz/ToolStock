using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolStock.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public DateTime LastUpdated { get; set; }
        public ICollection<ToolAssignment> ToolAssignments { get; set; }
        public ICollection<Doc> Docs { get; set; }
        public ICollection<BackLog> Backlogs { get; set; }
    }
}
