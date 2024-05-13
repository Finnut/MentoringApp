namespace MentoringApp
{
    public class TaskToDoModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string YouTrackId { get; set; } = default!;
    }
}
