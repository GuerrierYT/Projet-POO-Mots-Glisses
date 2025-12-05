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
        public Plateau()
        {
            ReadFile("Lettres.txt");
        }
        public void ReadFile(string filename)
        {
            StreamReader flux = null;
            string line;
            int i = 0;
            char[] sep = {';'};
            plateau = new char[,];
        }
        // Propriétés

        // Méthodes

    }
}
