namespace Task3
{
    public class Queue<T> : IQueue<T>
    {
        private T[] _queue;
        private int _head = 0;
        private int _tail = 0;
        private int _size;

        public Queue(int size = 10)
        {
            _size = size;
            _queue = new T[size];
        }

        public T Dequeue()
        {
            if (_head >= _size)
            {
                throw new InvalidOperationException("No elements in the queue!");
            }
            T element = _queue[_head];

            if (object.Equals(element, default(T)))
            {
                throw new InvalidOperationException("No elements in the queue!");
            }

            if (_head == _size)
            {
                _head = 1;
            }
            else
            {
                _head++;
            }

            return element;
        }

        public void Enqueue(T item)
        {
            if (_tail >= _size)
            {
                throw new InvalidOperationException("Queue is already full!");
            }
            _queue[_tail] = item;

            if (_tail == _size)
            {
                _tail = 1;
            }              
            else
            {
                _tail++;
            }         
        }

        public bool IsEmpty() => _head == _tail;
    }
}
