
using System;
using ProducteurConsomatteur;
using System.Threading;



namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Storable storage = new Panier(001, 10, 5);

            Producteur prod = new Producteur(021, 1000, 2000, storage);
            Consomateur cons = new Consomateur(031, 5000, 10000, storage);

            prod.Start();
            cons.Start();

            while (true)
            {
                Thread.Sleep(2000);
                System.Console.WriteLine(storage.Count());
            }


        }


    }
}
