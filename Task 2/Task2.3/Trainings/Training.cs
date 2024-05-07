namespace Task2._3.Trainings
{
    public class Training : TrainingEntity
    {
        private int _trainingEntitiesCount;
        private BaseTraining[] _trainingEntities;

        public Training(string description)
        {
            Description = description;
            _trainingEntities = new BaseTraining[1];
        }

        public void Add(BaseTraining training)
        {
            if (_trainingEntities.Length == _trainingEntitiesCount)
            {
                ResizeArray();
            }
            _trainingEntities[_trainingEntitiesCount] = training;
            _trainingEntitiesCount++;
        }

        public bool IsPractical()
        {
            foreach (var training in _trainingEntities)
            {
                if (training is Lecture)
                {
                    return false;
                }
            }
            return true;
        }

        public Training Clone()
        {
            var cloned = new Training(Description);

            foreach (var training in _trainingEntities)
            {
                cloned.Add((BaseTraining)training.Clone());
            }

            return cloned;
        }

        private void ResizeArray()
        {
            var newArray = new BaseTraining[_trainingEntitiesCount * 2];
            Array.Copy(_trainingEntities, newArray, _trainingEntitiesCount);
            _trainingEntities = newArray;
        }
    }
}
