using System;
using System.Collections;

namespace My_Course_Project_2021
{
    class MyStack<T> : IEnumerable
    {
        public Node<T> Top { get; private set; } = null;
        public T this[int index]
        {
            get
            {
                Node<T> ptr = Top;
                while (ptr != null)
                {
                    if (index == IndexOf(ptr.Data))
                        return ptr.Data;
                    ptr = ptr.Next;
                }
                throw new ArgumentOutOfRangeException("Error");
            }
        }
        public MyStack() { }
        public MyStack(T element) => Push(element);
        public MyStack(params T[] elements)
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
                Top = Top.Next;
            }
            else
                Console.WriteLine("Stack empty");
        }
        public void Clear() => Top = null;
        public void Clone(MyStack<T> S)
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
        /// <summary>
        /// Визначення індексу елемента
        /// </summary>
        /// <param name="element">Елемент, індекс якого визначаємо</param>
        /// <returns>Індекс</returns>
        public int IndexOf(T element)
        {
            int index = 0;
            Node<T> ptr = Top;
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
        /// <summary>
        /// Метод "Sort" базується на алгоритмі сортування бульбашкою
        /// </summary>
        /// <param name="S">Стек який сортуєм</param>
        public static void Sort<V>(MyStack<V> S) where V : IComparable<V>
        {
            Node<V> ptr1 = S.Top;
            Node<V> ptr2;
            while (ptr1 != null)
            {
                ptr2 = S.Top;
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
        public static MyStack<T> operator+(MyStack<T> S1, MyStack<T> S2)
        {
            MyStack<T> tmp = new MyStack<T>();
            tmp.Clone(S2);
            Node<T> ptr = tmp.Top;
            while (ptr.Next != null)
                ptr = ptr.Next;
            ptr.Next = S1.Top;
            return tmp;
        }
        /// <summary>
        /// Реалізація інтерфейсу IEnumerable, для ітерації в стилі foreach
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            Node<T> current = Top;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        /// <summary>
        /// Операція явного перетворення. Наприклад:"(int)a"
        /// </summary>
        /// <param name="L">Список який перетворюєм</param>
        public static explicit operator MyStack<T>(MyLinkedList<T> L)
        {
            MyStack<T> S = new MyStack<T>();
            foreach (T item in L)
                S.Push(item);
            return S;
        }
    }
}
