
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProducteurConsomatteur
{
    public abstract class Machine {

    
        #region ATTRIBUTS
        protected int id;

        protected ulong minTime;

        protected ulong maxTime;

        protected Task _thread;

        protected bool _inProgess;
        #endregion

        #region GETSET
        public int Id { get => id; set => id = value; }
        public ulong MinTime { get => minTime; set => minTime = value; }
        public ulong MaxTime { get => maxTime; set => maxTime = value; }
        #endregion

        #region CONSTRUCTORS
        public Machine(int id, ulong minTime, ulong maxTime)
        {
            Id = id;
            MinTime = minTime;
            MaxTime = maxTime;
            _thread = new Task(Execute);
            _inProgess = false;

        }

        public Machine(Machine copy)
        {
            if (copy == null)
                throw new ArgumentNullException("l'arguments passé ne peux pas être null", "copy");
            _thread = new Task(Execute);
            _inProgess = false;
        }
        #endregion

        public void Start()
        {
            _inProgess = true;
            _thread.Start();
        }

        public void Stop()
        {
            _inProgess = false;
        }

        public void Pause()
        {
            //_thread.Suspend();
        }

        public void Resume()
        {
            //_thread.Resume();
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

        protected abstract void OnExecute();
    }
}
