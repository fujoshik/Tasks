namespace Task3
{
    public interface IQueue<T>
    {
        void Enqueue(T item);
        T Dequeue();
        bool IsEmpty();
        IQueue<T> Clone();
    }
}
