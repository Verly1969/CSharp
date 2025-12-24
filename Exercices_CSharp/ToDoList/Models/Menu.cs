using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Structures;

namespace ToDoList.Models
{
    internal struct Menu
    {
        internal void AfficheMenu()
        {
            Tache tache = new Tache();
            int result = 0;
            do
            {
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
                    /*System.Environment.Exit(0);*/
                    break;
                case 1:
                    Console.WriteLine("Afficher toutes les tâches");
                    break;
                case 2:
                    Console.WriteLine("Ajouter une nouvelle tâche");
                    break;
                case 3:
                    Console.WriteLine("Modifier le statut d'une tâche");
                    break;
                case 4:
                    Console.WriteLine("Supprimer une tâche");
                    break;
                case 5:
                    Console.WriteLine("Rechercher une tâche");
                    break;
                case 6:
                    Console.WriteLine("Afficher les statistiques");
                    break;
                default:
                    Console.WriteLine("Le numéro ne correspond pas au menu");
                    Console.Clear();
                    Console.Beep();
                    Console.Clear();
                    AfficheMenu();
                    break;

            }

        }

    }
}
