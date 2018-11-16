using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System.Data.Odbc;

namespace CapaDiseño
{
    public partial class RepEmpleados : Form
    {
        //VARIABLES
        //string DPI;
        int ID;
        public RepEmpleados()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Reporte_Empleado_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       



        private void button1_Click(object sender, EventArgs e)
        {
            ID = Convert.ToInt32(txt_dpiempleado.Text);
            Int32.TryParse(txt_dpiempleado.Text, out ID);
            OdbcConnection cnx = new OdbcConnection("Dsn=Colchoneria");
            cnx.Open();
            //OdbcCommand cmd = new OdbcCommand("drop view `innerprueba`", cnx);
            //cmd.ExecuteNonQuery();
            cnx.Close();
            cnx.Open();
            OdbcDataAdapter adp = new OdbcDataAdapter(
            "SELECT tbl_empleados1.ID_Empleado, tbl_empleados1.Nombre, tbl_empleados1.Apellido, tbl_puestos1.Nombre, tbl_areas1.Nombre, tbl_contratos1.fechaInicio, tbl_contratos1.salario FROM((Db_Colchoneria.tbl_empleados tbl_empleados1 INNER JOIN Db_Colchoneria.tbl_areas tbl_areas1 ON tbl_empleados1.ID_Area = tbl_areas1.ID_Area) INNER JOIN Db_Colchoneria.tbl_contratos tbl_contratos1 ON tbl_empleados1.ID_Contrato = tbl_contratos1.ID_Contrato) INNER JOIN Db_Colchoneria.tbl_puestos tbl_puestos1 ON(tbl_empleados1.ID_Puesto = tbl_puestos1.ID_Puesto) AND(tbl_areas1.ID_Area = tbl_puestos1.ID_Area) where ID_Empleado = '"+ID+"';", cnx);

            DataSet dst = new DataSet();
            adp.Fill(dst, "busqueda");


            ReportDocument rpt = new ReportDocument();
            rpt.Load(@"C:\Users\Richie\Desktop\UMG\8vo Ciclo\Analisis de sistemas II\Nominas\Nominas\ModuloNominas\CapaDiseño\innerjoin.rpt");
            rpt.SetDataSource(dst.Tables["busqueda"]);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();

        }

        private void RepEmpleados_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, "C://ayuda_cierre de nominas.chm");
        }

        /*
          "SELECT tbl_empleados.ID_Empleado, tbl_empleados.Nombre,"+
             "tbl_empleados.Apellido, tbl_puestos.Nombre as 'Puesto', tbl_areas.Nombre as 'Area',"+
             "tbl_contratos.fechaInicio, tbl_contratos.salario from tbl_empleados"+
             "inner join tbl_puestos on tbl_empleados.ID_Puesto = tbl_puestos.ID_Puesto"+
             "inner join tbl_areas on tbl_empleados.ID_Area = tbl_areas.ID_Area"+
             "inner join tbl_contratos "+
             "on tbl_empleados.ID_Contrato = tbl_contratos.ID_Contrato WHERE tbl_empleados.ID_Empleado = '2'"
         */
        /*
         "Select tbl_empleados.ID_Empleado, tbl_empleados.Nombre,tbl_empleados.Apellido, tbl_puestos.Nombre  from tbl_empleados inner join tbl_puestos on tbl_empleados.ID_Puesto = tbl_puestos.ID_Puesto where Sexo = 'M'", cnx);
*/
    }
}
