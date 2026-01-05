using System;
using System.Collections.Generic;
using System.Text;

namespace CarWash.Models
{
    public class Voiture
    {
        public string Plaque { get; init; }
        public Voiture(string plaque)
        {
            Plaque = plaque;
        }
    }
}
