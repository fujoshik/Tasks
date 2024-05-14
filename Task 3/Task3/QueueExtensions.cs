namespace Task3
{
    public static class QueueExtensions
    {
        public static IQueue<T> Tail<T>(this IQueue<T> queue)
            where T : struct
        {
            var clonedQueue = queue.Clone();
            clonedQueue.Dequeue();

            return clonedQueue;
        }
    }
}
