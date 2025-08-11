using System;

namespace LinearDataStructureDemo
{
    // Node class
    class Node
    {
        public int Data;
        public Node Next;
    }

    // Queue class using Linked List
    class Queue
    {
        private Node front = null;
        private Node rear = null;

        // Insert (Enqueue): Add to the rear of the queue
        public void Insert(int data)
        {
            Node newNode = new Node();
            newNode.Data = data;
            newNode.Next = null;

            if (rear == null) // Queue is empty
            {
                front = rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }

            Console.WriteLine($"Inserted: {data}");
        }

        // Delete (Dequeue): Remove from the front of the queue
        public void Delete()
        {
            if (front == null)
            {
                Console.WriteLine("Queue Underflow! No element to delete.");
                return;
            }

            Console.WriteLine($"Deleted: {front.Data}");
            front = front.Next;

            if (front == null) // Queue is now empty
            {
                rear = null;
            }
        }

        // Display: Show all elements from front to rear
        public void Display()
        {
            if (front == null)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }

            Console.WriteLine("Queue elements:");
            Node current = front;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }

    // Main class
    class Program
    {
        static void Main()
        {
            Queue myQueue = new Queue();

            string choice = "y";
            while (choice.ToLower() == "y")
            {
                Console.WriteLine("\n1. Insert\n2. Delete\n3. Display\nEnter your choice:");
                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        Console.Write("Enter value to insert: ");
                        int val = int.Parse(Console.ReadLine());
                        myQueue.Insert(val);
                        break;

                    case 2:
                        myQueue.Delete();
                        break;

                    case 3:
                        myQueue.Display();
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.Write("Do you want to continue? (y/n): ");
                choice = Console.ReadLine();
            }
        }
    }
}
