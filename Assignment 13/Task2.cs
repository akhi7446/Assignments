using System;
using System.IO;

class Task2
{
    public static void Run()
    {
        string filePath = @"C:\Users\aakas\OneDrive\Desktop\cgi classes\Assignments\Assignment 13\myfile.txt";
        int choice;

        do
        {
            Console.WriteLine("\n--- File Menu ---");
            Console.WriteLine("1. Create a new file");
            Console.WriteLine("2. Add contents to the file");
            Console.WriteLine("3. Append contents to the file");
            Console.WriteLine("4. Display contents line by line");
            Console.WriteLine("5. Display all contents");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        if (File.Exists(filePath))
                        {
                            Console.WriteLine("File already exists.");
                        }
                        else
                        {
                            using (FileStream fs = File.Create(filePath))
                            {
                                Console.WriteLine("File created successfully.");
                            }
                        }
                        break;

                    case 2:
                        if (!File.Exists(filePath))
                            throw new FileNotFoundException();

                        Console.Write("Enter content to add: ");
                        string content = Console.ReadLine();
                        using (StreamWriter sw = new StreamWriter(filePath, false))
                        {
                            sw.WriteLine(content);
                        }
                        Console.WriteLine("Content written to file.");
                        break;

                    case 3:
                        if (!File.Exists(filePath))
                            throw new FileNotFoundException();

                        Console.Write("Enter content to append: ");
                        string append = Console.ReadLine();
                        using (StreamWriter sw = new StreamWriter(filePath, true))
                        {
                            sw.WriteLine(append);
                        }
                        Console.WriteLine("Content appended.");
                        break;

                    case 4:
                        if (!File.Exists(filePath))
                            throw new FileNotFoundException();

                        using (StreamReader sr = new StreamReader(filePath))
                        {
                            string line;
                            Console.WriteLine("\nContents line by line:");
                            while ((line = sr.ReadLine()) != null)
                                Console.WriteLine(line);
                        }
                        break;

                    case 5:
                        if (!File.Exists(filePath))
                            throw new FileNotFoundException();

                        string allText = File.ReadAllText(filePath);
                        Console.WriteLine("\nAll file content:\n" + allText);
                        break;

                    case 0:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: The file does not exist. Please create it first.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        } while (choice != 0);
    }
}
