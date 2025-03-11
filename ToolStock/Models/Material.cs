namespace ToolStock.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryID { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public int SupplierId { get; set; }
        public decimal PricePerUnit { get; set; }
        public int MinStockLevel { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
