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
        public LinkedList(T element) => AddAtEnd(element);
        public LinkedList(params T[] elements)
        {
            foreach (T item in elements)
                AddAtEnd(item);
        }
        public bool IsEmpty()
        {
            if (Head == null)
                return true;
            return false;
        }
        public void Clear() => Head = null;
        public void Clone(LinkedList<T> L)
        {
            Node<T> ptr = L.Head;
            while (ptr != null)
            {
                AddAtEnd(ptr.Data);
                ptr = ptr.Next;
            }
        }
        public void AddAtFront(T element)
        {
            Node<T> n = new Node<T>(element){ Next = Head };
            Head = n;
        }
        public void AddAtEnd(T element)
        {
            Node<T> n = new Node<T>(element);
            if (Head == null)
            {
                Head = n;
            }
            else
            {
                Node<T> ptr = GetLastNode();
                ptr.Next = n;
            }
        }
        public Node<T> GetLastNode()
        {
            Node<T> ptr = Head;
            while (ptr.Next != null)
                ptr = ptr.Next;
            return ptr;
        }
        public Node<T> Search(T element)
        {
            Node<T> ptr = Head;
            while (ptr != null && !ptr.Data.Equals(element))
                ptr = ptr.Next;
            return ptr;
        }
        public Node<T> DeleteNode(T element)
        {
            Node<T> n = Search(element);
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
        public static LinkedList<T> operator+(LinkedList<T> L1, LinkedList<T> L2)
        {
            LinkedList<T> tmp = new LinkedList<T>();
            tmp.Clone(L1);
            Node<T> ptr = tmp.GetLastNode();
            ptr.Next = L2.Head;
            return tmp;
        }
    }
}
