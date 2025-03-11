namespace ToolStock.Models
{
    public class InventoryMovement
    {
        public int Id { get; set; }
        public int itemId { get; set; }
        public string itemType { get; set; }
        public string movementType { get; set; }
        public int Quantity { get; set; }
        public DateTime date { get; set; }
        public int RelatedProjectId { get; set; }
        public int UserId { get; set; }

    }
}
