using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Entry
    {
        private double _input;
        private double _weight;

        public double Input { get => _input; set => _input = value; }
        public double Weight { get => _weight; set => _weight = value; }

        //public Entry(double input)
        //{
        //    _input = input;
        //    _weight = new Random().NextDouble() * (-2) - 1;
        //}
    }
}
