using System;
using System.Collections.Generic;
using System.Text;

namespace Exo_2.Models
{
    internal class Banque
    {
        

        public Courant? Compte { get; private set; }
        public string Nom { get; set; } = string.Empty;

        private Dictionary<string, Courant> _listeCompte = new Dictionary<string, Courant>();

        public Courant? this[string numero]
        {
            get
            {
                if (numero == null) return null;
                if(!_listeCompte.ContainsKey(numero)) return null;
                return _listeCompte[numero];
            }
        }

        public void Ajouter(Courant compte)
        {
            if (compte == null) return;
            if (_listeCompte.ContainsKey(compte.Numero)) return;
            _listeCompte.Add(compte.Numero, compte);
            Console.WriteLine($"Le compte numéro {compte.Numero} a été ajouté.");
        }

        public void Supprimer(Courant compte)
        {
            if (compte.Numero == null) return;
            if (_listeCompte.Remove(compte.Numero))
            {
                Console.WriteLine($"Le compte numéro {compte.Numero} a bien été supprimé.");
            }
            else
            {
                Console.WriteLine($"Le compte {compte.Numero} n'a pas été supprimé.");
            }
        }

        public void AfficherListe()
        {
            foreach (KeyValuePair<string, Courant> cpt in _listeCompte)
            {
                Console.WriteLine($"\nNuméro de compte: {cpt.Key}\nTitulaire: {cpt.Value.Titulaire}\nSolde: {cpt.Value.Solde}");
            }
        }
    }
}
