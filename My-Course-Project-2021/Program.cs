using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Course_Project_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> L1 = new MyLinkedList<int>();
            MyLinkedList<int> L2 = new MyLinkedList<int>();
            L1.AddAtFront(2);
            L1.AddAtEnd(7);
            L1.AddAtFront(4);
            L1.Print();
            int[] array = L1.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("{0} {1}",i,array[i]);
            }
            L1.DeleteNode(4);
            L1.Print();
            L2.Clone(L1);
            L2.Print();
            MyLinkedList<int> L3 = L1 + L2;
            L3.Print();
            MyLinkedList<int>.Sort(L3);
            L3.Print();
            MyLinkedList<int> L4 = new MyLinkedList<int>(3, 6, 2, 4);
            foreach (var item in L4)
            {
                Console.Write("{0} ",item);
            }
            Console.WriteLine();
            MyStack<int> S1 = new MyStack<int>();
            S1.Push(6);
            S1.Push(3);
            S1.Print();
            MyStack<int> S2 = new MyStack<int>();
            S2.Clone(S1);
            S2.Print();
            MyStack<int> S3 = S1 + S2;
            S3.Print();
            MyStack<int>.Sort(S3);
            S3.Print();
            MyQueue<int> Q1 = new MyQueue<int>();
            Q1.Enqueue(3);
            Q1.Enqueue(2);
            Q1.Print();
            MyQueue<int> Q2 = new MyQueue<int>();
            Q2.Clone(Q1);
            Q2.Print();
            MyQueue<int> Q3 = Q1 + Q2;
            Q3.Print();
            MyQueue<int>.Sort(Q3);
            Q3.Print();
            int[] arr = Enumerable.Range(1, 5).ToArray();
            MyLinkedList<int> list = (MyLinkedList<int>)arr;
            MyLinkedList<int> l = new MyLinkedList<int>(3, 4, 7, 2);
            MyStack<int> s = (MyStack<int>)1;
            s.Print();
            MyQueue<int> q = new MyQueue<int>();
            try
            {
                q.Dequeue();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
