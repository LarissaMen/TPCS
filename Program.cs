namespace TP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nom = ValiderChaineDeCaracteres("Entrer le nom de personnage");
          

            PrintClasse();
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
            //string afficheInve = string.Format("\n{0,-1} {1,-50} {2,58}", "#Items", "Description", "Prix");
            //string afficheInve1 = string.Format("{0,-1} {1,-50} {2,60}", "=====", "============", "======");
            Console.WriteLine("Quelle classe choisissez vous pour votre personnage?\n");
            Console.WriteLine("1- Archer");
            Console.WriteLine("2- Mage");
            Console.WriteLine("3- Guerrier");
            Console.WriteLine("4- Assassin");
            Console.WriteLine("5- Moine");
            Console.WriteLine("Entrez une valeur entre 1 et 5:");
        }
        public static void PrintArme()
        {
            Console.WriteLine("Quelle arme voulez vous utiliser?\n");
            Console.WriteLine("1- Aucune (mains Nues)");
            Console.WriteLine("2- Épée et bouclier");
            Console.WriteLine("3- Épée à deux mains");
            Console.WriteLine("4- Arc");
            Console.WriteLine("Entrez une valeur entre 1 et 4:");
        }
        public static void PrintSort()
        {
            Console.WriteLine("Quelle sort voulez-vous ajouter?\n");
            Console.WriteLine("0- Quitter");
            Console.WriteLine("1- Boule de feu");
            Console.WriteLine("2- Missile magique");
            Console.WriteLine("Entrez une valeur entre 0 et 3:");
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
    }
}