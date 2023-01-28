using Data_Structures.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.DataStructures.Linked_List
{
    public class MyLinkedList
    {
        public int Length { get; private set; }
        private Node<int> Head;
        private Node<int> End;

        public bool IsEmpty()
            => Length == 0;

        public void AddFirst(int item)
        {
            Node<int> node = new Node<int>(item, Head);
            Head = node;    

            if (IsEmpty())
                End = node;
            
            Length++;
        }

        public void AddLast(int item)
        {
            Node<int> node = new Node<int>(item, null);
            
            if (IsEmpty())
                End = Head = node;
            else
            {
                End.Next = node;
                End = node; 
            }

            Length++;
        }

        public void AddAtPos(int pos, int item)
        {
            if (pos < 0 || pos >= Length)
            {
                Console.WriteLine("Out of range");
                return;
            }

            if (pos == 0)
            {
                AddFirst(item);
                return;
            }
            
            if (pos == Length - 1)
            {
                AddLast(item);
                return;
            }

            Node<int> cur = Head;
           
            for (int i = 0; i < pos; i++)
                cur = cur.Next;

            Node<int> node = new Node<int>(item, cur.Next);
            cur.Next = node;
        }

        public void removeFirst()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Linked List is empty");
                return;
            }

            if (Length == 1)
            {
                Head = End = null;
                Length--;
                return;
            }

            Head = Head.Next;
            Length--;
        }

        public void removeLast()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Linked List is empty");
                return;
            }

            if (Length == 1)
            {
                Head = End = null;
                Length--;
                return;
            }

            Node<int> curr = Head;

            while (curr.Next != End)
                curr = curr.Next;

            curr.Next = null;
            End = curr;
        }

        public void removeByElement(int element)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Linked List is empty");
                return;
            }

            if (Head.Item == element)
                removeFirst();
            else if (End.Item == element)
                removeLast();
            else
            {
                Node<int> curr = Head;

                while (curr.Next != End)
                {
                    if (curr.Next.Item == element)
                    {
                        curr.Next = curr.Next.Next;
                        Length--;
                    }
                    else
                        curr = curr.Next;
                }
            }
        }

        public void removeAtPos(int pos)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Linked List is empty");
                return;
            }

            if (pos == 0)
                removeFirst();
            else if (pos == Length - 1)
                removeLast();
            else
            {
                Node<int> curr = Head;

                for (int i = 0; i < pos - 1; i++)
                    curr = curr.Next;

                curr.Next = curr.Next.Next;
                Length--;
            }
        }

        public void Reverse()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Linked List is empty");
                return;
            }

            Node<int> curr = Head;
            Node<int> prev = null;  
            Node<int> next = Head.Next;
            
            while (curr != null)
            {
                curr.Next = prev;
                prev = curr;
                curr = next;
                if (next != null)
                    next = next.Next;
            }

            End = Head;
            Head = prev;
        }

        public int Search(int element)
        {
            if (IsEmpty())
                throw new Exception("Linked list is empty");

            Node<int> curr = Head;
            int index = 0;

            while (curr != null)
            {
                if (curr.Item == element)
                    return index;

                curr = curr.Next;
                index++;
            }

            throw new Exception();
        }

        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Linked List is empty");
                return;
            }

            Node<int> cur = Head;

            Console.Write("{ ");

            while (cur != null)
            {
                Console.Write(cur.Item + " ");
                cur = cur.Next;
            }

            Console.WriteLine("}");
        }
    }
}