namespace TestLibrary
{
    /// <summary>
    /// Represents a queue.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    public class Queue<T>
    {
        public int Size { get; set; }
        public Node<T>? Head { get; set; }
        public Node<T>? Tail { get; set; }

        /// <summary>
        /// Initializes a new instance of the Queue class.
        /// </summary>
        public Queue()
        {
            this.Clear();
        }

        /// <summary>
        /// Creates a new Node with the new element and adds it to the front of the queue.
        /// </summary>
        /// <param name="element">The element added to the front of the queue.</param>
        public void Enqueue(T element)
        {
            Node<T> newNode = new Node<T>(element);

            if (this.IsEmpty())
            {
                this.Head = newNode;
            }
            else
            {
                this.Tail.Next = newNode;
            }

            this.Tail = newNode;
            this.Size++;
        }

        /// <summary>
        /// Returns the front element in the queue without removing it from the data structure.
        /// </summary>
        /// <returns>The element in the front of the queue.</returns>
        public T Front()
        {
            this.ThrowIsEmpty();

            return this.Head.Element;
        }

        /// <summary>
        /// Returns the front element in the queue, removing it from the data structure.
        /// </summary>
        /// <returns>The element removed from the queue.</returns>
        public T Dequeue()
        {
            T element = this.Front();

            if (this.Size == 1)
            {
                this.Clear();
            }
            else
            {
                this.Head = this.Head.Next;
                this.Size--;
            }

            return element;
        }

        /// <summary>
        /// Clears the queue and sets initial values.
        /// </summary>
        public void Clear()
        {
            this.Head = null;
            this.Tail = null;
            this.Size = 0;
        }

        /// <summary>
        /// Returns whether the queue is empty or not empty.
        /// </summary>
        /// <returns>True if the queue is empty, false if the queue is not empty.</returns>
        public bool IsEmpty() => this.Head == null;

        // Helper Methods

        /// <summary>
        /// Throws an exception if the queue is empty.
        /// </summary>
        /// <exception cref="ApplicationException">The exception thrown if the queue is empty.</exception>
        public void ThrowIsEmpty()
        {
            if (this.IsEmpty()) throw new ApplicationException();
        }
    }
}
