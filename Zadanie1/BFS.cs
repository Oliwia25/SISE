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

        public BFS()
        {
            this.helper = new Helper();
        }

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
                        helper.Track(solution, currentVert.children[i]);
                        break;
                    }
                    if (!helper.IsInQueue(toSearch, currentVert.children[i]) && !helper.IsInQueue(searched, currentVert.children[i]))
                    {
                        toSearch.Enqueue(currentVert.children[i]);
                    }
                }
            }
            return solution;
        }        
    }
}
