using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace ProyectoEstudio
{
    class Manipulationcls
    {
        OleDbCommand _command;
        OleDbConnection _connection;
        OleDbDataReader _reader;
        string _cadenaconeccion;
        DataTable _tabla;

        public Manipulationcls()
        {
            _command = new OleDbCommand();
            _connection = new OleDbConnection();
            _reader = null;
            _cadenaconeccion = "";
            _tabla = new DataTable();
        }
        public Manipulationcls(string cadenacon)
        {
            _command = new OleDbCommand();
            _connection = new OleDbConnection(cadenacon);
            _reader = null;
            _cadenaconeccion = cadenacon;
            _tabla = new DataTable();
        }

        public OleDbCommand Command { get => _command; set => _command = value; }
        public OleDbConnection Connection { get => _connection; set => _connection = value; }
        public OleDbDataReader Reader { get => _reader; set => _reader = value; }
        public string Cadenaconeccion { get => _cadenaconeccion; set => _cadenaconeccion = value; }
        public DataTable Tabla { get => _tabla; set => _tabla = value; }

        public void conectar()
        {
            _connection.ConnectionString = Cadenaconeccion;
            _connection.Open();
            _command.Connection = _connection;
            _command.CommandType = CommandType.Text;
        }
        public void desconectar()
        {
            _connection.Close();
            _connection.Dispose();
        }
        public void leertabla(string nombretabla)
        {
            conectar();
            _command.CommandText = "select * from " + nombretabla + " order by 1";
            _reader = _command.ExecuteReader();
        }
        public DataTable consultartabla(string nombretabla)
        {
            conectar();
            _command.CommandText = "select * from " + nombretabla + " order by 1";
            _tabla.Load(_command.ExecuteReader());
            desconectar();
            return _tabla;
        }
        public DataTable consultarbd(string consultasql)
        {
            conectar();
            _command.CommandText = consultasql;
            _tabla.Load(_command.ExecuteReader());
            desconectar();
            return _tabla;
        }
        public void modificarbd(string consultasql)
        {
            conectar();
            _command.CommandText = consultasql;
            _command.ExecuteNonQuery();
            desconectar();

        }
    }
}
