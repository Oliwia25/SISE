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
                    List<double> errors =  new List<double>(); // roznica miedzy wyjsciem, a wartoscia oczekiwana
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

    }
}
