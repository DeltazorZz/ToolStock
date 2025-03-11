namespace ToolStock.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int QuotationId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
