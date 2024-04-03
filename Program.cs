namespace TP2
{
    internal class Program
    {
    

        static void Main(string[] args)
        {

            List<Sort> listeSorts = Utility.CreerListeSorts();
            Personnage joueur = Utility.CreerJoueur(listeSorts);
            Personnage ennemi = Utility.CreerEnnemi();

            Utility.EngagerCombat(joueur, ennemi);



        }
      
    }
}