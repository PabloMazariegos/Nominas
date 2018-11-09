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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public double[] sueldo = new double[5];
        public int dias;
        public int x = 1;

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
            int prueba;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            ConexionCapaDatos cone = new ConexionCapaDatos();
            string cadena;
            int fechaI;
            int fechaF;
            
            string aux;
            


            fechaI = dateTimePicker1.Value.Day;
            fechaF = dateTimePicker2.Value.Day;
            dias = fechaF - fechaI;
            if (fechaI >fechaF)
            {
                MessageBox.Show("la fecha final debera ser mayor a la inicial");
            }
            else
            {
                textBox1.Text = dias.ToString();
                cadena = "SELECT tbl_empleados.ID_empleado ,tbl_empleados.nombre,tbl_contratos.salario " +
                        "FROM tbl_empleados " +
                        "INNER JOIN tbl_contratos ON tbl_empleados.ID_contrato = tbl_contratos.ID_contrato;";
                OdbcCommand cmd = new OdbcCommand(cadena, cone.cnxOpen());
                OdbcDataReader leer = cmd.ExecuteReader();
                x = 1;
                while (leer.Read())
                {
                    dataGridView1.Rows.Add(leer.GetString(0), leer.GetString(1), leer.GetString(2));
                    aux= leer.GetString(2);
                    sueldo[x] = double.Parse(aux);
                    x = x + 1;
                    
                }
                cone.cnxClose();
                
                
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            string cadena;
            string aux;
            double saldo;
            int z = 1;
            ConexionCapaDatos cone = new ConexionCapaDatos();
            cadena = "SELECT  tE.ID_empleado, SUM(tCR.importe) AS total" +
            " FROM tbl_empleados tE" +
            " INNER JOIN tbl_empleadoconcepto tEC ON" +
            " tE.ID_Empleado = tEC.ID_Empleado" +
            " INNER JOIN tbl_conceptosretributivos tCR ON" +
            " tCR.ID_ConceptosR = tEC.ID_ConceptosR" +
            " WHERE tCR.tipo = 'ABONO'" +
            " group by 1;";
            OdbcCommand cmd = new OdbcCommand(cadena, cone.cnxOpen());
            OdbcDataReader leer = cmd.ExecuteReader();
            while (leer.Read())
            {

                aux = leer.GetString(1);
                saldo= double.Parse(aux);
                sueldo[z]+= saldo;
                z++;
            }
            for (int y = 1; y < x; y++)
            {
                dataGridView1.Rows[y - 1].Cells[3].Value = sueldo[y];
            }
        }
    }
}
