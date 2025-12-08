using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

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
        public List<int> AppartientBase(string mot) // Vérifie si le mot appartient à une base de départ (la première ligne)
        {
            List<int> positions = new List<int>();
            for (int j = 0; j < taille; j++)
            {
                if (plateau[taille - 1, j] == mot[0])
                {
                    positions.Add(j);
                }
            }
            return positions;
        }
        public Stack<(int, int, int)> RechercheMot(string mot) // A finir
        {
            List<int> depart = AppartientBase(mot);
            if (depart.Count == 0)
            {
                Console.WriteLine("Le mot ne peut pas commencer, il n'y a pas de lettre de départ correspondante.");
                return null;
            }
            Stack<(int, int, int)> position = new Stack<(int, int, int)>();
            for (int i = 0; i < depart.Count; i++) // Pour chaque position de départ possible
            {
                if (position.Count != mot.Length) // Si le mot n'a pas encore été trouvé
                {
                    Console.WriteLine("Recherche du mot à partir de la position de départ en colonne " + depart[i]);
                    {
                        position.Push((taille - 1, depart[i], 0)); // On empile la position de départ (ligne, colonne, 0)
                        while (position.Count < mot.Length && position.Count > 0) // Tant que la pile n'est pas vide et que le mot n'est pas entièrement trouvé
                        {
                            int x = position.Peek().Item1; // Ligne actuelle
                            int y = position.Peek().Item2; // Colonne actuelle
                            int dir = position.Peek().Item3; // Direction déjà explorée
                            int j = position.Count; // Index de la lettre à chercher dans le mot
                            if (x > 0 && plateau[x, y] == mot[j])
                            {
                                Console.WriteLine("Lettre trouvée : " + mot[j] + " à la position (" + x + ", " + y + ")");
                                position.Push((x - 1, y, 1)); // On empile la nouvelle position (ligne - 1, même colonne, 1)
                            }
                            else if (x < taille - 1 && plateau[x + 1, y] == mot[j])
                            {
                                Console.WriteLine("Lettre trouvée : " + mot[j] + " à la position (" + (x + 1) + ", " + y + ")");
                                position.Push((x + 1, y, 2)); // On empile la nouvelle position (ligne + 1, même colonne, 2)
                            }
                            else if (y > 0 && plateau[x, y - 1] == mot[j])
                            {
                                Console.WriteLine("Lettre trouvée : " + mot[j] + " à la position (" + x + ", " + (y - 1) + ")");
                                position.Push((x, y - 1, 3)); // On empile la nouvelle position (même ligne, colonne - 1, 3)
                            }
                            else
                            {
                                Console.WriteLine("Lettre non trouvée : " + mot[j]);
                                position.Pop(); // On dépile la position actuelle car aucune direction n'a fonctionné
                            }
                        }
                    }
                }
            }


            return position;
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
