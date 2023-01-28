using Data_Structures.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.DataStructures.Queue
{
    public class QueueWithLinkedList<T>
    {
        public int size { get; private set; }
        private Node<T> front; 
        private Node<T> back;

        public QueueWithLinkedList()
        {
            front = null;
            back = null;
            size = 0;
        }

        // Check of queue is empty
        public bool IsEmpty()
            => size is 0;
        
        // Add a new node to queue
        public void EnQueue(T item)
        {
            Node<T> node = new Node<T>(item, null);
            
            if (IsEmpty())
                front = back = node;
            
            else
                back.Next = node;

            back = node;
            size++;
        }

        // delete node from queue
        public T DeQueue()
        {
            if (IsEmpty())
                throw new Exception("Queue is empty");

            T value = front.Item;
            front = front.Next;
            size--;

            if (front is null)
                back = null;

            return value;
        }

        // Get back queue
        public T GetBack()
        {
            if (IsEmpty())
                throw new Exception("Queue is empty");

            return back.Item;
        }

        // Get front queue
        public T GetFront()
        {
            if (IsEmpty())
                throw new Exception("Queue is empty");

            return front.Item;
        }

        // Remove all nodes from this queue
        public void Clear()
        {
            front = null;
            back = null;
            size = 0;
        }

        // Print all items in this queue
        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            Node<T> temp = front;

            Console.Write("{ ");

            while (temp != null)
            {
                Console.Write(temp.Item + " ");
                temp = temp.Next;
            }
            
            Console.WriteLine("}");
        }
    }
}