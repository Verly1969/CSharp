using Exo_1.Models;

namespace Exo_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime maintenant = DateTime.Now;
            Console.WriteLine($"{maintenant.Year}");
            Console.WriteLine("Entrez l'année de votre naissance:");
            int annee = int.Parse( Console.ReadLine()! );
            Console.WriteLine("Entrez le mois de votre naissance:");
            int mois = int.Parse( Console.ReadLine()! );
            Console.WriteLine("Entrez le jour de votre naissance");
            int jour = int.Parse( Console.ReadLine()! ) ;

            DateTime test = new DateTime(annee, mois,jour);

            if((maintenant.Year - 18) >= test.Year)
            {
                Console.WriteLine("Vous êtes majeur");
            }
            else
            {
                Console.WriteLine("Vous êtes mineur");
            }
        }
    }
}
