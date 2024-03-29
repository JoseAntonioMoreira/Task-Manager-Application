namespace TaskManager
{
    public abstract class Task(string title, string description, DateTime creationDate)
    {
        public string Title { get; set; } = title;
        public string Description { get; set; } = description;
        public DateTime CreationDate { get; } = creationDate;

        //public void UpdateTask() { } this is for reference only
    }
}
