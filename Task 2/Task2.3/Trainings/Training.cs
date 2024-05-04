namespace Task2._3.Trainings
{
    public class Training : TrainingEntity
    {
        private int _trainingsCount;
        private BaseTraining[] _trainings;

        public Training(string description)
        {
            Description = description;
            _trainings = new BaseTraining[1];
        }

        public void Add(BaseTraining training)
        {
            if (_trainings.Length == _trainingsCount)
            {
                ResizeArray();
            }
            _trainings[_trainingsCount] = training;
            _trainingsCount++;
        }

        public bool IsPractical()
        {
            foreach (var training in _trainings)
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

            foreach (var training in _trainings)
            {
                if (training is Lecture lecture)
                {
                    cloned.Add(lecture.Clone() as Lecture);
                }
                else if (training is PracticalLesson lesson)
                {
                    cloned.Add(lesson.Clone() as PracticalLesson);
                }
            }

            return cloned;
        }

        private void ResizeArray()
        {
            var newArray = new BaseTraining[_trainingsCount * 2];
            Array.Copy(_trainings, newArray, _trainingsCount);
            _trainings = newArray;
        }
    }
}
