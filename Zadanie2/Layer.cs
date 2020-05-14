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

        public List<Neuron> Neurons { get => _neurons; set => _neurons = value; }

        public Layer(int neuronsNumber)
        {
            _neurons = new List<Neuron>();
            for(int i = 0; i < neuronsNumber; i++)
            {
                _neurons.Add(new Neuron()); 
            }
        }

        public void Forward()
        {
            for (int i = 0; i < _neurons.Count; i++)
            {
                _neurons[i].Calculate();
            }
        }

        public void CountWeights(double momentum, double learningRate)
        {
            for(int i = 0; i < _neurons.Count; i++)
            {
                _neurons[i].UpdateWeights(momentum, learningRate);
            }
        }
     

    }
}
