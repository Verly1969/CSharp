using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using ToDoList.Enums;

namespace ToDoList.Models
{
    public class Tache
    {
        private Dictionary<int, Tache> _taches = new Dictionary<int, Tache>();
        private List<int> _keyList = new List<int>();
        private int _key = 1;
        private string _name = string.Empty;
        private string _description = "Sans description";
        private StatutTache _statut;
        private DateTime _dateDeCreation = DateTime.Now;

        public Tache()
        {
            _taches.Add(_key, new Tache(_key, "Sel", new DateTime(2016, 1, 18), "Sel pour Sombreffe"));
            _keyList.Add(_key);
            _key = _taches.Count + 1;

            _taches.Add(_key, new Tache(_key, "Technofutur", new DateTime(2018, 12, 26), "Tutoriel", StatutTache.Terminee));
            _keyList.Add(_key);
            _key = _taches.Count + 1;

            _taches.Add(_key, new Tache(_key, "CT", new DateTime(2025, 12, 12), "Contrôle technique pour A5", StatutTache.EnCours));
            _keyList.Add(_key);
            _key = _taches.Count + 1;
        }

        private Tache(int key, string titre, DateTime dateDeCreation, string description = "Sans description", StatutTache statut = StatutTache.EnAttente) 
        {
            _key = key;
            _name = titre;
            _description = description;
            _statut = statut;
            _dateDeCreation = dateDeCreation;
        }

        public void AfficherTaches()
        {
            string str = "";

            if (_taches.Count > 0)
            {
                foreach (KeyValuePair<int, Tache> tache in _taches)
                {
                    str += $"- [{tache.Key}] {tache.Value._name}:\n   {tache.Value._description}\n   {tache.Value._statut}\n   {tache.Value._dateDeCreation}\n";
                }
            }
            else
            {
                str = "Il n'y a pas de tâche dans la liste";
            }

            Console.WriteLine(str);
        }

        public void AjouterTache()
        {
            do
            {
                Console.WriteLine("Veuillez entrer le nom de la tâche");
                _name = Console.ReadLine()!;

            } while (_name == null || _name == string.Empty);

            Console.WriteLine("[optionnel] Veuillez entrer une description, sinon tapez sur 'Enter'");
            _description = Console.ReadLine()!;

            if (_description == null || _description == string.Empty)
            {
                _description = "Sans description";
            }

            _taches.Add(_key, new Tache(_key, _name, _dateDeCreation, _description, _statut));
            _keyList.Add(_key);
            _key = _taches.Count + 1;

            Console.WriteLine($"La tâche {_name} a bien été ajouté\n");
            Console.WriteLine("Pour continuer, tapez sur une touche ...");
            Console.ReadLine();
        }

        public void SupprimerTache()
        {
            AfficherTaches();
            int result = 0;
            int cpt = 0;
            do
            {
                do
                {
                    Console.WriteLine("Indiquez le numéro de la tâche a supprimer");
                    if (cpt > 0)
                    {
                        Console.WriteLine("La donnée entrée n'est pas correcte, vous devez entrer un numéro\n");
                    }
                    cpt++;
                } while (!int.TryParse(Console.ReadLine(), out result));
            } while (!_keyList.Contains(result));
            
            // Comfirmation
            int comfirm = 0;
            do
            {
                Console.WriteLine($"Vous allez supprimer la tâche {result} ?\nTapez 1 pour continuer\nTapez 0 pour annuler\n");
            } while (!int.TryParse(Console.ReadLine(), out comfirm) || comfirm < 0 || comfirm > 1);

            if (comfirm == 1)
            {
                _taches.Remove(result);
                _keyList.Remove(result);
                Console.WriteLine($"La tâche numéro {result} à bien été supprimée.");
            }
            else
            {
                Console.WriteLine("Opération de suppression annulée");
            }
            Console.WriteLine("Pour continuer, tapez sur une touche ...");
            Console.ReadLine();
        }

