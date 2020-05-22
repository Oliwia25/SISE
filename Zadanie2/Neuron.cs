using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Neuron
    {
        private List<double> _weights;
        private List<double> _deltaWeight;
        private double _output;
        private double _sum;
        private double _delta;
        private double _alpha = 0.01; // krok 
        private double _beta = 0.0; // momentum


        public List<double> Weights { get => _weights; set => _weights = value; }
        public List<double> DeltaWeight { get => _deltaWeight; set => _deltaWeight = value; }
        public double Output { get => _output; set => _output = value; }
        public double Sum { get => _sum; set => _sum = value; }
        public double Delta { get => _delta; set => _delta = value; }
        public double Alpha  { get => _alpha; set => _alpha = value; }
        public double Beta  { get => _beta; set => _beta = value; }

        public Neuron()
        {
            _weights = new List<double>();
            _deltaWeight = new List<double>();
        }

        public void DrawWeights(int x)
        {
            Random rand = new Random();
            for (int i = 0; i < x; i++)
            {
                _deltaWeight.Add(0.0);
                _weights.Add(rand.NextDouble() * (-2) + 1 );
            }
        }

        public double Sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        public void CalculateOutput(List<double> input)
        {
            double s = 0;
            for(int i = 0; i < _weights.Count; i++)
            {
                s += _weights[i] * input[i];
            }
            _sum = s;
            _output = Sigmoid(_sum);
        }

        public double Derivative()
        {
            return _output * (1 - _output);
        }

        public void CalcDeltaLastLayer(double error) //zmienione z * Derivative()
        {
            _delta = error * Derivative();
        }

        public void CalcDeltaHiddenLayer(List<double> BB, List<double> TW, int neuronsInSecondLayer) 
        {
            double s = 0;
            for (int i = 0; i < neuronsInSecondLayer; i++) 
            {
                s += BB[i] * TW[i];
            }
           _delta= s * Derivative();
        }

        public double GetWeight(int nr)
        {
            return _weights[nr];
        }

        public void UpdateWeight(List<double> input)
        {
            for (int i = 0; i < _deltaWeight.Count; i++)
            {
                double newDelta = (_beta * _deltaWeight[i] - _alpha * _delta *input[i]) ;
                _deltaWeight[i] = newDelta;
                _weights[i] += _deltaWeight[i];
            }
        }
        //private List<Entry> _entries;
        //private double _output;
        //private double _delta;

        //public Neuron()
        //{
        //    Entries = new List<Entry>();
        //}

        //public double Output { get => _output; set => _output = value; }
        //public List<Entry> Entries { get => _entries; set => _entries = value; }
        //public double Delta { get => _delta; set => _delta = value; }

        //public void UpdateWeights(double momentum, double learningRate)
        //{
        //    double derivative = Derivative();
        //    foreach (var e in Entries)
        //    {
        //        double newDelta = e.DeltaWeight * momentum - e.Input * learningRate * Delta * derivative;
        //        e.DeltaWeight = newDelta;
        //        e.Weight += e.DeltaWeight;
        //    }
        //}

        //public double Sum()
        //{
        //    double result = 0.0;
        //    foreach(var e in Entries)
        //    {
        //        result += e.Input * e.Weight; 
        //    }
        //    return result;
        //}

        //public double Activation(double input) 
        //{
        //    return 1.0 / (1.0 + Math.Exp(-input));
        //}

        //public void Calculate()
        //{
        //    _output = Sum();
        //    _output = Activation(_output);
        //}

        //public double Derivative()
        //{
        //    return _output * (1 - _output);
        //}
    }
}
