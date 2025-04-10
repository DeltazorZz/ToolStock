namespace ToolStock.Logic.DTOs
{
    public class DocDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ProjectName { get; set; }
        public string Document { get; set; }
        public string DocType { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
