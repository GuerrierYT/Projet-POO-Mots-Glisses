using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_POO_Mots_Glisses
{
    internal class Program  // Le main
    {
        #region Main
        static void Main(string[] args)
        {
            #region Mise en forme
            string ligne = "----------------------------------------------------------------------------------------------------------------------";
            string espace = "                                        ";

            #endregion

            Console.WriteLine(ligne);
            Console.WriteLine(espace + "Bienvenue dans le jeu des mots glissés !");
            Console.WriteLine(ligne);
            Console.WriteLine();

            #region Chargement du jeu
            Console.WriteLine(espace + "Veuillez patienter pendant le chargement du jeu...");
            Dictionnaire dico = CreerETtrierDico();
            Console.WriteLine("Dictionnaire prêt !");
            Console.WriteLine();

            int choix = QueFaire(espace, dico);

            if (choix != 1)
            {
                Console.WriteLine("\nMerci d'avoir utilisé le programme. Au revoir !");
                return;
            }
            else
            {

                Console.WriteLine(ligne + "\n");
                Console.WriteLine(espace + "Creation des personnages...\n" + espace);
                Console.WriteLine("Nommez le joueur 1 :");
                string nomJ1 = Console.ReadLine();
                Console.WriteLine("Nommez le joueur 2 :");
                string nomJ2 = Console.ReadLine();
                Jeu jeu = new Jeu(dico, null, nomJ1, nomJ2);

            }

            #endregion

            #region Création du plateau
            //Lettre lettre = new Lettre();
            //Plateau plateau = new Plateau(lettre);
            Plateau plateau = new Plateau("plateautest.csv");
            Console.WriteLine(plateau);
            plateau.RechercheMot("BONJOUR");
            //plateau.WriteFile("plateautest.csv");
            #endregion
            /*
            Console.WriteLine("Bienvenue dans le jeu des mots glissés !");
            string mot = SaisirMot();
            Console.WriteLine($"Le mot saisi est : {mot}");
            Console.WriteLine(dico.RechDichoRecursif(mot));
            Console.ReadKey();
            */
        }
        #endregion

        #region methodes

        static Dictionnaire CreerETtrierDico()
        {
            Dictionnaire dictionnaire = new Dictionnaire("Dictionnaire Français");
            Console.WriteLine("Lecture du fichier terminé");
            dictionnaire.Tri_Fusion();
            Console.WriteLine("Tri terminé");
            return dictionnaire;
        }

        static int QueFaire(string espace, Dictionnaire dico)
        {
            int rep = 0;
            Console.WriteLine("Que souhaitez-vous faire ?\n");
            Console.WriteLine(espace + "1) Démarrer le jeu.");
            Console.WriteLine(espace + "2) Afficher les caractéristiques du dictionnaire.");
            Console.WriteLine(espace + "3) Rechercher un mot dans le dictionnaire.");
            Console.WriteLine(espace + "4) Afficher le dictionnaire. (attention, prend beaucoup de temps à charger)");
            do
            {
                Console.WriteLine("\nVotre choix : ");
                string choix = Console.ReadLine();
                try
                {
                    rep = Convert.ToInt32(choix);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Veuillez entrer un nombre valide.");
                }
            }
            while (rep < 1 || rep > 4);
            switch (rep)
            {

                case 1: // Démarrer le jeu
                    Console.WriteLine("Démarrage du jeu...");
                    break;
                case 2: // Afficher les caractéristiques du dictionnaire
                    Console.WriteLine(dico.toString());
                    break;
                case 3: // Rechercher un mot dans le dictionnaire
                    string mot = SaisirMot();
                    bool trouve = dico.RechDichoRecursif(mot);
                    if (trouve)
                    {
                        Console.WriteLine($"Le mot \"{mot}\" a été trouvé dans le dictionnaire.");
                    }
                    else
                    {
                        Console.WriteLine($"Le mot \"{mot}\" n'a pas été trouvé dans le dictionnaire.");
                    }
                    break;
                case 4: // Afficher le dictionnaire
                    Console.WriteLine(dico.ToString());
                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    break;

                    return rep;
            }

        }



        #endregion
    }
}