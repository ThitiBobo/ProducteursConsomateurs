

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProducteurConsomatteur
{
    public class Producteur : Machine
    {

        private Panier Output;

        public Producteur(int id, ulong minTime, ulong maxTime) :
            base(id, minTime, maxTime)
        {

        }

        public Producteur(Machine copy) : base(copy)
        {
        }

        protected override void OnExecute()
        {
            Console.WriteLine("coucou");
        }

    }
}

