using Exo_1.Enums;
using Exo_1.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_1.Models
{
    internal class Courant
    {
        private Messages amountSup = Messages.AMOUNT_SUP_ZERO;
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
                DisplayMessages.
            }
            while (montant <= 0);
        }
    }
}
