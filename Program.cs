using System;
using System.IO;
using System.Text;

namespace StringReadingReversingApp
{
    static class Program
    {
        //Method which reverses a given string
        public static string reverse(this string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }
        //Method which checks if a given string is an isogram or not
        public static bool isIsogram(this string str)
        {
            str = str.ToLower();
            int len = str.Length;

            char[] arr = str.ToCharArray();

            Array.Sort(arr);
            for (int i = 0; i < len - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            //Defining main variables
            string stringFromFile;
            string SourceFilePath;
            string DestinationFilePath;

            //User dialog implemented
            Console.WriteLine("Input the path of the file from which a string will be read and press [Enter] button:");
            SourceFilePath = Console.ReadLine();
            Console.WriteLine("Input the path of the file to which the reversed string will be written and press [Enter] button:");
            DestinationFilePath = Console.ReadLine();

            //Reading a string from file
            stringFromFile = File.ReadAllText(SourceFilePath, Encoding.UTF8);

            //Reversing the string
            stringFromFile = reverse(stringFromFile);
            
            //Writing the string to a file
            File.WriteAllText(DestinationFilePath, stringFromFile);
            Console.WriteLine($"The reversed string is: \"{stringFromFile}\". Reversed string successfully written to {DestinationFilePath} file.");

            //Printing if the given string was an isogram or not
            if (isIsogram(stringFromFile))
                {
                    Console.WriteLine("String from the file was an isogram.");
                }
            else
            {
                Console.WriteLine("String from the file was not an isogram.");
            }

            //Closing the program dialog
            Console.WriteLine("Press any key to close the screen...");
            Console.ReadKey();
        }
    }
}
