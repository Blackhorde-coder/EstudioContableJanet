using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstudio
{
    class comprobantecls
    {
        int _id_comprobante;
        int _id_tipo;
        string _tipo;
        int _puesto_venta;
        int _numero;
        DateTime _fecha;
        DateTime _periodo;
        int _id_proveedor;
        int _id_consorcio;
        double _neto;
        double _neto105;
        double _iva105;
        double _neto21;
        double _iva21;
        double _neto27;
        double _iva27;
        double _iibb;
        double _piva;
        double _exento;
        double _otros;
        string _observaciones;
        bool _pagado;

        public comprobantecls()
        {
            _id_comprobante = 0;
            _id_tipo = 0;
            _tipo = "";
            _puesto_venta = 0;
            _numero = 0;
            _fecha = DateTime.Today;
            _periodo = DateTime.Today;
            _id_proveedor = 0;
            _id_consorcio = 0;
            _neto = 0;
            _neto105 = 0;
            _iva105 = 0;
            _neto21 = 0;
            _iva21 = 0;
            _neto27 = 0;
            _iva27 = 0;
            _iibb = 0;
            _piva = 0;
            _exento = 0;
            _otros = 0;
            _observaciones = "";
            _pagado = false;

        }
        public comprobantecls(int id, int id_tipo, string tipo, int puesto_venta, int numero, DateTime fecha, DateTime periodo, int id_proveedor, int id_consorcio, double neto, double neto105, double iva105, double neto21, double iva21, double neto27, double iva27, double iibb, double piva, double exento, double otros, string observaciones, bool pagado)
        {
            _id_comprobante = id;
            _id_tipo = id_tipo;
            _tipo = tipo;
            _puesto_venta = puesto_venta;
            _numero = numero;
            _fecha = fecha;
            _periodo = periodo;
            _id_proveedor = id_proveedor;
            _id_consorcio = id_consorcio;
            _neto = neto;
            _neto105 = neto105;
            _iva105 = iva105;
            _neto21 = neto21;
            _iva21 = iva21;
            _neto27 = neto27;
            _iva27 = iva27;
            _iibb = iibb;
            _piva = piva;
            _exento = exento;
            _otros = otros;
            _observaciones = observaciones;
            _pagado = pagado;
        }

        public int Id_comprobante { get => _id_comprobante; set => _id_comprobante = value; }
        public int Id_tipo { get => _id_tipo; set => _id_tipo = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public int Puesto_venta { get => _puesto_venta; set => _puesto_venta = value; }
        public int Numero { get => _numero; set => _numero = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public DateTime Periodo { get => _periodo; set => _periodo = value; }
        public int Id_proveedor { get => _id_proveedor; set => _id_proveedor = value; }
        public int Id_consorcio { get => _id_consorcio; set => _id_consorcio = value; }
        public double Neto { get => _neto; set => _neto = value; }
        public double Neto105 { get => _neto105; set => _neto105 = value; }
        public double Iva105 { get => _iva105; set => _iva105 = value; }
        public double Neto21 { get => _neto21; set => _neto21 = value; }
        public double Iva21 { get => _iva21; set => _iva21 = value; }
        public double Neto27 { get => _neto27; set => _neto27 = value; }
        public double Iva27 { get => _iva27; set => _iva27 = value; }
        public double Iibb { get => _iibb; set => _iibb = value; }
        public double Piva { get => _piva; set => _piva = value; }
        public double Exento { get => _exento; set => _exento = value; }
        public double Otros { get => _otros; set => _otros = value; }
        public string Observaciones { get => _observaciones; set => _observaciones = value; }
        public bool Pagado { get => _pagado; set => _pagado = value; }
    }
}
