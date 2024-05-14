namespace Task3
{
    public interface IQueue<T> where T : struct
    {
        void Enqueue(T item);
        T Dequeue();
        bool IsEmpty();
        IQueue<T> Clone();
    }
}
