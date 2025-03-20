namespace ToolStock.API.ViewModels.Get_RequestViews
{
    public class ToolViewModel
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? LastMaintenance { get; set; }
    }
}
