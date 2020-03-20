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
            string inputFile = args[2];
            string lines = File.ReadAllText(inputFile);
            string[] stringList = lines.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
            int[] intList = stringList.Select(arg => int.Parse(arg)).ToArray();

            Vertex initVert = new Vertex(intList);            
            initVert.PrintBoard();
            List<Vertex> solution = new List<Vertex>();

            string algorithm = args[0];
            string option = args[1];
            option.ToUpper();
           // algorithm = Console.ReadLine(); //to niepotrzebne chyba wtedy
            
            string solutionFile =  args[3];
            string statisticFile = args[4];

            string[] order = new string[4];

            if (algorithm != "astar")
            {
                order = option.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
            }

            switch (algorithm)
            {
                case "bfs":                    
                    BFS bfs = new BFS(order);
                    solution = bfs.BfsSteps(initVert);
                    break;
                    
                case "dfs":
                    DFS dfs = new DFS(order);
                    solution = dfs.DfsSteps(initVert);
                    break;

                case "astar":
                    //string heurestic;
                    //heurestic = Console.ReadLine(); //wywalić potem
                    //heurestic = args[1];
                    AStar aStar = new AStar(option);
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

            List<string> toSolutionFile = new List<string>();
            if (solution.Count == 0)
            {
                toSolutionFile.Add("-1");
            }
            else
            {
                int firstLine = solution.Count - 1;
                string secondLine = "";
                toSolutionFile.Add(firstLine.ToString());
                for (int i = solution.Count - 2; i >= 0; i--)
                {
                    secondLine += solution[i].moveLetter;
                }
                toSolutionFile.Add(secondLine);
            }
            WriteToFile("Solution.TXT", toSolutionFile);

            Console.ReadLine();
        }
    }
}
