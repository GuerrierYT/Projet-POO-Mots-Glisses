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
        #endregion

        #region Propriétés
        #endregion

        #region Méthodes
        #endregion
    }
}
