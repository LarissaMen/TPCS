using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Personnage
    {
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
		}
	

		public Arme Arme
		{
			get { return arme; }
			set { arme = value; }
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
			private set { stats = value; }
		}
	

		public List<Sort> Sorts
        {
			get { return sorts; }
			private set {
				if(value is null)
				{
					throw new ArgumentNullException("la liste de sort nedoit  pas être null");
				}
				sorts = value; }
		}


		public List<int> DegatsDernierCombats
        {
			get { return degatsDernierCombats; }
			set {

				degatsDernierCombats = value; }
		}

		public Personnage(string nom, Classe classe, List<Sort> sorts,Arme arme)
		{

			this.Nom = nom;
			this.Classe = classe;
			this.Sorts = sorts;
			this.Arme = arme;
		    this.NbPotion = 0;
			this.DegatsDernierCombats=new List<int>();
			this.Sorts=new List<Sort>();
			this.Stats=new StatsPersonnage(9,5,2);
		}
		public void AjoutSort(Sort sort)
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
				throw new ArgumentNullException("Le personnage  ne doit pa être null");
			}
                if (this.Stats.EstMort())
			{
				throw new InvalidOperationException("Le personnage est déjà mort");
			}
			
			int degats = 0;

            Random aleatoire = new Random();
            if( aleatoire.Next(MIN_DE, MAX_DE+1)>2)
			{
				if (this.Classe==Classe.Mage)
				{
					degats=this.Sorts[0].GetDegats();

                }
				else
				{
					switch (this.Arme)
					{
						case Arme.MainsNues:
							degats=DEGATS_DEFAULT;
							break;
						case Arme.EpeeBouclier:
							degats=DEGATS_EPEE_BOUCLIER;
							break;
						case Arme.EpeeDeuxMains:
							degats=DEGATS_EPEE_DEUX_MAINS;
							break;
						case Arme.Arc:
							degats=DEGATS_ARC;
							break;
                    }
				}

				ennemi.RecevoirDegats(degats);
				this.DegatsDernierCombats.Add(degats);
			

            }
		
        }
		public void RecevoirDegats(int degats)
        {
            if (this.Stats.EstMort())
            {
                throw new InvalidOperationException("Le personnage est déjà mort");
            }

            switch (this.Arme)
            {
                case Arme.MainsNues:
                    degats-=ARMURE_DEFAULT;
                    break;
                case Arme.EpeeBouclier:
                    degats-=ARMURE_EPEE_BOUCLIER;
                    break;
                case Arme.EpeeDeuxMains:
                    degats-=ARMURE_EPEE_DEUX_MAINS;
                    break;
                case Arme.Arc:
                    degats-=ARMURE_ARC;
                    break;
            }
			if(degats>0)
			{
                this.Stats.CalculerPtsVieApresAttaque(degats);
            }
            this.DegatsDernierCombats.Add(-degats);
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

	}
}
