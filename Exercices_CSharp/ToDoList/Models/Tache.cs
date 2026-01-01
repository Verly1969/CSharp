using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using ToDoList.Enums;

namespace ToDoList.Models
{
    public class Tache
    {
        private Dictionary<int, Tache> _taches = new Dictionary<int, Tache>();
        private int _key = 1;
        private string _name = string.Empty;
        private string? _description;
        private StatutTache _statut;
        private DateTime _dateDeCreation = DateTime.Now;

        public Tache()
        {
            _taches.Add(_key, new Tache("Sel", new DateTime(2016, 1, 18), "Sel pour Sombreffe"));
            _key++;
            _taches.Add(_key, new Tache("Technofutur", new DateTime(2018, 12, 26), "Tutoriel", StatutTache.Terminee));
            _key++;
            _taches.Add(_key, new Tache("CT", new DateTime(2025, 12, 12), "Contrôle technique pour A5", StatutTache.EnCours));
            _key++;
        }

        public Tache(string titre, DateTime dateDeCreation, string description = "Sans description", StatutTache statut = StatutTache.EnAttente) 
        {
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

            _taches.Add(_key, new Tache(_name, _dateDeCreation, _description, _statut));
            _key++;

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
            } while (result <= 0 || result > _taches.Count);

            _taches.Remove(result);
            Console.WriteLine($"La tâche numéro {result} à bien été supprimée.");
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
                            Console.WriteLine($"{i} {StatutTache.EnAttente}");
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine($"{i} {StatutTache.EnCours}");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"{i} {StatutTache.Terminee}");
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
            } while (statut < 0 || statut > 2);

            // Modification du statut sur la tâche
            if (_taches.TryGetValue(result, out Tache? value))
            {
                switch (statut)
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
    }
}
