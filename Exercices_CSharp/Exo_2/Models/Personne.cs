using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Exo_2.Models
{
    internal class Personne
    {
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        private DateTime _dateNaiss;

        public DateTime DateNaissance
        {
            get => _dateNaiss;

            set
            {
                DateTime maintenant = DateTime.Now;
                // contrôle si majeur
                if ((maintenant.Year - 18) >= value.Year)
                {
                    Console.WriteLine("Vous êtes majeur");
                }

            }
        }

        public override string ToString()
        {
            return $"{Nom} {Prenom}";
        }
    }
}
