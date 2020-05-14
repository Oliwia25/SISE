﻿using System;
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
            _layers.Add(layer);
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
            Random rand = new Random();
            for (int i = 0; i < connectingFrom.Neurons.Count; i++)
            {
                connectingTo.Neurons[i].Entries.Add(new Entry());
            }
            for (int i = 0; i < connectingTo.Neurons.Count; i++)
            {
                for (int j = 0; j < connectingFrom.Neurons.Count; j++)
                {
                    connectingTo.Neurons[i].Entries.Add(new Entry() { Input = connectingFrom.Neurons[j].Output, Weight = rand.NextDouble() * (-2) + 1 });
                }
            }
        }

        public void PrintNewtork()
        {
            DataTable products = new DataTable();
            products.Columns.Add("Neurons");

            foreach (var element in Layers)
            {
                DataRow row = products.NewRow();
                //row[0] = element.Name;
                row[0] = element.Neurons.Count;

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

        public void OptimizeWeights(double accuracy)
        {
            double momentum = 0.0;
            double learningRate = 0.2;
            //Pomiń jeżeli accuracy osiągnęła 100%
            if (accuracy == 1)
            {
                return;
            }

            if (accuracy > 1)
            {
                learningRate = -learningRate;
            }

            //Update the weights for all the layers
            for (int i = 0; i < _layers.Count; i++)
            {
                _layers[i].CountWeights(momentum, learningRate);
            }
        }

        public void TrainNetwork(List<List<double>> DataX, List<List<double>> DataY, int iterations, double learningRate = 0.1)
        {
            int epoch = 1;

            while (iterations >= epoch)
            {
                var inputLayer = Layers[0];
                //List<double> outputs = new List<double>();

                //Forward dla jednego punktu
                for (int i = 0; i < DataX.Count; i++)
                {
                    for (int j = 0; j < DataX[j].Count; j++)
                    {
                        inputLayer.Neurons[j].Output = DataX[i][j];
                    }

                    CalculateOutput();
                    //  outputs.Add(Layers.Last().Neurons.First().Output);

                    //Obliczenie delty dla wszystkich neuronów, warstwami od końca
                        //Last layer
                    for (int k = 0; k < _layers.Last().Neurons.Count; k++)
                    {
                        _layers.Last().Neurons[k].Delta = DataY[i][k] - _layers.Last().Neurons[k].Output;
                    }
                        //Hidden Layer
                    for (int k = 0; k < _layers[1].Neurons.Count; k++)
                    {
                        double sum = 0.0;
                        for (int l = 0; l < _layers.Last().Neurons.Count; l++)
                        {
                            sum += _layers.Last().Neurons[l].Delta * _layers.Last().Neurons[l].Entries[k].DeltaWeight;
                        }
                        _layers[1].Neurons[k].Delta = sum;
                    }

                    //Update weights
                    OptimizeWeights(1);
                }

                
            }
        }

    }
}
