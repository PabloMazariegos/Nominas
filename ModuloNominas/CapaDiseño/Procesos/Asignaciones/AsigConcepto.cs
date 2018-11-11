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
    public partial class AsigConcepto : Form
    {
        ConexionCapaDatos cnx = new ConexionCapaDatos();
        List<int> empleadosSelect = new List<int>();
        public AsigConcepto()
        {
            InitializeComponent();
            
        }

        //CONSTRUCTOR CON EMPLEADOS INDIVIDUALES
        public AsigConcepto (List<int> lista)
        {
            InitializeComponent();
            empleadosSelect = lista;
            string query = "";
            foreach(var DPI in lista)
            {
                query += "SELECT * FROM empleadoConceptoVW WHERE DPI=" + DPI + "\n UNION ";
            }
            string queryFix= query.Remove(query.Length - 6, 6);
            OdbcDataAdapter cmd = new OdbcDataAdapter(queryFix, cnx.cnxOpen());
            DataSet ds = new DataSet();
            cmd.Fill(ds, "tbl_empSelected");
            dtEmpSelected.DataSource = ds.Tables["tbl_empSelected"];
            dtEmpSelected.Refresh();
            cnx.cnxClose();

        }

        //CONTRUCTOR CON AREA
        public AsigConcepto (string area)
        {
            InitializeComponent();
            OdbcDataAdapter cmd = new OdbcDataAdapter("Select * from empleadoConceptoVW where Area='"+area+"';" , cnx.cnxOpen());
            DataSet ds = new DataSet();
            cmd.Fill(ds, "tbl_empSelected");
            dtEmpSelected.DataSource = ds.Tables["tbl_empSelected"];
            dtEmpSelected.Refresh();
            cnx.cnxClose();
        }

        private void Asignacion_de_area_Load(object sender, EventArgs e)
        {
           
            OdbcDataAdapter emp = new OdbcDataAdapter("SELECT * FROM empleadoConceptoVW_conceptos", cnx.cnxOpen());
            DataSet dst2 = new DataSet();
            dst2.Tables.Add("tbl_conceptos");
            dst2.Tables["tbl_conceptos"].Columns.Add("Seleccion", typeof(bool));
            dst2.Tables["tbl_conceptos"].Columns["Seleccion"].DefaultValue = false;
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
            string query="", query2 = "";
            string queryFix="", queryFix2 = "";
            for (int i = 0; i < dtConceptos.Rows.Count; i++)
            {
                bool chkSelected = Convert.ToBoolean(dtConceptos.Rows[i].Cells[0].Value);
                if (chkSelected == true)
                {
                    idConceptos.Add(Convert.ToInt32(dtConceptos.Rows[i].Cells["Codigo"].Value));
                }
            }
            if (idConceptos.Count != 0)
            {
                DialogResult op = MessageBox.Show("Esta seguro de Asignar el concepto al empleado?", "Asignacion Conceptos", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (op == DialogResult.Yes)
                {
                    foreach (var concepto in idConceptos)
                    {
                        foreach (var empleado in empleadosSelect)
                        {
                            query += "(" + empleado + "," + concepto + "),";
                            
                        }
                        queryFix = query.Remove(query.Length - 1, 1);
                    }
                    string queryInsert = "INSERT INTO tbl_empleadoconcepto VALUES" + queryFix;
                    
                    MessageBox.Show(queryInsert);
                    try
                    {
                        OdbcCommand cmd = new OdbcCommand(queryInsert, cnx.cnxOpen());
                        cmd.ExecuteNonQuery();
                        cnx.cnxClose();
                        MessageBox.Show("Cambios realizados!");
                        this.Dispose();
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("ERROR " + ex);
                    }


                }
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
