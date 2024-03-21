namespace TaskManager
{
    public abstract class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; }

        public Task(string title, string description, DateTime creationDate)
        {
            Title = title;
            Description = description;
            CreationDate = creationDate;
        }

        public void UpdateTask() { }
    }
}
