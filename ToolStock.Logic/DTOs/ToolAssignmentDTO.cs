namespace ToolStock.Logic.DTOs
{
    public class ToolAssignmentDTO
    {
        public int Id { get; set; }
        public int ToolId { get; set; }
        public int UserId { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime? DateIn { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
