using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System.Data.Odbc;

namespace PRUEBABETA
{
    public partial class ReporteGeneral : Form
    {
        public ReporteGeneral()
        {
            InitializeComponent();
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
            adt.SelectCommand =cmd;

            adt.Fill(tbl);
            cnx.Close();

            DataSet ds = new DataSet();
            ds.Tables.Add("pruebareporte");
            ds.Tables[0].Merge(tbl);            
            ReportDocument rpt = new ReportDocument();
            rpt.Load(@"c:\users\richie\documents\visual studio 2015\Projects\PRUEBABETA\PRUEBABETA\CrystalReport1.rpt");
            rpt.SetDataSource(ds);
        

        }
    }
}
