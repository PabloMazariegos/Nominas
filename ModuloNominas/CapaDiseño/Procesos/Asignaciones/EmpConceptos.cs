using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using CapaDatosNominas;

namespace CapaDiseño
{
    public partial class EmpConceptos : Form
    {
        ConexionCapaDatos cnx = new ConexionCapaDatos();
        int idEmp;
        public EmpConceptos()
        {
            InitializeComponent();
            
        }    

        //CONTRUCTOR CON DPI EMPLEADO
        public EmpConceptos(int DPI)
        {
            InitializeComponent();
            idEmp = DPI;
            OdbcDataAdapter cmd = new OdbcDataAdapter("Select * from empleadoConceptoVW where DPI="+ idEmp + ";" , cnx.cnxOpen());
            DataSet ds = new DataSet();
            cmd.Fill(ds, "tbl_empSelected");
            dtEmpSelected.DataSource = ds.Tables["tbl_empSelected"];
            dtEmpSelected.Refresh();
            cnx.cnxClose();
        }

        private void Asignacion_de_area_Load(object sender, EventArgs e)
        {
           
            OdbcDataAdapter emp = new OdbcDataAdapter("SELECT tbl_conceptosretributivos.ID_ConceptosR as 'Codigo',"+
                                                             "tbl_conceptosretributivos.nombre,"+
                                                             "tbl_conceptosretributivos.descripcion,"+
                                                             "tbl_conceptosretributivos.importe,"+
                                                             "tbl_conceptosretributivos.tipo "+
                                                             "FROM tbl_empleados "+
                                                             "INNER JOIN tbl_empleadoconcepto ON tbl_empleadoconcepto.ID_Empleado= tbl_empleados.ID_Empleado "+
                                                             "INNER JOIN tbl_conceptosretributivos ON tbl_empleadoconcepto.ID_ConceptosR= tbl_conceptosretributivos.ID_ConceptosR "+
                                                             "WHERE tbl_empleados.ID_Empleado="+idEmp+";", cnx.cnxOpen());
            DataSet dst2 = new DataSet();
            dst2.Tables.Add("tbl_conceptos");
            dst2.Tables["tbl_conceptos"].Columns.Add("Seleccion", typeof(bool));
            dst2.Tables["tbl_conceptos"].Columns["Seleccion"].DefaultValue = true;
            emp.Fill(dst2, "tbl_conceptos");            
            dtConceptos.DataSource = dst2.Tables["tbl_conceptos"];
            dtConceptos.AllowUserToAddRows = false;
            dtConceptos.Refresh();
            cnx.cnxClose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           if(e.ColumnIndex==6)
            {
                bool value =(bool) dtConceptos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value == true)
                {
                    dtConceptos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value=false;
                }else
                {
                    dtConceptos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chk_individual_CheckStateChanged(object sender, EventArgs e)
        {
           
        }

        private void chk_area_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void chk_todos_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<int> idConceptos = new List<int>();
            string query = "";
            for (int i = 0; i < dtConceptos.Rows.Count; i++)
            {
                bool chkSelected = Convert.ToBoolean(dtConceptos.Rows[i].Cells[0].Value);
                if (chkSelected == false)
                {
                    idConceptos.Add(Convert.ToInt32(dtConceptos.Rows[i].Cells["Codigo"].Value));
                }
            }

            if (idConceptos.Count != 0)
            {
                DialogResult op = MessageBox.Show("Esta seguro de eliminar el concepto al empleado?", "Conceptos Asignados", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(op== DialogResult.Yes)
                {
                    foreach (var concepto in idConceptos)
                    {
                        query += "DELETE FROM tbl_empleadoconcepto WHERE tbl_empleadoconcepto.ID_Empleado=" + idEmp + " AND tbl_empleadoconcepto.ID_ConceptosR="+concepto+"\n UNION ";
                    }
                    string queryFix = query.Remove(query.Length - 6, 6);
                    try
                    {                        
                        OdbcCommand cmd = new OdbcCommand(queryFix, cnx.cnxOpen());
                        cmd.ExecuteNonQuery();
                        cnx.cnxClose();
                        MessageBox.Show("Cambios realizados!");
                        this.Dispose();
                    }catch(OdbcException ex)
                    {
                        MessageBox.Show("ERROR "+ex);
                    }
                    
                }
            }else
            {
                this.Dispose();
            }
        }

        private void chk_excepcion_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void cbxArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
