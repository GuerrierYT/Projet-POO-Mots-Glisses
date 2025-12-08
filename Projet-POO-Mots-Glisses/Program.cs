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
            string Espace = "                                        ";

            #endregion

            Console.WriteLine(ligne);
            Console.WriteLine(Espace + "Bienvenue dans le jeu des mots glissés !");
            Console.WriteLine(ligne);
            Console.WriteLine();

            #region Chargement du jeu
            Console.WriteLine(Espace + "Veuillez patienter pendant le chargement du jeu...");
            Dictionnaire dico = CreerETtrierDico();
            Console.WriteLine(dico.toString()); //Attention à ne pas faire ToString car ça retourne le dico en entier et très long à charger
            Console.WriteLine("Dictionnaire prêt !");

            #endregion

            string mot = SaisirMot();
            Console.WriteLine($"Le mot saisi est : {mot}");
            Console.WriteLine(dico.RechDichoRecursif(mot));
            Console.ReadKey();
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
                if(estValide == false)
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