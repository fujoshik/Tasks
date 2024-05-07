namespace Task3
{
    public static class QueueExtensions
    {
        public static IQueue<T> Tail<T>(this IQueue<T> queue, int length = 10)
        {
            int index = 0;
            var result = new Queue<T>(length);

            while (!queue.IsEmpty())
            {
                if (index == 0)
                {
                    queue.Dequeue();
                    index++;
                }
                else
                {
                    result.Enqueue(queue.Dequeue());
                }           
            }

            return result;
        }
    }
}
