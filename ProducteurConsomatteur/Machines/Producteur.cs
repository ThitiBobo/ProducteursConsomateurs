

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProducteurConsomatteur
{
    /// <summary>
    /// Représente une instance dérivant de la classe <c>Machine</c> pouvant 
    /// fabriquer un objet avec un temps de fabrication comprit dans une intervalle
    /// et le déposer en sortie dans une instance implémentant l'interface Storable.
    /// </summary>
    public class Producteur : Machine
    {

        #region ATTRIBUTS
        /// <summary>
        /// Instance de type <c>Storable</c> utilisé comme sortie
        /// </summary>
        private Storable _output;
        #endregion

        #region GETSET
        /// <summary>
        /// Permet de modifier le Stockage de sortie
        /// </summary>
        public Storable Output {
            get => _output;
            set => _output = value ??
                throw new ArgumentNullException("le paramètre ne peux pas être null", "output");
        }
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Permet de créer une nouvelle instance en précisant l'idantifiant, le temps minimum 
        /// et maximum de fabrication ainsi que le stokage de sorite 
        /// </summary>
        /// <param name="id">Identifiant de l'instance</param>
        /// <param name="minTime">Temps minimum de fabrication</param>
        /// <param name="maxTime">Temps maximum de fabrication</param>
        /// <param name="output">Stokage de sortie</param>
        public Producteur(int id, uint minTime, uint maxTime, Storable output) :
            base(id, minTime, maxTime)
        {
            Output = output;
        }

        /// <summary>
        /// Permet de créer une nouvelle instance en précisant l'identifiant, le temp de fabrication
        /// et le stokage de sortie
        /// </summary>
        /// <param name="id">Identifiant de l'instance</param>
        /// <param name="time">Temps de fabrication</param>
        /// <param name="output">Stokage de sortie</param>
        /// <remarks>Temps de fabrication est comprise dans l'intervalle [minTime; maxTime] 
        /// / minTime = maxTime </remarks>
        public Producteur(int id, uint time, Storable output) :
            base(id, time)
        {
            Output = output; 
        }

        /// <summary>
        /// Permet de créer une nouvelle instance à partir d'une instance déjà existante
        /// </summary>
        /// <param name="copy">Instance à recopier</param>
        public Producteur(Producteur copy) : base(copy)
        {
            _output = copy._output;
        }
        #endregion

        /// <summary>
        /// méthode contenant le protocole de fabrication de la machine
        /// </summary>
        protected override void OnExecute()
        {
            Work();
            _output.Add();
            Console.WriteLine("Machine {0}: dépot pièce P{1} ({2})", _id, _output.GetName(), _output.Count());
        }

        /// <summary>
        /// Permet de vérifier si la machine est intégre avant le démarage
        /// </summary>
        /// <returns>retourne <c>true</c> si l'instance est intégre, sinon <c>false</c>.</returns>
        protected override bool IsReady()
        {
            if (_output == null)
                return false;
            return true;
        }
    }
}

