namespace TP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int archer=new Random().Next(1,11);
            //int archer = 7;
            //int squelette = 10;
            Personnage joueur = new Personnage("Sameh", Classe.Archer, new List<Sort>(), Arme.EpeeDeuxMains);
            Personnage ennemi = new Personnage("Larissa", Classe.Squellette, new List<Sort>(), Arme.EpeeBouclier);
            joueur.Stats=new StatsPersonnage(9, 5, 2);
            ennemi.Stats=new StatsPersonnage(7, 2, 1);


            //Act
            Console.WriteLine(joueur.Stats.ToString());
            Console.WriteLine(ennemi.Stats.ToString());
            joueur.DegatsDernierCombats = new List<int>();
            ennemi.DegatsDernierCombats = new List<int>();

            joueur.Attaquer(ennemi);
           
            Console.WriteLine(joueur.Stats.ToString());
            Console.WriteLine(ennemi.Stats.ToString());

        }
    }
}