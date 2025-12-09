using System;
using System.CodeDom.Compiler;
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
            int choix;
            do
            {
                choix = QueFaire(espace, dico);

                if (choix == 1)
                {
                    Lettre lettre = new Lettre();
                    Jeu jeu = new Jeu();

                    #region création personnage
                    Console.WriteLine(ligne + "\n");
                    Console.WriteLine(espace + "Creation des personnages...\n" + espace);
                    Console.WriteLine("Nommez le joueur 1 :");
                    string nomJ1 = Console.ReadLine();
                    string nomJ2 = nomJ1;
                    do
                    {
                        Console.WriteLine("Nommez le joueur 2 :");
                        nomJ2 = Console.ReadLine();
                        if (nomJ2 == nomJ1)
                        {
                            Console.WriteLine("Le nom du joueur 2 ne peut pas être identique à celui du joueur 1. Veuillez choisir un autre nom.");
                        }
                    }
                    while (nomJ2 == nomJ1);
                    #endregion

                    Console.WriteLine("\n" + ligne + "\n");

                    #region Plateau
                    int plateau = ChoixPlateau();
                    switch (plateau)
                    {
                        case 1:
                            Plateau plateau1 = new Plateau("plateau1.csv");
                            jeu = new Jeu(dico, plateau1, nomJ1, nomJ2);
                            break;
                        case 2:
                            Plateau plateau2 = new Plateau("plateau2.csv");
                            jeu = new Jeu(dico, plateau2, nomJ1, nomJ2);
                            break;
                        case 3:
                            Plateau plateauAleatoire = new Plateau(lettre);
                            jeu = new Jeu(dico, plateauAleatoire, nomJ1, nomJ2);
                            break;
                    }
                    jeu.LancerJeu();
                }
            }
            while (choix != 5);

            Console.WriteLine("\nMerci d'avoir utilisé le programme. Au revoir !");
            Console.ReadKey();

        }

        #endregion

        #region Création du plateau
        //Lettre lettre = new Lettre();
        //Plateau plateau = new Plateau(lettre);
        //Plateau plateau = new Plateau("plateautest.csv");
        //Console.WriteLine(plateau);
        //plateau.RechercheMot("BONJOUR");
        //plateau.WriteFile("plateautest.csv");
        #endregion
        /*
        Console.WriteLine("Bienvenue dans le jeu des mots glissés !");
        string mot = SaisirMot();
        Console.WriteLine($"Le mot saisi est : {mot}");
        Console.WriteLine(dico.RechDichoRecursif(mot));
        Console.ReadKey();
        */

        #endregion

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
            Console.WriteLine("\nQue souhaitez-vous faire ?\n");
            Console.WriteLine(espace + "1) Démarrer le jeu.");
            Console.WriteLine(espace + "2) Afficher les caractéristiques du dictionnaire.");
            Console.WriteLine(espace + "3) Rechercher un mot dans le dictionnaire.");
            Console.WriteLine(espace + "4) Afficher le dictionnaire. (attention, prend beaucoup de temps à charger)");
            Console.WriteLine(espace + "5) Quitter le programme.");
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
            while (rep < 0);
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

                case 5:
                    break;

                default:
                    Console.WriteLine("Choix invalide.");
                    rep = -1;
                    break;
            }
            return rep;
        }

 

        static int ChoixPlateau()       //Retourne 1, 2 ou 3
        {
            Console.WriteLine("Choississez un plateau à utiliser : ");
            Console.WriteLine("1) Plateau 1");
            Console.WriteLine("2) Plateau 2");
            Console.WriteLine("3) Plateau aléatoire");
            int choix = 0;
                do
            {
                choix = SaisirNombrePositif();
            }
            while (choix < 1 || choix > 3);
            return choix;
        }

        static int SaisirNombrePositif()    //Utiliser un Console.WriteLine avant !!
        {
            int rep = -1;
            do
            {
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
            while (rep < 0);
            return rep;
        }

        #region Saisie et validation du mot
        static string SaisirMot()
        {
            string mot;
            bool estValide = false;
            do
            {
                Console.WriteLine("Veuillez saisir un mot d'au moins 2 lettres :");
                mot = Console.ReadLine();
                estValide = EstMotValide(mot);
                if (estValide == false)
                {
                    Console.WriteLine("Le mot ne doit contenir que des lettres.");
                }
            }
            while (mot.Length < 2 || estValide == false);
            return mot.ToUpper();
        }
        static bool EstMotValide(string mot)
        {
            foreach (char c in mot)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #endregion

    }
}