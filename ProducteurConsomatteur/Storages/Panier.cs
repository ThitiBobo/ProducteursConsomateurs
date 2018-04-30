
using System;
using System.Threading;

namespace ProducteurConsomatteur
{
    /// <summary>
    /// Repr�sente une instance pouvant contenir, ajouter ou retirer des objets dans un stokage limit�.
    /// L'Ajout et le Retrait ne peuvent �tre �x�cut�s que par une seule instance ext�rieur � la fois,
    /// les deux m�thodes sont control�es par une instance <c>Semaphore</c>
    /// Impl�mente l'interface Storable ainsi que toutes ses m�thodes.
    /// </summary>
    public class Panier : Storable
    {

        #region ATTRIBUTS
        /// <summary>
        /// Identifiant de l'intance <c>Panier</c>
        /// </summary>
        protected int _id;

        /// <summary>
        /// Capcait� maximum de l'intance <c>Panier</c>
        /// </summary>
        protected uint _capacity;

        /// <summary>
        /// Nombre d'objet contenu par l'intance <c>Panier</c> 
        /// </summary>
        protected uint _nbObject;
        
        #endregion

        #region GETSET
        /// <summary>
        /// Permet de modifier l'id de l'intance
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Permet de modifier la capacit� de l'intance
        /// </summary>
        public uint Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        /// <summary>
        /// Permet de modifier le nombre d'objets contenu par l'intance
        /// </summary>
        public uint NbObject
        {
            get { return _nbObject; }
            set
            {
                if (NbObject > _capacity)
                    throw new ArgumentOutOfRangeException("le nombre d'objet pr�cis� est sup�rieur � la capacit�", "nbObject");
                _nbObject = value;
            }
        }
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Permet de cr�er une nouvelle intance de <c>Panier</c> en pr�cisant son id,
        /// sa capacit�e et son nombre d'objet au d�but. 
        /// </summary>
        /// <param name="id">Identifiant de l'intance</param>
        /// <param name="capacity">Nombre d'objet maximum que peux contenir l'instance</param>
        /// <param name="nbObject">Nombre d'objet contenue par l'instance au d�but</param>
        /// <remarks><c>nbObject</c> doit etre inf�rieur ou �gal � <c>capacity</c> </remarks>
        /// <exception cref="ArgumentOutOfRangeException"
        public Panier(int id, uint capacity, uint nbObject)
        {
            _id = id;
            Capacity = capacity;
            NbObject = nbObject;
            
        }

        /// <summary>
        /// Permet de cr�er une nouvelle intance de <c>Panier</c> en pr�cisant son id et
        /// sa capacit�e.
        /// </summary>
        /// <param name="id">Identifiant de l'intance</param>
        /// <param name="capacity">Nombre d'objet maximum que peux contenir l'instance</param>
        public Panier(int id, uint capacity) :
            this(id, capacity, 0)
        { }

        /// <summary>
        /// Permet de cr�er une nouvelle intance de <c>Panier</c> � partir d'une copie
        /// </summary>
        /// <param name="copy">instance de type <c>Panier</c> � recopier</param>
        public Panier(Panier copy)
        {
            if (copy == null)
                throw new ArgumentNullException("l'arguments pass� ne peux pas �tre null", "copy");
            _id = copy._id;
            _capacity = copy._capacity;
            _nbObject = copy._nbObject;       
        }

        #endregion

        public string GetName()
        {
            return Id.ToString();
        }

        /// <summary>
        /// Permet d'ajouter un objet dans le stokage de l'intance <c>Panier</c> 
        /// </summary>
        /// <remarks>Retourne une exception si la capacit� a d�ja �tait atteinte</remarks>
        /// <exception cref="AddObjectException"
        public void Add()
        {
            lock (this)
            {
                if (_nbObject >= Capacity)
                {
                    Console.WriteLine("panier P{1} plein", _id, GetName());
                    Monitor.Wait(this);
                }
                    
                _nbObject++;

                Monitor.Pulse(this);
            }
            
            
        }

        /// <summary>
        /// Permet de prendre un objet dans le stokage de l'intance <c>Panier</c> 
        /// </summary>
        /// <remarks>Retourne une exception si il n'y � plus d'objet</remarks>
        /// <exception cref="TakeObjectException"
        public void Take()
        {
            
            lock (this)
            {
                if (_nbObject <= 0)
                {
                    Console.WriteLine("panier P{1} vide", _id, GetName());
                    Monitor.Wait(this);
                }
                _nbObject--;
                Monitor.Pulse(this);
            }
            
            
        }

        /// <summary>
        /// Permet de connaitre le nombre d'objet contenu dans le stokage de l'instance
        /// </summary>
        /// <returns>Retourne le nombre d'objet</returns>
        public int Count()
        {
            return (int)_nbObject;
        }

        public int GetCapacity()
        {
            return (int)_capacity;
        }

        /// <summary>
        /// Vide le stokage de l'intance
        /// </summary>
        public void Clean()
        {
            _nbObject = 0;
        }

        /// <summary>
        /// Permet de savoir si le stokage est vide
        /// </summary>
        /// <returns>retourne <c>true</c> si le stokage est vide, sinon <c>false</c></returns>
        public bool IsEmpty()
        {
            if (_nbObject <= 0)
                return true;
            return false;
        }

        /// <summary>
        /// Permet de savoir si le stokage est plein
        /// </summary>
        /// <returns>retourne <c>true</c> si le stokage est plein, sinon <c>false</c></returns>
        public bool IsFull()
        {
            if (_nbObject >= _capacity)
                return true;
            return false;
        }
    }
}
