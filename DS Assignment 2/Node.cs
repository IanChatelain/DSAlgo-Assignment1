namespace TestLibrary
{
    /// <summary>
    /// Represents a node in a linked list which contains an element and references to the next node.
    /// </summary>
    /// <typeparam name="T">The type of the element stored in the node.</typeparam>
    public class Node<T>
    {
        public T? Element { get; set; }
        public Node<T>? Next { get; set; }

        /// <summary>
        /// Initializes a new instance of the Node class with default values. 
        /// </summary>
        public Node()
        {
            this.Element = default;
            this.Next = null;
        }

        /// <summary>
        /// Initializes a new instance of the Node class with the specified element.
        /// </summary>
        /// <param name="element">The element to store in the node.</param>
        public Node(T element)
        {
            this.Element = element;
        }

        /// <summary>
        /// Initializes a new instance of the Node class with the specified element, and next node.
        /// </summary>
        /// <param name="element">The element to store in the node.</param>
        /// <param name="nextNode">The next node in the linked list.</param>
        public Node(T element, Node<T> nextNode)
        {
            this.Element = element;
            this.Next = nextNode;
        }
    }
}
