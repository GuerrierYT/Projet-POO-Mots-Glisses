using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_POO_Mots_Glisses
{
    internal class Dictionnaire
    {
        #region Attributs
        string nom;
        private List<string[]> mots;

        #endregion

        #region Constructeurs
        public Dictionnaire(string nom)
        {
            this.nom = nom;
            this.mots = LireMots();
        }

        #endregion

        #region Propriétés
        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public List<string[]> Mots
        {
            get { return this.mots; }
            set { this.mots = value; }
        }
        #endregion


        #region Méthodes
        #region Lire les mots depuis le fichier "MotsFrancais.txt"
        public static List<string[]> LireMots()
        {
            string filename = "MotsFrancais.txt";
            if (File.Exists(filename))      // On regarde si le fichier existe
            {
                string[] lines = File.ReadAllLines(filename);   // On lit toutes les lignes du fichier dans le tableau lines
                List<string[]> tableauTrie = new List<string[]>();  // On crée une liste qui va regrouper les sous tableaux des mots triés
                for (int i = 0; i < lines.Length; i += 2)
                {
                    string line = lines[i + 1];
                    string[] mots = line.Split(' ');
                    tableauTrie.Add(mots);
                }
                return tableauTrie;
            }
            else
            {
                Console.WriteLine("Ce fichier n'existe pas.");
                return new List<string[]>();
            }
        }

        #endregion

        #region tri fusion

        public void TrierMots()
        {
            for (int i = 0; i < mots.Count; i++)
            {
                TriFusion(mots[i], 0, mots[i].Length - 1);
            }
        }

        private void TriFusion(string[] tab, int min, int max)
        {
            // CORRECTION IMPORTANTE :
            // La condition d'arrêt était inversée. On s'arrête si min >= max
            // (c'est-à-dire s'il reste 0 ou 1 seul élément).
            if (min >= max)
                return;

            int milieu = (min + max) / 2;
            TriFusion(tab, min, milieu);
            TriFusion(tab, milieu + 1, max);
            Fusion(tab, min, milieu, max);
        }



        private void Fusion(string[] tab, int min, int milieu, int max)
        {
            string[] temp = new string[max - min + 1];
            int i = min;
            int j = milieu + 1;
            int k = 0;

            while (i <= milieu && j <= max)
            {
                if (tab[i].CompareTo(tab[j]) <= 0)
                {
                    temp[k++] = tab[i++];
                }
                else
                {
                    temp[k++] = tab[j++];
                }
            }

            while (i <= milieu)
                temp[k++] = tab[i++];

            while (j <= max)
                temp[k++] = tab[j++];

            for (int t = 0; t < temp.Length; t++)
                tab[min + t] = temp[t];
        }
        #endregion

        public override string ToString()
        {
            // Sécurité si la liste est vide ou null
            if (mots == null || mots.Count == 0)
                return "Le dictionnaire est vide.";

            string resultat = "Contenu du dictionnaire :\n";

            // On parcourt chaque tableau de mots (chaque ligne valide du fichier)
            for (int i = 0; i < mots.Count; i++)
            {
                resultat += $"Ligne {i + 1} : ";
                // On ajoute tous les mots de la ligne séparés par un espace
                foreach (string mot in mots[i])
                {
                    resultat += mot + " ";
                }
                resultat += "\n"; // Retour à la ligne après chaque tableau
            }
            return resultat;
        }
        #endregion
    }
}
