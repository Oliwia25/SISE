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
        private double _weight;

        public Neuron()
        {
            Entries = new List<Entry>();
        }

        public double Output { get => _output; set => _output = value; }
        public List<Entry> Entries { get => _entries; set => _entries = value; }

        //public void UpdateWeights(double newWeight)
        //{
        //    for (int i = 0; i < _entries.Count; i++)
        //    {
        //        _entries[i].Weight = newWeight;
        //    }
        //}

        public void CountWeight(double learningRate, double delta)
        {
            _weight += learningRate * delta;
            foreach (var e in Entries)
            {
                e.Weight = _weight;
            }
        }

        public double Sum()
        {
            double result = 0.0;
            foreach(var e in Entries)
            {
                result += e.Input * e.Weight; 
            }
            return result;
        }

        public double Activation(double input) 
        {
            return 1.0 / (1.0 + Math.Exp(-input));
        }

        public void Calculate()
        {
            _output = Sum();
            _output = Activation(_output);
        }

       
    }
}
