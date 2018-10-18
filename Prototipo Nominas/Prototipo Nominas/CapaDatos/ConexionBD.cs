using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace Prototipo_Nominas.CapaDatos
{
    class ConexionBD
    {
        public String ip = "";
        public String server = "";
        public String user="";
        public String pass = "";
        public String bd = "";
        private OdbcConnection cnx;
        
        public ConexionBD(String IN_ip, String IN_server, String IN_user, String IN_pass, String IN_bd)
        {
            this.ip = IN_ip;
            this.server = IN_server;
            this.user = IN_user;
            this.pass = IN_pass;
            this.bd = IN_bd;
            this.cnx = new OdbcConnection("Driver=MySQL ODBC 8.0 ANSI Driver;"+
                "Server="+this.server+
                ";Database="+this.bd+
                ";User="+this.user+
                ";Password=+"+this.pass+
                "; Option=3");
        }

        public void BD_Open()
        {

        }
        
        public void BD_Close()
        {

        }
        
        public bool Ping()
        {
            return true;
        }
    }
}
