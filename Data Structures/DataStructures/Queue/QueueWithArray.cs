using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.DataStructures.Queue
{
    public class QueueWithArray<T>
    {
        private int front;
        private int back;
        private int count;
        private T[] array;

        public QueueWithArray(int size)
        {
            if (size < 0)
                size *= size;

            front = 0;
            back = size - 1;
            count = 0;
            array = new T[size];
        }

        // Check of queue is empty
        public bool isEmpty() => count == 0;

        // Check of queue is full
        public bool isFull() => count == array.Length;

        // Add a new item to queue
        public void Add(T item)
        {
            if (isFull())
                throw new Exception("Q is full!");
            
            back = (back + 1) % array.Length;
            array[back] = item;
            count++;
        }

        // delete item from queue
        public void Remove()
        {
            if (isEmpty())
                throw new Exception("Q is empty");

            front = (front + 1) % array.Length;
            count--;
        }

        // Print all items in this queue
        public void Print()
        {
            if (isEmpty())
                throw new Exception("Q is empty");

            int pointr = front;

            Console.Write("{ ");
            while (pointr != back + 1)
            {
                Console.Write(array[pointr] + " ");
                pointr = (pointr + 1) % array.Length;
            }
            Console.WriteLine("}");
        }

        // Get front queue
        public T GetFront()
        {
            if (isEmpty())
                throw new Exception("Q is empty");

            return array[front];
        }

        // Get back queue
        public T GetBack()
        {
            if (isEmpty())
                throw new Exception("Q is empty");

            return array[back];
        }

        public int GetSize() => count;
        
        public void Clear()
        {
            front = 0;
            back = array.Length - 1;

            count = 0;
        }
    }
}
