using Exo_2.Models;

namespace Exo_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Création de personne
            Personne p1 = new Personne { Nom = "VERLY", Prenom = "Eddy", DateNaissance = new DateTime(1969, 11, 26) };
            Personne p2 = new Personne { Nom = "MERCY", Prenom = "Pascal", DateNaissance = new DateTime(1966, 9, 21) };

            Console.WriteLine("Affichage des personnes:");
            Console.WriteLine(p1);
            Console.WriteLine(p2);

            // Création de compte
            Courant c1 = new Courant { Titulaire = p1, Numero = "0001", LigneDeCredit = 500 };
            Courant c2 = new Courant { Titulaire = p2, Numero = "0002", LigneDeCredit = 0 };

            Console.WriteLine("Affichage des comptes:");
            Console.WriteLine(c1);
            Console.WriteLine(c2);
        }
    }
}
