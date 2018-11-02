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
using System.Data.SqlClient;


namespace CapaDiseño.Procesos.Liquidacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    }

        public string totalDevengado = "";
        public string total= "";
        public double sal = 0;
        public double salariototal = 0;
        public double salariomes = 0;
        public double percibe = 0;
        public double totalpercibe = 0;


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
            string codigo_emp;
            string cadenaN;
            string cadenaA;
            string cadenaP;
            
            string percepcion="";
            string salario = "";




            if (textBox1.Text == "")
            {
                MessageBox.Show("No puede quedar vacio el campo del codigo");
            }else { 
            codigo_emp = textBox1.Text;
           

            cadenaN = "select nombre from tbl_empleados where tbl_empleados.ID_Empleado=" + codigo_emp + ";";
            OdbcCommand cmd = new OdbcCommand(cadenaN, cone.cnxOpen());
            OdbcDataReader leer = cmd.ExecuteReader();
            while (leer.Read())
            {
                textBox3.Text = leer.GetString(0);
            }
            cone.cnxClose();

                
            cadenaA = "select tbl_empleados.ID_Empleado, tbl_areas.Nombre  from tbl_empleados"+
            " inner join tbl_areas on tbl_areas.ID_Area = tbl_empleados.ID_Area"+
            " WHERE tbl_empleados.ID_Empleado = "+
            codigo_emp + "; ";
            OdbcCommand cmd1 = new OdbcCommand(cadenaA, cone.cnxOpen());
            OdbcDataReader leer1 = cmd1.ExecuteReader();
            while (leer1.Read())
            {
                textBox4.Text = leer1.GetString(1);
            }
            cone.cnxClose();

            cadenaP = "select tbl_empleados.ID_Empleado, tbl_puestos.Nombre from tbl_empleados"+
            " inner join tbl_puestos on tbl_puestos.ID_Puesto = tbl_empleados.ID_Puesto"+
            " WHERE tbl_empleados.ID_Empleado =" +
            codigo_emp + "; ";
            OdbcCommand cmd2 = new OdbcCommand(cadenaP, cone.cnxOpen());
            OdbcDataReader leer2 = cmd2.ExecuteReader();
            while (leer2.Read())
            {
                textBox2.Text = leer2.GetString(1);
            }
            cone.cnxClose();

            cadenaP = "select tbl_empleados.Nombre as 'empleado', tbl_conceptosretributivos.nombre as 'concepto', tbl_conceptosretributivos.importe,sum(tbl_conceptosretributivos.importe)as Suma" +
            " from tbl_empleados" +
            " inner join tbl_empleadoconcepto on tbl_empleados.ID_Empleado = tbl_empleadoconcepto.ID_Empleado" +
            " inner join tbl_conceptosretributivos on tbl_conceptosretributivos.ID_ConceptosR = tbl_empleadoconcepto.ID_ConceptosR" +
            " where tbl_conceptosretributivos.tipo = 'ABONO' and tbl_empleados.ID_Empleado = " +
            codigo_emp + "; ";
            OdbcCommand cmd3 = new OdbcCommand(cadenaP, cone.cnxOpen());
            OdbcDataReader leer3 = cmd3.ExecuteReader();
            while (leer3.Read())
            {
                percepcion = leer3.GetString(3);
            }
            cone.cnxClose();

            cadenaP = "select tbl_empleados.ID_Empleado,tbl_contratos.salario"+
            " from tbl_empleados"+
            " inner join tbl_contratos on tbl_contratos.ID_Contrato = tbl_empleados.ID_Contrato"+
            " WHERE tbl_empleados.ID_Empleado ="+
            codigo_emp + "; ";
            OdbcCommand cmd4 = new OdbcCommand(cadenaP, cone.cnxOpen());
            OdbcDataReader leer4 = cmd4.ExecuteReader();
            while (leer4.Read())
            {
                salario = leer4.GetString(1);
            }
            cone.cnxClose();

            percibe = Int32.Parse(percepcion);
            sal = Int32.Parse(salario);

            salariototal = percibe + sal;
            totalDevengado = salariototal.ToString();
            textBox7.Text = (totalDevengado);
            textBox8.Text = ("369");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double dias = 0;
            int posicion = 0;
            string aux;
            if (textBox6.Text == "")
            {
                MessageBox.Show("Debe ingresar los dias devengados");
                }else{ 
            posicion = comboBox1.SelectedIndex;
            aux = textBox6.Text;
            dias = Int32.Parse(aux);
            if (dias > 31)
            {
                MessageBox.Show("El numero de dias no debera superar los 31 dias");
            }else
            {
                switch (posicion)
                {
                    case 0:
                        salariomes = sal / 31;
                        salariototal = (salariomes * dias) + percibe;
                        totalDevengado = salariototal.ToString();
                        textBox7.Text = totalDevengado;
                        totalpercibe = salariototal - 369;
                        textBox9.Text = totalpercibe.ToString();
                    break;
                    case 1:
                        salariomes = sal / 28;
                        salariototal = (salariomes * dias) + percibe;
                        totalDevengado = salariototal.ToString();
                        textBox7.Text = totalDevengado;
                        break;
                    case 2:
                        salariomes = sal / 31;
                        salariototal = (salariomes * dias) + percibe;
                        totalDevengado = salariototal.ToString();
                        textBox7.Text = totalDevengado;
                        break;
                    case 3:
                        salariomes = sal / 30;
                        salariototal = (salariomes * dias) + percibe;
                        totalDevengado = salariototal.ToString();
                        textBox7.Text = totalDevengado;
                        break;
                    case 4:
                        salariomes = sal / 31;
                        salariototal = (salariomes * dias) + percibe;
                        totalDevengado = salariototal.ToString();
                        textBox7.Text = totalDevengado;
                        break;
                    case 5:
                        salariomes = sal / 30;
                        salariototal = (salariomes * dias) + percibe;
                        totalDevengado = salariototal.ToString();
                        textBox7.Text = totalDevengado;
                        break;
                    case 6:
                        salariomes = sal / 31;
                        salariototal = (salariomes * dias) + percibe;
                        totalDevengado = salariototal.ToString();
                        textBox7.Text = totalDevengado;
                        break;
                    case 7:
                        salariomes = sal / 30;
                        salariototal = (salariomes * dias) + percibe;
                        totalDevengado = salariototal.ToString();
                        textBox7.Text = totalDevengado;
                        break;
                    case 8:
                        salariomes = sal / 31;
                        salariototal = (salariomes * dias) + percibe;
                        totalDevengado = salariototal.ToString();
                        textBox7.Text = totalDevengado;
                        break;
                    case 9:
                        salariomes = sal / 30;
                        salariototal = (salariomes * dias) + percibe;
                        totalDevengado = salariototal.ToString();
                        textBox7.Text = totalDevengado;
                        break;
                    case 10:
                        salariomes = sal / 31;
                        salariototal = (salariomes * dias) + percibe;
                        totalDevengado = salariototal.ToString();
                        textBox7.Text = totalDevengado;
                        break;
                    case 11:
                        salariomes = sal / 30;
                        salariototal = (salariomes * dias) + percibe;
                        totalDevengado = salariototal.ToString();
                        textBox7.Text = totalDevengado;
                        break;
                 }
              }
           }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            

        }
    }
}
