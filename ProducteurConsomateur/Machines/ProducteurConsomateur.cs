
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProducteurConsomateur
{
    /// <summary>
    /// Repr�sente une instance d�rivant de la classe <c>Machine</c> 
    /// pouvant prendre un objet en entr�e dans une instance impl�mentant l'interface Storable.
    /// Fabriquer un objet avec un temps de fabrication comprit dans une intervalle
    /// et le d�poser en sortie dans une instance impl�mentant l'interface Storable.
    /// </summary>
    public class ProducteurConsomateur : Machine {


        #region ATTRIBUTS
        /// <summary>
        /// Instance de type <c>Storable</c> utilis� comme entr�e
        /// </summary>
        private Storable _input;

        /// <summary>
        /// Instance de type <c>Storable</c> utilis� comme sortie
        /// </summary>
        private Storable _output;
        #endregion

        #region GETSET
        /// <summary>
        /// Permet de modifier le Stokage d'entr�e
        /// </summary>
        public Storable Input {
            get => _input;
            set => _input = value ??
                throw new ArgumentNullException("le param�tre ne peux pas �tre null", "input");
        }

        /// <summary>
        /// Permet de modifier le Stockage de sortie
        /// </summary>
        public Storable Output {
            get => _output;
            set => _output = value ??
                throw new ArgumentNullException("le param�tre ne peux pas �tre null", "output");
        }
        #endregion

        #region CONTRUCTORS
        /// <summary>
        /// Permet de cr�er une nouvelle instance en pr�cisant l'idantifiant, le temps minimum 
        /// et maximum de fabrication ainsi que le stockage d'entr�e et le stockage de sortie 
        /// </summary>
        /// <param name="id">Identifiant de l'instance</param>
        /// <param name="minTime">Temps minimum de fabrication</param>
        /// <param name="maxTime">Temps maximum de fabrication</param>
        /// <param name="input">Stockage d'entr�e</param>
        /// <param name="output">Stockage de sortie</param>
        public ProducteurConsomateur(int id, uint minTime, uint maxTime, Storable input, Storable output) : 
            base(id, minTime, maxTime)
        {
            Input = input;
            Output = output;
        }

        /// <summary>
        /// Permet de cr�er une nouvelle instance en pr�cisant l'identifiant, le temp de fabrication,
        /// le stockage d'entr�e et le stockage de sortie
        /// </summary>
        /// <param name="id">Identifiant de l'instance</param>
        /// <param name="time">Temps de fabrication</param>
        /// <param name="input">Stockage d'entr�e</param>
        /// <param name="output">Stockage de sortie</param>
        /// <remarks>Temps de fabrication est comprise dans l'intervalle [minTime; maxTime] 
        /// / minTime = maxTime </remarks>
        public ProducteurConsomateur(int id, uint time, Storable input, Storable output) :
            base(id, time)
        {
            Input = input;
            Output = output;
        }

        /// <summary>
        /// Permet de cr�er une nouvelle instance � partir d'une instance d�j� existante
        /// </summary>
        /// <param name="copy">Instance � recopier</param>
        public ProducteurConsomateur(ProducteurConsomateur copy) :
            base(copy)
        {
            _input = copy._input;
            _output = copy._output;
        }
        #endregion

        /// <summary>
        /// m�thode contenant le protocole de fabrication de la machine
        /// </summary>
        protected override void OnExecute()
        {
            _input.Take();
            Console.WriteLine("Machine {0}: prise pi�ce P{1} ({2})", _id, _input.GetName(), _input.Count());
            Work();
            _output.Add();
            Console.WriteLine("Machine {0}: d�pot pi�ce P{1} ({2})", _id, _output.GetName(), _output.Count());
        }

        /// <summary>
        /// Permet de v�rifier si la machine est int�gre avant le d�marage
        /// </summary>
        /// <returns>retourne <c>true</c> si l'instance est int�gre, sinon <c>false</c>.</returns>
        protected override bool IsReady()
        {
            if (_input == null)
                return false;
            if (_output == null)
                return false;
            return true;
        }
    }
}
