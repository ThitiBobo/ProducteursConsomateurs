
using System;
using ProducteurConsomateur;
using System.Threading;



namespace Console
{
    class Program
    {
        public const int SECONDE = 1000;
        public const int MINUTE = 60 * SECONDE;

        static void Main(string[] args)
        {
<<<<<<< HEAD
            Exemple1.Execute(10 * MINUTE);


=======
            Exemple1.Execute(60000);
>>>>>>> 8b20e0e39078be71826c2e2ab7e3a642c76d335f
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("[ END ]");
            System.Console.ReadKey();
        }


    }
}
