using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.DataStructures.ListArray
{
    public class ListArray
    {
        public int Length { get; private set; }
        private int[] array;

        public ListArray(int size)
        {
            if (size < 0)
                size = 0;

            Length = 0;
            array = new int[size];
        }

        public bool IsFull() 
            => Length == array.Length;

        public bool IsEmpty()
            => Length == 0; 

        public void Add(int item)
        {
            if (IsFull())
            {
                Console.WriteLine("Array is full");
                return;
            }
            
            array[Length] = item;
            Length++;
        }

        public void AddAt(int item, int index)
        {
            if (IsFull())
            {
                Console.WriteLine("Array is full");
                return;
            }

            if (index >= array.Length)
            {
                Console.WriteLine("Out of range");
                return;
            }

            for (int i = Length; i > index; i--)
                array[i] = array[i - 1];
            
            array[index] = item;
            Length++;
        }

        public void Remove(int pos)
        {
            for (int i = pos; i < Length - 1; i++)
                array[i] = array[i + 1];

            array[Length - 1] = 0;
            Length--;

            Console.WriteLine("Done.");
        }

        public int? FindItem(int pos)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Array is empty");
                return null;
            }

            if (pos < 0 || pos >= Length)
            {
                Console.WriteLine("Out of range");
                return null;
            }

            return array[pos];
        }

        public void UpDateAt(int pos, int newItem)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Array is empty");
                return;
            }

            if (pos >= Length)
            {
                Console.WriteLine("Out of range");
                return;
            }

            array[pos] = newItem;
            Console.WriteLine("Done");
        }

        public void AddNotDuplicate(int item)
        {
            if (IsFull())
            {
                Console.WriteLine("Array is full");
                return;
            }

            for (int i = 0; i < Length; i++)
            {
                if (array[i] == item)
                {
                    Console.WriteLine("Item already exists");
                    return;
                }
            }

            array[Length] = item;
            Length++;
        }

        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Array is empty");
                return;
            }

            Console.Write("{ ");

            for (int i = 0; i < Length; i++)
                Console.Write(array[i] + " ");
            
            Console.WriteLine("}");
        }
    }
}