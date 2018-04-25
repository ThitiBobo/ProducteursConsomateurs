
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProducteurConsomatteur
{
    public class Consomateur : Machine {

        #region ATTRIBUTS
        private Panier _input;
        #endregion

        #region GETSET
        public Panier Input
        {
            get => _input;
            set => _input = value ?? 
                throw new ArgumentNullException("le paramètre ne peux pas être null", "input");   
        }
        #endregion

        #region CONSTRUCTORS
        public Consomateur(int id, uint minTime, uint maxTime, Panier input) : 
            base(id, minTime, maxTime)
        {
            Input = input;
        }

        public Consomateur(int id, uint time, Panier input):
            base(id,time)
        {
            Input = input;
        }

        public Consomateur(Consomateur copy):
            base(copy._id,copy._minTime, copy._maxTime)
        {
            _input = copy._input;
        }
        #endregion

        
        protected override void OnExecute()
        {
            throw new NotImplementedException();
        }

        protected override bool IsReady()
        {
            if (_input == null)
                return false;
            return true;
        }


    }
}
