using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Neuron
    {
        private List<Entry> _entries;
        private double _output;


        public Neuron()
        {
            Entries = new List<Entry>();
        }

        public double Output { get => _output; set => _output = value; }
        internal List<Entry> Entries { get => _entries; set => _entries = value; }

        public double Sum()
        {
            double result = 0.0;
            foreach(var e in Entries)
            {
                result += e.Input * e.Weight;
            }
            return result;
        }



    }
}
