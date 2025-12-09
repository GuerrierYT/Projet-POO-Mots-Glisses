using System;

namespace Projet_POO_Mots_Glisses
{
    internal class Jeu
    {
        #region Attributs
        private Dictionnaire dictionnaire;
        private Plateau plateau;
        private Joueur joueur1;
        private Joueur joueur2;

        private static int tempstour = 10;
        private static int tempspartie = 120;
        #endregion

        #region Constructeurs
        public Jeu()
        {
            this.dictionnaire = null;
            this.plateau = null;
            this.joueur1 = null;
            this.joueur2 = null;
        }
        public Jeu(Dictionnaire dictionnaire, Plateau plateau, Joueur joueur1, Joueur joueur2)
        {
            this.dictionnaire = dictionnaire;
            this.plateau = plateau;
            this.joueur1 = joueur1;
            this.joueur2 = joueur2;
        }

        public Jeu(Dictionnaire dictionnaire, Plateau plateau, string joueur1, string joueur2)      // Avec des string
        {
            this.dictionnaire = dictionnaire;
            this.plateau = plateau;
            this.joueur1 = new Joueur(joueur1);
            this.joueur2 = new Joueur(joueur2);
        }

        public Jeu(Dictionnaire dictionnaire, Joueur joueur1, Joueur joueur2, Lettre lettre)
        {
            this.dictionnaire = dictionnaire;
            this.joueur1 = joueur1;
            this.joueur2 = joueur2;
            this.plateau = new Plateau(lettre);
        }

        public Jeu(Dictionnaire dictionnaire, string joueur1, string joueur2, Lettre lettre)    //Avec des string
        {
            this.dictionnaire = dictionnaire;
            this.joueur1 = new Joueur(joueur1);
            this.joueur2 = new Joueur(joueur2);
            this.plateau = new Plateau(lettre);
        }
        #endregion

        #region Propriétés

        public Plateau Plateau
        {
            get { return plateau; }
        }
        public Dictionnaire Dictionnaire
        {
            get { return dictionnaire; }
        }
        public Joueur Joueur1
        {
            get { return joueur1; }
        }
        public Joueur Joueur2
        {
            get { return joueur2; }
        }
        public static int Tempstour
        {
            get { return tempstour; }
            set { tempstour = value; }
        }
        public static int Tempspartie
        {
            get { return tempspartie; }
            set { tempspartie = value; }
        }
        #endregion

        #region Méthodes
        public void LancerJeu()
        {
            Console.WriteLine("Bonjour");
        }

        #region Saisie et validation du mot
        static string SaisirMot()
        {
            string mot;
            bool estValide = false;
            do
            {
                Console.WriteLine("Veuillez saisir un mot d'au moins 2 lettres :");
                mot = Console.ReadLine();
                estValide = EstMotValide(mot);
                if (estValide == false)
                {
                    Console.WriteLine("Le mot ne doit contenir que des lettres.");
                }
            }
            while (mot.Length < 2 || estValide == false);
            return mot.ToUpper();
        }
        static bool EstMotValide(string mot)
        {
            foreach (char c in mot)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        




        #endregion
    }
}
