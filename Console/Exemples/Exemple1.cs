using System;
using ProducteurConsomatteur;
using System.Threading;

namespace Console
{
    public static class Exemple1
    {

        public static void Execute(int time)
        {
            Storable panier1 = new Panier(1, 5);
            Storable panier2 = new Panier(2, 7);

            Machine machine1 = new Producteur(1, 3, 6, panier1);
            Machine machine2 = new ProducteurConsomateur(2, 5, 9, panier1, panier2);
            Machine machine3 = new Consomateur(3, 3, 6, panier2);

            machine1.Start();
            machine2.Start();
            machine3.Start();

            Thread.Sleep(time);

            machine1.Stop();
            machine2.Stop();
            machine3.Stop();

        }
    }
}
