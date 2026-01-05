using System;
using System.Collections.Generic;
using System.Text;

namespace CarWash.Models
{
    public delegate void WashDelegate(Voiture voiture);
    internal class CarWash
    {
        private WashDelegate? _wash = null;

        public CarWash()
        {
            _wash += Preparer;
            _wash += Laver;
            _wash += Secher;
            _wash += Finaliser;
        }
        private void Preparer(Voiture v)
        {
            Console.WriteLine($"Je prépare la voiture {v.Plaque}");
        }

        private void Laver(Voiture v)
        {
            Console.WriteLine($"Je lave la voiture {v.Plaque}");
        }

        private void Secher(Voiture v)
        {
            Console.WriteLine($"Je sèche la voiture {v.Plaque}");
        }

        private void Finaliser(Voiture v)
        {
            Console.WriteLine($"Je finalise la voiture {v.Plaque}\n");
        }

        public void Traiter(Voiture v)
        {
            _wash?.Invoke(v);
        }
    }
}
