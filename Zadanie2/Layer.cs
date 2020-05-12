using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Layer
    {
        private List<Neuron> _neurons;
        //private string _name;
        private double _weight;

        public List<Neuron> Neurons { get => _neurons; set => _neurons = value; }
        //public string Name { get => _name; set => _name = value; }
        public double Weight { get => _weight; set => _weight = value; }

        public Layer(int neuronsNumber, double initialWeight)//, string name = " ")
        {
            _neurons = new List<Neuron>();
            for(int i = 0; i < neuronsNumber; i++)
            {
                _neurons.Add(new Neuron()); 
            }

            _weight = initialWeight;
            //_name = name;
        }

        //public void Forward()
        //{
        //    for(int i = 0; i < _neurons.Count; i++)
        //    {
        //        _neurons[i].Fire();
        //    }
        //}

        //public void OptimizeWeights(double learningRate, double delta)
        //{
        //    _weight += learningRate * delta;
        //    for(int i = 0; i < _neurons.Count; i++)
        //    {
        //        _neurons[i].UpdateWeights(_weight);
        //    }
        //}


        public void CountWeights(double learningRate, double delta)
        {
            for(int i = 0; i < _neurons.Count; i++)
            {
                _neurons[i].CountWeight(learningRate, delta);
            }
        }
     

    }
}
