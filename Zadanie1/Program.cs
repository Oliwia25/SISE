using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zadanie1
{
    class Program
    {
        public static  List<string>  ReadFromFile(string filename)
        {
            List<string> allLinesText = File.ReadAllLines(filename).ToList();

            return allLinesText;
        }

        public static void  WriteToFile(string filename, List<string> finishedBoard)
        {
            File.WriteAllLines(filename,finishedBoard);
        }

        static void Main(string[] args)
        {
            List<string> lines = ReadFromFile(@"C:\Users\Olivia\Desktop\gitHub\SISE\Zadanie1\ExampleBoard.TXT");
            for(int i = 0; i < lines.Capacity; i++)
            {
                Console.WriteLine(lines);
            }

            WriteToFile(@"C:\Users\Olivia\Desktop\gitHub\SISE\Zadanie1\FinishedBoard.TXT",lines);
        }
    }
}
