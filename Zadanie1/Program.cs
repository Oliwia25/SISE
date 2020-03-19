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

            string option;
            option = Console.ReadLine();

            switch (option)
            {
                case "bfs":                    
                    BFS bfs = new BFS();
                    solution = bfs.BfsSteps(initVert);
                    break;
                    
                case "dfs":
                    DFS dfs = new DFS();
                    solution = dfs.DfsSteps(initVert);
                    break;

                case "astar":
                    string heurestic;
                    heurestic = Console.ReadLine();
                    AStar aStar = new AStar(heurestic);
                    solution = aStar.AStarSteps(initVert);
                    break;

                default:
                    Console.WriteLine("Wrong arguments! ");
                    break;            
                                      
            }           

            Console.WriteLine();
            Console.Write("SOLUTION: ");
            Console.WriteLine();
            for (int i = solution.Count - 1; i >= 0; i--)
            {
                solution[i].PrintBoard();
            }

            Console.ReadLine();
        }
    }
}
