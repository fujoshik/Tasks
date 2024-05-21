namespace Task2._3.Trainings
{
    public abstract class BaseTraining : TrainingEntity, ICloneable
    {
        public abstract object Clone();
    }
}
