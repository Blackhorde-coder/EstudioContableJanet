using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstudio
{
    class providercls
    {
        int _idprovider;
        string _reason;
        int _cuit;
        int _ivacondition;
        string _address;
        int _number;
        string _observation;

        public int Idprovider { get => _idprovider; set => _idprovider = value; }
        public string Reason { get => _reason; set => _reason = value; }
        public int Cuit { get => _cuit; set => _cuit = value; }
        public int Ivacondition { get => _ivacondition; set => _ivacondition = value; }
        public string Address { get => _address; set => _address = value; }
        public int Number { get => _number; set => _number = value; }
        public string Observation { get => _observation; set => _observation = value; }

        public providercls(int id, string reason, int cuit, int icondition, string addr, int num, string observa)
        {
            _idprovider = id;
            _reason = reason;
            _cuit = cuit;
            _ivacondition = icondition;
            _address = addr;
            _number = num;
            _observation = observa;
        }
        public providercls()
        {
            _idprovider = 0;
            _reason = "";
            _cuit = 0;
            _ivacondition = 0;
            _address = "";
            _number = 0;
            _observation = "";
        }


    }
}
