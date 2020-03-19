using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class BFS
    {
        public BFS() { }

        public List<Vertex> BfsSteps(Vertex root)
        {
            Queue<Vertex> toSearch = new Queue<Vertex>();
            Queue<Vertex> searched = new Queue<Vertex>();
            List<Vertex> solution = new List<Vertex>();

            bool solved = false;

            toSearch.Enqueue(root);

            while(toSearch.Count > 0 && !solved)
            {
                Vertex currentVert = toSearch.ElementAt(0);
                searched.Enqueue(currentVert);
                toSearch.Dequeue();

                currentVert.MakeChildren();

                for (int i = 0; i < currentVert.children.Count; i++)
                {
                    if (currentVert.children[i].GoalCheck())
                    {
                      
                        solved = true;
                        Track(solution, currentVert.children[i]);
                        break;
                    }
                    if (!IsInQueue(toSearch, currentVert.children[i]) && !IsInQueue(searched, currentVert.children[i]))
                    {
                        toSearch.Enqueue(currentVert.children[i]);
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

        public bool IsInQueue(Queue<Vertex> q, Vertex v)
        {
            for (int i = 0; i < q.Count(); i++)
            {
                if (q.ElementAt(i).IsBoardRepeated(v.game))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
