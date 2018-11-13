using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatosNominas;
using System.Data.Odbc;


namespace CapaDiseño.Procesos.Liquidacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string ID_EMP;
        public string DIA,ID_PER;

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ConexionCapaDatos cone = new ConexionCapaDatos();
            try
            {
                try
                {
                    string mes = textBox5.Text;
                    string año = textBox8.Text;
                    string cadena;
                    DataTable dt = new DataTable();
                    cadena = "SELECT  ID_Empleado, ID_Percepcion, Total, Dias FROM Percepciones" +
                       " WHERE ID_Percepcion=" + "\"" + mes + "-" + año + "\"" + ";";

                    OdbcDataAdapter dta = new OdbcDataAdapter(cadena, cone.cnxOpen());
                    DataSet dst = new DataSet();
                    dta.Fill(dst);
                    dt = dst.Tables[0];

                    dataGridView1.DataSource = dt;
                    
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("Error en la base de datos \n" + ex);
                    cone.cnxClose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la base de datos\n" + ex);
                cone.cnxClose();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //textBox1.Text = this.dataGridView1.CurrentCell.Value.ToString();
            ConexionCapaDatos cone = new ConexionCapaDatos();
            
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox7.Text = row.Cells[2].Value.ToString();
            textBox6.Text = row.Cells[3].Value.ToString();
            ID_PER= row.Cells[1].Value.ToString();

            textBox6.ReadOnly = false;
            string cadenaN, cadenaA,cadenaP;
            ID_EMP= textBox1.Text;
            DIA = textBox6.Text;
            try
            {
                try
                {
                    string ID_EMP = textBox1.Text;
                    string DIA = textBox6.Text;

                    cadenaN = "select nombre from tbl_empleados where tbl_empleados.ID_Empleado=" + ID_EMP + ";";
                    OdbcCommand cmd = new OdbcCommand(cadenaN, cone.cnxOpen());
                    OdbcDataReader leer = cmd.ExecuteReader();
                    while (leer.Read())
                    {
                        textBox3.Text = leer.GetString(0);
                    }
                    cone.cnxClose();


                    cadenaA = "select tbl_empleados.ID_Empleado, tbl_areas.Nombre  from tbl_empleados" +
                        " inner join tbl_areas on tbl_areas.ID_Area = tbl_empleados.ID_Area" +
                        " WHERE tbl_empleados.ID_Empleado = " +
                        ID_EMP + "; ";
                    OdbcCommand cmd1 = new OdbcCommand(cadenaA, cone.cnxOpen());
                    OdbcDataReader leer1 = cmd1.ExecuteReader();
                    while (leer1.Read())
                    {
                        textBox4.Text = leer1.GetString(1);
                    }
                    cone.cnxClose();

                    cadenaP = "select tbl_empleados.ID_Empleado, tbl_puestos.Nombre from tbl_empleados" +
                       " inner join tbl_puestos on tbl_puestos.ID_Puesto = tbl_empleados.ID_Puesto" +
                       " WHERE tbl_empleados.ID_Empleado =" +
                       ID_EMP + "; ";
                    OdbcCommand cmd2 = new OdbcCommand(cadenaP, cone.cnxOpen());
                    OdbcDataReader leer2 = cmd2.ExecuteReader();
                    while (leer2.Read())
                    {
                        textBox2.Text = leer2.GetString(1);
                    }
                    cone.cnxClose();

                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("Error en la base de datos \n" + ex);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la base de datos\n" + ex);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DIA= textBox6.Text;
            ConexionCapaDatos cone = new ConexionCapaDatos();
            string cadena = "UPDATE `Percepciones` SET `Dias` = " + "'" + DIA + "'" + " WHERE (Percepciones.ID_Percepcion=" +
                            "\"" + ID_PER + "\"" + " and Percepciones.ID_Empleado=" + ID_EMP+ ");";
            
            OdbcCommand cmd = new OdbcCommand(cadena, cone.cnxOpen());
            cmd.ExecuteNonQuery();
            MessageBox.Show("Actualizado");
            cone.cnxClose();
        }
    }
        
}