        public void ModifierStatut()
        {
            AfficherTaches();

            // Sélection de la tâche a modifier
            int result = 0;
            int cpt = 0;
            do
            {
                do
                {
                    Console.WriteLine("Indiquez le numéro de la tâche a modifier");
                    if (cpt > 0)
                    {
                        Console.WriteLine("La donnée entrée n'est pas correcte, vous devez entrer un numéro\n");
                    }
                    cpt++;
                } while (!int.TryParse(Console.ReadLine(), out result));
            } while (result <= 0 || result > _taches.Count);

            // Afficher la liste des statuts
            foreach (int i in Enum.GetValues<StatutTache>().Select(v => (int)v))
            {
                switch (i)
                {
                    case 0:
                        {
                            Console.WriteLine($"{i + 1} {StatutTache.EnAttente}");
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine($"{i + 1} {StatutTache.EnCours}");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"{i + 1} {StatutTache.Terminee}");
                            break;
                        }
                }
            }

            // Sélection du statut a appliquer
            cpt = 0;
            int statut;
            do
            {
                do
                {
                    Console.WriteLine("Indiquez le numéro du statut a appliquer");
                    if (cpt > 0)
                    {
                        Console.WriteLine("La donnée entrée n'est pas correcte, vous devez entrer un numéro\n");
                    }
                    cpt++;
                } while (!int.TryParse(Console.ReadLine(), out statut));
            } while (statut < 0 || statut > Enum.GetValues<StatutTache>().Length);

            // Modification du statut sur la tâche
            if (_taches.TryGetValue(result, out Tache? value))
            {
                switch (statut - 1)
                {
                    case 0:
                        {
                            value._statut = StatutTache.EnAttente;
                            break;
                        }
                    case 1:
                        {
                            value._statut = StatutTache.EnCours;
                            break;
                        }
                    case 2:
                        {
                            value._statut = StatutTache.Terminee;
                            break;
                        }
                }
                
            }
            Console.WriteLine($"Le statut de la tâche numéro {result} à bien été modifiée.");
            Console.WriteLine("Pour continuer, tapez sur une touche ...");
            Console.ReadLine();
        }

        public void RechercherTache()
        {
            /*
             * Demander un mot-clé de recherche
             * Rechercher dans les titres et descriptions (insensible à la casse)
             * Afficher toutes les tâches correspondantes
             */
            string motCle;
            string str = "";
            do
            {
                Console.WriteLine("Veuillez entrer un mot-clé pour la recherche ...");
                motCle = Console.ReadLine()!.ToLower();
            } while (motCle == null || motCle == "");

            foreach (Tache valeur in _taches.Values)
            {
                if (valeur._name.Contains(motCle, StringComparison.OrdinalIgnoreCase) ||
                    valeur._description.Contains(motCle, StringComparison.OrdinalIgnoreCase))
                {
                    str += $"- [{valeur._key}] {valeur._name}:\n   {valeur._description}\n   {valeur._statut}\n   {valeur._dateDeCreation}\n";
                }
            }

            /*foreach (KeyValuePair<int, Tache> tache in _taches) 
            { 
                if (tache.Value._name.Equals(motCle, StringComparison.OrdinalIgnoreCase) ||
                    tache.Value._description.Equals(motCle, StringComparison.OrdinalIgnoreCase))
                {
                    str += $"- [{tache.Key}] {tache.Value._name}:\n   {tache.Value._description}\n   {tache.Value._statut}\n   {tache.Value._dateDeCreation}\n";
                }
            }*/

            Console.WriteLine(str);
            Console.WriteLine("Pour continuer, tapez sur une touche ...");
            Console.ReadLine();

        }

        public void AfficherStatistique()
        {
            /*
             * Nombre total de tâches
             * Nombre de tâches par statut
             * Pourcentage de tâches terminées
             * Par exemple:
             * Total des tâches : 5
             * En attente : 2 ( 40 % )
             * En cours : 1 ( 20 % )
             * Terminées : 2 ( 40 % )
             */

            TotalTaches();
            TotalParStatut(StatutTache.EnAttente);
            TotalParStatut(StatutTache.EnCours);
            TotalParStatut(StatutTache.Terminee);
            Console.WriteLine("Pour continuer, tapez sur une touche ...");
            Console.ReadLine();
        }

        private void TotalTaches()
        {
            Console.WriteLine($"Total des tâches : {_taches.Count}");
        }

        private void TotalParStatut(StatutTache statut)
        {
            int nb = 0;
            foreach (Tache kvp in _taches.Values)
            {
                if (kvp._statut == statut)
                {
                    nb++; 
                }
            }

            int pourcentage = (int)((double)nb / _taches.Count * 100);

            Console.WriteLine($"{statut} : {nb} ( {pourcentage} % )");
            
        }
    }
}
