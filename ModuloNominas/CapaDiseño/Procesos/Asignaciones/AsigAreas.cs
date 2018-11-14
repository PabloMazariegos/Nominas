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
    public partial class AsigAreas : Form
    {
        ConexionCapaDatos cnx = new ConexionCapaDatos();
        DataSet dst2 = new DataSet();
        DataView DataView = new DataView();
        DataSet dataset = new DataSet();
        public AsigAreas()
        {
            InitializeComponent();
            
        }

        private void Asignacion_de_area_Load(object sender, EventArgs e)
        {
           
            OdbcDataAdapter dta = new OdbcDataAdapter("SELECT tbl_areas.ID_Area, tbl_areas.Nombre FROM tbl_areas", cnx.cnxOpen());
            DataSet dst = new DataSet();
            dta.Fill(dst, "tbl_areas");
            cbxArea.DisplayMember = "Nombre";
            cbxArea.ValueMember = "Nombre";
            cbxArea.DataSource = dst.Tables["tbl_areas"];
            cnx.cnxClose();

            OdbcDataAdapter emp = new OdbcDataAdapter("SELECT * FROM empleadoConceptoVW", cnx.cnxOpen());
           
            dst2.Tables.Add("tbl_empleados");
            dst2.Tables["tbl_empleados"].Columns.Add("Seleccion", typeof(bool));
            dst2.Tables["tbl_empleados"].Columns["Seleccion"].DefaultValue = false;
            emp.Fill(dst2, "tbl_empleados");            
            dtEmpleados.DataSource = dst2.Tables["tbl_empleados"];
            dtEmpleados.AllowUserToAddRows = false;
            dtEmpleados.Refresh();
            cnx.cnxClose();
            dtEmpleados.Columns["Seleccion"].SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           if(e.ColumnIndex==6)
            {
                bool value =(bool) dtEmpleados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value == true)
                {
                    dtEmpleados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value=false;
                }else
                {
                    dtEmpleados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
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
            if (chk_individual.Checked == true)
            {
                groupEmpleado.Enabled = true;
                chk_area.Checked = false;
                chk_excepcion.Checked = false;
                chk_todos.Checked = false;
                dtEmpleados.Visible = true;
            }
            else
            {
                groupEmpleado.Enabled = false;
                dtEmpleados.Visible = false;
            }
        }

        private void chk_area_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk_area.Checked == true)
            {
                groupArea.Enabled = true;
                chk_individual.Checked = false;
                chk_excepcion.Checked = false;
                chk_todos.Checked = false;
            }
            else
            {
                groupArea.Enabled = false;
            }
        }

        private void chk_todos_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_todos.Checked == true)
            {
                chk_individual.Checked = false;
                chk_excepcion.Checked = false;
                chk_area.Checked = false;
                dtEmpleados.Visible = false;
                groupEmpleado.Enabled = false;             
                
            }else
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {            
            if (chk_area.Checked == true)
            {
                string idArea = cbxArea.SelectedValue.ToString();
                AsigConcepto asigconcepto = new AsigConcepto(idArea);
                asigconcepto.Show();

            }

            if (chk_individual.Checked == true)
            {
                List<int> idEmps = new List<int>();
                for (int i=0; i<dtEmpleados.Rows.Count; i++)
                {
                    bool chkSelected = Convert.ToBoolean(dtEmpleados.Rows[i].Cells[0].Value);
                    if (chkSelected == true)
                    {
                        idEmps.Add(Convert.ToInt32(dtEmpleados.Rows[i].Cells["DPI"].Value));
                    }
                }
                if (idEmps.Count == 0)
                {
                    MessageBox.Show("Seleccione Empleados", "Asignacion Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                {
                    AsigConcepto asigcon = new AsigConcepto(idEmps);
                    asigcon.Show();
                }
               

            }

            if (chk_todos.Checked == true)
            {
                DialogResult press;
                press = MessageBox.Show("Desea asignar a todos los empleados?", "Asignacion de Conceptos", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                List<int> idEmps = new List<int>();
                if (press== DialogResult.Yes)
                {
                    for (int i = 0; i < dtEmpleados.Rows.Count; i++)
                    {                       
                        idEmps.Add(Convert.ToInt32(dtEmpleados.Rows[i].Cells["DPI"].Value));

                    }
                    AsigConcepto asigcon = new AsigConcepto(idEmps);
                    asigcon.Show();
                }
            }

            if (chk_excepcion.Checked == true)
            {
                List<int> idEmps = new List<int>();
                for (int i = 0; i < dtEmpleados.Rows.Count; i++)
                {
                    bool chkSelected = Convert.ToBoolean(dtEmpleados.Rows[i].Cells[0].Value);
                    if (chkSelected == false)
                    {
                        idEmps.Add(Convert.ToInt32(dtEmpleados.Rows[i].Cells["DPI"].Value));
                    }
                }
                AsigConcepto asigcon = new AsigConcepto(idEmps);
                asigcon.Show();
            }

            
        }

        private void chk_excepcion_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk_excepcion.Checked == true)
            {
                chk_area.Checked = false;
                chk_individual.Checked = false;
                chk_todos.Checked = false;
                groupEmpleado.Enabled = true;
                dtEmpleados.Visible = true;
            }
            else
            {
                groupEmpleado.Enabled = false;
                dtEmpleados.Visible = false;
            }
        }

        private void cbxArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnx.cnxClose();
            string idArea = cbxArea.SelectedValue.ToString();
            OdbcCommand dta = new OdbcCommand("SELECT  tbl_areas.ID_Area, tbl_areas.nombre, tbl_areas.descripcion FROM tbl_areas WHERE tbl_areas.Nombre='" + idArea+"';", cnx.cnxOpen());
            OdbcDataReader dr = dta.ExecuteReader();
            while (dr.Read())
            {
                lbl_codArea.Text = "Codigo: " + dr.GetString(0);
                lbl_nomArea.Text = dr.GetString(1).ToLower();
                lbl_decripArea.Text =  dr.GetString(2).ToLower();

            }
            cnx.cnxClose();
        }

        private void dtEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int DPI = Convert.ToInt32(dtEmpleados.CurrentRow.Cells["DPI"].Value);
            EmpConceptos emp = new EmpConceptos(DPI);
            emp.Show();
        }




        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                foreach (DataGridViewRow row in dtEmpleados.Rows)
                {
                    row.Selected = false;
                }
            }
            if (checkBox6.Checked == true)
            {
                checkBox4.Checked = false;
                string value = textBox1.Text;
                foreach(DataGridViewRow row in dtEmpleados.Rows)
                {
                    if (row.Cells["Nombre"].Value.Equals(value))
                    {
                        row.Selected = true;
                    }
                }
            }else
            {
                if (checkBox4.Checked == true)
                {
                    checkBox6.Checked = false;
                    string value = textBox1.Text;
                    foreach (DataGridViewRow row in dtEmpleados.Rows)
                    {
                        if (row.Cells["Area"].Value.Equals(value))
                        {
                            row.Selected = true;
                        }

                    }
                }
            }
        }

        private void dtEmpleados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dtEmpleados_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int dpiSelected = Convert.ToInt32(dtEmpleados.CurrentRow.Cells["DPI"].Value);
            EmpConceptos fm = new EmpConceptos(dpiSelected);
            fm.Show();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox6.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                checkBox4.Checked = false;
            }
        }
    }
}
