
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProducteurConsomatteur
{
    public class Consomateur : Machine {

        private Panier Input;

        protected override void OnExecute()
        {
            throw new NotImplementedException();
        }

        public Consomateur() : base(3,3,3)
        {

        }
    }
}
