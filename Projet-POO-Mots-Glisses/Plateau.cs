using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projet_POO_Mots_Glisses
{
    internal class Plateau
    {
        #region Attributs
        private char[,] plateau;
        private int taille = 10;
        #endregion

        #region Constructeurs
        public Plateau(string filename) // Lecture du plateau depuis un fichier
        {
            ReadFile(filename);
        }
        public Plateau(Lettre lettre) // Création d'un plateau aléatoire en fonction de Lettres.txt
        {
            Random random = new Random();
            plateau = new char[taille, taille];
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    plateau[i, j] = lettre.LettreAleatoire();
                    Thread.Sleep(2);
                }
            }
        }
        #endregion

        #region Propriétés
        #endregion

        #region Méthodes
        public void WriteFile(string filename) // Écriture du plateau dans un fichier
        {
            StreamWriter flux = null;
            try
            {
                flux = new StreamWriter(filename);
                for (int i = 0; i < taille; i++)
                {
                    for (int j = 0; j < taille; j++)
                    {
                        flux.Write(plateau[i, j]);
                        if (j < taille - 1)
                            flux.Write(";");
                    }
                    flux.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (flux != null)
                    flux.Close();
            }
        }
        private void ReadFile(string filename) // Lecture du plateau depuis un fichier
        {
            StreamReader flux = null;
            string line;
            int i = 0;
            char[] sep = { ';' };
            plateau = new char[taille, taille];
            try
            {
                flux = new StreamReader(filename);
                while ((line = flux.ReadLine()) != null && i < taille)
                {
                    char[] lettres = line.Split(sep).Select(s => Convert.ToChar(s)).ToArray();
                    for (int j = 0; j < 8 && j < lettres.Length; j++)
                    {
                        plateau[i, j] = lettres[j];
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (flux != null)
                    flux.Close();
            }
        }
        public void RechercheMot(string mot)
        {

        }
        public override string ToString() // Affichage du plateau
        {
            string result = "";
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    result += plateau[i, j] + " ";
                }
                result += "\n";
            }
            return result;
        }
        #endregion  
    }
}
