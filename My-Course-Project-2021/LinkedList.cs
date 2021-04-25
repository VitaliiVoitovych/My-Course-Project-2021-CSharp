using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Course_Project_2021
{
    class LinkedList<T>
    {
        public Node<T> Head { get; private set; } = null;
        public LinkedList() { }
        public bool IsEmpty()
        {
            if (Head == null)
                return true;
            return false;
        }
        public void Clear() => Head = null;
        public void AddAtFront(Node<T> n)
        {
            n.Next = Head;
            Head = n;
        }
        public void AddAtEnd(Node<T> n)
        {
            if (Head == null)
            {
                Head = n;
                n.Next = null;
            }
            else
            {
                Node<T> n2 = GetLastNode();
                n2.Next = n;
            }
        }
        public Node<T> GetLastNode()
        {
            Node<T> ptr = Head;
            while (ptr != null)
                ptr = ptr.Next;
            return ptr;
        }
        public Node<T> Search(T k)
        {
            Node<T> ptr = Head;
            while (ptr != null && !ptr.Data.Equals(k))
                ptr = ptr.Next;
            return ptr;
        }
        public Node<T> DeleteNode(T x)
        {
            Node<T> n = Search(x);
            Node<T> ptr = Head;
            if (IsEmpty())
                throw new NullReferenceException("Стек пуст");
            else if (ptr == n)
            {
                Head = n.Next;
                return n;
            }
            else
            {
                while (ptr.Next != n)
                    ptr = ptr.Next;
                ptr.Next = n.Next;
                return n;
            }
        }
        public void Print()
        {
            Node<T> ptr = Head;

            while (ptr != null)
            {
                Console.Write("{0} -> ", ptr.Data);
                ptr = ptr.Next;
            }
            Console.WriteLine();
        }
        public override string ToString()
        {
            int counter = 0;
            Node<T> ptr = Head;
            while (ptr != null)
            {
                ptr = ptr.Next;
                counter++;
            }
            return $"Linked List have {counter} elements";
        }
    }
}
