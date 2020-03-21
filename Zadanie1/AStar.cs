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
            Queue<Vertex> toSearch = new Queue<Vertex>();
            List<Vertex> searched = new List<Vertex>();
            List<Vertex> solution = new List<Vertex>();
            //List<int> indexesToSkip = new List<int>();
            List<Vertex> visited = new List<Vertex>();

            bool solved = false;

            toSearch.Enqueue(root);
            searched.Add(root);

            while (toSearch.Count > 0 && !solved)
            {
                //indexesToSkip.Clear();
                Vertex currentVert = toSearch.ElementAt(0);
                visited.Add(currentVert);
                toSearch.Dequeue();

                currentVert.MakeChildren();

                int lowestHvalue = (heurestic == "HAMM") ? currentVert.children[0].CalculateHammingDistance() : currentVert.children[0].CalculateManhattanDistance();
                int lowestHindex = 0;
                if (!helper.IsInList(searched, currentVert.children[0]))
                {
                    searched.Add(currentVert.children[lowestHindex]);
                }

                if (lowestHvalue == 0)
                {
                    visited.Add(currentVert.children[lowestHindex]);
                    solved = true;
                    helper.Track(solution, currentVert.children[0]);
                    break;
                }

                int otherH;

                for (int i = lowestHindex + 1; i < currentVert.children.Count; i++)
                {
                    otherH = (heurestic == "HAMM") ? currentVert.children[i].CalculateHammingDistance() : currentVert.children[i].CalculateManhattanDistance();
                    if (!helper.IsInList(searched, currentVert.children[i]))
                    {
                        searched.Add(currentVert.children[lowestHindex]);
                    }

                    if (otherH == 0)
                    {
                        visited.Add(currentVert.children[i]);
                        solved = true;
                        helper.Track(solution, currentVert.children[i]);
                        break;
                    }
                    else if (otherH < lowestHvalue)
                    {
                        lowestHvalue = otherH;
                        lowestHindex = i;
                    }
                }
                if (!helper.IsInList(visited, currentVert.children[lowestHindex]))
                {
                    toSearch.Enqueue(currentVert.children[lowestHindex]);
                }
                else
                {
                    visited.Add(currentVert.children[lowestHindex]);
                    currentVert.children.RemoveAt(lowestHindex);
                    lowestHindex = FindAnotherH(currentVert.children);
                    toSearch.Enqueue(currentVert.children[lowestHindex]);
                }

                
            }

            Program.visited = visited.Count;
            Program.processed = searched.Count;

            return solution;
        }

        public int FindAnotherH(List<Vertex> children)
        {
            int lowestHvalue = children[0].h;
            int lowestHindex = 0;

            int otherH;

            for (int i = 1; i < children.Count; i++)
            {
                otherH = children[i].h;
                if (otherH < lowestHvalue)
                {
                    lowestHvalue = otherH;
                    lowestHindex = i;
                }
            }         
            
            return lowestHindex;
        }

    }


}
