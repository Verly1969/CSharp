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
        Dictionary<string, Courant> ListeCompte 
        { 
            get { return _listeCompte = _listeCompte ?? new Dictionary<string, Courant>() ; } 
        }

        public string this[string numero]
        {
            get
            {
                Courant? cpt = null;
                cpt = ListeCompte[numero];
                return cpt.ToString();
            }
        }

        public void Ajouter(Courant compte)
        {
            if (compte.Numero == null)
            {
                Console.WriteLine("Le compte n'a pas été trouvé !");
                return;
            }
            _listeCompte.Add(compte.Numero, compte);
        }

        public void Supprimer(Courant compte)
        {
            if (compte.Numero == null)
            {
                Console.WriteLine("Le compte n'a pas été trouvé !");
                return;
            }
            _listeCompte.Remove(compte.Numero);
        }
    }
}
