using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_POO_Mots_Glisses
{
    internal class Joueur
    {
        // Attributs
        private string nom;
        private List<string> mots;
        private List<int> scores;

        // Constructeurs
        public Joueur(string nom)
        {
            this.nom = nom;
            mots = new List<string>();
            scores = new List<int>();
        }
        // Propriétés

        // Méthodes
        public void AjouterMot(string mot)
        {
            mots.Add(mot);
        }
        public void AjouterScore(int score)
        {
            scores.Add(score);
        }
    }
}
