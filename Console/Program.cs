
using ProducteurConsomatteur;
using System.Threading;



namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Producteur tt = new Producteur(3, 3, 30);

            tt.Start();

            Thread.Sleep(5000);

            tt.Stop();

        }


    }
}
