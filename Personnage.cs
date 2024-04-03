using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Personnage
    {
        const string PERSO_FORMAT = "{0,-10}{1,-10}{2,-10}";
        private const int MIN_DE = 1;
		private const int MAX_DE = 6;
		private const int DEGATS_DEFAULT = 1;
        private const int DEGATS_EPEE_BOUCLIER= 3;
        private const int DEGATS_EPEE_DEUX_MAINS = 5;
        private const int DEGATS_ARC = 3;
		private const int PTS_VIE_POTION = 6;
		private const int ARMURE_DEFAULT=0;
        private const int ARMURE_EPEE_BOUCLIER = 5;
        private const int ARMURE_EPEE_DEUX_MAINS = 2;
        private const int ARMURE_ARC = 1;

		private const int NB_PTSVIE_MIN_CLASSE= 1;
        private const int NB_PTSVIE_MIN_GUERRIER = 2;
		private const int NB_PTSVIE_MAX_ARCHER = 10;
        private const int NB_PTSVIE_MAX_MAGE= 4;
        private const int NB_PTSVIE_MAX_GUERRIER = 20;
        private const int NB_PTSVIE_MAX_ASSASSIN = 6;
        private const int NB_PTSVIE_MAX_MOINE=8;


        private const int NB_ATTAQUE_MIN_CLASSE = 1;
        private const int NB_ATTAQUE_MAX_ARCHER = 6;
        private const int NB_ATTAQUE_MAX_MAGE = 8;
        private const int NB_ATTAQUE_MAX_GUERRIER = 10;
        private const int NB_ATTAQUE_MAX_ASSASSIN = 6;
        private const int NB_ATTAQUE_MAX_ARCHER_MOINE = 8;

		private const int NB_PTS_DEFENSE_MIN_CLASSE = 1;
        private const int NB_DEFENSE_MAX_ARCHER = 6;
        private const int NB_DEFENSE_MAX_MAGE = 8;
        private const int NB_DEFENSE_MAX_GUERRIER = 10;
        private const int NB_DEFENSE_MAX_ASSASSIN = 6;
        private const int NB_DEFENSE_MAX_ARCHER_MOINE = 8;





        private string nom;
        private Classe classe;
        private Arme arme;
        private int nbPotion;
        private StatsPersonnage stats;
        private List<Sort> sorts;
        private List<int> degatsDernierCombats;

        public string Nom
		{
			get { return nom; }
			private set {
                if (value is null)
                {
                    throw new ArgumentNullException("Le nom de personnage ne doit pas être null");
                }
                value=value.Trim();
                if (value.Length == 0)
                {
                    throw new ArgumentOutOfRangeException("Le nom de personnage ne doit pas être vide");
                }
                nom = value; }
		}
		

		public Classe Classe
		{
			get { return classe; }
			private set { 

				classe = value; }
            //questin à poser
		}


        //public Arme Arme
        //{
        //    get { return arme; }
        //    set
        //    {
        //        if (this.Classe == Classe.Mage && (value == Arme.EpeeBouclier || value == Arme.EpeeDeuxMains))
        //        {
        //            throw new InvalidOperationException("Le magicien ne peut pas choisir l'arme épée!");
        //        }
        //        else
        //        {
        //            arme = value;
        //        }
        //    }
        //}
        public Arme Arme
        {
            get { return arme; }
            set
            {
                if (this.PeutChoisirEpee(value))
                {
                    arme = value;
                }
                else
                {
                    throw new InvalidOperationException("Le magicien ne peut pas choisir l'arme épée!");
                }
            }
        }

        private bool PeutChoisirEpee(Arme arme)
        {
            if (this.Classe == Classe.Mage && (arme == Arme.EpeeBouclier || arme == Arme.EpeeDeuxMains))
            {
                return false;
            }
            return true;
        }

        public int NbPotion
        {
			get { return nbPotion; }
			set { 
				if (value<0)
				{
					throw new ArgumentOutOfRangeException("Le nombre de potion ne doit pas être négatif");
				}
				nbPotion = value; }
		}
		

		public StatsPersonnage  Stats
		{
			get { return stats; }
			set {
                if(value is null)
                {
                    throw new ArgumentNullException("Les statistiques du personnage ne doivent pas être nulles");
                }
                stats = value; }
		}
	

		public List<Sort> Sorts
        {
			get { return sorts; }
		    private set {
				if(value is null)
				{
					throw new ArgumentNullException("la liste de sort ne doit  pas être nulle");
				}
				sorts = value; }
		}


		public List<int> DegatsDernierCombats
        {
			get { return degatsDernierCombats; }
			set { degatsDernierCombats = value; }
		}

		public Personnage(string nom, Classe classe, List<Sort> sorts,Arme arme)
		{


			this.Nom = nom;
			this.Classe = classe;
			this.Sorts = sorts;
			this.Arme = arme;
		    this.NbPotion = 0;
            this.DegatsDernierCombats=new List<int>();
            this.Stats= DeterminerStatsPersonnage();
            MettreAJoursPtsDefense();

        }
		public void AjouterSort(Sort sort)
		{
			if(sort is null)
			{
				throw new ArgumentNullException("Le sort ne doit pas être null");
			}
			this.Sorts.Add(sort);
			
		}
		public bool EstMort()
		{
			return this.Stats.EstMort();
		}
		public void Attaquer(Personnage ennemi)
		{
            if (ennemi is null)
			{
				throw new ArgumentNullException("Le personnage  ne doit pas être null");
			}
                if (this.EstMort() )
			{
				throw new InvalidOperationException("Le personnage est déjà mort");
			}
			
			int degats = 0;

            Random aleatoire = new Random();
            if( aleatoire.Next(MIN_DE, MAX_DE+1)>2)
			{
				degats=this.CalculerDegatsInfliges(ennemi);
				ennemi.RecevoirDegats(degats);
				
				this.DegatsDernierCombats.Add(degats);
			}
        
        }
		private  StatsPersonnage DeterminerStatsPersonnage()
		{
            Random aleatoire = new Random();
            int ptsVieMax =0;
            int ptsAttaque = 0;
            int ptsDefense = 0;

            switch (this.Classe)
			{
				case Classe.Archer:
                     ptsAttaque = aleatoire.Next(NB_ATTAQUE_MIN_CLASSE, NB_ATTAQUE_MAX_ARCHER+1);
                     ptsDefense = aleatoire.Next(NB_PTS_DEFENSE_MIN_CLASSE, NB_DEFENSE_MAX_ARCHER+1);
                    ptsVieMax = aleatoire.Next(NB_ATTAQUE_MIN_CLASSE, NB_PTSVIE_MAX_ARCHER + 1);
                    break;
			    case Classe.Mage:
                    ptsAttaque = aleatoire.Next(NB_ATTAQUE_MIN_CLASSE, NB_ATTAQUE_MAX_MAGE+1);
                    ptsDefense = aleatoire.Next(NB_PTS_DEFENSE_MIN_CLASSE, NB_DEFENSE_MAX_MAGE+1);
                    ptsVieMax = aleatoire.Next(NB_ATTAQUE_MIN_CLASSE, NB_PTSVIE_MAX_MAGE + 1);
                    break;
                case Classe.Guerrier:
                    ptsAttaque = aleatoire.Next(NB_PTSVIE_MIN_GUERRIER , NB_ATTAQUE_MAX_GUERRIER+1);
                    ptsDefense = aleatoire.Next(NB_PTS_DEFENSE_MIN_CLASSE, NB_DEFENSE_MAX_GUERRIER+1);
                    ptsVieMax = aleatoire.Next(NB_PTSVIE_MIN_GUERRIER, NB_PTSVIE_MAX_GUERRIER + 1);
                    break;
                case Classe.Assassin:
                    ptsAttaque = aleatoire.Next(NB_ATTAQUE_MIN_CLASSE, NB_ATTAQUE_MAX_ASSASSIN+1);
                    ptsDefense = aleatoire.Next(NB_PTS_DEFENSE_MIN_CLASSE, NB_DEFENSE_MAX_ASSASSIN+1);
                    ptsVieMax = aleatoire.Next(NB_ATTAQUE_MIN_CLASSE, NB_PTSVIE_MAX_ASSASSIN + 1);
                    break;
                case Classe.Moine:
                    ptsAttaque = aleatoire.Next(NB_ATTAQUE_MIN_CLASSE, NB_ATTAQUE_MAX_ARCHER_MOINE+1);
                    ptsDefense = aleatoire.Next(NB_PTS_DEFENSE_MIN_CLASSE, NB_DEFENSE_MAX_ARCHER_MOINE+1);
                    ptsVieMax = aleatoire.Next(NB_ATTAQUE_MIN_CLASSE, NB_PTSVIE_MAX_MOINE + 1);
                    break;
            


            }
            StatsPersonnage stats = new StatsPersonnage(ptsVieMax, ptsAttaque, ptsDefense);
            return stats;
        }
		public void RecevoirDegats(int degats)
        {
            if (this.EstMort())
            {
                throw new InvalidOperationException("Le personnage est déjà mort");
            }


			if(degats>0)
			{
                this.Stats.CalculerPtsVieApresAttaque(degats);
                
            }
         
            this.DegatsDernierCombats.Add(-degats);
 
        }
		public int CalculerDegatsInfliges(Personnage ennemi)
		{
			int degats = 0;
            int degatsInfliges = 0; 
            if (this.Classe==Classe.Mage)
            {
                degats=this.Sorts[0].GetDegats();

            }
            else
            {
                switch (this.Arme)
                {
                    case Arme.MainsNues:
                        degatsInfliges=DEGATS_DEFAULT;
                        break;
                    case Arme.EpeeBouclier:
                        degatsInfliges=DEGATS_EPEE_BOUCLIER;
                        break;
                    case Arme.EpeeDeuxMains:
                        degatsInfliges=DEGATS_EPEE_DEUX_MAINS;
                        break;
                    case Arme.Arc:
                        degatsInfliges=DEGATS_ARC;
                        break;
                }
                degats=this.stats.PtsAttaque+degatsInfliges-ennemi.Stats.PtsDefense;
            }
           
            return degats;
			
        }
        public void MettreAJoursPtsDefense()
        {
            switch (this.Arme)
            {
                case Arme.MainsNues:
                    this.Stats.PtsDefense+=ARMURE_DEFAULT;
                    break;
                case Arme.EpeeBouclier:
                    this.Stats.PtsDefense+=ARMURE_EPEE_BOUCLIER;
                    break;
                case Arme.EpeeDeuxMains:
                    this.Stats.PtsDefense+=ARMURE_EPEE_DEUX_MAINS;
                    break;
                case Arme.Arc:
                    this.Stats.PtsDefense+=ARMURE_ARC;
                    break;
            }
        }
        public void MettreAJoursPtsVie(Personnage ennemi ,int degat)
        {
           ennemi.Stats.PtsVie-=degat;
        }
		public void BoirePotion()
		{
			if (this.NbPotion<=0)
			{
				throw new InvalidOperationException("Vous n'avez pas de potion à utiliser");
			}
			this.stats.CalculerPtsVieApresBoirePotion(PTS_VIE_POTION);
			this.nbPotion--;

		}
        public override string ToString()
        {
            string result =
                   "Nom :" +this.Nom +"\n"+
                   "Arme :" +this.Arme+"\n"+
                   "Classe :" +this.Classe+"\n"+
                   this.stats.ToString()+"\n";
              if (this.Sorts.Count > 0)
              {
                result+="Sorts :";
                for (int i = 0; i < this.Sorts.Count; i++)
                {
                    
                    result+= string.Format("{0,20}{1,30}",this.Sorts[i].NomSort ,"Degats = "+this.Sorts[i].NbDegatsMin+"-"+ this.Sorts[i].NbDegatsMax)+"\n"+"       ";
                }
              }
                      
            return result;
        }
    }
}
