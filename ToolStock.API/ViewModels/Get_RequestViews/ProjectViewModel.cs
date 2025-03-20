namespace ToolStock.API.ViewModels.Get_RequestViews
{
    public class ProjectViewModel
    {
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
