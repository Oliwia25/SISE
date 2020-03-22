using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class BFS
    {
        Helper helper;
        char[] order;

        public BFS(char[] order)
        {
            this.helper = new Helper();
            this.order = order;
        }

        public List<Vertex> BfsSteps(Vertex root)
        {
            Queue<Vertex> toSearch = new Queue<Vertex>();
            Queue<Vertex> searched = new Queue<Vertex>();
            List<Vertex> solution = new List<Vertex>();

            bool solved = false;

            toSearch.Enqueue(root);

            while (toSearch.Count > 0 && !solved)
            {
                Vertex currentVert = toSearch.ElementAt(0);
                searched.Enqueue(currentVert);
                toSearch.Dequeue();

                if (currentVert.GoalCheck())
                {
                    solved = true;
                    helper.Track(solution, currentVert);
                    break;
                }

                currentVert.MakeChildren(order);

                for (int i = 0; i < currentVert.children.Count; i++)
                {
                    if (!helper.IsInQueue(toSearch, currentVert.children[i]) && !helper.IsInQueue(searched, currentVert.children[i]))
                    {
                        toSearch.Enqueue(currentVert.children[i]);
                    }
                }
            }

            Program.visited = searched.Count;
            Program.processed = searched.Count + toSearch.Count;
            Program.deepest = solution[0].depth;
            return solution;
        }        
    }
}
