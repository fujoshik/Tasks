using Task3;

var queue = new Task3.Queue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
queue.Enqueue(3);
queue.Enqueue(4);
queue.Enqueue(15);

Console.WriteLine("Is queue empty: " + queue.IsEmpty());
Console.WriteLine(queue.Dequeue());
Console.WriteLine(queue.Dequeue());

Console.WriteLine();
Console.WriteLine("Is queue empty: " + queue.IsEmpty());

var tail = queue.Tail();
Console.WriteLine("Tail elements:");
while (!tail.IsEmpty())
{
    Console.Write(tail.Dequeue() + " ");
}
Console.WriteLine();

Console.WriteLine("Is queue empty: " + queue.IsEmpty());

Console.WriteLine(queue.Dequeue());

var queue2 = new Task3.Queue<int>(5);
queue2.Enqueue(1);
queue2.Enqueue(2);
queue2.Enqueue(3);
queue2.Enqueue(4);
queue2.Enqueue(5);

queue2.Dequeue();
queue2.Dequeue();
queue2.Dequeue();
queue2.Dequeue();
queue2.Dequeue();

queue2.Enqueue(1);
queue2.Enqueue(1);
queue2.Dequeue();

Console.WriteLine(queue2.ToString());
