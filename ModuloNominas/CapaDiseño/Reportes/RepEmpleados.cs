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
            ID = Convert.ToInt32(txt_dpiempleado.Text); /*Almanenar valor de textbox*/
            Int32.TryParse(txt_dpiempleado.Text, out ID); /*Convertir a Int*/

            OdbcConnection cnx = new OdbcConnection("Dsn=Colchoneria"); /*Variable de conexion*/
            cnx.Open(); /*abriendo conexion*/
            cnx.Close(); /*cerrando conexion*/
            cnx.Open();/*abriendo conexion*/
            OdbcDataAdapter adp = new OdbcDataAdapter(
            "SELECT tbl_empleados.ID_Empleado, tbl_empleados.Nombre,tbl_empleados.Apellido,tbl_puestos.Nombre, tbl_contratos.fechaInicio,tbl_contratos.salario from tbl_empleados inner join tbl_puestos on tbl_puestos.ID_Puesto= tbl_empleados.ID_Puesto  inner join tbl_contratos on tbl_contratos.ID_Contrato = tbl_empleados.ID_Contrato where ID_Empleado= '" + ID + "';", cnx); /*Consulta a la base de datos*/
            DataSet dst = new DataSet(); /*objeto data set*/
            adp.Fill(dst, "busqueda"); /*llenar en la tabla*/


            ReportDocument rpt = new ReportDocument(); /*nuevo documento de reporte*/
            rpt.Load(@"C:\Users\Richie\Desktop\UMG\8vo Ciclo\Analisis de sistemas II\Nominas\Nominas\ModuloNominas\CapaDiseño\innerjoin.rpt"); /*ruta del documento de reporte*/
            rpt.SetDataSource(dst.Tables["busqueda"]); /*busqueda de la tabla*/
            crystalReportViewer1.ReportSource = rpt; /*llamar a la vista del reporte*/
            crystalReportViewer1.Refresh(); /*refrescar reporte*/

        }

        private void RepEmpleados_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, "C://ayuda_cierre de nominas.chm"); /*Archivo chm de ayuda*/
        }

        /*
         "Select tbl_empleados.ID_Empleado, tbl_empleados.Nombre,tbl_empleados.Apellido, tbl_puestos.Nombre  from tbl_empleados inner join tbl_puestos on tbl_empleados.ID_Puesto = tbl_puestos.ID_Puesto where Sexo = 'M'", cnx);
*/
    }
}
