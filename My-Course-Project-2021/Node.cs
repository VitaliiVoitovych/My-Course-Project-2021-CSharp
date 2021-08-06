using System;

namespace My_Course_Project_2021
{
    class Node<T>
    {
        private T data = default(T);
        public T Data
        {
            get => data;
            set
            {
                if (value != null)
                    data = value;
                else
                    throw new ArgumentNullException(nameof(value));
            }
        }
        public Node<T> Next { get; set; } = null;
        public Node(T data) => Data = data;
        public static void Swap<V>(Node<V> n1, Node<V> n2)
        {
            V temp = n1.Data;
            n1.Data = n2.Data;
            n2.Data = temp;
        }
    }
}
