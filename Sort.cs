using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Sort
    {
		private const int MIN_BOULE_DE_FEU = 5;
        private const int MAX_BOULE_DE_FEU = 15;

		private const int MIN_MISSILE_MAGIQUE = 1;
        private const int MAX_MISSILE_MAGIQUE = 4;

		private const int MIN_FOUDRE = 2;
        private const int MAX_FOUDRE = 20;



        private string nomSort;
        private int nbDegatsMin;
        private int nbDegatsMax;

        public string NomSort
        {
			get { return nomSort; }
		    private	set { 
				if(value is null)
				{
					throw new ArgumentNullException("Le nom ne doit pas être null");
				}
				value=value.Trim();
				if(value.Length == 0 )
				{
					throw new ArgumentOutOfRangeException("Le nom ne doit pas être vide");
				}
				nomSort = value; }
		}
	

		public int NbDegatsMin
        {
			get { return nbDegatsMin; }
			set {
				if(value < 0)
				{
					throw new ArgumentOutOfRangeException("Le nombre de dommage ne doit pas être négatif");
				}
				nbDegatsMin = value; }
		}
	

		public int NbDegatsMax
        {
			get { return nbDegatsMax; }
			set {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Le nombre de dommage maximum ne doit pas être négatif");
                }
                nbDegatsMax = value; }
		}

		public Sort(string nom)
		{
			this.NomSort = nom;
			DeterminerNbDegats();

        }
		public int GetDegats()
		{
			Random aleatoire = new Random();

            return aleatoire.Next(this.NbDegatsMin,this.NbDegatsMax+1);
		}
		public void DeterminerNbDegats()
		{
			switch (this.NomSort)
			{
				case "Boule de feu":
					this.nbDegatsMin=MIN_BOULE_DE_FEU;
					this.NbDegatsMax=MAX_BOULE_DE_FEU;
					break;
				case "Missile magique":
                    this.nbDegatsMin=MIN_MISSILE_MAGIQUE;
                    this.NbDegatsMax=MAX_MISSILE_MAGIQUE;
                    break;
                case "Foudre":
                    this.nbDegatsMin=MIN_FOUDRE;
                    this.NbDegatsMax=MAX_FOUDRE;
                    break;

            }
        }
     
    }
}
