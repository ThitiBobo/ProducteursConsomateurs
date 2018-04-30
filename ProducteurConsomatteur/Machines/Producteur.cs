

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProducteurConsomatteur
{
    public class Producteur : Machine
    {

        #region ATTRIBUTS
        private Storable _output;
        #endregion

        #region GETSET
        public Storable Output {
            get => _output;
            set => _output = value ??
                throw new ArgumentNullException("le paramètre ne peux pas être null", "output");
        }
        #endregion

        #region CONSTRUCTORS
        public Producteur(int id, uint minTime, uint maxTime, Storable output) :
            base(id, minTime, maxTime)
        {
            Output = output;
        }

        public Producteur(int id, uint time, Storable output) :
            base(id, time)
        {
            Output = output; 
        }

        public Producteur(Producteur copy) : base(copy)
        {
            _output = copy._output;
        }
        #endregion


        protected override void OnExecute()
        {
            Work();
            _output.Add();
            Console.WriteLine("Machine {0}: dépot pièce P{1} ({2})", _id, ((Panier)_output).Id, ((Panier)_output).Count());
        }

        protected override bool IsReady()
        {
            if (_output == null)
                return false;
            return true;
        }
    }
}

