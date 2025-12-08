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
        public Stack<(int, int, int)> RechercheMot(string mot)
        {
            List<int> depart = AppartientBase(mot); // Positions de départ possibles

            if (depart.Count == 0)
            {
                Console.WriteLine("Le mot ne peut pas commencer, il n'y a pas de lettre de départ correspondante.");
                return null;
            }
            Stack<(int, int, int)> positions = new Stack<(int, int, int)>(); // Pile pour stocker les positions (ligne, colonne, direction)

            for (int i = 0; i < depart.Count; i++) // Pour chaque position de départ possible
            {
                positions.Clear();
                positions.Push((taille - 1, depart[i], 0)); // On empile la position de départ : Ligne, Colonne, Direction (0 = rien testé)

                while (positions.Count > 0 && positions.Count < mot.Length) // Tant qu'on a des positions à explorer et qu'on n'a pas trouvé tout le mot
                {
                    var (x, y, dir) = positions.Pop(); // On récupère l'élément du haut sans le retirer définitivement pour l'instant
                    dir++;

                    if (dir <= 3)
                    {
                        positions.Push((x, y, dir)); // On remet l'élément avec sa nouvelle direction
                        int nextX = x;
                        int nextY = y;

                        switch (dir)
                        {
                            case 1: nextY = y - 1; break; // Gauche
                            case 2: nextY = y + 1; break; // Droite
                            case 3: nextX = x - 1; break; // Haut
                        }

                        if (IsValide(nextX, nextY) && plateau[nextX, nextY] == mot[positions.Count] && !DejaVisite(positions, nextX, nextY)) // Vérifications
                        {
                            positions.Push((nextX, nextY, 0)); // Trouvé ! On empile le voisin
                        }
                    }
                }
                if (positions.Count == mot.Length) // Si on sort de la boucle et qu'on a la bonne longueur, c'est gagné !
                {
                    Console.WriteLine($"Mot '{mot}' trouvé !");
                    return positions;
                }
            }
            Console.WriteLine("Mot non trouvé.");
            return null;
        }
        private bool IsValide(int x, int y) // Vérifie si la case (x,y) est dans les limites du plateau
        {
            return x >= 0 && x < taille && y >= 0 && y < taille;
        }
        private bool DejaVisite(Stack<(int, int, int)> pile, int x, int y)
        {
            foreach (var item in pile)
            {
                if (item.Item1 == x && item.Item2 == y) return true;
            }
            return false;
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
