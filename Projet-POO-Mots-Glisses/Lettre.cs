using System;
using System.IO;
using System.Threading;

namespace Projet_POO_Mots_Glisses
{
    internal class Lettre
    {
        #region Attributs
        private string[] lettres;
        private int[] max;
        private int[] poids;
        #endregion

        #region Constructeurs
        public Lettre()
        {
            ReadFile("Lettres.txt");
        }
        #endregion

        #region Propriétés
        #endregion

        #region Méthodes
        private void ReadFile(string filename) // Lecture du fichier Lettres.txt
        {
            StreamReader flux = null;
            lettres = new string[26];
            max = new int[26];
            poids = new int[26];
            string line;
            int i = 0;
            char[] sep = { ',' };
            try
            {
                flux = new StreamReader(filename);
                while ((line = flux.ReadLine()) != null)
                {
                    string[] mots = line.Split(sep);
                    lettres[i] = mots[0];
                    max[i] = Convert.ToInt32(mots[1]);
                    poids[i] = Convert.ToInt32(mots[2]);
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
        public char LettreAleatoire()
        {
            Random random = new Random();
            int index = random.Next(0, lettres.Length);
            if (max[index] <= 0)
            {
                Thread.Sleep(2); // Pour éviter d'avoir le même index à chaque appel
                return LettreAleatoire();
            }
            else
            {
                max[index]--;
                return Convert.ToChar(lettres[index]);
            }
        }
        public override string ToString() //Affichage des lettres avec leurs max et poids + total des lettres max
        {
            string res = "";
            int nblettresmax = 0;
            for (int i = 0; i < lettres.Length; i++)
            {
                res += lettres[i] + " - Max: " + max[i] + " - Poids: " + poids[i] + "\n";
                nblettresmax += max[i];
            }
            res += "Nombre total de lettres maximales dans le jeu : " + nblettresmax;
            return res;
        }
        #endregion
    }
}
