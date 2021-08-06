using System;
using System.Collections;

namespace My_Course_Project_2021
{
    class MyLinkedList<T> : IEnumerable
    {
        public Node<T> Head { get; private set; } = null;
        public T this[int index]
        {
            get
            {
                Node<T> ptr = Head;
                while (ptr != null)
                {
                    if (index == IndexOf(ptr.Data))
                        return ptr.Data;
                    ptr = ptr.Next;
                }
                throw new ArgumentOutOfRangeException("Error");
            }
        }
        public MyLinkedList() { }
        public MyLinkedList(T element) => AddAtEnd(element);
        public MyLinkedList(params T[] elements)
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
        public void Clone(MyLinkedList<T> L)
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
        public int IndexOf(T element)
        {
            int index = 0;
            Node<T> ptr = Head;
            while (ptr != null)
            {
                if (ptr.Data.Equals(element))
                    return index;
                else
                    index++;
                ptr = ptr.Next;
            }
            return -1;
        }
        public Node<T> DeleteNode(T element)
        {
            Node<T> n = Search(element);
            Node<T> ptr = Head;
            if (IsEmpty())
            {
                throw new NullReferenceException("Linked list empty!");
            }
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
        /// <summary>
        /// Метод "Sort" базується на алгоритмі сортування бульбашкою
        /// </summary>
        /// <param name="L">Список який сортується</param>
        public static void Sort<V>(MyLinkedList<V> L) where V : IComparable<V>
        {
            Node<V> ptr1 = L.Head;
            Node<V> ptr2;
            while (ptr1 != null)
            {
                ptr2 = L.Head;
                while (ptr2.Next != null)
                {
                    if (ptr2.Data.CompareTo(ptr2.Next.Data) > 0)
                    {
                        var tmp = ptr2.Next;
                        Node<T>.Swap(ptr2, tmp);
                    }
                    ptr2 = ptr2.Next;
                }
                ptr1 = ptr1.Next;
            }
        }
        public static MyLinkedList<T> operator+(MyLinkedList<T> L1, MyLinkedList<T> L2)
        {
            MyLinkedList<T> tmp = new MyLinkedList<T>();
            tmp.Clone(L1);
            Node<T> ptr = tmp.GetLastNode();
            ptr.Next = L2.Head;
            return tmp;
        }
        /// <summary>
        /// Реалізація інтерфейсу IEnumerable, для ітерації в стилі foreach
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
