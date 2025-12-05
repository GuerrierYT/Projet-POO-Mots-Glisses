using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_POO_Mots_Glisses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le jeu des mots glissés !");
            string mot = SaisirMot();
            Console.WriteLine($"Le mot saisi est : {mot}");
            Console.ReadLine();
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
            }
            while (mot.Length < 2 || estValide = false);
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
    }
}
