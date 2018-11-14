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
        public int x = 1, contaux,mesi; 
        public double diai;
        public int contadorID=0;

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
            contadorID = 0;
            x = 1;
            try {
                try { 
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            ConexionCapaDatos cone = new ConexionCapaDatos();
            string cadena;
            int fechaI;
            int fechaF;
            
            int añoi;
            string aux;
                    
                    
            fechaI = dateTimePicker1.Value.Day;
            fechaF = dateTimePicker2.Value.Day;
            añoi = dateTimePicker1.Value.Year;
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
                        x = 0;
                        while (leer.Read())
                {
                            x++;
                            idemp[x] = leer.GetString(0);
                            dataGridView1.Rows.Add(leer.GetString(0), leer.GetString(1), leer.GetString(2));
                            aux= leer.GetString(2);
                            sueldo[x] = double.Parse(aux);
                            contadorID++;
                        }
                cone.cnxClose();
                }
                }
                catch(Exception ex)
            {
                MessageBox.Show("HUBO UN ERROR \n" +ex);
            }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("ERROE EN LA BASE DE DATOS \n" + ex);
            }

            contaux = contadorID;
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
                        double saldo,sueldoM=0, sueldoD = 0;
                        string result;
                       
                        
                        for(int w=1; w<=contadorID;w++)
                        {
                        ConexionCapaDatos cone = new ConexionCapaDatos();
                        cadena = "SELECT  tE.ID_empleado, SUM(tCR.importe) AS total" +
                        " FROM tbl_empleados tE" +
                        " INNER JOIN tbl_empleadoconcepto tEC ON" +
                        " tE.ID_Empleado = tEC.ID_Empleado" +
                        " INNER JOIN tbl_conceptosretributivos tCR ON" +
                        " tCR.ID_ConceptosR = tEC.ID_ConceptosR" +
                        " WHERE tCR.tipo = 'ABONO' AND tE.ID_empleado="+idemp[w] +
                        " group by 1;";
                        OdbcCommand cmd = new OdbcCommand(cadena, cone.cnxOpen());
                        OdbcDataReader leer = cmd.ExecuteReader();
                        while (leer.Read())
                         {
                                    aux[w] = leer.GetString(1);
                                    saldo = double.Parse(aux[w]);
                                switch (mesi)
                                {
                                    case (1):
                                        sueldoM = (sueldo[w] / 31);
                                        sueldoD = (sueldoM * dias);
                                        sueldo[w] = sueldoD;
                                        break;
                                    case (2):
                                        sueldoM = (sueldo[w] / 28);
                                        sueldoD = (sueldoM * dias);
                                        sueldo[w] = sueldoD;
                                        break;
                                    case (3):
                                        sueldoM = (sueldo[w] / 31);
                                        sueldoD = (sueldoM * dias);
                                        sueldo[w] = sueldoD;
                                        break;
                                    case (4):
                                        sueldoM = (sueldo[w] / 30);
                                        sueldoD = (sueldoM * dias);
                                        sueldo[w] = sueldoD;
                                        break;
                                    case (5):
                                        sueldoM = (sueldo[w] / 31);
                                        sueldoD = (sueldoM * dias);
                                        sueldo[w] = sueldoD;
                                        break;
                                    case (6):
                                        sueldoM = (sueldo[w] / 30);
                                        sueldoD = (sueldoM * dias);
                                        sueldo[w] = sueldoD;
                                        break;
                                    case (7):
                                        sueldoM = (sueldo[w] / 31);
                                        sueldoD = (sueldoM * dias);
                                        sueldo[w] = sueldoD;
                                        break;
                                    case (8):
                                        sueldoM = (sueldo[w] / 31);
                                        sueldoD = (sueldoM * dias);
                                        sueldo[w] = sueldoD;
                                        break;
                                    case (9):
                                        sueldoM = (sueldo[w] / 30);
                                        sueldoD = (sueldoM * dias);
                                        sueldo[w] = sueldoD;
                                        break;

                                    case (10):
                                        sueldoM = (sueldo[w] / 31);
                                        sueldoD = (sueldoM * dias);
                                        sueldo[w] = sueldoD;
                                        break;
                                    case (11):
                                        sueldoM = (sueldo[w] / 30);
                                        sueldoD = (sueldoM * dias);
                                        sueldo[w] = sueldoD;
                                        break;
                                    case (12):
                                        sueldoM = (sueldo[w] / 31);
                                        sueldoD = (sueldoM * dias);
                                        sueldo[w] = sueldoD;
                                        break;
                                }
                                sueldo[w] += saldo;


                            }
                        }
                        for (int y = 1; y<= contadorID; y++)
                        {
                            if (aux[y]== null || aux[y] == "")
                            {
                                aux[y] = "0";
                            }
                            dataGridView1.Rows[y - 1].Cells[3].Value = aux[y];                     
                            auxi = String.Format("{0:0.00}", sueldo[y]);
                            result = auxi.Replace(",", ".");
                            dataGridView1.Rows[y - 1].Cells[5].Value = result;
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("HUBO UN ERROR \n" + ex);
                }
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("ERROE EN LA BASE DE DATOS \n" + ex);
            }
            for (int y = 1; y <= contadorID; y++)
            {
                aux[y] = "";
            }
                contadorID = 0;
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



                            for (int y = 1; y <= contaux; y++)
                            {
                                auxi = String.Format("{0:0.00}", sueldo[y]);
                                string result = auxi.Replace(",", ".");
                                string cadena = "INSERT INTO Percepciones values(" + "\"" +
                                                mes + "-" + año + "\"" + " ," +
                                                idemp[y] + "," +
                                                result + "," +
                                                dias + ");";
                                ConexionCapaDatos cone = new ConexionCapaDatos();
                                OdbcCommand cmd = new OdbcCommand(cadena, cone.cnxOpen());
                                cmd.ExecuteNonQuery();
                                cone.cnxClose();
                                idemp[y] = "";
                                sueldo[y] =0;
                                cadena = "";
                            }
                            MessageBox.Show("Percepciones guardadas con exito");
                    }
                }
         } catch (Exception ex)
            {
                MessageBox.Show("HUBO UN ERROR \n" + ex);
            }

        }catch (OdbcException ex)
            {
                MessageBox.Show("ERROE EN LA BASE DE DATOS \n" + ex);
            }
        }
    }
}
