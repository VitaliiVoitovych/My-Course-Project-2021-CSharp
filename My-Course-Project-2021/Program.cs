using System;
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
            LinkedList<int> L1 = new LinkedList<int>();
            LinkedList<int> L2 = new LinkedList<int>();
            L1.AddAtFront(2);
            L1.AddAtEnd(7);
            L1.AddAtFront(4);
            L1.Print();
            L1.DeleteNode(4);
            L1.Print();
            L2.Clone(L1);
            L2.Print();
            LinkedList<int> L3 = L1 + L2;
            L3.Print();
            LinkedList<int>.Sort(L3);
            L3.Print();
            LinkedList<int> L4 = new LinkedList<int>(3, 6, 2, 4);
            foreach (var item in L4)
            {
                Console.Write("{0} ",item);
            }
            Console.WriteLine();
            Stack<int> S1 = new Stack<int>();
            S1.Push(6);
            S1.Push(3);
            S1.Print();
            Stack<int> S2 = new Stack<int>();
            S2.Clone(S1);
            S2.Print();
            Stack<int> S3 = S1 + S2;
            S3.Print();
            Stack<int>.Sort(S3);
            S3.Print();
            Queue<int> Q1 = new Queue<int>();
            Q1.Enqueue(3);
            Q1.Enqueue(2);
            Q1.Print();
            Queue<int> Q2 = new Queue<int>();
            Q2.Clone(Q1);
            Q2.Print();
            Queue<int> Q3 = Q1 + Q2;
            Q3.Print();
            Queue<int>.Sort(Q3);
            Q3.Print();
            Console.ReadLine();
        }
    }
}
