using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert the number of neurons in the hidden layer: ");
            int neuronsHiddenLayer = int.Parse(Console.ReadLine());

            // WCZYTANIE DANYCH Z PLIKU DO DWÓCH LIST X - INPUT, Y - REQUIRED

            List<List<double>> DataX = new List<List<double>>();
            List<List<double>> DataY = new List<List<double>>();

            
            Network _newtork = new Network();
            _newtork.AddLayer(new Layer(1));
            _newtork.AddLayer(new Layer(neuronsHiddenLayer));
            _newtork.AddLayer(new Layer(2));
            //_newtork.Layers.Add(new Layer(1));
            //_newtork.Layers.Add(new Layer(neuronsHiddenLayer));
            //_newtork.Layers.Add(new Layer(2));

            Console.WriteLine("Before training: ");
            _newtork.BuildNetwork();
            _newtork.PrintNewtork();

            _newtork.TrainNetwork(DataX, DataY, 100);

            Console.WriteLine("After training: ");
            _newtork.PrintNewtork();
            Console.ReadLine(); //żeby się konsola nie zamykała od razu
        }
    }
}
