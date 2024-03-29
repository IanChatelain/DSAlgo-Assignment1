﻿namespace TestLibrary
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
            this.ThrowEmptyList();
            return this.Head.Element;
        }

        /// <summary>
        /// Gets the element in the last node of the linked list.
        /// </summary>
        /// <returns>The element in the last node of the linked list.</returns>
        /// <exception cref="ApplicationException">Thrown if the linked list is empty.</exception>
        public T GetLast()
        {
            this.ThrowEmptyList();
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
            this.ThrowEmptyList();

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
            this.ThrowEmptyList();

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

        // Milestone #2

        /// <summary>
        /// Removes and returns the element from the first node of the list.
        /// </summary>
        /// <returns>The element that was removed from the list.</returns>
        public T RemoveFirst()
        {
            this.ThrowEmptyList();

            T firstElement = this.GetFirst();

            if (this.Size == 1)
            {
                this.Head = null;
                this.Tail = null;
            }
            else
            {
                this.Head = this.Head.Next;
                this.Head.Previous = null;
            }

            this.Size--;

            return firstElement;
        }

        /// <summary>
        /// Removes and returns the element from the last node of the list.
        /// </summary>
        /// <returns>The element that was removed from the list.</returns>
        public T RemoveLast()
        {
            this.ThrowEmptyList();

            T lastElement = this.GetLast();

            if (this.Size == 1)
            {
                this.Head = null;
                this.Tail = null;
            }
            else
            {
                this.Tail = this.Tail.Previous;
                this.Tail.Next = null;
            }

            this.Size--;

            return lastElement;
        }

        /// <summary>
        /// Retrieves the element at the specified position in the list.
        /// </summary>
        /// <param name="position">The integer based position of the element to retrieve.</param>
        /// <returns>The element at the specified position.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list is empty</exception>
        /// <exception cref="ApplicationException">Thrown if the position is larger than the size of the list, 0, or negative.</exception>
        public T Get(int position)
        {
            return this.GetNodeByPosition(position).Element;
        }

        /// <summary>
        /// Removes and returns the element from the specified position in the list.
        /// </summary>
        /// <param name="position">The integer based position of the element to retrieve.</param>
        /// <returns>The element contained in the removed node.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list is empty</exception>
        /// <exception cref="ApplicationException">Thrown if the position is larger than the size of the list, 0, or negative.</exception>
        public T Remove(int position)
        {
            Node<T> nodeToRemove = this.GetNodeByPosition(position);

            if (this.Size == 1)
            {
                this.RemoveFirst();
            }
            else
            {
                if (position == 1)
                {
                    this.RemoveFirst();
                }
                else if (position == this.Size)
                {
                    this.RemoveLast();
                }
                else
                {
                    nodeToRemove.Next.Previous = nodeToRemove.Previous;
                    nodeToRemove.Previous.Next = nodeToRemove.Next;
                    this.Size--;
                }
            }

            return nodeToRemove.Element;
        }

        /// <summary>
        /// Replaces the element at the specified position with a new element and returns the old element.
        /// </summary>
        /// <param name="element">The new element to be set.</param>
        /// <param name="position">The integer based position of the element to retrieve.</param>
        /// <returns>The original element that was replaced.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list, or element is empty</exception>
        /// <exception cref="ApplicationException">Thrown if the position is larger than the size of the list, 0, or negative.</exception>
        public T Set(T element, int position)
        {
            this.ThrowNullElement(element);

            Node<T> oldNode = this.GetNodeByPosition(position);
            T oldElement = oldNode.Element;
            oldNode.Element = element;

            return oldElement;
        }

        /// <summary>
        /// Adds a new node containing the specified element after the node at the specified position.
        /// </summary>
        /// <param name="element">The element to be added.</param>
        /// <param name="position">The integer based position of the element to retrieve.</param>
        /// <exception cref="ArgumentNullException">Thrown if the list, or element is empty</exception>
        /// <exception cref="ApplicationException">Thrown if the position is larger than the size of the list, 0, or negative.</exception>
        public void AddAfter(T element, int position)
        {
            this.ThrowNullElement(element);

            Node<T> nodeBeforeAdd = this.GetNodeByPosition(position);
            Node<T> newNode = new Node<T>(element);

            if (position == this.Size)
            {
                this.AddLast(element);
            }
            else
            {
                newNode.Next = nodeBeforeAdd.Next;
                nodeBeforeAdd.Next.Previous = newNode;
                nodeBeforeAdd.Next = newNode;
                newNode.Previous = nodeBeforeAdd;
                this.Size++;
            }
        }

        /// <summary>
        /// Adds a new node containing the specified element before the node at the specified position.
        /// </summary>
        /// <param name="element">The element to be added.</param>
        /// <param name="position">The integer based position of the element to retrieve.</param>
        /// <exception cref="ArgumentNullException">Thrown if the list, or element is empty</exception>
        /// <exception cref="ApplicationException">Thrown if the position is larger than the size of the list, 0, or negative.</exception>
        public void AddBefore(T element, int position)
        {
            this.ThrowNullElement(element);

            Node<T> nodeAfterAdd = this.GetNodeByPosition(position);
            Node<T> newNode = new Node<T>(element);

            if (position == 1)
            {
                this.AddFirst(element);
            }
            else
            {
                newNode.Previous = nodeAfterAdd.Previous;
                nodeAfterAdd.Previous.Next = newNode;
                nodeAfterAdd.Previous = newNode;
                newNode.Next = nodeAfterAdd;
                this.Size++;
            }
        }

        /// <summary>
        /// Retrieves the element from the list that matches the specified element.
        /// </summary>
        /// <param name="element">The element to be retrieved from the list.</param>
        /// <returns>The matching element from the list.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list, or element is empty</exception>
        /// <exception cref="ApplicationException">Thrown if the position is larger than the size of the list, 0, or negative.</exception>
        public T Get(T element)
        {
            return this.GetNodeByElement(element).Element;
        }

        /// <summary>
        /// Adds a new node containing the specified element after the node containing the oldElement.
        /// </summary>
        /// <param name="element">The element to be added to the list.</param>
        /// <param name="oldElement">The element after which the new element is to be added.</param>
        /// <exception cref="ArgumentNullException">Thrown if the list, or element is empty</exception>
        /// <exception cref="ApplicationException">Thrown if the position is larger than the size of the list, 0, or negative.</exception>
        public void AddAfter(T element, T oldElement)
        {
            this.ThrowNullElement(element);

            Node<T> nodeBeforeAdd = GetNodeByElement(oldElement);
            Node<T> newNode = new Node<T>(element);

            if (oldElement.CompareTo(GetLast()) == 0)
            {
                this.AddLast(element);
            }
            else
            {
                newNode.Next = nodeBeforeAdd.Next;
                nodeBeforeAdd.Next.Previous = newNode;
                nodeBeforeAdd.Next = newNode;
                newNode.Previous = nodeBeforeAdd;
                this.Size++;
            }
        }

        /// <summary>
        /// Adds a new node containing the specified element before the node containing the oldElement.
        /// </summary>
        /// <param name="element">The element to be added to the list.</param>
        /// <param name="oldElement">The element before which the new element is to be added.</param>
        /// <exception cref="ArgumentNullException">Thrown if the list, or element is empty</exception>
        /// <exception cref="ApplicationException">Thrown if the position is larger than the size of the list, 0, or negative.</exception>
        public void AddBefore(T element, T oldElement)
        {
            this.ThrowNullElement(element);

            Node<T> nodeAfterAdd = this.GetNodeByElement(oldElement);
            Node<T> newNode = new Node<T>(element);

            if (oldElement.CompareTo(GetFirst()) == 0)
            {
                this.AddFirst(element);
            }
            else
            {
                newNode.Previous = nodeAfterAdd.Previous;
                nodeAfterAdd.Previous.Next = newNode;
                nodeAfterAdd.Previous = newNode;
                newNode.Next = nodeAfterAdd;
                this.Size++;
            }
        }

        /// <summary>
        /// Removes the node from the list that contains the specified element.
        /// </summary>
        /// <param name="element">The element whose node is to be removed from the list.</param>
        /// <returns>The element that was removed from the list.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list, or element is empty</exception>
        /// <exception cref="ApplicationException">Thrown if the position is larger than the size of the list, 0, or negative.</exception>
        public T Remove(T element)
        {
            Node<T> nodeToRemove = this.GetNodeByElement(element);

            if (this.Size == 1)
            {
                this.RemoveFirst();
            }
            else
            {
                if (element.CompareTo(GetFirst()) == 0)
                {
                    this.RemoveFirst();
                }
                else if (element.CompareTo(GetLast()) == 0)
                {
                    this.RemoveLast();
                }
                else
                {
                    nodeToRemove.Next.Previous = nodeToRemove.Previous;
                    nodeToRemove.Previous.Next = nodeToRemove.Next;
                    this.Size--;
                }
            }

            return nodeToRemove.Element;
        }

        /// <summary>
        /// Replaces the element in the list that matches the oldElement with the specified element.
        /// </summary>
        /// <param name="element">The new element that replaces the old element in the list.</param>
        /// <param name="oldElement">The old element to be replaced.</param>
        /// <returns>The old element that was replaced in the list.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list, or element is empty</exception>
        /// <exception cref="ApplicationException">Thrown if the position is larger than the size of the list, 0, or negative.</exception>
        public T Set(T element, T oldElement)
        {
            this.ThrowNullElement(element);

            Node<T> oldNode = this.GetNodeByElement(oldElement);
            oldNode.Element = element;

            return oldElement;
        }

        /// <summary>
        /// Inserts the specified element into the list in a sorted order. 
        /// This method assumes the list is in sorted order.
        /// </summary>
        /// <param name="element">The element to be inserted into the list.</param>
        /// <exception cref="ArgumentNullException">Thrown if the list, or element is empty</exception>
        /// <exception cref="ApplicationException">Thrown if the element cannot be inserted.</exception>
        public void Insert(T element)
        {
            this.ThrowNullElement(element);

            Node<T> current = this.Head;

            if (IsEmpty())
            {
                this.AddFirst(element);
                return;
            }

            for (int i = 1; i < this.Size; i++)
            {
                int comparison = current.Element.CompareTo(element);

                if (comparison > 0)
                {
                    break;
                }

                if (comparison <= 0)
                {
                    current = current.Next;
                }
            }

            if (current.Element.CompareTo(GetLast()) == 0 && current.Element.CompareTo(element) < 0)
            {
                this.AddAfter(element, current.Element);
            }
            else
            {
                this.AddBefore(element, current.Element);
            }
        }

        /// <summary>
        /// Sorts the elements of the list in ascending order.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if the list, or element is empty</exception>
        /// <exception cref="ApplicationException">Thrown if the sort fails.</exception>
        public void SortAscending()
        {
            LinkedList<T> sortedList = new LinkedList<T>();
            Node<T> current = this.Head;
            
            while (current != null)
            {
                sortedList.Insert(current.Element);
                current = current.Next;
            }

            this.Head = sortedList.Head;
            this.Tail = sortedList.Tail;
        }

        // Helper Methods

        /// <summary>
        /// Retrieves the node at the specified position in the linked list.
        /// </summary>
        /// <param name="position">The integer based position of the element to retrieve.</param>
        /// <returns>The node at the specified position.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list is empty</exception>
        /// <exception cref="ApplicationException">Thrown if the position is larger than the size of the list, 0, or negative.</exception>
        private Node<T> GetNodeByPosition(int position)
        {
            this.ThrowEmptyList();
            this.ThrowInvalidPosition(position, this.Size);

            Node<T> current = this.Head;

            for (int i = 1; i < position; i++)
            {
                current = current.Next;
            }

            return current;
        }

        /// <summary>
        /// Retrieves the node of the specified element in the linked list.
        /// </summary>
        /// <param name="element">An element in the linked list.</param>
        /// <returns>The node of the specified element</returns>
        /// <exception cref="ApplicationException">Thrown if the position is larger than the size of the list, 0, or negative.</exception>
        private Node<T> GetNodeByElement(T element)
        {
            this.ThrowEmptyList();
            this.ThrowNullElement(element);

            Node<T> current = this.Head;

            for (int i = 1; i < this.Size; i++)
            {
                if (current.Element.CompareTo(element) == 0)
                {
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }

            if (current.Element.CompareTo(element) != 0)
            {
                throw new ApplicationException();

            }

            return current;
        }

        /// <summary>
        /// Validates that the elements added to the list are not null.
        /// </summary>
        /// <param name="element">The element to validate.</param>
        /// <exception cref="ArgumentNullException">Thrown if the provided element is null.</exception>
        private void ThrowNullElement(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Validates the given position.
        /// </summary>
        /// <param name="position">The position to validate.</param>
        /// <param name="size">The current size of the list.</param>
        /// <exception cref="ApplicationException">Thrown if the position is larger than the size of the list, 0, or negative.</exception>
        private void ThrowInvalidPosition(int position, int size)
        {
            if (position > size || position <= 0)
            {
                throw new ApplicationException();
            }
        }

        /// <summary>
        /// Checks if the provided element is null and throws an ArgumentNullException if it is.
        /// </summary>
        /// <param name="element">The element to check for null.</param>
        /// <exception cref="ArgumentNullException">Thrown when the provided element is null.</exception>
        private void ThrowNotNull(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Checks if the linked list is empty and throws an ApplicationException if it is.
        /// </summary>
        /// <exception cref="ApplicationException">Thrown when the linked list is empty.</exception>
        private void ThrowEmptyList()
        {
            if (this.IsEmpty())
            {
                throw new ApplicationException("List is empty");
            }
        }
    }
}
