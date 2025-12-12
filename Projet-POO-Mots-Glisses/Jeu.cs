using System;
using System.Collections.Generic;
using System.Threading;

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

        #region Lancer le jeu
        public void LancerJeu(int tempsTotal,int tempsTour)
        {
            string ligne = "----------------------------------------------------------------------------------------------------------------------";
            string espace = "                                        ";
            DateTime DebutPartie = DateTime.Now;
            Console.WriteLine("Lancement du jeu :");
            TimeSpan tempsPartie;
            bool terminer = false; 
            int tour = 0;
            do
            {

                if (tour % 2 == 0)
                {
                    Console.WriteLine($"Au tour de {joueur1.Nom}");
                }
                else
                {
                    Console.WriteLine($"Au tour de {joueur2.Nom}");
                }
                DateTime debutTour = DateTime.Now;  //On note l'heure de début du tour
                Console.WriteLine(plateau);
                string mot = SaisirMot();
                TimeSpan tempsEcoule = DateTime.Now - debutTour;    //On fait la différence entre l'heure du début du tour et maintenant
                if (tempsEcoule.TotalSeconds > tempsTour)
                {
                    Console.WriteLine("Temps écoulé ! Tour suivant.");
                }
                else if (dictionnaire.RechDichoRecursif(mot) == true)
                {
                    Stack < (int, int, int) > positions = plateau.RechercheMot(mot);
                    if (positions != null)
                    {
                        plateau.MajPlateau(positions);
                        if (tour % 2 == 0)
                        {
                            joueur1.AjouterMot(mot);
                            int score = joueur1.AjouterScore(mot);
                            Console.WriteLine($"{joueur1.Nom} a trouvé le mot {mot} et marque {score} points !");
                        }
                        else
                        {
                            joueur2.AjouterMot(mot);
                            int score = joueur2.AjouterScore(mot);
                            Console.WriteLine($"{joueur2.Nom} a trouvé le mot {mot} et marque {score} points !");
                        }
                    }
                }
                tour++;
                Thread.Sleep(500);
                tempsPartie = DateTime.Now - DebutPartie;
                if (tempsPartie.TotalSeconds > tempsTotal)
                {
                    terminer = true;
                }
            }
            while (terminer != true);

            #region Fin de partie
            Console.WriteLine($"\n{ligne}\n{espace}Partie terminée !\n");

            Console.WriteLine($"\n{espace}C'est maintenant l'heure des résultats...\n");
            Thread.Sleep(250);
            Console.WriteLine($"\n{espace}Etes-vous prêt ? \n");
            Thread.Sleep(1000);
            Console.WriteLine($"\n{espace}3\n");
            Thread.Sleep(1000);
            Console.WriteLine($"\n{espace}2\n");
            Thread.Sleep(1000); 
            Console.WriteLine($"\n{espace}1\n\n\n");
            Thread.Sleep(1000);

            if (joueur1 > joueur2)
            {
                Console.WriteLine($"{espace}{joueur1.Nom} a gagné avec {joueur1.CompterScore()} points contre {joueur2.CompterScore()} points pour {joueur2.Nom} !\n\n\n");
            }
            else if (joueur1 < joueur2)
            {
                Console.WriteLine($"{espace}{joueur2.Nom} a gagné avec {joueur2.CompterScore()} points contre {joueur1.CompterScore()} points pour {joueur1.Nom} !\n\n\n");
            }
            else
            {
                Console.WriteLine($"{espace}Egalité !!! Vous avez tous les deux {joueur2.CompterScore()} !\n\n\n");
            }
            Thread.Sleep(2000);
            #endregion
            Console.WriteLine($"{espace}Merci d'avoir joué ! Retour au menu principal.\n\n\n");
            Thread.Sleep(1000);
            Console.WriteLine(ligne + "\n\n");
        }

        #endregion

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
