namespace Task3
{
    public static class QueueExtensions
    {
        public static IQueue<T> Tail<T>(this IQueue<T> queue, int length = 10)
        {
            int index = 0;

            var clonedQueue = queue.Clone();
            var result = new Queue<T>(length - 1);

            while (!clonedQueue.IsEmpty())
            {
                if (index == 0)
                {
                    clonedQueue.Dequeue();
                    index++;
                }
                else
                {
                    result.Enqueue(clonedQueue.Dequeue());
                }           
            }

            return result;
        }
    }
}
