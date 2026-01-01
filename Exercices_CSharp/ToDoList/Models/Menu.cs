using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Models
{
    public struct Menu
    {
        Tache tache = new Tache();

        public Menu()
        {
        }

        public void AfficheMenu()
        {
            int result = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(" === GESTIONNAIRE DE TACHES ===\n" +
                " 1 . Afficher toutes les tâches\n" +
                " 2 . Ajouter une nouvelle tâche\n" +
                " 3 . Modifier le statut d'une tâche\n" +
                " 4 . Supprimer une tâche\n" +
                " 5 . Rechercher une tâche\n" +
                " 6 . Afficher les statistiques\n" +
                " 0 . Quitter\n" +
                "\tFaites votre choix:");

            } while (!int.TryParse(Console.ReadLine(), out result));

            switch (result)
            {
                case 0:
                    Console.WriteLine("\n\tFermeture de l'application\n");
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Liste des tâches");
                    Console.WriteLine("================\n");
                    tache.AfficherTaches();
                    Console.WriteLine("Pour continuer, tapez sur une touche ...");
                    Console.ReadLine();
                    AfficheMenu();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Ajouter une nouvelle tâche");
                    Console.WriteLine("==========================\n");
                    tache.AjouterTache();
                    AfficheMenu();
                    break;
                case 3:
                    Console.WriteLine("Modifier le statut d'une tâche");
                    Console.WriteLine("==============================\n");
                    tache.ModifierStatut();
                    AfficheMenu();
                    break;
                case 4:
                    Console.WriteLine("Supprimer une tâche");
                    Console.WriteLine("===================");
                    tache.SupprimerTache();
                    AfficheMenu();
                    break;
                case 5:
                    Console.WriteLine("Rechercher une tâche");
                    Console.WriteLine("====================");
                    break;
                case 6:
                    Console.WriteLine("Afficher les statistiques");
                    Console.WriteLine("=========================");
                    break;
                default:
                    Console.Beep();
                    Console.WriteLine("Le numéro ne correspond pas au menu");
                    Console.WriteLine("Pour continuer, tapez sur une touche ...");
                    Console.ReadLine();
                    AfficheMenu();
                    break;

            }

        }

    }
}
