namespace ToolStock.API.ViewModels.Get_RequestViews
{
    public class MaterialViewModel
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal PricePerUnit { get; set; }
        public int MinStockLevel { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
