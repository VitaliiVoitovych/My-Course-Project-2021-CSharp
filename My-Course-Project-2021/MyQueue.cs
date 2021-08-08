using System;
using System.Collections;
using System.Collections.Generic;

namespace My_Course_Project_2021
{
    /// <summary>
    /// Черга
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyQueue<T> : IEnumerable, IEnumerable<T>
    {
        /// <summary>
        /// Перший елемент черги
        /// </summary>
        public Node<T> Front { get; private set; } = null;
        /// <summary>
        /// Останній елемент черги
        /// </summary>
        public Node<T> Back { get; private set; } = null;
        /// <summary>
        /// Повертає значення по указаному індексу
        /// </summary>
        /// <param name="index">Індекс</param>
        /// <returns>Значення вузла</returns>
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
        /// <summary>
        /// Додає елемент в кінець черги
        /// </summary>
        /// <param name="element"></param>
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
        /// <summary>
        /// Видаляє перший елемент з черги
        /// </summary>
        public void Dequeue()
        {
            if (Front == null)
                throw new NullReferenceException("Queue empty");
            Front = Front.Next;
            if (Front == null)
                Back = null;
        }
        /// <summary>
        /// Перевіряє чи список пустий
        /// </summary>
        /// <returns>Булеве значення</returns>
        public bool IsEmpty()
        {
            if (Front == null)
                return true;
            return false;
        }
        /// <summary>
        /// Очищує чергу
        /// </summary>
        public void Clear() => Front = Back = null;
        /// <summary>
        /// Клонує елементи з іншої черги
        /// </summary>
        /// <param name="Q"></param>
        public void Clone(MyQueue<T> Q)
        {
            Node<T> ptr = Q.Front;
            while (ptr != null)
            {
                Enqueue(ptr.Data);
                ptr = ptr.Next;
            }
        }
        /// <summary>
        /// Повертає значення з верхньої частини стеку
        /// </summary>
        /// <returns>Значення верхнього елементу</returns>
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
       /// <summary>
       /// Виводить чергу
       /// </summary>
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
        /// Сортує черг, методом бульбашки
        /// </summary>
        /// <param name="Q">Черга який сортується</param>
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
        /// Операція явного перетворення. Наприклад:"(int)a"
        /// </summary>
        /// <param name="array">Масив який перетворюєм</param>
        public static explicit operator MyQueue<T>(T[] array)
        {
            MyQueue<T> Q = new MyQueue<T>();
            foreach (T item in array)
                Q.Enqueue(item);
            return Q;
        }
        /// <summary>
        /// Реалізація інтерфейсу IEnumerable<T>,IEnumerable для ітерації в стилі foreach
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Front;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}