namespace ToolStock.Models
{
    public class ToolAssignment
    {
        public int Id { get; set; }
        public int ToolId { get; set; }
        public int UserId { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime DateIn { get; set; }
        public string Status { get; set; }
    }
}
