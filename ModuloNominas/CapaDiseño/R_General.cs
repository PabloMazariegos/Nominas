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
    public partial class R_General : Form
    {
        public R_General()
        {
            InitializeComponent();
            OdbcConnection cnx = new OdbcConnection("Dsn=colchoneria");
            cnx.Open();

           string query = ("SELECT tbl_empleados.ID_Empleado, tbl_empleados.Nombre, tbl_puestos.Nombre as 'Puesto', tbl_areas.Nombre as 'Area', tbl_contratos.fechaInicio, tbl_contratos.salario from tbl_empleados inner join tbl_puestos on tbl_empleados.ID_Puesto = tbl_puestos.ID_Puesto inner join tbl_areas on tbl_empleados.ID_Area = tbl_areas.ID_Area inner join tbl_contratos on tbl_empleados.ID_Contrato = tbl_contratos.ID_Contrato; ");

            OdbcCommand cmd = new OdbcCommand(query, cnx);
            OdbcDataAdapter adt = new OdbcDataAdapter();
            DataTable tbl = new DataTable();
            adt.SelectCommand = cmd;

            adt.Fill(tbl);
            cnx.Close();

            DataSet ds = new DataSet();
            ds.Tables.Add("pruebareporte2");
            ds.Tables[0].Merge(tbl);
            ReportDocument rpt = new ReportDocument();
            rpt.Load(@"C:\Users\Richie\Desktop\UMG\8vo Ciclo\Analisis de sistemas II\Nominas\Nominas\ModuloNominas\CapaDiseño\ReporteGeneral.rpt");
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh(); 


        }
    }
}
