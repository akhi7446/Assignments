using System;
using System.IO;

class Task1
{
    public static void Main1()
    {
        string baseDir = @"C:\Users\aakas\OneDrive\Desktop\cgi classes\Assignments\demo";
        string demo1 = Path.Combine(baseDir, "demo1");
        string demo2 = Path.Combine(baseDir, "demo2");

        try
        {
            // Create directories with existence check
            if (!Directory.Exists(demo1)) Directory.CreateDirectory(demo1);
            if (!Directory.Exists(demo2)) Directory.CreateDirectory(demo2);
            Console.WriteLine("Directories created.");

            // File paths
            string file1 = Path.Combine(demo1, "file1.txt");
            string file2 = Path.Combine(demo1, "file2.txt");

            // Create file1 using File class if it doesn't exist
            if (!File.Exists(file1))
            {
                File.WriteAllText(file1, "This is file1 created using File class.");
                Console.WriteLine("file1.txt created.");
            }

            // Create file2 using FileInfo if it doesn't exist
            FileInfo fInfo = new FileInfo(file2);
            if (!fInfo.Exists)
            {
                using (StreamWriter writer = fInfo.CreateText())
                {
                    writer.WriteLine("This is file2 created using FileInfo class.");
                }
                Console.WriteLine("file2.txt created.");
            }

            // Copy file1 to demo2
            string destFile = Path.Combine(demo2, "file1_copy.txt");
            File.Copy(file1, destFile, true);
            Console.WriteLine("file1.txt copied to demo2.");

            // Display files & directories
            Console.WriteLine("\nDirectories in 'demo':");
            foreach (var dir in Directory.GetDirectories(baseDir))
                Console.WriteLine($"Directory: {dir} - Created at: {Directory.GetCreationTime(dir)}");

            Console.WriteLine("\nFiles in demo1:");
            foreach (var file in Directory.GetFiles(demo1))
                Console.WriteLine($"File: {file} - Created at: {File.GetCreationTime(file)}");

            Console.WriteLine("\nFiles in demo2:");
            foreach (var file in Directory.GetFiles(demo2))
                Console.WriteLine($"File: {file} - Created at: {File.GetCreationTime(file)}");

            // Delete all files
            //foreach (var file in Directory.GetFiles(demo1)) File.Delete(file);
            //foreach (var file in Directory.GetFiles(demo2)) File.Delete(file);
            //Console.WriteLine("\nAll files deleted.");

            // Delete directories
            //Directory.Delete(demo1);
            //Directory.Delete(demo2);
            //Directory.Delete(baseDir);
            //Console.WriteLine("All directories deleted.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
