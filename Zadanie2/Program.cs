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
            int neuronsHiddenLayer = int.Parse(Console.ReadLine());

            //tests
            Network _newtork = new Network();
            _newtork.Layers.Add(new Layer(1));
            _newtork.Layers.Add(new Layer(neuronsHiddenLayer));
            _newtork.Layers.Add(new Layer(1));

            _newtork.BuildNetwork();
            _newtork.PrintNewtork();

            Console.ReadLine(); //żeby się konsola nie zamykała od razu
        }
    }
}
