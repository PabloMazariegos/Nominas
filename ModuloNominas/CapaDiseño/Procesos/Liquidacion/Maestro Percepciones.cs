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
        public double[] sueldo = new double[1024];
        public string[] aux = new string[1024];
        public string[] idemp = new string[1024];
        public double dias;
        public string mes, año, idper;
        public int x = 1;
        public double diai;

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
            try {
                try { 
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            ConexionCapaDatos cone = new ConexionCapaDatos();
            string cadena;
            int fechaI;
            int fechaF;
            int mesi; 
            string aux;


                    
            fechaI = dateTimePicker1.Value.Day;
            fechaF = dateTimePicker2.Value.Day;
            int añoi = dateTimePicker1.Value.Year;
             mesi = dateTimePicker1.Value.Month;
            año = añoi.ToString();
            mes = mesi.ToString();
            idper = mes + "-" + año;
            dias = (fechaF - fechaI)+1;
            if (fechaI >=fechaF)
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
                    idemp[x] = leer.GetString(0);
                    dataGridView1.Rows.Add(leer.GetString(0), leer.GetString(1), leer.GetString(2));
                    aux= leer.GetString(2);
                    sueldo[x] = double.Parse(aux);
                    x = x + 1;
                    
                }
                cone.cnxClose();
                }

            }catch(Exception ex)
            {
                MessageBox.Show("HUBO UN ERRO \n" +ex);
            }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("ERROE EN LA BASE DE DATOS \n" + ex);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try {
                try {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("DEBERA ESCOGER PRIMERO LA FECHA");
                    }
                    else
                    {
                        string cadena;
                        string auxi;
                        double saldo;
                        string result;
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

                            aux[z] = leer.GetString(1);
                            saldo = double.Parse(aux[z]);
                            sueldo[z] += saldo;
                            z++;
                        }

                        for (int y = 1; y < x; y++)
                        {
                            dataGridView1.Rows[y - 1].Cells[3].Value = aux[y];                     
                            auxi = String.Format("{0:0.00}", sueldo[y]);
                            result = auxi.Replace(",", ".");
                            dataGridView1.Rows[y - 1].Cells[5].Value = result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("HUBO UN ERRO \n" + ex);
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("ERROE EN LA BASE DE DATOS \n" + ex);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("DEBERA ESCOGER PRIMERO LA FECHA");
                    }
                    else
                    {
                        string auxi = "";
                        string cadenaN = "";
                        int contador = 1;
                        ConexionCapaDatos cone1 = new ConexionCapaDatos();
                        cadenaN = "SELECT  ID_Percepcion from Percepciones;";
                        OdbcCommand cmd1 = new OdbcCommand(cadenaN, cone1.cnxOpen());
                        OdbcDataReader leer = cmd1.ExecuteReader();
                        contador = 1;
                        while (leer.Read())
                        {

                            if (idper == leer.GetString(0))
                            {
                                contador = 0;
                            }
                            else
                            {
                                contador = 1;
                            }
                        }
                        if (contador == 0)
                        {
                            MessageBox.Show("MES Y AÑO YA CALCULADOS SI \n DESEA UN CAMBIO UN INDIVIDUAL \n " +
                                "INGRESARLO EN PERCEPCION INDIVIDUAL");
                        }
                        else
                        {



                            for (int y = 1; y < x; y++)
                            {
                                auxi = String.Format("{0:0.00}", sueldo[y]);
                                string result = auxi.Replace(",", ".");
                                string cadena = "INSERT INTO Percepciones values(" + "\"" +
                                                mes + "-" + año + "\"" + " ," +
                                                idemp[y] + "," +
                                                sueldo[y] + "," +
                                                dias + ");";

                                ConexionCapaDatos cone = new ConexionCapaDatos();
                                OdbcCommand cmd = new OdbcCommand(cadena, cone.cnxOpen());
                                cmd.ExecuteNonQuery();
                                cone.cnxClose();
                                cadena = "";
                            }
                            MessageBox.Show("Percepciones guardadas con exito");
                    }
                }
         } catch (Exception ex)
            {
                MessageBox.Show("HUBO UN ERRO \n" + ex);
            }

        }catch (OdbcException ex)
            {
                MessageBox.Show("ERROE EN LA BASE DE DATOS \n" + ex);
            }
        }
    }
}
