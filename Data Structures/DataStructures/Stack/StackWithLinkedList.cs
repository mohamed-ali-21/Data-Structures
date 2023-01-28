using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Data_Structures.Helpers;

namespace Data_Structures.DataStructures
{
    public class StackWithLinkedList<T>
    {
        private Node<T> top;

        public void push(T newItem)
        {
            Node<T> newNode = new Node<T>(newItem, top);
            top = newNode;
        }

        public bool isEmpty()
            => top == null;

        public void pop()
        {
            if (isEmpty())
                throw new Exception("Stack is empty.");
            
            top = top.Next;
        }

        public T getTop()
        {
            if (isEmpty())
                throw new Exception("Stack is empty.");

            return top.Item;
        }

        public void print()
        {
            if (isEmpty())
                throw new Exception("Stack is empty.");

            Node<T> display = top;

            Console.Write("{ ");
            
            while(display != null)
            {
                Console.Write(display.Item + " ");
                display = display.Next;
            }

            Console.WriteLine("}");
        }

    }
}