using Data_Structures.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures.DataStructures.Linked_List
{
    public class DoublyLinkedList
    {
        public int Length { get; private set; }
        private DoublyNode<int> Head;
        private DoublyNode<int> End;

        public bool IsEmpty()
            => Length == 0;

        public void AddFirst(int element)
        {
            DoublyNode<int> node = new DoublyNode<int>(element, null, null);

            if (!IsEmpty())
            {
                node.Next = Head;
                Head.Prev = node;
                Head = node;
            }
            else
                Head = End = node;
            
            Length++;
        }

        public void AddLast(int element)
        {
            DoublyNode<int> node = new DoublyNode<int>(element, null, null);

            if (!IsEmpty())
            {
                node.Prev = End;
                End.Next = node;
                End = node;
            }
            else
                Head = End = node;

            Length++;
        }

        public void AddAtPos(int pos, int element)
        {
            if (pos < 0 || pos > Length)
            {
                Console.WriteLine("Out of range");
                return;
            }

            if (pos == 0)
                AddFirst(element);
            else if (pos == Length)
                AddLast(element);
            else
            {
                DoublyNode<int> curr = Head.Next;
                DoublyNode<int> node = new DoublyNode<int>(element, null, null);

                for (int i = 1; i < Length - 1; i++)
                {
                    if (i == pos)
                        break;

                    curr = curr.Next;   
                }

                node.Prev = curr.Prev;
                curr.Prev.Next = node;
                node.Next = curr;
                curr.Prev = node;
            }
        }

        public void removeFirst()
        {
            if (IsEmpty())
            {
                Console.WriteLine("linked List is empty");
                return;
            }

            Head = Head.Next;
            Head.Prev = null;
            Length--;
        }

        public void removeLast()
        {
            if (IsEmpty())
            {
                Console.WriteLine("linked List is empty");
                return;
            }

            End = End.Prev;
            End.Next = null;
            Length--;
        }

        public void removeAtPos(int pos)
        {
            if (IsEmpty())
            {
                Console.WriteLine("linked List is empty");
                return;
            }

            if (pos < 0 || pos >= Length)
            {
                Console.WriteLine("Out of range");
                return;
            }

            if (pos == 0)
                removeFirst();
            else if (pos == Length - 1)
                removeLast();
            else
            {
                DoublyNode<int> curr = Head.Next;

                for (int i = 1; i < Length - 1 && i != pos; i++)
                    curr = curr.Next;

                curr.Next.Prev = curr.Prev;
                curr.Prev.Next = curr.Next;
                Length--;
            }
        }

        public void removeElement(int element)
        {
            if (IsEmpty())
            {
                Console.WriteLine("linked List is empty");
                return;
            }

            DoublyNode<int> curr = Head;

            int count = Length;

            for (int i = 0; i < Length; i++)
            {
                if (curr.Item == element && curr == Head)
                    removeFirst();
                else if (curr.Item == element && curr == End)
                    removeLast();
                else if (element == curr.Item)
                {
                    curr.Next.Prev = curr.Prev;
                    curr.Prev.Next = curr.Next;
                    Length--;
                }

                curr = curr.Next;
            }

            if (Length == count)
                Console.WriteLine("This Element Is Not Found");
        }

        public void print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("linked List is empty");
                return;
            }

            DoublyNode<int> curr = Head;

            Console.Write("{ ");

            while(curr != null)
            {
                Console.Write(curr.Item + " ");
                curr = curr.Next;
            }

            Console.WriteLine("}");
        }

        public void printReverse()
        {
            if (IsEmpty())
            {
                Console.WriteLine("linked List is empty");
                return;
            }

            DoublyNode<int> curr = End;

            Console.Write("{ ");

            while (curr != null)
            {
                Console.Write(curr.Item + " ");
                curr = curr.Prev;
            }

            Console.WriteLine("}");
        }
    }
}