using Task2._3.Trainings.Interfaces;

namespace Task2._3.Trainings
{
    public class PracticalLesson : BaseTraining, ITraining
    {
        public string TaskLink { get; set; }
        public string SolutionLink { get; set; }
        public PracticalLesson(string description, string taskLink, string solutionLink)
            : base(description)
        {
            TaskLink = taskLink;
            SolutionLink = solutionLink;
        }
    }
}
