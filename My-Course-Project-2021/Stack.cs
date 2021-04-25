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
        public void Push(Node<T> n)
        {
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
        public void Clear()
        {
            Top = null;
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
                Console.WriteLine(ptr.Data);
                ptr = ptr.Next;
            }
            Console.WriteLine();
        }
    }
}
