using System;
using System.IO;

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
        private void ReadFile(string filename)
        {
            StreamReader flux = null;
            string line;
            int i = 0;
            char[] sep = { ';' };
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
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < lettres.Length; i++)
            {
                res += lettres[i] + " - Max: " + max[i] + " - Poids: " + poids[i] + "\n";
            }
            return res;
        }
        #endregion
    }
}
