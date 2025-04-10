namespace ToolStock.API.ViewModels
{
    public class MaterialViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public int PricePerUnit { get; set; }
        public int MinStockLevel { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
