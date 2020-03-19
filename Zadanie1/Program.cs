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
        public static void  WriteToFile(string filename, List<string> finishedBoard)
        {
            File.WriteAllLines(filename,finishedBoard);
        }

        static void Main(string[] args)
        {
            string lines = File.ReadAllText("ExampleBoard.TXT");
            string[] stringList = lines.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
            int[] intList = stringList.Select(arg => int.Parse(arg)).ToArray();

            Vertex initVert = new Vertex(intList);            
            initVert.PrintBoard();
            List<Vertex> solution = new List<Vertex>();
            
            BFS bfs = new BFS();
            solution = bfs.BfsSteps(initVert);

            Console.WriteLine();
            for (int i = solution.Count - 1; i >= 0; i--)
            {
                solution[i].PrintBoard();
            }

            //Vertex initial = new Vertex(intList);

            //AStart root = new AStart(intList);
            //for (int i = 0; i < lines.Count; i++)
            //{
            //    Console.WriteLine(lines[i]);

            //}

            // WriteToFile(@"C:\Users\Olivia\Desktop\gitHub\SISE\Zadanie1\FinishedBoard.TXT",lines);
            Console.ReadLine();
        }
    }
}
