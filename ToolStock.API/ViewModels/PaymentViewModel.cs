namespace ToolStock.API.ViewModels
{
    public class PaymentViewModel
    {
        public DateTime DatePaid { get; set; }
        public int Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
