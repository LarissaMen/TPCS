using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Sort
    {
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
			this.nbDegatsMin = 0;
			this.nbDegatsMax = 0;
		}
		public int GetDegats()
		{
			Random aleatoire = new Random();

            return aleatoire.Next(this.NbDegatsMin,this.NbDegatsMax+1);
		}
	}
}
