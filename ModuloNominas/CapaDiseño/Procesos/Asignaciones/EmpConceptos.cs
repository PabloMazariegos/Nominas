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
using CapaLogicaNominas;

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
            CapaLogicaNominas.querysConceptos conceptoEmpleado = new querysConceptos();
            DataSet dst2 = new DataSet();
            dst2.Tables.Add(conceptoEmpleado.ConceptosdeEmpleados(idEmp));
            dtConceptos.DataSource = dst2.Tables[0];
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
                CapaLogicaNominas.querysConceptos conEmp = new querysConceptos();                
                DialogResult op = MessageBox.Show("Esta seguro de eliminar el concepto al empleado?", "Conceptos Asignados", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(op== DialogResult.Yes)
                {                    
                    try
                    {                        
                        OdbcCommand cmd = new OdbcCommand(conEmp.GetQueryDelete(idEmp,idConceptos), cnx.cnxOpen());
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                foreach (DataGridViewRow row in dtConceptos.Rows)
                {
                    row.Selected = false;
                }
            }

            if (checkBox5.Checked == true)
            {
                checkBox6.Checked = false;
                string value = textBox1.Text;
                foreach (DataGridViewRow row in dtConceptos.Rows)
                {
                    if (row.Cells["Tipo"].Value.Equals(value))
                    {
                        row.Selected = true;
                    }
                }
            }
            else
            {
                if (checkBox6.Checked == true)
                {
                    checkBox5.Checked = false;
                    string value = textBox1.Text;
                    foreach (DataGridViewRow row in dtConceptos.Rows)
                    {
                        if (row.Cells["Nombre"].Value.Equals(value))
                        {
                            row.Selected = true;
                        }
                    }
                }
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox5.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox6.Checked = false;
            }
        }
    }
}
