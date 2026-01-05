using System;
using System.Collections.Generic;
using System.Text;

namespace CarWash.Models
{
    internal class CarWashV2
    {
        public delegate void CarWashV2Delegate(Voiture voiture);

        private CarWashV2Delegate _carWashV2Delegate = null; // renvoie par défaut null

        public CarWashV2()
        {
            // version simplifliée 
            _carWashV2Delegate += delegate (Voiture v) { Console.WriteLine($"Je prépare la voiture {v.Plaque}"); };
            _carWashV2Delegate += (Voiture v) => { Console.WriteLine($"Je lave la voiture {v.Plaque}"); };
            _carWashV2Delegate += (Voiture v) => Console.WriteLine($"Je sèche la voiture {v.Plaque}");
            _carWashV2Delegate += v => Console.WriteLine($"Je finalise la voiture {v.Plaque}\n");
        }

        public void Traiter(Voiture v) 
        {
            // vérifier que le délégué n'est pas null et invocation des méthodes
            _carWashV2Delegate?.Invoke(v);
        }
    }
}
