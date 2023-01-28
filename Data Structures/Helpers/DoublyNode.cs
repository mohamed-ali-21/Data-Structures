using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.Helpers
{
    public class DoublyNode<T>
    {
        public T Item { get; set; }  
        public DoublyNode<T> Prev { get; set; }
        public DoublyNode<T> Next { get; set; }

        public DoublyNode(T item, DoublyNode<T> next, DoublyNode<T> prev)
        {
            Item = item;
            Prev = prev;
            Next = next;
        }
    }
}
