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
                if (value <= _finishedDate && value.Date > CreationDate) //start date can never be before creation date nor after finished date
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

        public List<(string milestone, bool isCompleted)> Milestones { get; }//tuple to hold milestone and if they are done, for easier management of task

        public double MilestonePercentage { get; private set; }

        // maybe variable to add attachments?

        private WorkTask(string title, string description, DateTime creationDate, TaskState state, List<(string milestones, bool isCompleted)> milestones) : base(title, description, creationDate)
        {
            State = state;
            Milestones = milestones;
        }

        //In regards to the tuple... The tupple is instantiated here and during the task life, it will never close, even if is empty
        public static WorkTask CreateNewTask(string title, string description, DateTime creationDate, List<(string milestones, bool isCompleted)> milestones)
        {
            return new WorkTask(title, description, creationDate, TaskState.New, milestones);
        }

        //This (string milestone) parammeters are not optimal, they need to change in the future, I just don't know to what, maybe when frontend is more advanced 
        public void AddMilestone(string milestone)
        {
            Milestones.Add((milestone, false));
        }

        public void RemoveMilestone(string milestone)
        {
            Milestones.Remove((milestone, false));//this is bad beacuse a milestone can be true and should still be removable, needs refactor !
        }

        public void ChangeMilestoneStatus(string milestone)
        {
            int index = Milestones.FindIndex(m => m.milestone == milestone);
            if (index != -1)
            {
                Milestones[index] = (Milestones[index].milestone, !Milestones[index].isCompleted);
                MilestonePercentage = CalculateProgressPercentage();
            }
        }

        private double CalculateProgressPercentage()
        {
            int completedMilestones = Milestones.Count(m => m.isCompleted);

            if (Milestones.Count == 0)
            {
                return 0.0; // In case there are no milestones so the program doesn't crash from dividing by zero
            }

            return (double)completedMilestones / Milestones.Count * 100.0;
        }
    }
}
