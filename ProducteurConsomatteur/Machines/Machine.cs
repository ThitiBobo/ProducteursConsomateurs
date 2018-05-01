
using System;
using System.Threading;


namespace ProducteurConsomatteur
{
    /// <summary>
    /// Repr�sente une instance abstraite pouvant fabriquer des objets de fa�on fictive avec
    /// un temps de fabrication compris dans une intervalle.
    /// L'instance est mod�lis� par un thread. 
    /// </summary>
    public abstract class Machine {


        #region STATICS ATTRIBUTS
        /// <summary>
        /// instance de g�n�rateur al�atoire
        /// </summary>
        Random RANDOM = new Random();
        #endregion

        #region ATTRIBUTS
        /// <summary>
        /// identifiant de l'instance
        /// </summary>
        protected int _id;

        /// <summary>
        /// intervalle inf�rieur du temps de fabrication
        /// </summary>
        protected uint _minTime;

        /// <summary>
        /// intervalle sup�rieur du temps de fabrication
        /// </summary>
        protected uint _maxTime;

        /// <summary>
        /// instance de Thread 
        /// </summary>
        protected Thread _thread;

        /// <summary>
        /// Etat de la machine 
        /// true = la machine marche 
        /// false = la machine est arr�t�e
        /// </summary>
        protected bool _inProgess;
        #endregion

        #region GETSET

        /// <summary>
        /// Permet de modifier l'identifiant de l'instance
        /// </summary>
        public int Id { get => _id; set => _id = value; }

        /// <summary>
        /// Permet de modifier l'intrvalle inf�rieur du temps de fabrication
        /// </summary>
        public uint MinTime
        {
            get => _minTime;
            set
            {
                if (value > _maxTime)
                    throw new ArgumentException("l'argument ne peux pas �tre sup�rieur � maxTime","minTime");
                _minTime = value;
            }
        }

        /// <summary>
        /// Permet de modifier l'intervalle sup�rieur du temps de fabrication
        /// </summary>
        public uint MaxTime
        {
            get => _maxTime;
            set
            {
                if (value < _minTime)
                    throw new ArgumentException("l'argument ne peux pas �tre inf�rieur � minTime", "maxTime");
                _maxTime = value;
            }
        }
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Permet de cr�er une nouvelle instance en pr�cisant l'identifiant, et l'intervalle pour le
        /// temps de fabrication : le temps minimum et le temps maximum
        /// </summary>
        /// <param name="id">Identifiant de l'instance</param>
        /// <param name="minTime">Temps minimum de fabrication</param>
        /// <param name="maxTime">Temps maximum de fabrication</param>
        public Machine(int id, uint minTime, uint maxTime)
        {
            Id = id;
            MinTime = minTime;
            MaxTime = maxTime;
            _thread = new Thread(Execute);
            _inProgess = false;
        }

        /// <summary>
        /// Permet de cr�er une nouvelle instance en pr�cisant l'identifiant et le
        /// temps de fabrication 
        /// </summary>
        /// <param name="id">Identifiant de l'instance</param>
        /// <param name="time">Temps de fabrication</param>
        /// <remarks>Temps de fabrication est comprise dans l'intervalle [minTime; maxTime] 
        /// / minTime = maxTime </remarks>
        public Machine(int id, uint time):
            this(id, time, time)
        {}

        /// <summary>
        /// Permet de cr�er une nouvelle instance en recopiant une instance d�j� �xistante
        /// </summary>
        /// <param name="copy">instance � recopier</param>
        public Machine(Machine copy)
        {
            if (copy == null)
                throw new ArgumentNullException("l'arguments pass� ne peux pas �tre null", "copy");
            _thread = new Thread(Execute);
            _inProgess = false;
        }
        #endregion

        /// <summary>
        /// Permet de d�marer l'instance <c>Machine</c> ou retourne une exception
        /// si la machine n'est pas bien configur�e
        /// </summary>
        /// <exception cref="NotReadyException"
        public void Start()
        {
            if (!IsReady())
                throw new NotReadyException("la machine ne peut pas d�marrer dans cet �tat");
            _inProgess = true;
            _thread.Start();
        }

        /// <summary>
        /// Permet d'arreter l'instance <c>Machine</c>
        /// </summary>
        public void Stop()
        {
            _inProgess = false;
        }

        /// <summary>
        /// Permet de red�marer l'instance <c>Machine</c> ou retourne une exception
        /// si la machine n'est pas bien configur�e
        /// </summary>
        /// <exception cref="NotReadyException"
        public void Restart()
        {
            Stop();
            Start();
        }

        /// <summary>
        /// M�thode principale �xecut�e par le thread de l'instance 
        /// </summary>
        private void Execute()
        {
            Console.WriteLine("Machine {0}: START", Id);
            // temps que la machine est � l'�tat de marche
            while (_inProgess)
            {
                // �x�cute le protocole de fabrication
                OnExecute();
            }
            Console.WriteLine("Machine {0}: STOP", Id);
        }

        /// <summary>
        /// M�thode simulant le temps de fabrication pour l'instance <c>Machine</c>
        /// </summary>
        protected void Work()
        {
            Thread.Sleep(RANDOM.Next((int)_minTime, (int)_maxTime));
        }

        /// <summary>
        /// Permet d'attendre le thread de l'instance
        /// </summary>
        public void Join()
        {
            _thread.Join();
        }

        /// <summary>
        /// m�thode abstraite contenant tout le protocole de fabrication de la machine.
        /// Le protocole peux varier selon les classes d�riv�es.
        /// </summary>
        protected abstract void OnExecute();

        /// <summary>
        /// m�thode abstraite v�rifiant si l'instance est int�gre pour d�marrer.
        /// La v�rifiacation peux varier selon les classes d�riv�es.
        /// </summary>
        /// <returns>Retourne <c>true</c> si l'instance est int�gre, sinon <c>false</c>.</returns>
        protected abstract bool IsReady();
    }
}
