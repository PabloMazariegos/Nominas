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
    public partial class RepCierre : Form
    {

        
        public RepCierre()
        {
            InitializeComponent();
            OdbcConnection cnx = new OdbcConnection("Dsn=colchoneria"); /*objeot de la conexion*/
            cnx.Open(); /*abriendo conexion*/

            string query = ("SELECT tbl_empleados.ID_Empleado, tbl_empleados.Nombre, tbl_puestos.Nombre as 'Puesto', tbl_areas.Nombre as 'Area', tbl_contratos.fechaInicio, tbl_contratos.salario from tbl_empleados inner join tbl_puestos on tbl_empleados.ID_Puesto = tbl_puestos.ID_Puesto inner join tbl_areas on tbl_empleados.ID_Area = tbl_areas.ID_Area inner join tbl_contratos on tbl_empleados.ID_Contrato = tbl_contratos.ID_Contrato; "); /*consulta a la base de datos*/

            OdbcCommand cmd = new OdbcCommand(query, cnx); /*envia de consulta*/
            OdbcDataAdapter adt = new OdbcDataAdapter(); 
            DataTable tbl = new DataTable();/*nueva tabla*/
            adt.SelectCommand = cmd; /*adaptando al cmd*/

            adt.Fill(tbl); /*llenar talba*/
            cnx.Close(); /*cerrar conexion*/

            DataSet ds = new DataSet(); /*creacion del data set*/
            ds.Tables.Add("pruebareporte2"); /*agregar a la tabla*/
            ds.Tables[0].Merge(tbl); /*pusear a la tabla*/
            ReportDocument rpt = new ReportDocument(); /*creacion del reporte*/
            rpt.Load(@"C:\Users\Richie\Desktop\UMG\8vo Ciclo\Analisis de sistemas II\Nominas\Nominas\ModuloNominas\CapaDiseño\ReporteGeneral.rpt"); /*ubicacion del reporte*/
            rpt.SetDataSource(ds); /*carga de reporte*/
            crystalReportViewer1.ReportSource = rpt; /*envio a la vista del reporte*/
            crystalReportViewer1.Refresh(); /*refrescar reporte*/


        }

        private void label1_Click(object sender, EventArgs e)
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void RepEmpleados_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, "C://ayuda_cierre de nominas.chm");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OdbcConnection cnx = new OdbcConnection("Dsn=colchoneria");
            cnx.Open();

            string query = ("SELECT tbl_empleados.ID_Empleado, tbl_empleados.Nombre, tbl_puestos.Nombre " +
         " as 'Puesto', tbl_areas.Nombre as 'Area', tbl_contratos.fechaInicio, tbl_contratos.salario, " +
        "  tbl_conceptosretributivos.importe as 'Bono', Percepciones.Total as 'Total' " +

           " from tbl_empleados " + 
            " inner join tbl_puestos on tbl_empleados.ID_Puesto = tbl_puestos.ID_Puesto " +
            " inner join tbl_areas on tbl_empleados.ID_Area = tbl_areas.ID_Area " +
            " inner join tbl_contratos on tbl_empleados.ID_Contrato = tbl_contratos.ID_Contrato " +
            "inner join tbl_empleadoconcepto on tbl_empleados.ID_Empleado = tbl_empleadoconcepto.ID_Empleado " +    
            "inner join tbl_conceptosretributivos on tbl_empleadoconcepto.ID_ConceptosR = tbl_conceptosretributivos.ID_ConceptosR " +
            " inner join Percepciones on tbl_empleados.ID_Empleado = Percepciones.ID_Empleado where tbl_empleados.ID_Empleado = '1 ';");

            OdbcCommand cmd = new OdbcCommand(query, cnx);
            OdbcDataAdapter adt = new OdbcDataAdapter();
            DataTable tbl = new DataTable();
            adt.SelectCommand = cmd;

            adt.Fill(tbl);
            cnx.Close();

            DataSet ds = new DataSet();
            ds.Tables.Add("pruebareporte");
            ds.Tables[0].Merge(tbl);
            ReportDocument rpt = new ReportDocument();
            rpt.Load(@"C:\Users\Richie\Desktop\UMG\8vo Ciclo\Analisis de sistemas II\Nominas\Nominas\ModuloNominas\CapaDiseño\Reportes\General.rpt");
            rpt.SetDataSource(ds);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void RepCierre_HelpRequested(object sender, HelpEventArgs hlpevent)
        {

        }
    }
}
