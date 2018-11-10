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

        public int contador = 1;
        public string Mes = "";
        public string Año = "";
        public int posicion = 0;
        public double dias = 0;
        public string codigo_emp;
        public int mes = DateTime.Now.Month;
        public int año = DateTime.Now.Year;

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


                    string cadenaN;
                    string cadenaA;
                    string cadenaP;
                    Mes = textBox5.Text;
                    Año = textBox8.Text;

                    string percepcion = "";
                    string salario = "";



                    if (textBox1.Text == "" || textBox5.Text == "" || textBox8.Text == "")

                    {
                        MessageBox.Show("No puede quedar los campos, ID, AÑO ,MES");
                    }
                    else
                    {
                        codigo_emp = textBox1.Text;


                        cadenaN = "select nombre from tbl_empleados where tbl_empleados.ID_Empleado=" + codigo_emp + ";";
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
                        codigo_emp + "; ";
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
                        codigo_emp + "; ";
                        OdbcCommand cmd2 = new OdbcCommand(cadenaP, cone.cnxOpen());
                        OdbcDataReader leer2 = cmd2.ExecuteReader();
                        while (leer2.Read())
                        {
                            textBox2.Text = leer2.GetString(1);
                        }
                        cone.cnxClose();

                        cadenaP = "SELECT Total FROM Percepciones where Percepciones.ID_Percepcion=" +
                            "\"" + Mes + "-" + Año + "\"" + " and Percepciones.ID_Empleado=" + codigo_emp + ";";

                        OdbcCommand cmd3 = new OdbcCommand(cadenaP, cone.cnxOpen());
                        OdbcDataReader leer3 = cmd3.ExecuteReader();
                        while (leer3.Read())
                        {
                            textBox7.Text = leer3.GetString(0);
                        }
                        cone.cnxClose();
                        if (textBox7.Text == "")
                        {
                            MessageBox.Show("FECHA NO ENCONTRADA");
                            contador = 0;
                        }
                        else
                        {
                            contador = 1;
                        }
                    }

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
            try
            {
                try
                {
                    string diasnuevo = textBox6.Text;
                    string Mes = mes.ToString();
                    string Año = año.ToString();
                    int diaP;
                    if (contador == 0 || textBox6.Text == "")
                    {
                        MessageBox.Show("INGRESE UNA FECHA EXISTENTE DEL EMPLEADO O INGRESE LOS DIAS");
                    }
                    else
                    {
                        diaP= Int32.Parse(textBox6.Text);
                        if (diaP > 31) {
                            MessageBox.Show("Los dias no deben sobrepasar los 31 dias");
                        }
                        else { 
                        ConexionCapaDatos cone = new ConexionCapaDatos();

                        string cadena = "UPDATE `Percepciones` SET `Dias` = " + "'" + diasnuevo + "'" + " WHERE (Percepciones.ID_Percepcion=" +
                            "\"" + Mes + "-" + Año + "\"" + " and Percepciones.ID_Empleado=" + codigo_emp + ");";

                        OdbcCommand cmd = new OdbcCommand(cadena, cone.cnxOpen());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Actualizado");
                        cone.cnxClose();
                    }
                }
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
    }
        
}

