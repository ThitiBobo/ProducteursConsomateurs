
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProducteurConsomatteur
{
    public class ProducteurConsomateur : Machine {

        /**
         * 
         */
        public ProducteurConsomateur(): base(3,3,3) {
        }

        /**
         * 
         */
        private Panier Input;

        /**
         * 
         */
        private Panier Output;

        protected override void OnExecute()
        {
            throw new NotImplementedException();
        }
    }
}
