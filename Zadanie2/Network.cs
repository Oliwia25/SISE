using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Network
    {
        private List<Layer> _layers;

        public List<Layer> Layers { get => _layers; set => _layers = value; }

        public Network()
        {
            _layers = new List<Layer>();
        }

        public void AddLayer(Layer layer)
        {
            for(int i = 0; i < layer.Neurons.Count(); i++)
            {
                layer.Neurons[i].Entries.Add(new Entry());
            }
        }
    }
}
