using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
            int entryNumber = 1;

            if (_layers.Count > 0)
            {
                entryNumber = _layers.Last().Neurons.Count; 
            }

            foreach (var n in layer.Neurons)
            {
                for (int i = 0; i < entryNumber; i++)
                {
                    n.Entries.Add(new Entry());
                }
            }
        }

        public void BuildNetwork()
        {
            for (int i = 0; i < _layers.Count - 1; i++) // ok?
            {
                var nextLayer = _layers[i + 1];
                CreateNetwork(_layers[i], nextLayer);
            }
        }

        private void CreateNetwork(Layer connectingFrom, Layer connectingTo)
        {
            for (int i = 0; i < connectingTo.Neurons.Count; i++)
            {
                for (int j = 0; j < connectingFrom.Neurons.Count; j++)
                {
                    connectingTo.Neurons[i].Entries.Add(new Entry() { Input = connectingTo.Neurons[i].Output, Weight = connectingTo.Weight });
                }
            }
        }

        public void PrintNewtork()
        {
            DataTable products = new DataTable();
            //products.Columns.Add("Name");
            products.Columns.Add("Neurons");
            products.Columns.Add("Weight");

            foreach (var element in Layers)
            {
                DataRow row = products.NewRow();
                //row[0] = element.Name;
                row[0] = element.Neurons.Count;
                row[1] = element.Weight;

                products.Rows.Add(row);
            }

            //Console.WriteLine(products.Rows.Count);
            //Console.Write(products.Columns);
            foreach(var columns in products.Columns)
            {
                Console.Write(" " + columns);
            }
            Console.Write('\n');
            foreach (DataRow dataRow in products.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(" " + item + "   ");
                }
                Console.Write('\n');
            }
        }

        public void CalculateOutput()
        {
            bool firstLayer = true;
            for (int i = 0; i < _layers.Count; i++)
            {
                if (firstLayer)
                {
                    firstLayer = false;
                    continue;
                }
                _layers[i].Forward(); 
            }
        }

        //public void OptimizeWeights(double accuracy)
        //{
        //    float learningRate = 0.1f;
        //    //Pomiń jeżeli accuracy osiągnęła 100%
        //    if (accuracy == 1)
        //    {
        //        return;
        //    }

        //    if (accuracy > 1)
        //    {
        //        learningRate = -learningRate;
        //    }

        //    //Update the weights for all the layers
        //    for(int i = 0; i < _layers.Count; i++)
        //    {
        //        _layers[i].OptimizeWeights(learningRate, 1);
        //    }
        //}

        //public void TrainNetwork(NeuralData X, NeuralData Y, int iterations, double learningRate = 0.1)
        //{
        //    int epoch = 1;

        //    while(iterations >= epoch)
        //    {

        //    }
        //}

    }
}
