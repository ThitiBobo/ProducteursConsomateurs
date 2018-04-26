
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProducteurConsomatteur
{
    public class Consomateur : Machine {

        #region ATTRIBUTS
        private Storable _input;
        #endregion

        #region GETSET
        public Storable Input
        {
            get => _input;
            set => _input = value ?? 
                throw new ArgumentNullException("le paramètre ne peux pas être null", "input");   
        }
        #endregion

        #region CONSTRUCTORS
        public Consomateur(int id, uint minTime, uint maxTime, Storable input) : 
            base(id, minTime, maxTime)
        {
            Input = input;
        }

        public Consomateur(int id, uint time, Storable input) : base(id,time)
        {
            Input = input;
        }

        public Consomateur(Consomateur copy) : base(copy)
        {
            _input = copy._input;
        }
        #endregion

        
        protected override void OnExecute()
        {
            Console.WriteLine("début prise machine " + _id);
            _input.Take();
            Console.WriteLine("fin prise machine " + _id);
            Work();
        }

        protected override bool IsReady()
        {
            if (_input == null)
                return false;
            return true;
        }


    }
}
