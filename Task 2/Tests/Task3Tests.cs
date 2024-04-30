using Task2._3.Trainings;

namespace Tests
{
    [TestClass]
    public class Task3Tests
    {
        [TestMethod]
        public void IsPractical_True()
        {
            var training = new Training("Test");
            training.Add(new PracticalLesson("Description", "Link1", "Link2"));

            Assert.IsTrue(training.IsPractical());
        }

        [TestMethod]
        public void IsPractical_False()
        {
            var training = new Training("Test");
            training.Add(new PracticalLesson("Description", "Link1", "Link2"));
            training.Add(new Lecture("Lecture", "Topic"));

            Assert.IsFalse(training.IsPractical());
        }

        [TestMethod]
        public void Clone_Success()
        {
            var training = new Training("Test");
            var clone = training.Clone();

            Assert.AreNotEqual(clone, training);
        }
    }
}
