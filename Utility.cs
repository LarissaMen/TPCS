using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Utility
    {
        public const int QUIT = 0;

        public const int MAX_SORT = 3;
        public const int PREMIERE_ARME_MAGICIEN_INTERDITE = 2;
        public const int DEUXIEME_ARME_MAGICIEN_INTERDITE = 3;
        public static List<Sort> CreerListeSorts()
        {
            Sort sort = new Sort("Boule de feu");
            Sort sort1 = new Sort("Missile magique");
            Sort sort2 = new Sort("Foudre");
            List<Sort> listeSorts = new List<Sort>();
            listeSorts.Add(sort);
            listeSorts.Add(sort1);
            listeSorts.Add(sort2);
            return listeSorts;
        }
        public static int ValiderNombre(string phrase, int min, int max)
        {

            int value = 0;
            bool success;
            Console.Write(phrase);
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string inputUser = Console.ReadLine();
                Console.ResetColor();

                success = int.TryParse(inputUser, out value);
                if (value < min || value > max || !success)
                    AfficherMessageErreur($"\n****Veuillez entrez un nombre entre {min} et {max}***** ");

            } while (value < min || value > max || !success);

            return value;
        }
        public static void AfficherMessageErreur(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;


            int cursorLeft = Console.CursorLeft;
            Console.WriteLine(errorMessage);
            Console.SetCursorPosition(cursorLeft + errorMessage.Length, Console.CursorTop - 1);
            Console.ResetColor();
        }
        public static void AfficherClasse()
        {
            Console.WriteLine("Quelle classe choisissez vous pour votre personnage?\n");
            Console.WriteLine("1- Archer");
            Console.WriteLine("2- Mage");
            Console.WriteLine("3- Guerrier");
            Console.WriteLine("4- Assassin");
            Console.WriteLine("5- Moine");

        }
        public static void AfficherArme()
        {
            Console.WriteLine("Quelle arme voulez vous utiliser?\n");
            Console.WriteLine("1- Aucune (mains Nues)");
            Console.WriteLine("2- Épée et bouclier");
            Console.WriteLine("3- Épée à deux mains");
            Console.WriteLine("4- Arc");

        }
        public static void AfficherSort(List<Sort> listeSorts)
        {
            Console.WriteLine("\nQuelle sort voulez-vous ajouter?\n");
            Console.WriteLine("0- Quitter");
            for (int i = 0; i < listeSorts.Count; i++)
            {
                Console.WriteLine($"{i+1}"+"-" + $"{listeSorts[i].NomSort}");
            }

        }
        public static string ValiderChaineDeCaracteres(string question)
        {
            bool succes;
            string reponse;

            do
            {
                succes = true;
                Console.WriteLine(question);
                reponse = Console.ReadLine();
                reponse = reponse.Trim();
                if (reponse == String.Empty)
                {
                    succes = false;
                    Console.WriteLine("Ne peut pas être vide!");
                }

            } while (!succes);

            return reponse;
        }
        public static Personnage CreerJoueur(List<Sort> listeSorts)
        {
            AfficherTitreSection("Création du personnage");

            string nom = ValiderChaineDeCaracteres("Entrer le nom de personnage");
            AfficherClasse();
            Classe choixClasse = (Classe)ValiderNombre("\nEntrez une valeur entre 1 et 5:", (int)Classe.Archer, (int)Classe.Moine);
            Arme choixArme;
            if (choixClasse == Classe.Mage)
            {

                AfficherArmeMagicien();
                choixArme = (Arme)ValiderNombreMagicien("\nEntrez une valeur entre 1 ou 4:", (int)Arme.MainsNues, (int)Arme.Arc);

            }
            else
            {
                AfficherArme();

                choixArme = (Arme)ValiderNombre("\nEntrez une valeur entre 1 et 4:", (int)Arme.MainsNues, (int)Arme.Arc);
            }


            List<Sort> sorts = new List<Sort>();
            Personnage joueur = new Personnage(nom, choixClasse, sorts, choixArme);
            if (choixClasse == Classe.Mage)
            {
                int choixSort;

                do
                {
                    AfficherSort(listeSorts);
                    choixSort = ValiderNombre($"Entrez une valeur entre 0 et {listeSorts.Count + 1}:", QUIT, listeSorts.Count + 1);
                    if (choixSort != QUIT)
                        joueur.AjouterSort(listeSorts[choixSort - 1]);
                    //sorts.Add(listeSorts[choixSort-1]);

                } while (choixSort != QUIT);


            }

            //Personnage joueur = new Personnage(nom, choixClasse, sorts, choixArme);
            foreach (Sort sort in joueur.Sorts)
            {
                Console.WriteLine(sort.NomSort);
            }
            AfficherTitreSection("Personnage créé");
            Console.WriteLine(joueur);
            return joueur;
        }

        public static void AfficherArmeMagicien()
        {
            Console.WriteLine("Quelle arme voulez vous utiliser?\n");
            Console.WriteLine("1- Aucune (mains Nues)");
            Console.WriteLine("4- Arc");
        }
        public static int ValiderNombreMagicien(string phrase, int min, int max)
        {

            int value = 0;
            bool success;
            Console.Write(phrase);
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string inputUser = Console.ReadLine();
                Console.ResetColor();

                success = int.TryParse(inputUser, out value);
                if (value < min || value > max ||value == 2 ||  value == 3 ||!success)
                    AfficherMessageErreur($"\n****Veuillez entrez un nombre  {min} ou {max}***** ");

            } while (value < min || value > max  ||value == PREMIERE_ARME_MAGICIEN_INTERDITE ||  value == DEUXIEME_ARME_MAGICIEN_INTERDITE ||!success);

            return value;
        }
        public static void AfficherTitreSection(string titre)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n*********************{titre}***************************\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void AfficherResultat(Personnage joueur, Personnage ennemi, bool resultat)
        {
            Console.WriteLine($"Stats du joueur :{joueur}");
            Console.WriteLine($"Stats de l'ennemi :{ennemi}");

            if (resultat)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Le jouer a gagné");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Le jouer a perdu");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static Personnage CreerEnnemi()
        {
            Personnage personnage = new Personnage("Assassin", Classe.Assassin, new List<Sort>(), Arme.MainsNues);
            StatsPersonnage stats = new StatsPersonnage(10, 2, 2);
            personnage.Stats = stats;
            return personnage;
        }
        public static void EngagerCombat(Personnage joueur, Personnage ennemi)
        {
            AfficherTitreSection("DEBUT COMBAT");
            GestionJeux gestionJeu = new GestionJeux(joueur, ennemi);

            bool resultat = gestionJeu.EngagerCombat();

            AfficherResultat(joueur, ennemi, resultat);

            AfficherTitreSection("FIN COMBAT");
        }
    }
}
