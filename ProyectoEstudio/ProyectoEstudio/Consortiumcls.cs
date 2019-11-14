using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstudio
{
    class Consortiumcls
    {
        int _idconsortium;
        string _name;
        double _cuit;
        string _address;
        int _number;
        string _district;

        public int Idconsortium { get => _idconsortium; set => _idconsortium = value; }
        public string Name { get => _name; set => _name = value; }
        public double Cuit { get => _cuit; set => _cuit = value; }
        public string Address { get => _address; set => _address = value; }
        public int Number { get => _number; set => _number = value; }
        public string District { get => _district; set => _district = value; }

        public Consortiumcls()
        {
            _idconsortium = 0;
            _name = "";
            _cuit = 0;
            _address = "";
            _number = 0;
            _district = "";
        }

        public Consortiumcls(int id, string nam, double cuit, string addr, int numb, string distr)
        {
            _idconsortium = id;
            _name = nam;
            _cuit = cuit;
            _address = addr;
            _number = numb;
            _district = distr;
        }




    }
}
