using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class DFS
    {
        public int maxDepth = 20;

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
                currentVert.MakeChildren();

                for (int i = 0; i < currentVert.children.Count; i++)
                {
                    if (currentVert.children[i].GoalCheck())
                    {
                        solved = true;
                        Track(solution, currentVert.children[i]);
                        break;
                    }
                    if (currentVert.depth < maxDepth && !IsInStack(toSearch, currentVert.children[i]) && !IsInList(searched, currentVert.children[i]))
                    {
                        toSearch.Push(currentVert.children[i]);
                    }
                }
            }
            return solution;
        }
        public void Track(List<Vertex> list, Vertex v)
        {
            Vertex currentV = v;
            list.Add(currentV);
            while (currentV.parent != null)
            {
                currentV = currentV.parent;
                list.Add(currentV);
            }
        }

        public bool IsInList(List<Vertex> list, Vertex v)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].IsBoardRepeated(v.game))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsInStack(Stack<Vertex> stack, Vertex v)
        {
            for (int i = 0; i < stack.Count(); i++)
            {
                if (stack.ElementAt(i).IsBoardRepeated(v.game))
                {
                    return true;
                }
            }
            return false;
        }

    }
}