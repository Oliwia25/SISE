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
        public List<Vertex> solution;
        public List<Vertex> odwiedzone;
        public List<Vertex> przetworzone;
        //public LinkedList<Vertex> toSearch;
        public Vertex winner;
        public bool solved;

        public DFS(char[] order)
        {
            this.helper = new Helper();
            this.order = order;
            solution = new List<Vertex>();
            odwiedzone = new List<Vertex>();
            przetworzone = new List<Vertex>();
            //toSearch = new LinkedList<Vertex>();
            solved = false;
        }
        public List<Vertex> DfsSteps(Vertex root)
        {
            przetworzone.Add(root);
            //odwiedzone.Add(root);
            SolveWithDFS(root);
            // toSearch.AddFirst(root);

            // while (toSearch.Count > 0 && !solved)
            // {
            //Vertex currentVert = toSearch.ElementAt(0);
            //toSearch.RemoveFirst();
            //currentVert.PrintBoard();
            //searched.Add(currentVert);
            //if(currentVert.depth > Program.deepest)
            //{
            //    Program.deepest = currentVert.depth;
            //}

            //if (currentVert.GoalCheck())
            //{
            //    solved = true;
            //    helper.Track(solution, currentVert);
            //    break;
            //}

            //currentVert.MakeChildren(order);
            //currentVert.children.Reverse();

            //for (int i = 0; i < currentVert.children.Count; i++)
            //{
            //    if (currentVert.depth < maxDepth && /*!helper.IsInStack(toSearch, currentVert.children[i]) &&*/ !helper.IsInList(searched, currentVert.children[i]))
            //    {
            //        if (helper.IsInLinkedList(toSearch, currentVert.children[i]))
            //            toSearch.Remove(currentVert.children[i]);
            //        toSearch.AddFirst(currentVert.children[i]);
            //    }
            //}
            //Console.WriteLine(searched.Count);
            //Console.WriteLine(currentVert.depth);
            // }
            //Program.visited = searched.Count;
            //Program.processed = searched.Count + toSearch.Count;
            helper.Track(solution, winner);
            Program.visited = odwiedzone.Count;
            Program.processed = przetworzone.Count;
            return solution;
        }

        public void SolveWithDFS(Vertex currentVert)
        {
            odwiedzone.Add(currentVert);
            //currentVert.PrintBoard();
            //Console.WriteLine(odwiedzone.Count);
            //Console.WriteLine(przetworzone.Count);
            //Console.WriteLine(currentVert.depth);
            if (currentVert.depth > Program.deepest)
            {
                Program.deepest = currentVert.depth;
            }
            if (currentVert.GoalCheck())
            {
                winner = currentVert;
                solved = true;
                //return;
            }
            if (!solved)
            {
                currentVert.MakeChildren(order);
                for (int i = 0; i < currentVert.children.Count; i++)
                {
                    if (!helper.IsInList(przetworzone, currentVert.children[i]))
                    {
                        przetworzone.Add(currentVert.children[i]);
                    }
                }
                for (int i = 0; i < currentVert.children.Count; i++)
                {
                    while(!solved)
                    if (currentVert.depth < maxDepth && !helper.IsInList(odwiedzone, currentVert.children[i]))
                    {
                        SolveWithDFS(currentVert.children[i]);
                    }
                }
            }                                  
        }
    }

    
}