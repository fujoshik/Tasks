using Task2._3.Trainings.Interfaces;

namespace Task2._3.Trainings
{
    public class Lecture : BaseTraining, ITraining
    {
        public string Topic { get; set; }
        public Lecture(string description, string topic)
            : base(description)
        {
            Topic = topic;
        }
    }
}
