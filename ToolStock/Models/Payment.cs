namespace ToolStock.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public DateTime DatePaid { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
    }
}
