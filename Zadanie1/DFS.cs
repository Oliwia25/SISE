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
        public List<Vertex> searched;
        public List<Vertex> made;
        public LinkedList<Vertex> toSearch;
        public Vertex winner;
        public bool solved;

        public DFS(char[] order)
        {
            this.helper = new Helper();
            this.order = order;
            solution = new List<Vertex>();
            searched = new List<Vertex>();
            made = new List<Vertex>();
            toSearch = new LinkedList<Vertex>();
            solved = false;
        }
        public List<Vertex> DfsSteps(Vertex root)
        {

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
            Program.visited = made.Count;
            Program.processed = searched.Count;
            return solution;
        }

        public void SolveWithDFS(Vertex currentVert)
        {
            searched.Add(currentVert);
            currentVert.PrintBoard();
            Console.WriteLine(searched.Count);
            Console.WriteLine(currentVert.depth);
            if (currentVert.depth > Program.deepest)
            {
                Program.deepest = currentVert.depth;
            }
            if (currentVert.GoalCheck())
            {
                winner = currentVert;
                solved = true;
            }
            if (!currentVert.GoalCheck() && !solved)
            {
                currentVert.MakeChildren(order);
                for (int i = 0; i < currentVert.children.Count; i++)
                {
                    if (!helper.IsInList(made, currentVert.children[i]))
                    {
                        made.Add(currentVert.children[i]);
                    }
                }
                //while (currentVert.children.Count > 0 && !solved)
                for (int i = 0; i < currentVert.children.Count; i++)
                {
                    if (currentVert.depth < maxDepth && !helper.IsInList(searched, currentVert.children[i]))
                    {
                        SolveWithDFS(currentVert.children[i]);
                    }
                }
            }
            
           // helper.Track(solution, currentVert);
                        
        }
    }

    
}