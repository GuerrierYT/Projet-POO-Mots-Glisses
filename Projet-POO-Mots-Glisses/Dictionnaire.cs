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
                Console.WriteLine("Je le cherche ici : " + Path.GetFullPath(filename));// GetFullPath aide à localiser le fichier car nous avons eu un problème
                return new List<string[]>();
            }
        }

        #endregion

        #region tri fusion
        // On a repris le tr fusion du TD de la récusrivité, et on l'a adapté pour les string[]
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

        #region Recherche dichotomique
        // On a adapté la recherche dichotomique du TD de la récusrivité pour les string[]
        public bool RechercheDicho(string motCherche)  //On suppose que notre tableau est déjà trié
        {
            //Securité
            if (indexTableau < 0 || indexTableau >= mots.Count)
            {
                return false;
            }
            int index = motCherche.Length - 2; // -2 car on n'a pas de mot de taille 1 et l'index commence à 0
            return RechercheDichoRecursif(mots[index], 0, mots[index].Length - 1, motCherche);
        }


        private bool RechercheDichoRecursif(string[] tab, int min, int max, string motCherche)  //On suppose que notre tableau est déjà trié
        {
            // Condition d'arrêt
            if (min > max)
            {
                Console.WriteLine($"\"{motCherche}\" non trouvé dans le dictionnaire.");
                return false;
            }
            int milieu = (min + max) / 2;
            int res = motCherche.CompareTo(tab[milieu]);    // res sera 0 si égal, <0 si motCherche est avant, >0 si après
            if (res == 0)   // Alors c'est le bon mot
            {
                return true; 
            }
            else if (res < 0)   // Le mot cherché est avant dans l'ordre alaphabetétique
            {
                return RechercheDichoRecursif(tab, min, milieu - 1, motCherche);
            }
            else    // Alors le mot cherché est après dans l'ordre alphabétique
            {
                return RechercheDichoRecursif(tab, milieu + 1, max, motCherche);
            }
        }

        #endregion

        public override string ToString()   // Utilisé pour vérifier le fonctionnement de la lecture et du tri
        {
            // Sécurité
            if (mots == null || mots.Count == 0)
            {
                return "Le dictionnaire est vide.";
            }

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
