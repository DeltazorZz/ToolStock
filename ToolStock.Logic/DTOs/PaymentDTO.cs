namespace ToolStock.Logic.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public DateTime DatePaid { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
