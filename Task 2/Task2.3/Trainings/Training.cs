using Task2._3.Trainings.Interfaces;

namespace Task2._3.Trainings
{
    public class Training : BaseTraining
    {
        private int _trainingsCount;
        private ITraining[] _trainings;

        public Training(string description)
            : base(description)
        {
            _trainings = new ITraining[1];
        }

        public void Add(ITraining training)
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

            for (int i = 0; i < _trainingsCount; i++)
            {
                if (_trainings[i] is PracticalLesson practicalLesson)
                {
                    cloned.Add(new PracticalLesson(practicalLesson.Description,
                        practicalLesson.TaskLink, practicalLesson.SolutionLink));
                }
                else if (_trainings[i] is Lecture lecture)
                {
                    cloned.Add(new Lecture(lecture.Description, lecture.Topic));
                }
            }

            return cloned;
        }

        private void ResizeArray()
        {
            var newArray = new ITraining[_trainingsCount * 2];
            Array.Copy(_trainings, newArray, _trainingsCount);
            _trainings = newArray;
        }
    }
}
