using System;
using System.CodeDom;
using System.Collections.Generic;

namespace Projet_POO_Mots_Glisses
{
    internal class Joueur
    {
        #region Attributs
        private string nom;
        private List<string> mots;
        private List<int> scores;
        private int[] poids;
        #endregion

        #region Constructeurs

        public Joueur(string nom)
        {
            this.nom = nom;
            mots = new List<string>();
            scores = new List<int>();
            Lettre lettre = new Lettre();
            this.poids = lettre.Poids;
        }

        #endregion

        // Propriétés

        #region Propriétés
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        #endregion

        #region Méthodes
        public void AjouterMot(string mot)
        {
            mots.Add(mot);
        }

        public int AjouterScore(string mot)
        {
            int score = 0;
            for (int i = 0; i < mot.Length; i++)
            {
                int index = mot[i].CompareTo('A');
                score += poids[index];
                score += mot.Length * 2;
            }
            scores.Add(score);
            return score;
        }

        public int CompterScore()
        {
            int score = 0;
            for (int i = 0; i < scores.Count; i++)
            {
                score += scores[i];
            }
            return score;
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

        public static bool operator >(Joueur j1, Joueur j2)
        {
            return j1.CompterScore() > j2.CompterScore();
        }
        public static bool operator <(Joueur j1, Joueur j2)
        {
            return j1.CompterScore() < j2.CompterScore();
        }
        #endregion
    }
}
