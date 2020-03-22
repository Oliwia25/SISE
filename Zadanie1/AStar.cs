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
            List<Vertex> solution = new List<Vertex>();

            PriorityQueue<Vertex> toSearch = new PriorityQueue<Vertex>();
            List<Vertex> visited = new List<Vertex>();

            int processed = 0;
            bool solved = false;
            toSearch.Add(-1, root);

            while (toSearch.priorityQueue.Count > 0 && !solved)
            {
                Vertex currentVertex = toSearch.Remove();
                if (visited.Count != 0)
                {
                    while (helper.IsInList(visited, currentVertex))
                    {
                        currentVertex = toSearch.Remove();
                    }

                }

                if (currentVertex.GoalCheck())
                {
                    solved = true;
                    helper.Track(solution, currentVertex);
                    break;
                }
                currentVertex.MakeChildren();

                for (int i = 0; i < currentVertex.children.Count; i++)
                {
                    int countedH = (heurestic == "HAMM") ? currentVertex.children[i].CalculateHammingDistance() : currentVertex.children[i].CalculateManhattanDistance();
                    toSearch.Add(countedH, currentVertex.children[i]);
                    processed++;
                }
                visited.Add(currentVertex);

            }
            Program.visited = visited.Count;
            Program.processed = processed + 1;
            return solution;
        }

    }

}
