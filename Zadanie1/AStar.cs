﻿using System;
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
            List<int> indexesToSkip = new List<int>();
            List<Vertex> visited = new List<Vertex>();

            bool solved = false;

            toSearch.Enqueue(root);
            searched.Add(root);

            while (toSearch.Count > 0 && !solved)
            {
                indexesToSkip.Clear();
                Vertex currentVert = toSearch.ElementAt(0);
                visited.Add(currentVert);
                toSearch.Dequeue();

                currentVert.MakeChildren();

                int lowestHvalue = (heurestic == "HAM") ? currentVert.children[0].CalculateHammingDistance() : currentVert.children[0].CalculateManhattanDistance();
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
                    otherH = (heurestic == "HAM") ? currentVert.children[i].CalculateHammingDistance() : currentVert.children[i].CalculateManhattanDistance();
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
                    else
                    {
                        indexesToSkip.Add(lowestHindex);
                        while (helper.IsInList(visited, currentVert.children[lowestHindex]))
                        {
                            lowestHindex = FindAnotherH(currentVert.children, indexesToSkip);
                        }
                        toSearch.Enqueue(currentVert.children[lowestHindex]);
                    }

                }
            }

            Program.visited = visited.Count;
            Program.processed = searched.Count;

            return solution;
        }

        public int FindAnotherH(List<Vertex> children, List<int> indexToSkip)
        {
            int lowestHvalue = 0;
            int lowestHindex = 0;

            for (int i = 0; i < children.Count; i++)
            {
                if (!indexToSkip.Contains(i))
                {
                    lowestHvalue = children[i].h;
                    lowestHindex = i;
                }
                else
                {
                    Console.WriteLine("A* unsuccesful");
                    break;
                }
            }
            int otherH;
            for (int i = lowestHindex + 1; i < children.Count; i++)
            {
                if (!indexToSkip.Contains(i))
                {
                    otherH = children[i].h;
                    if (otherH < lowestHvalue)
                    {
                        lowestHvalue = otherH;
                        lowestHindex = i;
                    }
                }
            }
            return lowestHindex;
        }

    }


}