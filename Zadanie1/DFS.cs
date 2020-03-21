﻿using System;
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
        public int maxDepth = 20;

        public DFS(char[] order)
        {
            this.helper = new Helper();
            this.order = order;
        }
        public List<Vertex> DfsSteps(Vertex root)
        {
            List<Vertex> solution = new List<Vertex>();
            List<Vertex> searched = new List<Vertex>();
            Stack<Vertex> toSearch = new Stack<Vertex>();

            bool solved = false;
            toSearch.Push(root);

            while (toSearch.Count > 0 && !solved)
            {
                Vertex currentVert = toSearch.Pop();
                searched.Add(currentVert);

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

                    if (currentVert.depth < maxDepth && !helper.IsInStack(toSearch, currentVert.children[i]) && !helper.IsInList(searched, currentVert.children[i]))
                    {
                        toSearch.Push(currentVert.children[i]);
                    }
                }
            }
            Program.visited = searched.Count;
            Program.processed = searched.Count + toSearch.Count;
            return solution;
        }

    }
}