using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_POO_Mots_Glisses
{
    internal class Plateau
    {
        // Attributs
        private char[,] plateau;

        // Constructeurs
        public Plateau(string filename)
        {
            ReadFile(filename);
        }

        // Propriétés

        // Méthodes
        public void ReadFile(string filename)
        {
            StreamReader flux = null;
            string line;
            int i = 0;
            char[] sep = { ';' };
            plateau = new char[8, 8];
            try
            {
                flux = new StreamReader(filename);
                while ((line = flux.ReadLine()) != null && i < 8)
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
    }
}
