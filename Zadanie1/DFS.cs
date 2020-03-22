using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class DFS
    {
        public Helper helper;
        char[] order;
        public int maxDepth = 21;

        public DFS(char[] order)
        {
            this.helper = new Helper();
            this.order = order;
        }
        public List<Vertex> DfsSteps(Vertex root)
        {
            List<Vertex> solution = new List<Vertex>();
            List<Vertex> searched = new List<Vertex>();
            LinkedList<Vertex> toSearch = new LinkedList<Vertex>();

            bool solved = false;
            toSearch.AddFirst(root);

            while (toSearch.Count > 0 && !solved)
            {
                Vertex currentVert = toSearch.ElementAt(0);
                toSearch.RemoveFirst();
                currentVert.PrintBoard();
                searched.Add(currentVert);
                if(currentVert.depth > Program.deepest)
                {
                    Program.deepest = currentVert.depth;
                }

                if (currentVert.GoalCheck())
                {
                    solved = true;
                    helper.Track(solution, currentVert);
                    break;
                }

                currentVert.MakeChildren(order);
                currentVert.children.Reverse();

                for (int i = 0; i < currentVert.children.Count; i++)
                {
                    if (currentVert.depth < maxDepth && /*!helper.IsInStack(toSearch, currentVert.children[i]) &&*/ !helper.IsInList(searched, currentVert.children[i]))
                    {
                        if (helper.IsInLinkedList(toSearch, currentVert.children[i]))
                            toSearch.Remove(currentVert.children[i]);
                        toSearch.AddFirst(currentVert.children[i]);
                    }
                }
                Console.WriteLine(searched.Count);
                Console.WriteLine(currentVert.depth);
            }
            Program.visited = searched.Count;
            Program.processed = searched.Count + toSearch.Count;
            return solution;
        }

    }
}