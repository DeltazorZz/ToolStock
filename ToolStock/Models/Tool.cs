namespace ToolStock.Models
{
    public class Tool
    {
        public int Id { get; set; }  
        public string Name { get; set; }
        public int CategorId { get; set; }
        public string SerialNumber { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public int AssignedTo { get; set; }
        public DateTime PurchaseDate {  get; set; }
        public int SupplierId { get; set; }
        public DateTime LastMaintenance {  get; set; }

    }
}
