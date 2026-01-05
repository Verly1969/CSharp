using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_2.Models
{
    internal class Courant
    {
        public string Numero { get; set; } = string.Empty;
        public double Solde { get; private set; }
        public required Personne Titulaire { get; set; }

        private double _ligneDeCredit;

        public double LigneDeCredit
        {
            get => _ligneDeCredit;

            set
            {
                MessageMontantSup0(value);
            }
        }

        public void Depot(double montant)
        {
            MessageMontantSup0(montant);
            Solde += montant;
        }

        public void Retrait(double montant)
        {
            MessageMontantSup0(montant);
            // check if the amount can be debited
            while (montant > (Solde + _ligneDeCredit))
            {
                Console.WriteLine("Le montant du retrait est trop élevé");
            }
        }

        /// <summary>
        /// procedure to check if the amount is indeed greater than 0
        /// </summary>
        /// <param name="montant"></param>
        private void MessageMontantSup0(double montant)
        {
            do
            {
                Console.WriteLine("Le montant doit être supérieur à 0");
            }
            while (montant <= 0);
        }

        public override string ToString()
        {
            return $"\nTitulaire: {Titulaire}\nNuméro: {Numero}\nLigne de crédit: {LigneDeCredit} euros\nSolde: {Solde} euros\n";
        }
    }
}
