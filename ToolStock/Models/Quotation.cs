namespace ToolStock.Models
{
    public class Quotation
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProjectId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ValidUntil { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
