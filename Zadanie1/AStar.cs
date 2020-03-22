using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class AStar
    {
        public string heurestic;
        Helper helper;

        public AStar(string heurestic)
        {
            this.heurestic = heurestic;
            this.helper = new Helper();
        }

        public List<Vertex> AStarSteps(Vertex root)
        {
            AStarPriorityQueue<Vertex> toSearch = new AStarPriorityQueue<Vertex>();// na taki
            List<Vertex> visited = new List<Vertex>();
            List<Vertex> solution = new List<Vertex>();

            int processedVertexCount = 0;
            bool solved = false;
            toSearch.Add(-1, root);

            while (toSearch.priorityQueue.Count > 0 && !solved)
            {
                Vertex currentVert = toSearch.GetFirst();
                if (currentVert.depth > Program.deepest)
                {
                    Program.deepest = currentVert.depth;
                }
                while (helper.IsInList(visited, currentVert))
                {
                    currentVert = toSearch.GetFirst();
                }
                if (currentVert.GoalCheck())
                {
                    solved = true;
                    helper.Track(solution, currentVert);
                    break;
                }
                currentVert.MakeChildren();

                for (int i = 0; i < currentVert.children.Count; i++)
                {
                    int countedH;
                    if (heurestic == "HAMM")
                    {
                        countedH = currentVert.children[i].CalculateHammingDistance();
                    }
                    else 
                    {
                        countedH = currentVert.children[i].CalculateManhattanDistance();
                    }
                    toSearch.Add(countedH, currentVert.children[i]);
                    processedVertexCount += 1;
                }
                visited.Add(currentVert);

            }
            Program.visited = visited.Count;
            Program.processed = processedVertexCount + 1;
            return solution;
        }

    }

}


