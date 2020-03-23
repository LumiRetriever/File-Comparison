using System;
using System.IO;
using System.Linq;
namespace FileComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            string file1 = "";
            string file2 = "";
            int i = 0;
            while(i < 2)
            {
                Console.WriteLine($"Please enter the name of file {i+1}\nExample: \"GitRepositories_1a\""); //ask the user to type a file name
                string file = Console.ReadLine(); //read what the user has written
                string path = $"Files/{file}.txt";
                if (File.Exists(path))//check if the file exists
                {
                    if(i == 0)
                    {
                        file1 = file;
                    }
                    else
                    {
                        file2 = file;
                    }
                    i++; //file exists and was set to a variable successfully, iterate
                }
                else
                {
                    Console.WriteLine("That file doesn't exist. Try again."); //file doesn't exist, don't iterate
                }
            }
            CompareFiles.diff(file1, file2); // we have 2 files now, lets compare them.
        }
    }

    class CompareFiles
    {
        public static string[] ReadFile(string fileName)
        {
            string path = $"Files/{fileName}.txt"; 
            string[] lines = File.ReadAllLines(path); // read the file into an array
            return lines;
        }

        public static void diff(string file1, string file2)
        {
            if (ReadFile(file1).SequenceEqual(ReadFile(file2))) // check if the files are the same
            {
                Console.WriteLine("These Files are the same."); // print if files are same
            }
            else
            {
                Console.WriteLine("These Files are different."); //print if files are different
            }
        }

    }

}
