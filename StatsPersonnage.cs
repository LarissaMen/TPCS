using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class StatsPersonnage
    {
		private const string STATS_FORMAT = "{0,18} {1,18} {2,18} {3,18}";
		private int ptsVie;
        private int ptsVieMax;
        private int ptsAttaque;
        private int ptsDefense;
        private int ptsExperience;
        public int PtsVie
        {
			get { return ptsVie; }
			set {
                if (value<0)
                {
                    throw new ArgumentOutOfRangeException("Les points de vie ne doivent pas être négatifs");
                }
                ptsVie = value; }
		}
		

		public int PtsVieMax
        {
			get { return ptsVieMax; }
			set
            {
                if (value<0)
                {
                    throw new ArgumentOutOfRangeException("Les points de vie maximum ne doivent pas être négatifs");
                }
                ptsVieMax = value; }
		}
		

		public int PtsAttaque
        {
			get { return ptsAttaque; }
			set {
				if (value<0)
				{
					throw new ArgumentOutOfRangeException("Les points d'attaques ne doivent pas être négatifs");
				}
                
                ptsAttaque = value; }
		}
	

		public int PtsDefense
        {
			get { return ptsDefense; }
			set {
                if (value<0)
                {
                    throw new ArgumentOutOfRangeException("Les points de defenses ne doivent pas être négatifs");
                }
                ptsDefense = value; }
		}
	

		public int PtsExperience
        {
			get { return ptsExperience; }
			set { 
				if(value<0)
				{
					throw new ArgumentOutOfRangeException("Le point d'experience ne dois pas être négati");
				}
					
				ptsExperience = value; }
		}
		public StatsPersonnage(int ptsVieMax,int ptsAttaque,int ptsDefense)
		{
			this.PtsVieMax = ptsVieMax;
			this.PtsAttaque = ptsAttaque;
			this.PtsDefense = ptsDefense;
			this.PtsVie=ptsVieMax;
			//ptsVie à vérifier
            this.PtsExperience = 0;
			
		}
		public bool EstMort()
		{
			bool estMort=false;
			if (this.PtsVie<=0)
                estMort=true;
			return estMort;
        }
		public void CalculerPtsVieApresAttaque(int degats)
		{
			int newPtsVie = this.PtsVie-degats;

			if (newPtsVie<0)
			{
				newPtsVie=0;
			}
			this.PtsVie = newPtsVie;
       
          
		}
		
		public void CalculerPtsVieApresBoirePotion(int ptsVie)
		{
			int newPtsVie=this.PtsVie+ptsVie;
			if (newPtsVie>this.PtsVieMax) 
			{
				newPtsVie=this.PtsVieMax;
            }
            this.PtsVie = newPtsVie;
        }
        public override string ToString()
        {
			
            string resultat = string.Format(STATS_FORMAT, $"Pts Vie :{this.PtsVie}", $"Pts Armure:{this.PtsDefense}", $"Pts Force:{this.PtsAttaque}", $"Pts Exp : {this.PtsExperience}");
            return resultat;

        }
    }
}
