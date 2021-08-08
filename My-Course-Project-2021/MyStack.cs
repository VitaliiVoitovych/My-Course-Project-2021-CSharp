using System;
using System.Collections;
using System.Collections.Generic;

namespace My_Course_Project_2021
{
    /// <summary>
    /// Стек
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyStack<T> : IEnumerable, IEnumerable<T>
    {
        /// <summary>
        /// Вверх стеку
        /// </summary>
        public Node<T> Top { get; private set; } = null;
        /// <summary>
        /// Повертає значення по указаному індексу
        /// </summary>
        /// <param name="index">Індекс</param>
        /// <returns>Значення вузла</returns>
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
        /// <summary>
        /// Перевіряє чи стек пустий
        /// </summary>
        /// <returns>Булеве значення</returns>
        public bool IsEmpty()
        {
            if (Top == null)
                return true;
            return false;
        }
        /// <summary>
        /// Додає елемент в верхню частину стеку
        /// </summary>
        /// <param name="element">Елемент який додається</param>
        public void Push(T element)
        {
            Node<T> n = new Node<T>(element) { Next = Top};
            Top = n;
        }
        /// <summary>
        /// Видаляє верхній елемент стеку
        /// </summary>
        public void Pop()
        {
            if (!IsEmpty())
            {
                Top = Top.Next;
            }
            else
                Console.WriteLine("Stack empty");
        }
        /// <summary>
        /// Очищує стек
        /// </summary>
        public void Clear() => Top = null;
        /// <summary>
        /// Клонує елементи
        /// </summary>
        /// <param name="S">Стек з якого клонуємо</param>
        public void Clone(MyStack<T> S)
        {
            Node<T> ptr = S.Top;
            while(ptr != null)
            {
                Push(ptr.Data);
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
                return Top.Data;
            else
                throw new NullReferenceException("Stack empty");
        }
        /// <summary>
        /// Визначає індекс елемента
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
        /// <summary>
        /// Виводить стек
        /// </summary>
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
        /// Сортує стек, методом бульбашки
        /// </summary>
        /// <param name="S">Стек який сортується</param>
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
        /// Операція явного перетворення. Наприклад:"(int)a"
        /// </summary>
        /// <param name="array">Масив який перетворюєм</param>
        public static explicit operator MyStack<T>(T[] array)
        {
            MyStack<T> S = new MyStack<T>();
            foreach (T item in array)
                S.Push(item);
            return S;
        }
        /// <summary>
        /// Реалізація інтерфейсу IEnumerable<T>,IEnumerable для ітерації в стилі foreach
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Top;
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