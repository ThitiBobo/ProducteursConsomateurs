using System;
using ProducteurConsomateur;
using System.Threading;

namespace Console
{
    public static class Exemple1
    {

        public static void Execute(int time)
        {
            Storable panier1 = new Panier(1, 5);
            Storable panier2 = new Panier(2, 7);

            Machine machine1 = new Producteur(1, 3000, 6000, panier1);
            Machine machine2 = new ProducteurConsomateur.ProducteurConsomateur(2, 5000, 9000, panier1, panier2);
            Machine machine3 = new Consomateur(3, 3000, 6000, panier2);

            machine1.Start();
            machine2.Start();
            machine3.Start();

            Thread.Sleep(time);

            machine1.Stop();
            machine2.Stop();
            machine3.Stop();

            machine1.Join();
            machine2.Join();
            machine3.Join();

        }
    }
}
