using System;

namespace Assignment_14
{
    class Node
    {
        public int Data;
        public Node Next;
    }

    class Stack
    {
        private Node top = null;
        public void Push(int data)
        {
            Node newNode = new Node();
            newNode.Data = data;
            newNode.Next = top;
            top = newNode;
            Console.WriteLine($"Pushed: {data}");
        }

        public void Pop()
        {
            if(top == null )
            {
                Console.WriteLine("No element to pop(Underflow)");
                return;
            }

            Console.WriteLine($"Popped : {top.Data}");
            top = top.Next;
        }

        public void Top()
        {
            if(top == null )
            {
                Console.WriteLine("Stack is Empty");
            }
            else
            {
                Console.WriteLine($"Top element : {top.Data}");
            }
        }

        public void Display()
        {
            if (top == null)
            {
                Console.WriteLine("Stack is Empty");
                return;
            }
            Console.WriteLine("Stack Elements");
            Node current = top;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
    internal class linkedlists
    {
        static void Main(string[] args)
        {
            Stack myStack = new Stack();

            string choice = "y";
            while (choice.ToLower() == "y")
            {
                Console.WriteLine("\n1.Push\n2.Pop\n3.top\n4.Display\nEnter your choice :");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter value to push :");
                            int val = Convert.ToInt32(Console.ReadLine());
                            myStack.Push(val);
                            break;
                        }
                    case 2:
                        {
                            myStack.Pop();
                            break;
                        }
                    case 3:
                        {
                            myStack.Top();
                            break;
                        }
                    case 4:
                        {
                            myStack.Display();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice");
                            break;
                        }
                        Console.WriteLine("Do you want no Continue(y/n):");
                        choice = Console.ReadLine();
                }
            }
        }
    }
}
