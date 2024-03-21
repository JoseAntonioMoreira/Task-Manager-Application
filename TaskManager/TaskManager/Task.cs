namespace TaskManager
{
    public abstract class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly CreationDate { get; }
        public string Notes { get; set; }

        public Task(string title, string description, DateOnly creationDate, string notes)
        {
            Title = title;
            Description = description;
            CreationDate = creationDate;
            Notes = notes;
        }
    }
}
