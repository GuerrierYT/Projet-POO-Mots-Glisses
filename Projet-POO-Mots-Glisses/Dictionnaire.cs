using System;
using System.Collections.Generic;
using System.IO;

namespace Projet_POO_Mots_Glisses
{
    internal class Dictionnaire     // Classe non terminée
    {
        #region Attributs
        string nom;
        string langue;
        private List<string[]> mots;

        #endregion

        #region Constructeurs
        public Dictionnaire(string nom)
        {
            this.nom = nom;
            this.langue = "français";
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
        public string Langue
        {
            get { return this.langue; }
            set { this.langue = value; }
        }

        #endregion

        #region Méthodes

        #region Lire les mots depuis le fichier "MotsFrancais.txt" 

        public static List<string[]> LireMots()     //Fonctionnel
        {
            string filename = "Mots_Français.txt";
            if (File.Exists(filename))      // On regarde si le fichier existe
            {
                string[] lines = File.ReadAllLines(filename);   // On lit toutes les lignes du fichier dans le tableau lines
                List<string[]> tableauTrie = new List<string[]>();  // On crée une liste qui va regrouper les sous tableaux des mots triés
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
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
        public void Tri_Fusion()
        {
            for (int i = 0; i < mots.Count; i++)
            {
                TriFusion(mots[i], 0, mots[i].Length - 1);
            }
        }

        private void TriFusion(string[] tab, int min, int max)
        {
            if (min >= max)     //Condition d'arrêt
            {
                return;
            }

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
                if (tab[i].CompareTo(tab[j]) <= 0)  // On compare les deux mots, comme si c'était des nombres
                {
                    temp[k++] = tab[i++];
                }
                else
                {
                    temp[k++] = tab[j++];
                }
            }

            while (i <= milieu)
            {
                temp[k++] = tab[i++];
            }
            while (j <= max)
            {
                temp[k++] = tab[j++];
            }
<<<<<<< HEAD

=======
>>>>>>> b33cb436ab1d3684ee435734eb37bc615e075308
            for (int t = 0; t < temp.Length; t++)
            {
                tab[min + t] = temp[t];
            }
        }

        #endregion

        #region Recherche dichotomique

        // On a adapté la recherche dichotomique du TD de la récusrivité (9) pour les string[]
        public bool RechDichoRecursif(string motCherche)  //On suppose que notre tableau est déjà trié
        {
            int index = motCherche[0].CompareTo('A'); // Pour "ARBRE" on teste A comparé à A, donc index = 0 et on prend mots[0]
            //Console.WriteLine($"Index du mot cherché : {index}");
            //Securité                  
            if (index < 0 || index >= mots.Count)   // Si index <0, il y a une erreur dans le mot fourni car on compare à A.
            {
                return false;
            }
            return RechercheDichoRecursif(mots[index], 0, mots[index].Length - 1, motCherche);  //Recursivité
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

        #region ToString
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

        private int CompterDico()
        {
            int result = 0;
            for (int i = 0; i < mots.Count; i++)
            {
                result += mots[i].Length;
            }
            return result;
        }

        private int CompterLettre(char lettre)
        {
            int result = 0;
            for (int i = 0; i < mots.Count; i++)
            {
                for (int j = 0; j < mots[i].Length; j++)
                {
                    if (mots[i][j][0] == lettre)
                    {
                        result++;
                    }
                }
            }
            return result;
        }

        public string toString()    //Le toString demandé dans le sujet
        {
            int taille = CompterDico();
            return $"Nom : {nom},\nLangue : {langue},\nTaille : {taille},\nNombre de A : {CompterLettre('A')},\nNombre de B : {CompterLettre('B')}" +
                $",\nNombre de C : {CompterLettre('C')},\nNombre de D : {CompterLettre('D')},\nNombre de E : {CompterLettre('E')},\nNombre de F : {CompterLettre('F')}" +
                $",\nNombre de G : {CompterLettre('G')},\nNombre de H : {CompterLettre('H')},\nNombre de I : {CompterLettre('I')},\nNombre de J : {CompterLettre('J')}" +
                $",\nNombre de K : {CompterLettre('K')},\nNombre de L : {CompterLettre('L')},\nNombre de M : {CompterLettre('M')},\nNombre de N : {CompterLettre('N')}" +
                $",\nNombre de O : {CompterLettre('O')},\nNombre de P : {CompterLettre('P')},\nNombre de Q : {CompterLettre('Q')},\nNombre de R : {CompterLettre('R')}" +
                $",\nNombre de S : {CompterLettre('S')},\nNombre de T : {CompterLettre('T')},\nNombre de U : {CompterLettre('U')},\nNombre de V : {CompterLettre('V')}" +
                $",\nNombre de W : {CompterLettre('W')},\nNombre de X : {CompterLettre('X')},\nNombre de Y : {CompterLettre('Y')},\nNombre de Z : {CompterLettre('Z')}";
        }

        #endregion

        #endregion
    }
}
