
using System;

namespace ProducteurConsomatteur
{
    /// <summary>
    /// Représente une instance dérivant de la classe <c>Machine</c> pouvant prendre un objet 
    /// en entrée dans une instance implémentant l'interface Storable.
    /// Et consomme l'objet avec un temps compris dans une intervalle.
    /// </summary>
    public class Consomateur : Machine {

        #region ATTRIBUTS
        /// <summary>
        /// Instance de type <c>Storable</c> utilisé comme entrée
        /// </summary>
        private Storable _input;
        #endregion

        #region GETSET
        /// <summary>
        /// Permet de modifier le Stokage d'entrée
        /// </summary>
        public Storable Input
        {
            get => _input;
            set => _input = value ?? 
                throw new ArgumentNullException("le paramètre ne peux pas être null", "input");   
        }
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Permet de créer une nouvelle instance en précisant l'idantifiant, le temps minimum 
        /// et maximum de fabrication ainsi que le stokage d'entrée 
        /// </summary>
        /// <param name="id">Identifiant de l'instance</param>
        /// <param name="minTime">Temps minimum de fabrication</param>
        /// <param name="maxTime">Temps maximum de fabrication</param>
        /// <param name="input">Stokage d'entrée</param>
        public Consomateur(int id, uint minTime, uint maxTime, Storable input) : 
            base(id, minTime, maxTime)
        {
            Input = input;
        }

        /// <summary>
        /// Permet de créer une nouvelle instance en précisant l'identifiant, le temp de fabrication
        /// et le stokage d'entrée
        /// </summary>
        /// <param name="id">Identifiant de l'instance</param>
        /// <param name="time">Temps de fabrication</param>
        /// <param name="input">Stokage d'entrée</param>
        /// <remarks>Temps de fabrication est comprise dans l'intervalle [minTime; maxTime] 
        /// / minTime = maxTime </remarks>
        public Consomateur(int id, uint time, Storable input) : base(id,time)
        {
            Input = input;
        }

        /// <summary>
        /// Permet de créer une nouvelle instance à partir d'une instance déjà existante
        /// </summary>
        /// <param name="copy">Instance à recopier</param>
        public Consomateur(Consomateur copy) : base(copy)
        {
            _input = copy._input;
        }
        #endregion

        /// <summary>
        /// méthode contenant le protocole de fabrication de la machine
        /// </summary>
        protected override void OnExecute()
        {
            _input.Take();
            Console.WriteLine("Machine {0}: prise pièce P{1} ({2})", _id, _input.GetName(), _input.Count());
            Work();
        }

        /// <summary>
        /// Permet de vérifier si la machine est intégre avant le démarage
        /// </summary>
        /// <returns>retourne <c>true</c> si l'instance est intégre, sinon <c>false</c>.</returns>
        protected override bool IsReady()
        {
            if (_minTime > _maxTime)
                return false;
            if (_input == null)
                return false;
            return true;
        }


    }
}
