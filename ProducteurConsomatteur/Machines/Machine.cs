
using System;
using System.Threading;


namespace ProducteurConsomatteur
{
    public abstract class Machine {


        #region STATICS ATTRIBUTS
        Random RANDOM = new Random();
        #endregion

        #region ATTRIBUTS
        protected int _id;

        protected uint _minTime;

        protected uint _maxTime;

        protected Thread _thread;

        protected bool _inProgess;
        #endregion

        #region GETSET
        public int Id { get => _id; set => _id = value; }
        public uint MinTime { get => _minTime; set => _minTime = value; }
        public uint MaxTime { get => _maxTime; set => _maxTime = value; }
        #endregion

        #region CONSTRUCTORS
        public Machine(int id, uint minTime, uint maxTime)
        {
            Id = id;
            MinTime = minTime;
            MaxTime = maxTime;
            _thread = new Thread(Execute);
            _inProgess = false;

        }

        public Machine(int id, uint time):
            this(id, time, time)
        {}

        public Machine(Machine copy)
        {
            if (copy == null)
                throw new ArgumentNullException("l'arguments passé ne peux pas être null", "copy");
            _thread = new Thread(Execute);
            _inProgess = false;
        }
        #endregion

        public void Start()
        {
            if (!IsReady())
                throw new NotReadyException("la machine ne peut pas démarrer dans cet état");
            _inProgess = true;
            _thread.Start();
        }

        public void Stop()
        {
            _inProgess = false;
        }

        public void Pause()
        {
            _thread.Suspend(); //comme dit V.S "obolète" mais c'est pas grave
        }

        public void Resume()
        {
            _thread.Resume(); //comme dit V.S "obolète" mais c'est pas grave
        }

        public void Restart()
        {
            Stop();
            Start();
        }

        private void Execute()
        {
            while (_inProgess)
            {
                OnExecute();
            }
        }

        protected void Work()
        {
            Thread.Sleep(RANDOM.Next((int)_minTime, (int)_maxTime));
        }

        protected abstract void OnExecute();
        protected abstract bool IsReady();
    }
}
