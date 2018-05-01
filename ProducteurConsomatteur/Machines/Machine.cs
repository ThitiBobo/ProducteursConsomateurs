
using System;
using System.Threading;


namespace ProducteurConsomatteur
{
    /// <summary>
    /// Représente une instance abstraite pouvant fabriquer des objets de façon fictive avec
    /// un temps de fabrication compris dans une intervalle.
    /// L'instance est modélisé par un thread. 
    /// </summary>
    public abstract class Machine {


        #region STATICS ATTRIBUTS
        /// <summary>
        /// instance de générateur aléatoire
        /// </summary>
        Random RANDOM = new Random();
        #endregion

        #region ATTRIBUTS
        /// <summary>
        /// identifiant de l'instance
        /// </summary>
        protected int _id;

        /// <summary>
        /// intervalle inférieur du temps de fabrication
        /// </summary>
        protected uint _minTime;

        /// <summary>
        /// intervalle supérieur du temps de fabrication
        /// </summary>
        protected uint _maxTime;

        /// <summary>
        /// instance de Thread 
        /// </summary>
        protected Thread _thread;

        /// <summary>
        /// Etat de la machine 
        /// true = la machine marche 
        /// false = la machine est arrêtée
        /// </summary>
        protected bool _inProgess;
        #endregion

        #region GETSET

        /// <summary>
        /// Permet de modifier l'identifiant de l'instance
        /// </summary>
        public int Id { get => _id; set => _id = value; }

        /// <summary>
        /// Permet de modifier l'intrvalle inférieur du temps de fabrication
        /// </summary>
        public uint MinTime
        {
            get => _minTime;
            set
            {
                if (value > _maxTime)
                    throw new ArgumentException("l'argument ne peux pas être supérieur à maxTime","minTime");
                _minTime = value;
            }
        }

        /// <summary>
        /// Permet de modifier l'intervalle supérieur du temps de fabrication
        /// </summary>
        public uint MaxTime
        {
            get => _maxTime;
            set
            {
                if (value < _minTime)
                    throw new ArgumentException("l'argument ne peux pas être inférieur à minTime", "maxTime");
                _maxTime = value;
            }
        }
        #endregion

        #region CONSTRUCTORS
        /// <summary>
        /// Permet de créer une nouvelle instance en précisant l'identifiant, et l'intervalle pour le
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
        /// Permet de créer une nouvelle instance en précisant l'identifiant et le
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
        /// Permet de créer une nouvelle instance en recopiant une instance déjà éxistante
        /// </summary>
        /// <param name="copy">instance à recopier</param>
        public Machine(Machine copy)
        {
            if (copy == null)
                throw new ArgumentNullException("l'arguments passé ne peux pas être null", "copy");
            _thread = new Thread(Execute);
            _inProgess = false;
        }
        #endregion

        /// <summary>
        /// Permet de démarer l'instance <c>Machine</c> ou retourne une exception
        /// si la machine n'est pas bien configurée
        /// </summary>
        /// <exception cref="NotReadyException"
        public void Start()
        {
            if (!IsReady())
                throw new NotReadyException("la machine ne peut pas démarrer dans cet état");
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
        /// Permet de redémarer l'instance <c>Machine</c> ou retourne une exception
        /// si la machine n'est pas bien configurée
        /// </summary>
        /// <exception cref="NotReadyException"
        public void Restart()
        {
            Stop();
            Start();
        }

        /// <summary>
        /// Méthode principale éxecutée par le thread de l'instance 
        /// </summary>
        private void Execute()
        {
            Console.WriteLine("Machine {0}: START", Id);
            // temps que la machine est à l'état de marche
            while (_inProgess)
            {
                // éxécute le protocole de fabrication
                OnExecute();
            }
            Console.WriteLine("Machine {0}: STOP", Id);
        }

        /// <summary>
        /// Méthode simulant le temps de fabrication pour l'instance <c>Machine</c>
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
        /// méthode abstraite contenant tout le protocole de fabrication de la machine.
        /// Le protocole peux varier selon les classes dérivées.
        /// </summary>
        protected abstract void OnExecute();

        /// <summary>
        /// méthode abstraite vérifiant si l'instance est intégre pour démarrer.
        /// La vérifiacation peux varier selon les classes dérivées.
        /// </summary>
        /// <returns>Retourne <c>true</c> si l'instance est intégre, sinon <c>false</c>.</returns>
        protected abstract bool IsReady();
    }
}
