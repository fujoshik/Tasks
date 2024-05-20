namespace Task3
{
    public class Queue<T> : IQueue<T> where T : struct
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
            _head++;

            return element;
        }

        public void Enqueue(T item)
        {
            if (_head == _tail && _tail == _size)
            {
                _head = 0; 
                _tail = 0;
            }

            if (_tail >= _size)
            {
                throw new InvalidOperationException("Queue is already full!");
            }

            _queue[_tail++] = item;       
        }

        public bool IsEmpty() => _head == _tail;

        public IQueue<T> Clone()
        {
            var newQueue = new Queue<T>(_size);

            for (int i = _head; i < _tail; i++)
            {
                newQueue.Enqueue(_queue[i]);
            }

            return newQueue;
        }

        public override string ToString()
        {
            string result = "";

            for (int i = _head; i < _tail; i++)
            {
                result += $"{_queue[i]} ";
            }
            return result;
        }
    }
}
