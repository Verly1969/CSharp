using Exo_1.Models;

namespace Exo_1
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Personne p1 = new Personne{ Nom = "VERLY", Prenom = "Eddy", DateNaissance = new DateTime(1969, 11, 26)};
            Courant c1 = new Courant { Titulaire = p1, Numero = "0005", LigneDeCredit = 500 };

            Console.WriteLine(c1);
        }
    }
}
