using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.Tests
{
    [TestClass()]
    public class GestionJeuxTests
    {
        [TestMethod()]

        public void EngagerCombat_AvecDeuxPersonnageEnVie_AuMoinsUnMort()
        {             
            // Arrangevar

            Personnage joueur = new Personnage("Joueur", Classe.Guerrier, new List<Sort>(), Arme.MainsNues);
            Personnage ennemi = new Personnage("Ennemi", Classe.Assassin, new List<Sort>(), Arme.MainsNues);
            GestionJeux gestionDeJeu = new GestionJeux(joueur, ennemi);
            joueur.Stats.PtsAttaque=30;
            //Act

            gestionDeJeu.EngagerCombat();
            bool joueurEstMort = gestionDeJeu.Joueur.EstMort();
            bool ennemiEstMort = gestionDeJeu.Ennemi.EstMort();

            //Assert
            Assert.IsTrue(joueurEstMort || ennemiEstMort);
        }
        [TestMethod()]
        public void EngagerCombat_WhenJoueurAndEnnemiAreAlreadyDead_ReturnsFalse()
        {
            // Arrange
         
            Personnage joueur = new Personnage("Joueur", Classe.Guerrier, new List<Sort>(), Arme.MainsNues);
            joueur.Stats.PtsVie = 0;
            Personnage ennemi = new Personnage("Ennemi", Classe.Archer, new List<Sort>(), Arme.MainsNues);
            ennemi.Stats.PtsVie = 0;


            GestionJeux gestionJeux = new GestionJeux(joueur, ennemi);

            // Act
            bool result = gestionJeux.EngagerCombat();

            // Assert
            
            Assert.IsFalse(result);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EngagerCombat_WhenEnnemiIsNull_ThrowsArgumentNullException()
        {
            // Arrange
          
            Personnage joueur = new Personnage("Joueur", Classe.Guerrier, new List<Sort>(), Arme.MainsNues);

            GestionJeux gestionJeux = new GestionJeux(joueur, null);

             gestionJeux.EngagerCombat();
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EngagerCombat_WhenJoueurIsNull_ThrowsArgumentNullException()
        {
            // Arrange
      
            Personnage ennemi = new Personnage("Ennemi", Classe.Archer, new List<Sort>(), Arme.MainsNues);

            GestionJeux gestionJeux = new GestionJeux(null, null);

            // Act & Assert

            gestionJeux.EngagerCombat();
        }
        [TestMethod()]
        public void EngagerCombat_WhenJoueurDefeatsEnnemi_ReturnsTrue()
        {
            // Arrange

            Personnage joueur = new Personnage("Joueur", Classe.Guerrier, new List<Sort>(), Arme.MainsNues);
            Personnage ennemi = new Personnage("Ennemi", Classe.Archer, new List<Sort>(), Arme.MainsNues);
         //On a dû initialiser les stats du joueur pour s'assurer qu'il est plus fort que l'ennemi dans ce 
         //scénario et éviter ainsi le caractère aléatoire de la méthode attaquer.
            joueur.Stats.PtsAttaque=100;
            ennemi.Stats.PtsAttaque=0;
            ennemi.Stats.PtsVie = 1;


            GestionJeux gestionJeux = new GestionJeux(joueur, ennemi);

            // Act
            bool result = gestionJeux.EngagerCombat();

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(joueur.EstMort());
            Assert.IsTrue(ennemi.EstMort());
        }
        [TestMethod()]
        public void EngagerCombat_WhenEnnemiDefeatsJoueur_ReturnsFalse()
        {
            // Arrange

            Personnage joueur = new Personnage("Joueur", Classe.Guerrier, new List<Sort>(), Arme.MainsNues);
            Personnage ennemi = new Personnage("Ennemi", Classe.Archer, new List<Sort>(), Arme.MainsNues);
            //On a dû initialiser les stats du joueur pour s'assurer qu'il est plus fort que l'ennemi dans ce 
            //scénario et éviter ainsi le caractère aléatoire de la méthode attaquer.
            ennemi.Stats.PtsAttaque = 100;
            joueur.Stats.PtsAttaque=0;



            GestionJeux gestionJeux = new GestionJeux(joueur, ennemi);

            // Act
            bool result = gestionJeux.EngagerCombat();

            // Assert
            Assert.IsFalse(result);
            Assert.IsTrue(joueur.EstMort());
            Assert.IsFalse(ennemi.EstMort());
        }

    }
       
}

 
