
using System;

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
            _input.Take();
            Console.WriteLine("Machine {0}: prise pièce P{1} ({2})", _id, _input.GetName(), _input.Count());
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
