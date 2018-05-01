
using System;

namespace ProducteurConsomatteur
{
    /// <summary>
    /// Repr�sente une instance d�rivant de la classe <c>Machine</c> pouvant prendre un objet 
    /// en entr�e dans une instance impl�mentant l'interface Storable.
    /// Et consomme l'objet avec un temps compris dans une intervalle.
    /// </summary>
    public class Consomateur : Machine {

        #region ATTRIBUTS
        /// <summary>
        /// Instance de type <c>Storable</c> utilis� comme entr�e
        /// </summary>
        private Storable _input;
        #endregion

        #region GETSET
        /// <summary>
        /// Permet de modifier le Stokage d'entr�e
        /// </summary>
        public Storable Input
        {
            get => _input;
            set => _input = value ?? 
                throw new ArgumentNullException("le param�tre ne peux pas �tre null", "input");   
        }
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Permet de cr�er une nouvelle instance en pr�cissant l'idantifiant, le temps minimum 
        /// et maximum de fabrication ainsi que le stokage d'entr�e 
        /// </summary>
        /// <param name="id">Identifiant de l'instance</param>
        /// <param name="minTime">Temps minimum de fabrication</param>
        /// <param name="maxTime">Temps maximum de fabrication</param>
        /// <param name="input">Stokage d'entr�e</param>
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
            Console.WriteLine("Machine {0}: prise pi�ce P{1} ({2})", _id, _input.GetName(), _input.Count());
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
