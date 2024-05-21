namespace Task2._3.Trainings
{
    public class PracticalLesson : BaseTraining
    {
        public string TaskLink { get; set; }
        public string SolutionLink { get; set; }
        public PracticalLesson(string description, string taskLink, string solutionLink)
        {
            Description = description;
            TaskLink = taskLink;
            SolutionLink = solutionLink;
        }

        public override object Clone()
        {
            return new PracticalLesson(Description, TaskLink, SolutionLink);
        }
    }
}
