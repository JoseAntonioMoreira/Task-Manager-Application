namespace TaskManager
{
    public class WorkTask : Task
    {
        private DateTime _startedDate;
        public DateTime StartedDate
        {
            get => _startedDate;

            set
            {
                if (value <= _finishedDate && value.Date > CreationDate)
                {
                    _startedDate = value;
                }
                else
                {
                    _startedDate = DateTime.Now;
                }
            }
        }

        private DateTime _finishedDate;
        public DateTime FinishedDate
        {
            get => _finishedDate;
            set
            {
                if (value >= _startedDate)
                {
                    _finishedDate = value;
                }
                else
                {
                    _finishedDate = DateTime.Now;
                }
            }
        }
        public TaskState State { get; set; }

        public List<(string milestone, bool isCompleted)> Milestones { get; set; }

        //add progress percentage based on milestones

        // maybe variable to add attachments?

        private WorkTask(string title, string description, DateTime creationDate, TaskState state, List<(string milestones, bool isCompleted)> milestones) : base(title, description, creationDate)
        {
            State = state;
            Milestones = milestones;
        }

        public static WorkTask CreateNewTask(string title, string description, DateTime creationDate, List<(string milestones, bool isCompleted)> milestones)
        {
            return new WorkTask(title, description, creationDate, TaskState.New, milestones);
        }

        public void AddMilestone(string milestone)
        {
            Milestones.Add((milestone, false));
        }

        public void MarkMilestoneAsCompleted(string milestone)
        {
            var index = Milestones.FindIndex(m => m.milestone == milestone);
            if (index != -1)
            {
                Milestones[index] = (Milestones[index].milestone, true);
            }
        }
    }
}
