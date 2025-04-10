namespace ToolStock.API.ViewModels
{
    public class ToolAssignmentViewModel
    {
        public string ToolName { get; set; }
        public string UserName { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime? DateIn { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
