using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP2.Tests
{
    [TestClass()]
    public class PersonnageTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonnageTestNomNull()
        {
            Personnage joueur = new Personnage(null, Classe.Archer, new List<Sort>(), Arme.EpeeDeuxMains);
           
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PersonnageTestNomVide()
        {
            Personnage joueur = new Personnage("", Classe.Archer, new List<Sort>(), Arme.EpeeDeuxMains);

        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonnageTestSortNullPourMage()
        {
            Personnage joueur = new Personnage("Sameh", Classe.Mage, null, Arme.EpeeDeuxMains);

        }
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PersonnageTestSortPourMage()
        {
            Personnage joueur = new Personnage("Sameh", Classe.Mage, new List<Sort>(), Arme.EpeeDeuxMains);
            Arme Expected = Arme.MainsNues;
            Assert.AreEqual(Expected, joueur.Arme);


        }
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PersonnageTestArmePourMage()
        {
            Personnage joueur = new Personnage("Sameh", Classe.Mage, new List<Sort>(), Arme.EpeeDeuxMains);
        
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PersonnageTestNulleStats()
        {
           
            Personnage joueur = new Personnage("Sameh", Classe.Guerrier, new List<Sort>(), Arme.EpeeDeuxMains);
            joueur.Stats=null;

        }
        [TestMethod()]
        public void PersonnageTestconstructeur()
        {
            Personnage joueur = new Personnage("Ninja", Classe.Archer, new List<Sort>(), Arme.EpeeDeuxMains);

        }
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AttaquerTestEnnemiDejaMort()
        {
            Personnage joueur = new Personnage("Sameh", Classe.Archer, new List<Sort>(), Arme.EpeeDeuxMains);
            Personnage ennemi = new Personnage("Ninja", Classe.Moine, new List<Sort>(), Arme.EpeeDeuxMains);

            //Act

            joueur.Stats.PtsVie=0;
            joueur.Attaquer(ennemi);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AttaquerTestNulleEnnemi()
        {
            Personnage joueur = new Personnage("Sameh", Classe.Archer, new List<Sort>(), Arme.EpeeDeuxMains);
            Personnage ennemi =null;

            //Act
            joueur.Attaquer(ennemi);
        }
           

         [TestMethod()]
        public void AttaquerTestDeuxPersonnagesVivants()
        {
            Personnage joueur1 = new Personnage("Sameh", Classe.Archer, new List<Sort>(), Arme.EpeeDeuxMains);
            Personnage ennemi1 = new Personnage("Larissa", Classe.Guerrier, new List<Sort>(), Arme.EpeeDeuxMains);

            //Act

            joueur1.Attaquer(ennemi1);
            

            //Assert
            
            Assert.AreEqual(joueur1.DegatsDernierCombats[joueur1.DegatsDernierCombats.Count-1], -ennemi1.DegatsDernierCombats[ennemi1.DegatsDernierCombats.Count-1]);

        }
        [TestMethod()]
        public void EstMortReturnVraie()
        {
            Personnage joueur = new Personnage("Sameh", Classe.Archer, new List<Sort>(), Arme.EpeeDeuxMains);
           joueur.Stats.PtsVie = 0;
            //Act
            bool estMort = joueur.EstMort();
            //Assert
            Assert.IsTrue(estMort);
        }
        [TestMethod()]
        public void EstMortReturnFaux()
        {
            Personnage joueur = new Personnage("Sameh", Classe.Archer, new List<Sort>(), Arme.EpeeDeuxMains);
            joueur.Stats.PtsVie = 10;
            //Act
            bool estMort = joueur.EstMort();
            //Assert
            Assert.IsFalse(estMort);

        }
        //[TestMethod()]
        //public void AjouterSort_UnSortAjouteeALaListe()
        //{
        //    // Arrange
        //    List<Sort> sort = new List<Sort>();
        //    Personnage joueur = new Personnage("Sameh", Classe.Mage, sort, Arme.Arc);
          
        //    int EXPECTED_SORT = 1;
        //    //Act
        //    joueur.AjouterSort(sort);

        //    //Asssert
        //    Assert.AreEqual(EXPECTED_SORT, sort.Count);
        //}
    }
}

