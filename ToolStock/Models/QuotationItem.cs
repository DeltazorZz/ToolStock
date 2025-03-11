namespace ToolStock.Models
{
    public class QuotationItem
    {
        public int Id { get; set; }
        public int QuotationId { get; set; }
        public int ItemId { get; set; }
        public string ItemType { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
