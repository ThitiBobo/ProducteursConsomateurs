
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProducteurConsomatteur
{
    public class ProducteurConsomateur : Machine {


        #region ATTRIBUTS
        private Storable _input;

        private Storable _output;
        #endregion

        #region GETSET
        public Storable Input {
            get => _input;
            set => _input = value ??
                throw new ArgumentNullException("le paramètre ne peux pas être null", "input");
        }

        public Storable Output {
            get => _output;
            set => _output = value ??
                throw new ArgumentNullException("le paramètre ne peux pas être null", "output");
        }
        #endregion

        #region CONTRUCTORS
        public ProducteurConsomateur(int id, uint minTime, uint maxTime, Storable input, Storable output) : 
            base(id, minTime, maxTime)
        {
            Input = input;
            Output = output;
        }

        public ProducteurConsomateur(int id, uint time, Storable input, Storable output) :
            base(id, time)
        {
            Input = input;
            Output = output;
        }

        public ProducteurConsomateur(ProducteurConsomateur copy) :
            base(copy)
        {
            _input = copy._input;
            _output = copy._output;
        }
        #endregion

        protected override void OnExecute()
        {
            _input.Take();
            Console.WriteLine("Machine {0}: prise pièce P{1} ({2})", _id, ((Panier)_input).Id, ((Panier)_input).Count());
            Work();
            _output.Add();
            Console.WriteLine("Machine {0}: dépot pièce P{1} ({2})", _id, ((Panier)_output).Id, ((Panier)_output).Count());
        }

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
