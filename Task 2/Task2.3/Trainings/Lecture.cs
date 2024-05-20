namespace Task2._3.Trainings
{
    public class Lecture : BaseTraining
    {
        public string Topic { get; set; }
        public Lecture(string description, string topic)
        {
            Description = description;
            Topic = topic;
        }

        public override object Clone()
        {
            return new Lecture(Description, Topic);
        }
    }
}
