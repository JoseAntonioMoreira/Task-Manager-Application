
namespace TaskManager
{
    public class WorkTask : Task
    {
        public DateTime StartedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public TaskState State { get; set; }

        private WorkTask(string title, string description, DateOnly creationDate, string notes, TaskState state) : base(title, description, creationDate, notes)
        {
            State = state;
        }

        public static WorkTask CreateNewTask(string title, string description, DateOnly creationDate, string notes, TaskState state)
        {
            return new WorkTask(title, description, creationDate, notes, TaskState.New);
        }

        public static WorkTask CreateUrgentTask(string title, string description, DateOnly creationDate, string notes, TaskState state)
        {
            return new WorkTask(title, description, creationDate, notes, TaskState.Urgent);
        }
    }
}
