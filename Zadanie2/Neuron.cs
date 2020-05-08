﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Neuron
    {
        private List<Entry> _entries;
        private double _output;
        private double _weight;

        public Neuron()
        {
            Entries = new List<Entry>();
        }

        public double Output { get => _output; set => _output = value; }
        internal List<Entry> Entries { get => _entries; set => _entries = value; }

        public void UpdateWeights(double newWeight)
        {
            for (int i = 0; i < _entries.Count; i++)
            {
                _entries[i].Weight = newWeight;
            }
        }
        public void CountWeight(double learningRate, double delta)//korekta wag;to chyba nie będzie używane na rzecz tego UpdateWeights ale nwm to na razie zostawiam
        {
            _weight += learningRate * delta;
            foreach (var e in Entries)
            {
                e.Weight = _weight;
            }
        }

        public double Sum()
        {
            double result = 0.0;
            foreach(var e in Entries)
            {
                result += e.Input * e.Weight; //pobudzenie neuronu
            }
            return result;
        }

        public double Activation(double input) //progowa/schodkowa(treshold) funkcja aktywacji z wyjściem binarnym {0,1} (unipolarna)
        {
            double treshold = 1;
            if (input >= treshold)
            {
                return 0; //nie aktywowana
            }
            else
                return treshold; //aktywowana
        }

        public void Fire()
        {
            _output = Sum();
            _output = Activation(_output);
        }

       
    }
}
