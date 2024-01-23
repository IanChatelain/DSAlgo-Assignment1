using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    /// <summary>
    /// Represents a generic doubly linked list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the linked list.</typeparam>
    public class LinkedList<T> where T : IComparable<T>
    {
        // Milestone #1

        public Node<T>? Head { get; set; }
        public Node<T>? Tail { get; set; }
        public int Size { get; set; }

        /// <summary>
        /// Initializes a new instance of the LinkedList class.
        /// </summary>
        public LinkedList()
        {
            this.Clear();
        }

        /// <summary>
        /// Removes all nodes from the linked list.
        /// </summary>
        public void Clear()
        {
            this.Size = 0;
            this.Head = null;
            this.Tail = null;
        }

        /// <summary>
        /// Determines whether the linked list is empty.
        /// </summary>
        /// <returns>True if the linked list is empty, otherwise, false.</returns>
        public bool IsEmpty()
        {
            return Size == 0;
        }

        /// <summary>
        /// Gets the element in the first node of the linked list.
        /// </summary>
        /// <returns>The element in the first node of the linked list.</returns>
        /// <exception cref="ApplicationException">Thrown if the linked list is empty.</exception>
        public T GetFirst()
        {
            this.ThrowIsEmpty();
            return this.Head.Element;
        }

        /// <summary>
        /// Gets the element in the last node of the linked list.
        /// </summary>
        /// <returns>The element in the last node of the linked list.</returns>
        /// <exception cref="ApplicationException">Thrown if the linked list is empty.</exception>
        public T GetLast()
        {
            this.ThrowIsEmpty();
            return this.Tail.Element;
        }

        /// <summary>
        /// Replaces the element in the first node and returns the old element.
        /// </summary>
        /// <param name="element">The new element to set in the first node.</param>
        /// <returns>The old element that was replaced.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the provided element is null.</exception>
        /// <exception cref="ApplicationException">Thrown if the linked list is empty.</exception>
        public T SetFirst(T element)
        {
            this.ThrowNotNull(element);
            this.ThrowIsEmpty();

            T oldElement = this.Head.Element;

            this.Head.Element = element;

            return oldElement;
        }

        /// <summary>
        /// Replaces the element in the last node and returns the old element.
        /// </summary>
        /// <param name="element">The new element to set in the last node.</param>
        /// <returns>The old element that was replaced.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the provided element is null.</exception>
        /// <exception cref="ApplicationException">Thrown if the linked list is empty.</exception>
        public T SetLast(T element)
        {
            this.ThrowNotNull(element);
            this.ThrowIsEmpty();

            T oldElement = this.Tail.Element;

            this.Tail.Element = element;

            return oldElement;
        }

        /// <summary>
        /// Adds a new node containing the specified element to the start of the linked list.
        /// </summary>
        /// <param name="element">The element to add to the linked list.</param>
        /// <exception cref="ArgumentNullException">Thrown if the provided element is null.</exception>
        public void AddFirst(T element)
        {
            this.ThrowNotNull(element);

            Node<T> newNode = new Node<T>(element);

            if (this.IsEmpty())
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                newNode.Next = this.Head;
                this.Head.Previous = newNode;
                this.Head = newNode;
            }

            this.Size++;
        }

        /// <summary>
        /// Adds a new node containing the specified element to the end of the linked list.
        /// </summary>
        /// <param name="element">The element to add to the linked list.</param>
        /// <exception cref="ArgumentNullException">Thrown if the provided element is null.</exception>
        public void AddLast(T element)
        {
            this.ThrowNotNull(element);

            Node<T> newNode = new Node<T>(element);

            if (this.IsEmpty())
            {
                this.Head = newNode;
                this.Tail = newNode;
            }
            else
            {
                this.Tail.Next = newNode;
                newNode.Previous = this.Tail;
                this.Tail = newNode;
            }

            this.Size++;
        }

        /// <summary>
        /// Checks if the provided element is null and throws an ArgumentNullException if it is.
        /// </summary>
        /// <param name="element">The element to check for null.</param>
        /// <exception cref="ArgumentNullException">Thrown when the provided element is null.</exception>
        private void ThrowNotNull(T element)
        {
            if(element == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Checks if the linked list is empty and throws an ApplicationException if it is.
        /// </summary>
        /// <exception cref="ApplicationException">Thrown when the linked list is empty.</exception>
        private void ThrowIsEmpty()
        {
            if (this.IsEmpty())
            {
                throw new ApplicationException("List is empty");
            }
        }

        // Milestone #2

        public T RemoveFirst()
        {
            return
        }

        public T RemoveLast()
        {
            return
        }

        public T Get(int position)
        {
            return
        }

        public T Remove(int position)
        {
            return
        }

        public void AddAfter(T element, int position)
        {

        }

        public void AddBefore(T element, int position)
        {

        }
    }
}
