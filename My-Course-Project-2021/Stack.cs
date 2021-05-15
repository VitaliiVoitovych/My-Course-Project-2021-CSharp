using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Course_Project_2021
{
    class Stack<T> : IEnumerable
    {
        public Node<T> Top { get; private set; } = null;
        public Stack() { }
        public Stack(T element) => Push(element);
        public Stack(params T[] elements)
        {
            foreach (T item in elements)
                Push(item);
        }
        public bool IsEmpty()
        {
            if (Top == null)
                return true;
            return false;
        }
        public void Push(T element)
        {
            Node<T> n = new Node<T>(element) { Next = Top};
            Top = n;
        }
        public void Pop()
        {
            if (!IsEmpty())
            {
                Node<T> n = Top;
                Top = Top.Next;
            }
            else
                Console.WriteLine("Stack empty");
        }
        public void Clear() => Top = null;
        public void Clone(Stack<T> S)
        {
            Node<T> ptr = S.Top;
            while(ptr != null)
            {
                Push(ptr.Data);
                ptr = ptr.Next;
            }
        }
        public T Peek()
        {
            if (!IsEmpty())
                return Top.Data;
            else
                throw new NullReferenceException("Stack empty");
        }
        public void Print()
        {
            Node<T> ptr = Top;
            while (ptr != null)
            {
                Console.WriteLine("| {0} |", ptr.Data);
                ptr = ptr.Next;
            }
            Console.WriteLine();
        }
        public static void Sort<V>(Stack<V> L) where V : IComparable<V>
        {
            Node<V> ptr1 = L.Top;
            Node<V> ptr2;
            while (ptr1 != null)
            {
                ptr2 = L.Top;
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
        public static Stack<T> operator+(Stack<T> S1, Stack<T> S2)
        {
            Stack<T> tmp = new Stack<T>();
            tmp.Clone(S2);
            Node<T> ptr = tmp.Top;
            while (ptr.Next != null)
                ptr = ptr.Next;
            ptr.Next = S1.Top;
            return tmp;
        }
        public IEnumerator GetEnumerator()
        {
            Node<T> current = Top;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
