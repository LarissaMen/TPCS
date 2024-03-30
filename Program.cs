namespace TP2
{
    internal class Program
    {
        public const int  QUIT= 0;
       
        public const int MAX_SORT = 3;
        
     
       

        static void Main(string[] args)
        {
            Sort sort = new Sort("Boule de feu");
            Sort sort1 = new Sort("Missile magique");
            Sort sort2 = new Sort("Foudre");
            List<Sort> listeSorts = new List<Sort>();
            listeSorts.Add(sort);
            listeSorts.Add(sort1);
            listeSorts.Add(sort2);

            CreerPersonnage(listeSorts);




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
                    DisplayErrorMessage($"\n****Veuillez entrez un nombre entre {min} et {max}***** ");

            } while (value < min || value > max || !success);

            return value;
        }
        public static void DisplayErrorMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;


            int cursorLeft = Console.CursorLeft;
            Console.WriteLine(errorMessage);
            Console.SetCursorPosition(cursorLeft + errorMessage.Length, Console.CursorTop - 1);
            Console.ResetColor();
        }
        public static void PrintClasse()
        {
           Console.WriteLine("Quelle classe choisissez vous pour votre personnage?\n");
            Console.WriteLine("1- Archer");
            Console.WriteLine("2- Mage");
            Console.WriteLine("3- Guerrier");
            Console.WriteLine("4- Assassin");
            Console.WriteLine("5- Moine");
          
        }
        public static void PrintArme()
        {
            Console.WriteLine("Quelle arme voulez vous utiliser?\n");
            Console.WriteLine("1- Aucune (mains Nues)");
            Console.WriteLine("2- Épée et bouclier");
            Console.WriteLine("3- Épée à deux mains");
            Console.WriteLine("4- Arc");
           
        }
        public static void PrintSort(List<Sort> listeSorts)
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
        public static void CreerPersonnage(List<Sort> listeSorts)
        {
            string nom = ValiderChaineDeCaracteres("Entrer le nom de personnage");
            PrintClasse();
            Classe choixClasse = (Classe )ValiderNombre("\nEntrez une valeur entre 1 et 5:", (int)Classe.Archer, (int)Classe.Moine);
           
            PrintArme();
            Arme choixArme=(Arme)ValiderNombre("\nEntrez une valeur entre 1 et 4:",(int)Arme.MainsNues, (int)Arme.Arc);
            Console.WriteLine(choixArme);
            List<Sort> sorts = new List<Sort>();
            Personnage joueur = new Personnage(nom, choixClasse, sorts, choixArme);
            if (choixClasse==Classe.Mage)
            {
                int choixSort;
               
                do
                {
                    PrintSort(listeSorts);
                    choixSort=ValiderNombre($"Entrez une valeur entre 0 et {listeSorts.Count+1}:", QUIT,listeSorts.Count+1);
                    if (choixSort!=QUIT)
                     joueur.AjoutSort(listeSorts[choixSort-1]);
                    //sorts.Add(listeSorts[choixSort-1]);
                   
                } while (choixSort!=QUIT);
               

            }
            
            //Personnage joueur = new Personnage(nom, choixClasse, sorts, choixArme);
            foreach (var sort in joueur.Sorts)
            {
                Console.WriteLine(sort.NomSort);
            }
            Affiche();
            Console.WriteLine(joueur.ToString());

        }
        public static void Affiche()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("****************************************************************");
            Console.WriteLine("*********************Personnage créee***************************");
            Console.WriteLine("****************************************************************");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}