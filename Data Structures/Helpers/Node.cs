using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Structures.Helpers
{
    public class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }

        public Node(T item, Node<T> next)
        {
            Item = item;
            Next = next;
        }     
    }
}