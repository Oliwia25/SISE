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
        private double _delta;

        public Neuron()
        {
            Entries = new List<Entry>();
        }

        public double Output { get => _output; set => _output = value; }
        public List<Entry> Entries { get => _entries; set => _entries = value; }
        public double Delta { get => _delta; set => _delta = value; }

        public void UpdateWeights(double momentum, double learningRate)
        {
            double derivative = Derivative();
            foreach (var e in Entries)
            {
                double newDelta = e.DeltaWeight * momentum - e.Input * learningRate * Delta * derivative;
                e.DeltaWeight = newDelta;
                e.Weight += e.DeltaWeight;
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

        public double Derivative()
        {
            return _output * (1 - _output);
        }
    }
}
