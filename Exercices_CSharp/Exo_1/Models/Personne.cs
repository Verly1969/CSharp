using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_1.Models
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
                DateTime dateTest = maintenant.AddYears(-18);
                // contrôle si majeur

            }
        }
    }
}
