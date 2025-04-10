namespace ToolStock.Logic.DTOs
{
    public class ToolDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? LastMaintenance { get; set; }
    }
}
