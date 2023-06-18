namespace Mini_Project.Model
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Query { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
    }
}
