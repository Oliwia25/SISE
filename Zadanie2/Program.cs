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
            //tests
            Network _newtork = new Network();
            _newtork.Layers.Add(new Layer(2, 0.1, "INPUT"));
            _newtork.Layers.Add(new Layer(2, 0.1, "HIDDEN"));
            _newtork.Layers.Add(new Layer(1, 0.1, "OUTPUT"));

            _newtork.BuildNetwork();
            _newtork.PrintNewtork();

            Console.ReadLine(); //żeby się konsola nie zamykała od razu
        }
    }
}
