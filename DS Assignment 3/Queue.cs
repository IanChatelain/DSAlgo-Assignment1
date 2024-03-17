namespace TestLibrary
{
    public class Queue<T>
    {
        public int Size { get; set; }
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }

        public Queue()
        {

        }

        public void Enqueue(T element) { }

        public T Front()
        {
            return default;
        }

        public T Dequeue()
        {
            return default;
        }

        public void Clear() { }

        /// <summary>
        /// Returns whether the queue is empty or not empty.
        /// </summary>
        /// <returns>True if the queue is empty, false if the queue is not empty.</returns>
        public bool IsEmpty() => this.Head == null;
    }
}
