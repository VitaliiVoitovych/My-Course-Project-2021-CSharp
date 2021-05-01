using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Node(T data)
        {
            Data = data;
        }
    }
}
