using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            List<List<double>> TestDataX = new List<List<double>>();
            List<List<double>> DataY = new List<List<double>>();
            List<List<double>> TestDataY = new List<List<double>>();

            List<double> X = new List<double>();
            List<double> Y = new List<double>();
            string[] lines = File.ReadAllLines("../Zadanie2/test.TXT");
            //string firstValue;
            foreach (var line in lines)
            {
                var firstColumnValues = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[0];
                var secondColumnValues = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1];
                double dataX = double.Parse(firstColumnValues, System.Globalization.CultureInfo.InvariantCulture);
                double dataY = double.Parse(secondColumnValues, System.Globalization.CultureInfo.InvariantCulture);
                X.Add(dataX);
                Y.Add(dataY);
                //Console.WriteLine(X);
            }

            TestDataX.Add(X);
            TestDataY.Add(Y);
            foreach (var xData in TestDataX)
            {
                foreach(var x in xData)
                {
                    Console.WriteLine("X: " + x);
                }
               
            }

            foreach (var yData in TestDataY)
            {
                foreach (var y in yData)
                {
                    Console.WriteLine("Y: " + y);
                }

            }




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
