using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_POO_Mots_Glisses
{
    internal class Joueur
    {
        #region Attributs
        private string nom;
        private List<string> mots;
        private List<int> scores;

        #endregion

        #region Constructeurs
        // Constructeurs
        public Joueur(string nom)
        {
            this.nom = nom;
            mots = new List<string>();
            scores = new List<int>();
        }

        #endregion

        // Propriétés

        #region Méthodes
        public void AjouterMot(string mot)
        {
            mots.Add(mot);
        }
        public void AjouterScore(int score)
        {
            scores.Add(score);
        }
        public bool Contient(string mot)
        {
            return mots.Contains(mot);
        }
        public override string ToString()
        {
            string res = "";
            int score = 0;
            res += nom;
            res += "\nMots trouvés : ";
            for (int i = 0; i < mots.Count; i++)
            {
                res += mots[i].ToString() + " ";
                score += scores[i];
            }
            res += "\nScore : " + score;
            return res;
        }
        #endregion
    }
}
