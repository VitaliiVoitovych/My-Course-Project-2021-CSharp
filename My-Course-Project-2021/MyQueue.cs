using System;
using System.Collections;

namespace My_Course_Project_2021
{
    class MyQueue<T> : IEnumerable
    {
        public Node<T> Front { get; private set; } = null;
        public Node<T> Back { get; private set; } = null;
        public T this[int index]
        {
            get
            {
                Node<T> ptr = Front;
                while (ptr != null)
                {
                    if (index == IndexOf(ptr.Data))
                        return ptr.Data;
                    ptr = ptr.Next;
                }
                throw new ArgumentOutOfRangeException("Error");
            }
        }
        public MyQueue() { }
        public MyQueue(T element) => Enqueue(element);
        public MyQueue(params T[] elements)
        {
            foreach (T item in elements)
                Enqueue(item);
        }
        public void Enqueue(T element)
        {
            Node<T> n = new Node<T>(element);
            if(Back == null)
            {
                Front = Back = n;
            }
            else
            {
                Back.Next = n;
                Back = n;
            }
        }
        public void Dequeue()
        {
            if (Front == null)
                throw new NullReferenceException("Queue empty");
            Front = Front.Next;
            if (Front == null)
                Back = null;
        }
        public bool IsEmpty()
        {
            if (Front == null)
                return true;
            return false;
        }
        public void Clear() => Front = Back = null;
        public void Clone(MyQueue<T> Q)
        {
            Node<T> ptr = Q.Front;
            while (ptr != null)
            {
                Enqueue(ptr.Data);
                ptr = ptr.Next;
            }
        }
        public T Peek()
        {
            if (!IsEmpty())
                return Front.Data;
            else
                throw new NullReferenceException("Queue empty!");
        }
        /// <summary>
        /// Визначення індексу елемента
        /// </summary>
        /// <param name="element">Елемент, індекс якого визначаємо</param>
        /// <returns>Індекс</returns>
        public int IndexOf(T element)
        {
            int index = 0;
            Node<T> ptr = Front;
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
            Node<T> ptr = Front;
            while (ptr != null)
            {
                Console.Write("{0} <- ", ptr.Data);
                ptr = ptr.Next;
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Метод "Sort" базується на алгоритмі сортування бульбашкою
        /// </summary>
        /// <param name="Q">Черга яка сортується</param>
        public static void Sort<V>(MyQueue<V> Q) where V : IComparable<V>
        {
            Node<V> ptr1 = Q.Front;
            Node<V> ptr2;
            while (ptr1 != null)
            {
                ptr2 = Q.Front;
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
        public static MyQueue<T> operator+(MyQueue<T> Q1, MyQueue<T> Q2)
        {
            MyQueue<T> tmp = new MyQueue<T>();
            tmp.Clone(Q1);
            Node<T> ptr = tmp.Front;
            while (ptr.Next != null)
                ptr = ptr.Next;
            ptr.Next = Q2.Front;
            return tmp;
        }
        /// <summary>
        /// Реалізація інтерфейсу IEnumerable, для ітерації в циклі foreach
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            Node<T> current = Front;
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
        public static explicit operator MyQueue<T>(MyLinkedList<T> L)
        {
            MyQueue<T> Q = new MyQueue<T>();
            foreach (T item in L)
                Q.Enqueue(item);
            return Q;
        }
    }
}
