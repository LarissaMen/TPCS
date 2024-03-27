using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2CS
{
    public class StatsPersonnage
    {
        private int ptsVie;

        public int PtsVie
        {
            get { return ptsVie; }
            set { ptsVie = value; }
        }
        private int ptsvieMax;

        public int PtsvieMax
        {
            get { return ptsvieMax; }
            set { ptsvieMax = value; }
        }

        private int ptsAttaque;

        public int PtsAttaque
        {
            get { return ptsAttaque; }
            set { ptsAttaque = value; }
        }
        private int ptsDefense;

        public int PtsDefense
        {
            get { return ptsDefense; }
            set { ptsDefense = value; }
        }
        private int ptsExperience;

        public int PtsExperience
        {
            get { return ptsExperience; }
            set { ptsExperience = value; }
        }
        public StatsPersonnage(int ptsVieMax, int ptsAttaque, int ptsDefense)
        {
            this.PtsvieMax = ptsVieMax;
            this.PtsAttaque = ptsAttaque;
            this.PtsDefense = ptsDefense;
        }
        public bool EstMort()
        {
            return false;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
