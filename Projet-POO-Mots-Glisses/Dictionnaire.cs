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
                for (int i = 0; i<lines.Length; i+=2)
                {
                    string line = lines[i+1];
                    string[] mots = line.Split(' ');
                    tableauTrie.Add(mots);
                }
                return tableauTrie;
            }
            else
            {
                Console.WriteLine("Ce fichier n'existe pas.");
                return null;
            }
        }

        #endregion

        #endregion
    }
}
