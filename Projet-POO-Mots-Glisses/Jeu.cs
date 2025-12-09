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

        public Jeu(Dictionnaire dictionnaire, Joueur joueur1, Joueur joueur2)
        {
            this.dictionnaire = dictionnaire;
            this.joueur1 = joueur1;
            this.joueur2 = joueur2;
            int plat = ChoixPlateau();
            this.plateau = plateau;
        }
        #endregion

        #region Propriétés
        #endregion

        #region Méthodes
        static void Jeu()
        {
            Lettre lettre = new Lettre();
            int plateau = ChoixPlateau();
            switch (plateau)
            {
                case 1:
                    //Créer le plateau 1
                    break;
                case 2:
                    //Créer le plateau 2
                    break;
                case 3:
                    Plateau plateau = new Plateau(lettre);
                    break;
            }
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

        static int SaisirNombrePositif()    //Utiliser un Console.WriteLine avant !!
        {
            int rep = -1;
            do
            {
                string choix = Console.ReadLine();
                try
                {
                    rep = Convert.ToInt32(choix);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Veuillez entrer un nombre valide.");
                }
            }
            while (rep < 0);
        }



        static int ChoixPlateau()       //Retourne 1, 2 ou 3
        {
            Console.WriteLine("Choississez un plateau à utiliser : ");
            Console.WriteLine("1) Plateau 1");
            Console.WriteLine("2) Plateau 2");
            Console.WriteLine("3) Plateau aléatoire");
            int choix = 0
            do
            {
                choix = SaisirNombrePositif();
            }
            while (choix < 1 || choix > 3);
            return choix;
        }
        #endregion
    }
}
