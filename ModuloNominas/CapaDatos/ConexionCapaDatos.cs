using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace CapaDatosNominas
{
    public class ConexionCapaDatos
    {
        OdbcConnection conectar = new OdbcConnection("DSN=colchoneria");
        public OdbcConnection cnxOpen()
        {
            conectar.Open();
            return conectar;
        }

        public OdbcConnection cnxClose()
        {
            conectar.Close();
            return conectar;
        }
    }
}
