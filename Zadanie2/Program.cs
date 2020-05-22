using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Zadanie2
{
    public class Program
    {

        static double normalizeMin = 0, normalizeMax = 6500, normalizeRange = 6500;
        static void Main(string[] args)
        {
            Console.WriteLine("Insert the number of neurons in the hidden layer: ");
            int neuronsHiddenLayer = int.Parse(Console.ReadLine());

            // WCZYTANIE DANYCH Z PLIKU DO DWÓCH LIST 
            List<List<double>> Data = new List<List<double>>();

            string[] lines = File.ReadAllLines("../../dane.txt");
            
            foreach (var line in lines)
            {
                List<double> X = new List<double>();
                var thirdColumnValues = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[3];
                var fourthColumnValues = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[4];
                var fifthColumnValues = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[5];
                var sixthColumnValues = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[6];
                double dataInput1 = double.Parse(thirdColumnValues, System.Globalization.CultureInfo.InvariantCulture);
                double dataInput2 = double.Parse(fourthColumnValues, System.Globalization.CultureInfo.InvariantCulture);
                double dataRequired1 = double.Parse(fifthColumnValues, System.Globalization.CultureInfo.InvariantCulture);
                double dataRequired2 = double.Parse(sixthColumnValues, System.Globalization.CultureInfo.InvariantCulture);
                X.Add(Normalize(dataInput1));
                X.Add(Normalize(dataInput2));
                X.Add(Normalize(dataRequired1));
                X.Add(Normalize(dataRequired2));
                Data.Add(X);
            }
            int epochNumber = 2000;
            Network network = new Network(neuronsHiddenLayer);

            network.DrawWeights();
            network.Train(Data, epochNumber);


            List<double> distribution = new List<double>();

            for(int i = 0; i < 1866; ++i)
            {
                double wrongSamples = 0.00d;
                for(int j = 0; j < network.AvgError.Count; ++j)
                {
                    if(network.AvgError[j] < i)
                    {
                        wrongSamples += 1.00d;
                    }
                }
                Console.WriteLine("samp: " + wrongSamples);
                distribution.Add(wrongSamples / Data.Count);
            }

            List<string> distString = new List<string>();
            for(int i = 0; i < distribution.Count; ++i)
            {
                distString.Add(distribution[i].ToString());
            }
            System.IO.File.WriteAllLines("../../Dystrybuanta.txt", distString);
   
            Console.ReadLine(); 
        }

        public static double Normalize(double x)
        {
            return (x - normalizeMin) / normalizeRange;
        }

        public static double Denormalize(double x)
        {
            return (x * normalizeRange) + normalizeMin;
        }
    }
}
