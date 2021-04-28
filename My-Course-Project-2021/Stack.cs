using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Course_Project_2021
{
    class Stack<T>
    {
        public Node<T> Top { get; private set; } = null;
        public Stack() { }
        public bool IsEmpty()
        {
            if (Top == null)
                return true;
            return false;
        }
        public void Push(T x)
        {
            Node<T> n = new Node<T>(x);
            n.Next = Top;
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
    }
}
