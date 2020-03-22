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
        public List<Vertex> vis;
        public List<Vertex> proc;
        public Vertex winner;
        public bool solved;

        public DFS(char[] order)
        {
            this.helper = new Helper();
            this.order = order;
            this.solution = new List<Vertex>();
            this.vis = new List<Vertex>();
            this.proc = new List<Vertex>();
            this.solved = false;
        }
        public List<Vertex> DfsSteps(Vertex root)
        {
            proc.Add(root);
            SolveWithDFS(root);
            helper.Track(solution, winner);
            Program.visited = vis.Count;
            Program.processed = proc.Count;
            return solution;
        }

        public void SolveWithDFS(Vertex currentVert)
        {
            vis.Add(currentVert);
            if (currentVert.depth > Program.deepest)
            {
                Program.deepest = currentVert.depth;
            }
            if (currentVert.GoalCheck())
            {
                winner = currentVert;
                solved = true;
                return;
            }
            if ((!solved))
            {
                currentVert.MakeChildren(order);
                for (int i = 0; i < currentVert.children.Count; i++)
                {
                    if (!helper.IsInList(proc, currentVert.children[i]))
                    {
                        proc.Add(currentVert.children[i]);
                    }
                }
                for (int i = 0; i < currentVert.children.Count; i++)
                {
                    if (currentVert.depth < maxDepth)
                    {
                        SolveWithDFS(currentVert.children[i]);

                    }
                }
            }
        }
    }


}