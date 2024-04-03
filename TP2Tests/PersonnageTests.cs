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

            
            do
            {
                joueur1.Attaquer(ennemi1);

            } while(joueur1.DegatsDernierCombats.Count == 0);
            //Assert

            Assert.AreEqual(joueur1.DegatsDernierCombats[^1], -ennemi1.DegatsDernierCombats[^1]);

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
        [TestMethod()]
        public void AjouterSort_UnSortAjouteeAUneListeVide()
        {
            // Arrange
            List<Sort> sort = new List<Sort>();
            Personnage joueur = new Personnage("Sameh", Classe.Mage, sort, Arme.Arc);
            Sort premierSort = new Sort("Boule de feu");
            int EXPECTED_SORT = 1;
            //Act
            joueur.AjouterSort(premierSort);

            //Asssert
            Assert.AreEqual(EXPECTED_SORT, sort.Count);
        }
        [TestMethod()]
        public void AjouterSort_UnSortAjouteeAUneListeNonVide()
        {
            // Arrange
            Sort sort = new Sort("Boule de feu");
            Sort sort1 = new Sort("Missile magique");
    
            List<Sort> listeSorts = new List<Sort>();
            listeSorts.Add(sort);
            listeSorts.Add(sort1);
          
            Personnage joueur = new Personnage("Sameh", Classe.Mage, listeSorts, Arme.Arc);
            Sort troisiemeSort = new Sort("Boule de feu");
           const int EXPECTED_SORT = 3;
            //Act
            joueur.AjouterSort(troisiemeSort);

            //Asssert
            Assert.AreEqual(EXPECTED_SORT, listeSorts.Count);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BoirePotion_PotionNegative()
        {
            // Arrange
            Personnage joueur = new Personnage("Sameh", Classe.Archer, new List<Sort>(), Arme.EpeeDeuxMains);
           
            joueur.NbPotion = -2;

            //Act
          
            //Asssert

        }
        [TestMethod()]

        public void BoirePotion_PotionValide_PtsVieEgalPtsVieMax()
        {
            // Arrange
            Personnage joueur = new Personnage("Sameh", Classe.Archer, new List<Sort>(), Arme.EpeeDeuxMains);
            joueur.Stats.PtsVieMax = 8;
            joueur.Stats.PtsVie=2;
            joueur.NbPotion = 2;

            //Act
            joueur.BoirePotion();
            const int EXPECTED_POTION = 1;
            const int EXPECTED_PTSVIE_APRES_BOIREPOTON = 8;

            //Asssert
            Assert.AreEqual(EXPECTED_POTION, joueur.NbPotion);
            Assert.AreEqual(EXPECTED_PTSVIE_APRES_BOIREPOTON, joueur.Stats.PtsVie);
        }
        [TestMethod()]

        public void BoirePotion_PotionValide_PtsVieEgalePtsVieMaxPlusBonusPotion()
        {
            // Arrange
            Personnage joueur = new Personnage("Sameh", Classe.Archer, new List<Sort>(), Arme.EpeeDeuxMains);
            joueur.Stats.PtsVieMax = 8;
            joueur.Stats.PtsVie=1;
            joueur.NbPotion = 1;

            //Act
            joueur.BoirePotion();
            const int EXPECTED_POTION = 0;
            const int EXPECTED_PTSVIE_APRES_BOIREPOTON = 7;

            //Asssert
            Assert.AreEqual(EXPECTED_POTION, joueur.NbPotion);
            Assert.AreEqual(EXPECTED_PTSVIE_APRES_BOIREPOTON, joueur.Stats.PtsVie);
        }
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BoirePotion_AucunePotionDisponible()
        {
            // Arrange
            Personnage joueur = new Personnage("Sameh", Classe.Archer, new List<Sort>(), Arme.EpeeDeuxMains);
            joueur.Stats.PtsVieMax = 8;
            joueur.Stats.PtsVie=1;
            joueur.NbPotion = 0;

            //Act
            joueur.BoirePotion();

        }
    }
}

