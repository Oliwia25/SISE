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

            // WCZYTANIE DANYCH Z PLIKU DO DWÓCH LIST 
            List<List<double>> Input = new List<List<double>>();
            List<List<double>> Required = new List<List<double>>();

            string[] lines = File.ReadAllLines("../../test.txt");
            
            foreach (var line in lines)
            {
                List<double> X = new List<double>();
                List<double> Y = new List<double>();
                var thirdColumnValues = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
                var fourthColumnValues = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
                var fifthColumnValues = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
                var sixthColumnValues = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[6];
                double dataInput1 = double.Parse(thirdColumnValues, System.Globalization.CultureInfo.InvariantCulture);
                double dataInput2 = double.Parse(fourthColumnValues, System.Globalization.CultureInfo.InvariantCulture);
                double dataRequired1 = double.Parse(fifthColumnValues, System.Globalization.CultureInfo.InvariantCulture);
                double dataRequired2 = double.Parse(sixthColumnValues, System.Globalization.CultureInfo.InvariantCulture);
                X.Add(dataInput1);
                X.Add(dataInput2);
                Input.Add(X);

                Y.Add(dataRequired1);
                Y.Add(dataRequired2);
                Required.Add(Y);
            }

            //foreach (var xData in Input)
            //{
            //    Console.WriteLine();
            //    foreach (var x in xData)
            //        Console.Write("x: " + x + " ");               
            //}
            //Console.WriteLine();
            //foreach (var yData in Required)
            //{
            //    Console.WriteLine();
            //    for (int i = 0; i < 2; i++)
            //        Console.Write("x: " + yData[i] + " ");
            //}

            Network _newtork = new Network();
            _newtork.AddLayer(new Layer(2));
            _newtork.AddLayer(new Layer(neuronsHiddenLayer));
            _newtork.AddLayer(new Layer(2));
            //_newtork.Layers.Add(new Layer(1));
            //_newtork.Layers.Add(new Layer(neuronsHiddenLayer));
            //_newtork.Layers.Add(new Layer(2));
            
            Console.WriteLine();
            Console.WriteLine("Before training: ");
            _newtork.BuildNetwork();
            _newtork.PrintNewtork();

            _newtork.TrainNetwork(Input, Required, 2);

            Console.WriteLine("After training: ");
            _newtork.PrintNewtork();
            Console.ReadLine(); //żeby się konsola nie zamykała od razu
        }
    }
}
