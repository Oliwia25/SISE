using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class PriorityQueue<T>
    {
        public SortedDictionary<int, Queue<Vertex>> priorityQueue = new SortedDictionary<int, Queue<Vertex>>();

        public void Add(int key, Vertex v)
        {
            if (!priorityQueue.ContainsKey(key))
            {
                priorityQueue.Add(key, new Queue<Vertex>());
            }
            priorityQueue[key].Enqueue(v);
        }

        public Vertex Remove()
        {
            int minKey = priorityQueue.Keys.Min();
            Vertex v = priorityQueue[minKey].Dequeue();
            if (priorityQueue[minKey].Count == 0)
            {
                priorityQueue.Remove(minKey);
            }
            return v;
        }
    }
}
