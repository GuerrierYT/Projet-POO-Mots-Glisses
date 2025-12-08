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
        public void WriteFile(string filename)
        {
            StreamWriter flux = null;
            try
            {
                flux = new StreamWriter(filename);
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        flux.Write(plateau[i, j]);
                        if (j < 7)
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
        private void ReadFile(string filename)
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
        public void RechercheMot(string mot)
        {

        }
        public override string ToString() // Affichage du plateau
        {
            string result = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    result += plateau[i, j] + " ";
                }
                result += "\n";
            }
            return result;
        }
    }
}
