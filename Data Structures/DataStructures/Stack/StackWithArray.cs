using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Data_Structures.DataStructures
{
    public class StackWithArray<T>
    {
        private readonly int _maxSize;
        private T[] array;
        private int top;

        public StackWithArray(int MaxSize)
        {
            array = new T[MaxSize];
            _maxSize = MaxSize;
            top = -1;
        }

        public bool IsFull()
            => top >= _maxSize - 1;

        public bool IsEmpty()
            => top < 0;

        public void Push(T entity)
        {
            if(IsFull())
                Console.WriteLine("Stack Is Full.");
            else
            {
                top++;
                array[top] = entity; 
            }
        }

        public void Pop()
        {
            if(IsEmpty())
                Console.WriteLine("Stack Is Empty.");
            else
                top--;
        }

        public T GetTop()
        {
            if(IsEmpty())
                throw new Exception("Stack Is Empty.");

            return array[top];
        }

        public void Print()
        {
            if(IsEmpty())
                throw new Exception("Stack Is Empty");

            Console.Write("{ ");
           
            for(int i = top; i >= 0; i--)
            {
                if(i == 0)
                    Console.Write(array[i]);
                else
                    Console.Write(array[i] + ", ");

            }

            Console.WriteLine(" }");
        }
    }
}