using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2CS
{
    public class Sort
    {
		private string nom;
        private int ptsDegatMin;
        private int ptsDegatsMax;

        public string Nom
		{
			get { return nom; }
			set { nom = value; }
		}
	
		public int PtsDegatMin
        {
			get { return ptsDegatMin; }
			set { ptsDegatMin = value; }
		}

		public int PtsDegatsMax
        {
			get { return ptsDegatsMax; }
			set { ptsDegatsMax = value; }
		}

		public Sort(string nom)
		{
			this.Nom = nom;
			this.PtsDegatMin = 0;
			this.PtsDegatsMax = 0;
		}

		public int  GetDegats()
		{
			return -1;
		}
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
