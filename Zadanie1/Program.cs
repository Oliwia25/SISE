using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Zadanie1
{
    class Program
    {
        static Stopwatch stopwatch;
        //static int visited;
        //static int processed;

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
            algorithm = algorithm.ToUpper();
            option = option.ToUpper();

            char[] order = new char[4];

            if (algorithm != "ASTAR")
            {
                order = option.ToCharArray();
            }

            stopwatch = Stopwatch.StartNew();
            switch (algorithm)
            {
                case "BFS":                    
                    BFS bfs = new BFS(order);
                    solution = bfs.BfsSteps(initVert);
                    break;
                    
                case "DFS":
                    DFS dfs = new DFS(order);
                    solution = dfs.DfsSteps(initVert);
                    break;

                case "ASTAR":
                    AStar aStar = new AStar(option);
                    solution = aStar.AStarSteps(initVert);
                    //visited = aStar.visitedA;
                    //processed = aStar.processedA;
                    break;

                default:
                    Console.WriteLine("Wrong arguments! ");
                    break;           
            }
            stopwatch.Stop();

            string solutionFile = args[3];
            string statisticFile = args[4];
            Console.WriteLine();
            Console.Write("SOLUTION: ");
            Console.WriteLine();
            for (int i = solution.Count - 1; i >= 0; i--)
            {
                solution[i].PrintBoard();
            }

            List<string> toSolutionFile = new List<string>();
            List<string> toStatsFile = new List<string>();

            string firstLineStats;

            if (solution.Count == 0)
            {
                toSolutionFile.Add("-1");

                firstLineStats = "-1";
            }
            else
            {
                int firstLineSolution = solution.Count - 1;
                string secondLineSolution = "";
                toSolutionFile.Add(firstLineSolution.ToString());
                for (int i = solution.Count - 2; i >= 0; i--)
                {
                    secondLineSolution += solution[i].moveLetter;
                }
                toSolutionFile.Add(secondLineSolution);

                firstLineStats = (solution.Count - 1).ToString();
            }
            WriteToFile(solutionFile, toSolutionFile);

            string secondLineStats = "odwiedzone";
            string thirdLineStats = "przetworzone";
            string fourthLineStats = solution[0].depth.ToString();
            string fifthLineStats = Math.Round(stopwatch.Elapsed.TotalMilliseconds, 3).ToString();

            toStatsFile.Add(firstLineStats);
            toStatsFile.Add(secondLineStats);
            toStatsFile.Add(thirdLineStats);
            toStatsFile.Add(fourthLineStats);
            toStatsFile.Add(fifthLineStats);

            WriteToFile(statisticFile, toStatsFile);

            Console.ReadLine();
        }
    }
}
