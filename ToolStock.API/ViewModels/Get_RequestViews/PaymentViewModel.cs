namespace ToolStock.API.ViewModels.Get_RequestViews
{
    public class PaymentViewModel
    {
        public DateTime DatePaid { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
