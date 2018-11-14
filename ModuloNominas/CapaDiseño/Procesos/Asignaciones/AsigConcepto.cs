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
    public partial class AsigConcepto : Form
    {
        ConexionCapaDatos cnx = new ConexionCapaDatos();
        List<int> empleadosSelect = new List<int>();
        public AsigConcepto()
        {
            InitializeComponent();
            
        }

        //CONSTRUCTOR CON EMPLEADOS INDIVIDUALES
        //llena el datagrid con los empleados seleccionados en el form anterior, obtiene el query de la capa logica
        public AsigConcepto (List<int> lista)
        {
            InitializeComponent();
            empleadosSelect = lista;
            CapaLogicaNominas.querysConceptos querys = new querysConceptos();
            string query = querys.GetQueryEmpSelected(empleadosSelect); //query de la capa logica, solo los empleados que se seleccionaron
            OdbcDataAdapter cmd = new OdbcDataAdapter(query, cnx.cnxOpen());
            DataSet ds = new DataSet();
            cmd.Fill(ds, "tbl_empSelected");
            dtEmpSelected.DataSource = ds.Tables["tbl_empSelected"];
            dtEmpSelected.Refresh();
            cnx.cnxClose();

        }

        //CONTRUCTOR CON AREA
        // llena el data grid con los empleados del area que se selecciono en el form anterior
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
            //Llena el datagrid con todos los conceptos retributivos y agrega una columna de checkboxs para seleccionarlos
            OdbcDataAdapter emp = new OdbcDataAdapter("SELECT * FROM empleadoConceptoVW_conceptos", cnx.cnxOpen());
            DataSet dst2 = new DataSet();
            dst2.Tables.Add("tbl_conceptos");
            dst2.Tables["tbl_conceptos"].Columns.Add("Seleccion", typeof(bool)); //columna de checkboxs
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
            //Recorre el datagrid buscando todos los checkboxs que se seleccionaron, guarda el Codigo de cada concepto
            List<int> idConceptos = new List<int>();
            for (int i = 0; i < dtConceptos.Rows.Count; i++)
            {
                bool chkSelected = Convert.ToBoolean(dtConceptos.Rows[i].Cells[0].Value);
                if (chkSelected == true) //Si el checkbox esta seleccionado el codigo se guarda en una lista
                {
                    idConceptos.Add(Convert.ToInt32(dtConceptos.Rows[i].Cells["Codigo"].Value)); 
                }
            }
            if (idConceptos.Count != 0)
            {
                DialogResult op = MessageBox.Show("Esta seguro de Asignar el concepto al empleado?", "Asignacion Conceptos", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (op == DialogResult.Yes)
                {
                    //obtiene el query de la capa logica con todos los valores para asignar a los empleados seleccionados
                    //la capa logica devuelve el query solo con los datos que no existen en la tabla.
                    CapaLogicaNominas.querysConceptos query = new querysConceptos();
                    string queryInsert = query.GetQueryInsertEmpConcepto(empleadosSelect, idConceptos);
                    if (queryInsert != "")
                    {
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
                    }else
                    {
                        MessageBox.Show("Cambios realizados!");
                        this.Dispose();
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
                foreach(DataGridViewRow row in dtConceptos.Rows)
                {
                    if (row.Cells["Tipo"].Value.Equals(value))
                    {
                        row.Selected = true;
                    }
                }
            }else
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

        private void button1_Click(object sender, EventArgs e)
        {
            //Recorre el datagrid buscando todos los checkboxs que se seleccionaron, guarda el Codigo de cada concepto
            List<int> idConceptos = new List<int>();
            for (int i = 0; i < dtConceptos.Rows.Count; i++)
            {
                bool chkSelected = Convert.ToBoolean(dtConceptos.Rows[i].Cells[0].Value);
                if (chkSelected == true) //Si el checkbox esta seleccionado el codigo se guarda en una lista
                {
                    idConceptos.Add(Convert.ToInt32(dtConceptos.Rows[i].Cells["Codigo"].Value));
                }
            }
            if (idConceptos.Count != 0)
            {
                DialogResult op = MessageBox.Show("Esta seguro de Eliminar el concepto al empleado?", "Eliminacion Conceptos", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (op == DialogResult.Yes)
                {
                    //obtiene el query de la capa logica con todos los valores para asignar a los empleados seleccionados
                    //la capa logica devuelve el query solo con los datos que no existen en la tabla.
                    CapaLogicaNominas.querysConceptos query = new querysConceptos();
                    string queryInsert = query.GetQueryDeleteMultiple(empleadosSelect, idConceptos);
                    if (queryInsert != "")
                    {
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
                    else
                    {
                        MessageBox.Show("Cambios realizados!");
                        this.Dispose();
                    }
                }
            }
        }
    }
}
