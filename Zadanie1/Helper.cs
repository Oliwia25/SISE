using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Helper
    {
        public Helper() { }

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
