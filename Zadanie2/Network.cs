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
        private List<Neuron> _hiddenLayer; 
        private List<Neuron> _lastLayer;
        private List<double> _avgError;
        private int numberOfNeuronsInHiddenLayer;

        public List<Neuron> HiddenLayer { get => _hiddenLayer; set => _hiddenLayer = value; }
        public List<Neuron> Lastlayer { get => _lastLayer; set => _lastLayer = value; }
        public int NumberOfNeuronsInHiddenLayer { get => numberOfNeuronsInHiddenLayer; set => numberOfNeuronsInHiddenLayer = value; }
        public List<double> AvgError { get => _avgError; set => _avgError = value; }

        public Network(int number)
        {
            numberOfNeuronsInHiddenLayer = number;
            _hiddenLayer = new List<Neuron>();
            _lastLayer = new List<Neuron>();
            AvgError = new List<double>();
        }

        public void DrawWeights()
        {
            for (int i = 0; i < numberOfNeuronsInHiddenLayer; i++) 
            {
                Neuron n = new Neuron();
                n.DrawWeights(2);
                _hiddenLayer.Add(n);
            }

            for (int i = 0; i < 2; i++)
            {
                Neuron n = new Neuron();
                n.DrawWeights(numberOfNeuronsInHiddenLayer);
                _lastLayer.Add(n);
            }

        }

        public void Train(List<List<double>> dataAllInput, int epochNumber)
        {            
            for (int i = 0; i < epochNumber; i++) //poczatek epoki
            {
                Console.WriteLine("Epoch number: " + i);
                MyExtension.Shuffle(dataAllInput);

                for (int j = 0; j < dataAllInput.Count; j++)  // nowy zestaw danych
                {
                    List<double> outputs = new List<double>();//wyjscia pierwszej warstwy = wejscia drugiej
                    //List<double> required;
                    List<double> errors =  new List<double>(); // roznica miedzy wyjsciem, a wartoscia oczekiwana
                    //double avgError = 0; // blad sredniokwadratowy dla jednego zestawu danych
                    List<double> deltaLastLayer = new List<double>(_lastLayer.Count);

                    for (int k = 0; k < _hiddenLayer.Count; k++)
                    { //obl wyjscia pierwszej warstwy
                        _hiddenLayer[k].CalculateOutput(dataAllInput[j]);
                        outputs.Add(_hiddenLayer[k].Output); //wpisanie wyjść do wektora
                    }

                    for (int k = 0; k < _lastLayer.Count; k++)
                    { //obl wyjscia drugiej warstwy
                        _lastLayer[k].CalculateOutput(outputs);
                        errors.Add(_lastLayer[k].Output - dataAllInput[j][k + 2]);
                        _lastLayer[k].CalcDeltaLastLayer(errors[k]); // obl b dla neuronow drugiej warstwy
                        deltaLastLayer.Add(_lastLayer[k].Delta); // wpisanie bledow do tablicy :c
                    }

                    for (int k = 0; k < _hiddenLayer.Count; k++) // obl b dla neuronow pierwszej warstwy
                    { 
                        List<double> tempWeights = new List<double>();

                        for (int w = 0; w < _lastLayer.Count; w++)
                        {
                            tempWeights.Add(_lastLayer[w].GetWeight(k));
                        }
                        _hiddenLayer[k].CalcDeltaHiddenLayer(deltaLastLayer, tempWeights, _lastLayer.Count);
                    }                    
                                        
                    for (int k = 0; k < _lastLayer.Count; k++)
                        _lastLayer[k].UpdateWeight(outputs); // zmiana wag w warstwie ostatniej


                    for (int k = 0; k < _hiddenLayer.Count; k++)
                        _hiddenLayer[k].UpdateWeight(dataAllInput[j]); // zmiana wag w warstwie ukrytej

                    //for (int k = 0; k < _lastLayer.Count; k++)
                    //{
                    //    avgError += Math.Pow(errors[i], 2);
                    //}
                    //avgError /= 2;
                   //epochError += avgError;

                    if (i == (epochNumber-1))
                    {
                        double error = Math.Sqrt(Math.Pow(_lastLayer[0].Delta, 2) + Math.Pow(_lastLayer[1].Delta, 2));
                        Console.WriteLine("error: " + Program.Denormalize(error));
                        _avgError.Add(Program.Denormalize(error)); // błąd pomiaru

                        for (int q = 0; q < 2; q++)
                        {
                            Console.WriteLine("Wejsciowe: "+ Program.Denormalize(dataAllInput[j][q+2]));
                            Console.WriteLine("Wyjsciowe: "+ Program.Denormalize(_lastLayer[q].Output));
                        }
                    }
                }
                
            }

        }




        //        private List<Layer> _layers;
        //        private List<Double> _distribution;

        //        public List<Layer> Layers { get => _layers; set => _layers = value; }
        //        private List<Double> Distribution { get => _distribution; set => _distribution = value; }

        //        public Network()
        //        {
        //            _layers = new List<Layer>();
        //        }

        //        public void AddLayer(Layer layer)
        //        { 
        //            int entryNumber = 1;

        //            if (_layers.Count > 0)
        //            {
        //                entryNumber = _layers.Last().Neurons.Count; 
        //            }

        //            foreach (var n in layer.Neurons)
        //            {
        //                for (int i = 0; i < entryNumber; i++)
        //                {
        //                    n.Entries.Add(new Entry());
        //                }
        //            }
        //            _layers.Add(layer);
        //        }

        //        public void BuildNetwork()
        //        {
        //            for (int i = 0; i < _layers.Count - 1; i++) // ok?
        //            {
        //                var nextLayer = _layers[i + 1];
        //                CreateNetwork(_layers[i], nextLayer);
        //            }
        //        }

        //        private void CreateNetwork(Layer connectingFrom, Layer connectingTo)
        //        {
        //            Random rand = new Random();
        //            for (int i = 0; i < connectingFrom.Neurons.Count; i++)
        //            {
        //                connectingFrom.Neurons[i].Entries.Add(new Entry());
        //            }
        //            for (int i = 0; i < connectingTo.Neurons.Count; i++)
        //            {
        //                for (int j = 0; j < connectingFrom.Neurons.Count; j++)
        //                {
        //                    connectingTo.Neurons[i].Entries.Add(new Entry() { Input = connectingFrom.Neurons[j].Output, Weight = rand.NextDouble() * (-2) + 1 });
        //                }
        //            }
        //        }

        //        public void PrintNewtork()
        //        {
        //            DataTable products = new DataTable();
        //            products.Columns.Add("Neurons");

        //            foreach (var element in Layers)
        //            {
        //                DataRow row = products.NewRow();
        //                //row[0] = element.Name;
        //                row[0] = element.Neurons.Count;

        //                products.Rows.Add(row);
        //            }

        //            //Console.WriteLine(products.Rows.Count);
        //            //Console.Write(products.Columns);
        //            foreach(var columns in products.Columns)
        //            {
        //                Console.Write(" " + columns);
        //            }
        //            Console.Write('\n');
        //            foreach (DataRow dataRow in products.Rows)
        //            {
        //                foreach (var item in dataRow.ItemArray)
        //                {
        //                    Console.Write(" " + item + "   ");
        //                }
        //                Console.Write('\n');
        //            }
        //        }

        //        public void CalculateOutput()
        //        {
        //            bool firstLayer = true;
        //            for (int i = 0; i < _layers.Count; i++)
        //            {
        //                if (firstLayer)
        //                {
        //                    firstLayer = false;
        //                    continue;
        //                }
        //                _layers[i].Forward(); 
        //            }
        //        }

        //        public void OptimizeWeights(double error)
        //        {
        //            double momentum = 0.0;
        //            double learningRate = 0.2;
        //            //Pomiń jeżeli accuracy osiągnęła 100%
        //            if (error < 0.001)
        //            {
        //                return;
        //            }

        //            if (error < 0)
        //            {
        //                learningRate = -learningRate;
        //            }

        //            //Update the weights for all the layers
        //            for (int i = 0; i < _layers.Count; i++)
        //            {
        //                _layers[i].CountWeights(momentum, learningRate);
        //            }
        //        }

        //        public void TrainNetwork(List<List<double>> Data, int iterations)
        //        {
        //            int epoch = 1;
        //            int numberOfWrongSamples = 0;

        //            while (iterations >= epoch)
        //            {
        //                Console.WriteLine("Epoch: " + epoch);

        //                MyExtension.Shuffle(Data);
        //                foreach (var xData in Data)
        //                {
        //                    Console.WriteLine();
        //                    foreach (var x in xData)
        //                        Console.Write("x: " + x + " ");
        //                }
        //                Console.WriteLine();

        //                var inputLayer = Layers[0];
        //                //List<double> outputs = new List<double>();

        //                //Forward dla jednego punktu
        //                for (int i = 0; i < Data.Count; i++)
        //                {
        //                    for (int j = 0; j < 2; j++)
        //                    {
        //                        inputLayer.Neurons[j].Output = Data[i][j];
        //                    }

        //                    CalculateOutput();
        //                    //  outputs.Add(Layers.Last().Neurons.First().Output);

        //                    //Obliczenie delty dla wszystkich neuronów, warstwami od końca
        //                        //Last layer
        //                    for (int k = 0; k < _layers.Last().Neurons.Count; k++)
        //                    {
        //                        _layers.Last().Neurons[k].Delta = Data[i][k + 2] - _layers.Last().Neurons[k].Output;
        //                    }
        //                        //Hidden Layer
        //                    for (int k = 0; k < _layers[1].Neurons.Count; k++)
        //                    {
        //                        double sum = 0.0;
        //                        for (int l = 0; l < _layers.Last().Neurons.Count; l++)
        //                        {
        //                            sum += _layers.Last().Neurons[l].Delta * _layers.Last().Neurons[l].Entries[k].DeltaWeight;
        //                        }
        //                        _layers[1].Neurons[k].Delta = sum;
        //                    }

        //                    //Obliczenie błędu
        //                    //_layers.Last().Neurons[k].Delta = Math.Sqrt(Math.Pow(Data[i][k + 2], 2) + Math.Pow(_layers.Last().Neurons[k].Output, 2));
        //                    double error = Math.Sqrt(Math.Pow(_layers.Last().Neurons[0].Delta,2) + Math.Pow(_layers.Last().Neurons[0].Delta, 2));

        //                    if(error < i) 
        //                    {
        //                        numberOfWrongSamples++; //to  jest to L chyba
        //                    }

        //                    //dystrybuanta
        //                    double Dys = numberOfWrongSamples / Data.Count;
        //                    _distribution.Add(Dys);

        //                    //Update weights
        //                    //OptimizeWeights();
        //                }
        //                epoch++;                
        //            }
        //        }      

    }
}
