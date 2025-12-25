using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Enums;

namespace ToDoList.Models
{
    internal class Tache
    {
        private Dictionary<int, Tache> _taches = new Dictionary<int, Tache>();

        private int Number = 0;
        private string Titre = string.Empty;
        private string Description = string.Empty;

        private StatutTache Statut;
        private DateTime DateCreation;

        private Menu menu = new Menu();

        public string AfficherToutesLesTaches()
        {
            string str = "";
            if (_taches.Count > 0)
            {
                foreach (KeyValuePair<int, Tache> tache in _taches)
                {
                    str += $"\n[{tache.Key}] Titre: {tache.Value.Titre}\n" +
                        $"\tDescription: {tache.Value.Description}\n" +
                        $"\tStatut: {tache.Value.Statut}\n" +
                        $"\tCréé le: {tache.Value.DateCreation}";
                }
            }
            else
            {
                AfficheMessage("Aucune tâche dans la liste ...");
                Console.Clear();
                menu.AfficheMenu();
            }

            return str;

        }

        public void AjouterTache()
        {
            Tache tache = new Tache();
            tache.Number = Number += 1;
            do
            {
                Console.WriteLine("Veuillez entrer un titre pour la tâche à faire enregistrer:");
                tache.Titre = Console.ReadLine()!;
            } while (Console.ReadLine() == null);

            Console.WriteLine("Veuillez entrer une description (facultative)");
            tache.Description = Console.ReadLine() ?? "Pas de description";
            tache.Statut = StatutTache.EnAttente;
            tache.DateCreation = DateTime.Now;
            _taches.Add(tache.Number, tache);
            AfficheMessage($"Vous avez ajouter la tâche: {tache.Titre}\n");
        }

        public void AfficheMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Pour continuer, tapez sur une touche ...");
            Console.ReadLine();
        }
    }
}
