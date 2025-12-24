using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Enums;

namespace ToDoList.Structures
{
    internal struct Tache
    {
        private Dictionary<string, Tache> _taches = new Dictionary<string, Tache>();

        private int Numero = 0;

        public Tache()
        {
        }

        public string Titre { get; set; }
        public string Description { get; set; }

        public StatutTache Statut { get; set; }
        public DateTime DateCreation { get; set; }

        void AfficherToutesLesTaches()
        {
            string str = "";
            if (_taches.Count > 0)
            {
                foreach (KeyValuePair<string, Tache> tache in _taches)
                {
                    str += $"\n[{tache.Value.Numero}] Titre: {tache.Value.Titre}\n" +
                        $"\tDescription: {tache.Value.Description}\n" +
                        $"\tStatut: {tache.Value.Statut}\n" +
                        $"\tCréé le: {tache.Value.DateCreation}";
                }
            }
            else
            {
                str = "Aucune tâche dans la liste";
            }

        }

        void AjouterTache(string titre, string? description, StatutTache statut, DateTime dateCreation)
        {
            Numero += 1;
            Titre = titre;
            Description = description ?? "Pas de description";
            Statut = statut;
            DateCreation = DateTime.Now;
            _taches.Add(titre, new Tache {});
        }
    }
}
