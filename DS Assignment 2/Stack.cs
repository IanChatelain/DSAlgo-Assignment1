namespace TestLibrary
{
    /// <summary>
    /// Represents a stack.
    /// </summary>
    /// <typeparam name="T">The type of elements in the stack.</typeparam>
    public class Stack<T>
    {
        public Node<T>? Head { get; set; }
        public int Size { get; set; }

        /// <summary>
        /// Initializes a new instance of the Stack class.
        /// </summary>
        public Stack()
        {
            this.Clear();
        }

        /// <summary>
        /// Creates a new Node with the new element and adds it to the top of the stack.
        /// </summary>
        /// <param name="element">The element added to the top of the stack.</param>
        public void Push(T element)
        {
            Node<T> newNode = new Node<T>(element);

            newNode.Next = this.Head;
            this.Head = newNode;

            this.Size++;
        }

        /// <summary>
        /// Returns the top element on the stack without removing it from the data structure.
        /// </summary>
        /// <returns>The element at the top of the stack.</returns>
        public T? Top()
        {
            this.ThrowIsEmpty();

            return this.Head.Element;
        }

        /// <summary>
        /// Returns the top element on the stack, removing it from the data structure.
        /// </summary>
        /// <returns>The element removed from the stack.</returns>
        public T? Pop()
        {
            T element = this.Top();
            this.Head = this.Head.Next;
            this.Size--;

            return element;
        }

        /// <summary>
        /// Clears the stack and sets initial values.
        /// </summary>
        public void Clear()
        {
            this.Head = null;
            this.Size = 0;
        }

        /// <summary>
        /// Returns whether the stack is empty or not empty.
        /// </summary>
        /// <returns>True if the stack is empty, false if the stack is not empty.</returns>
        public bool IsEmpty() => this.Head == null;

        // Helper Methods
        
        /// <summary>
        /// Throws an exception if the stack is empty.
        /// </summary>
        /// <exception cref="ApplicationException">The exception thrown if the stack is empty.</exception>
        public void ThrowIsEmpty()
        {
            if (this.IsEmpty()) throw new ApplicationException();
        }
    }
}

