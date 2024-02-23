namespace TestLibrary
{
    public class Stack<T>
    {
        public Node<T>? Head { get; set; }
        public int Size { get; set; }

        public Stack()
        {
            this.Clear();
        }

        public void Push(T element)
        {
            Node<T> newNode = new Node<T>(element);

            this.Head = newNode;
            this.Head.Next = null;
        }

        public T? Top()
        {
            return this.Head.Element;
        }

        public T? Pop()
        {
            T oldElement = this.Head.Element;

            this.Head = this.Head.Next;

            return oldElement;
        }

        public void Clear()
        {
            this.Head = null;
            this.Head.Next = null;
            this.Size = 0;
        }

        public bool IsEmpty()
        {
            return this.Size == 0 ? true : false;
        }
    }
}

