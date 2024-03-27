using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2CS
{
    public class Personnage
    {
		private string nom;
        private Classe classe;
        private StatsPersonnage stats;
        private Arme arme;
        private int nbPotion;
        private List<Sort> sorts;
        private List<int> degatsDernierCombat;
        public string Nom
		{
			get { return nom; }
			set { nom = value; }
		}

		public Classe Classe
		{
			get { return classe; }
			set { classe = value; }
		}

		public StatsPersonnage Stats
        {
			get { return stats; }
			private set { stats = value; }
		}
	
		public Arme Arme
        {
			get { return arme; }
			set { arme = value; }
		}
		
		public int NbPotion
        {
			get { return nbPotion; }
			set { nbPotion = value; }
		}
	
        public List<Sort> Sorts
        {
			get { return sorts; }
			private set { sorts = value; }
		}

		public List<int> DegatsDernierCombat
        {
			get { return degatsDernierCombat; }
			set { degatsDernierCombat = value; }
		}

		public Personnage(string nom, Classe classe, List<Sort> sorts, Arme arme)
		{
			this.Nom = nom;
			this.Classe = classe;
			this.Sorts = sorts;
			this.Arme = arme;
		}

		public void AjoutSort(Sort sort)
		{
			
		}

		public bool EstMort()
		{
			return this.Stats.EstMort();
		}
		public void Attaquer(Personnage ennemi)
		{

		}
		public void BoirePotion()
		{

		}
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
