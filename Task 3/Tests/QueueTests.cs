using Task3;

namespace Tests
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void EnqueueDequeue_Success()
        {
            var queue = new Task3.Queue<int>(4);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(4, queue.Dequeue());
        }

        [TestMethod]
        public void Enqueue_QueueFull_ThrowsException()
        {
            var queue = new Task3.Queue<int>(4);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Assert.ThrowsException<InvalidOperationException>(() => queue.Enqueue(5));
        }

        [TestMethod]
        public void Dequeue_QueueEmpty_ThrowsException()
        {
            var queue = new Task3.Queue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        }

        [TestMethod]
        public void IsEmpty_EmptyQueue_True()
        {
            var queue = new Task3.Queue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            Assert.IsTrue(queue.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_NotEmptyQueue_False()
        {
            var queue = new Task3.Queue<int>(3);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            queue.Dequeue();
            queue.Dequeue();

            Assert.IsFalse(queue.IsEmpty());
        }

        [TestMethod]
        public void Tail_Success()
        {
            var queue = new Task3.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            var result = queue.Tail<int>();

            Assert.AreEqual(2, result.Dequeue());
            Assert.AreEqual(3, result.Dequeue());
        }
    }
}