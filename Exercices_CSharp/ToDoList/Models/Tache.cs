using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Enums;

namespace ToDoList.Models
{
    public class Tache
    {
        private Dictionary<int, Tache> _taches = new Dictionary<int, Tache>();

        private int Number = 0;
        private string? Titre = null;
        private string Description = string.Empty;

        private StatutTache Statut;
        private DateTime DateCreation;

        public string AfficherToutesLesTaches()
        {
            string str = "";
            Console.Clear();
            Console.WriteLine("\nListe des tâches:");
            Console.WriteLine("=================");
            if (_taches.Count > 0)
            {
                foreach (KeyValuePair<int, Tache> tache in _taches)
                {
                    str += $"[{tache.Key}] Titre: {tache.Value.Titre}\n" +
                        $"\tDescription: {tache.Value.Description}\n" +
                        $"\tStatut: {tache.Value.Statut}\n" +
                        $"\tCréé le: {tache.Value.DateCreation}\n";
                }
            }
            else
            {
                AfficheMessage("\nAucune tâche dans la liste ...\n");
                Console.Clear();
            }

            return str;

        }

        public void AjouterTache()
        {
            /*Tache tache = new Tache();*/
            Number++;
            do
            {
                Console.WriteLine("Veuillez entrer un titre pour la tâche à faire enregistrer:");
                Titre = Console.ReadLine()!;
            } while (Titre == null || Titre == "");

            Console.WriteLine("Veuillez entrer une description (facultative)");
            Description = Console.ReadLine() ?? "Pas de description";
            Statut = StatutTache.EnAttente;
            DateCreation = DateTime.Now;
            _taches.Add(Number, new Tache{ Titre = Titre, Description = Description, Statut = Statut, DateCreation = DateCreation});
            AfficheMessage($"Vous avez ajouter la tâche: {Titre}\n");
        }

        public void AjouterTache(string titre, string description)
        {
            /*Tache tache = new Tache();*/
            Number++;
            Titre = titre;
            Description = description;
            Statut = StatutTache.EnAttente;
            DateCreation = DateTime.Now;
            _taches.Add(Number, new Tache { Titre = Titre, Description = Description, Statut = Statut, DateCreation = DateCreation });
            Console.WriteLine($"La tâche {Titre} a été ajouté ...");
        }

        public void AfficheMessage(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Pour continuer, tapez sur une touche ...");
            Console.ReadLine();
        }
    }
}
