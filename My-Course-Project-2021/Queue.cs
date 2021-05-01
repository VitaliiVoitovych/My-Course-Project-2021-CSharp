using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Course_Project_2021
{
    class Queue<T>
    {
        public Node<T> Front { get; private set; } = null;
        public Node<T> Back { get; private set; } = null;
        public Queue() { }
        public Queue(T element) => Enqueue(element);
        public Queue(params T[] elements)
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
            Node<T> n = Front;
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
        public void Clone(Queue<T> Q)
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
                throw new NullReferenceException("Empty Queue");
        }
        public void Print()
        {
            Node<T> ptr = Front;
            while (ptr != null)
            {
                Console.Write("{0} -> ", ptr.Data);
                ptr = ptr.Next;
            }
            Console.WriteLine();
        }
        public static Queue<T> operator+(Queue<T> Q1, Queue<T> Q2)
        {
            Queue<T> tmp = new Queue<T>();
            tmp.Clone(Q1);
            Node<T> ptr = tmp.Front;
            while (ptr.Next != null)
                ptr = ptr.Next;
            ptr.Next = Q2.Front;
            return tmp;
        }
    }
}
