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
        public void AttaquerTest()
        {
            Personnage joueur = new Personnage("Sameh", Classe.Archer, new List<Sort>(), Arme.EpeeDeuxMains);
            Personnage ennemi = new Personnage("Larissa", Classe.Guerrier, new List<Sort>(), Arme.EpeeDeuxMains);

            //Act

            joueur.Attaquer(ennemi);
            ennemi.Attaquer(joueur);

            //Assert
            //Assert.AreEqual(joueur.DegatsDernierCombats[0], -ennemi.DegatsDernierCombats[0]);
            Assert.AreEqual(joueur.DegatsDernierCombats[^1], -ennemi.DegatsDernierCombats[^1]);

        }
    }
}

