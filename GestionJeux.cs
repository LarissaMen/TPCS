using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class GestionJeux
    {

        private const int MIN_RECOMPENSE = 1;
        private const int MAX_RECOMPENSE = 100;
        private const int MAX1_RECOMPENSE = 30;
        private const int MIN_RECOMPENSE_M = 31;
        private const int MAX_RECOMPENSE_M = 60;
     
       

        private const int MIN = 1;
        private const int MAX = 6;
		private Personnage joueur;
        private Personnage ennemi;
        private int noTableau;
         
        public Personnage Joueur
		{
			get { return joueur; }
			set {
                if(value is null)
                {
                    throw new ArgumentNullException("Le joueur ne doit pas être null");
                }

                joueur = value; }
		}
        public Personnage Ennemi
        {
            get { return ennemi; }
            set {
                if (value is null)
                {
                    throw new ArgumentNullException("L'ennemi ne doit pas être null");
                }
                ennemi = value; }
        }
        public int NoTableau
        {
            get { return noTableau; }
            set {
                if (value<0)
                
                { 
                    throw new ArgumentOutOfRangeException("Le numéro de tableau ne doit pas être négatif");
                }
                noTableau = value; }
        }
        public GestionJeux(Personnage joueur,Personnage ennemi)
        {
            this.Joueur = joueur;
            this.Ennemi = ennemi;
            this.NoTableau=0;
        }
        public bool EngagerCombat()
        {
            bool joueurEstGagnant = true;
            Random aleatoire = new Random();
            bool attaquant= aleatoire.Next(MIN, MAX+1)%2==0;
         
            while (!this.Joueur.EstMort() && !this.Ennemi.EstMort())
            {
                if (attaquant)
                {
                    this.Joueur.Attaquer(this.Ennemi);
                    this.Ennemi.Attaquer(this.Joueur);

                }
            }
            if (this.Joueur.EstMort())
            {
                joueurEstGagnant =false;
            }
            return joueurEstGagnant; 
        }
        public void RecueillirRecompense()
        {
            Random aleatoire = new Random();
            int recompense = aleatoire.Next(MIN_RECOMPENSE, MAX_RECOMPENSE + 1);

            if (recompense >= MIN_RECOMPENSE && recompense <= MAX1_RECOMPENSE)
            {
                Console.WriteLine("Vous avez gagné une potion.");
                this.Joueur.NbPotion += 1;
            }
            else if (recompense > MIN_RECOMPENSE_M && recompense <= MAX_RECOMPENSE_M)
            {
                Console.WriteLine("Vous avez gagné cinq potions.");
                this.Joueur.Stats.PtsVie += 5;
            }
            else 
            {
                Console.WriteLine("Désolé vous n'avez pas gagné de potion.");
            }
        }

    }
}
