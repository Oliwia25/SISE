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
        private double _deltaWeight;

        public double Input { get => _input; set => _input = value; }
        public double Weight { get => _weight; set => _weight = value; }
        public double DeltaWeight { get => _deltaWeight; set => _deltaWeight = value; }
    }
}
