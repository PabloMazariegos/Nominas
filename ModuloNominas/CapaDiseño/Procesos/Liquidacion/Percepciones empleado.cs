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

<<<<<<< HEAD
        public string totalDevengado = "";
        public string total = "";
        public double sal = 0;
        public double salariototal = 0;
        public double salariomes = 0;
        public double percibe = 0;
        public double totalpercibe = 0;
        public string fecha = "";
        public int posicion = 0;
        public double dias = 0;
        public string codigo_emp;

=======
        public string ID_EMP;
        public string DIA,ID_PER;
        public int btn1 = 0, btn = 0;
        public int mescmx;
        public double sueldo,bono;
>>>>>>> bc2179b49168c3f397d4fe38552d55e664ca5aab

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
<<<<<<< HEAD
=======
            
>>>>>>> bc2179b49168c3f397d4fe38552d55e664ca5aab
            try
            {
                try
                {
<<<<<<< HEAD
                    

                    string cadenaN;
                    string cadenaA;
                    string cadenaP;


                    string percepcion = "";
                    string salario = "";



                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("No puede quedar vacio el campo del codigo");
                    }
                    else
                    {
                        codigo_emp = textBox1.Text;


                        cadenaN = "select nombre from tbl_empleados where tbl_empleados.ID_Empleado=" + codigo_emp + ";";
=======
                    mescmx = comboBox1.SelectedIndex;
                    string mes = mescmx.ToString();
                    string año = textBox8.Text;
                    string cadena;
                    if (mescmx== 0 || textBox8.Text == "")
                    {
                        MessageBox.Show("Ingrese primero mes y año");
                        btn1 = 0;
                        btn= 0;
                    }
                    else { 
                    DataTable dt = new DataTable();
                    cadena = "SELECT  ID_Empleado, ID_Percepcion, Total, Dias FROM Percepciones" +
                       " WHERE ID_Percepcion=" + "\"" + mes + "-" + año + "\"" + ";";

                    OdbcDataAdapter dta = new OdbcDataAdapter(cadena, cone.cnxOpen());
                    DataSet dst = new DataSet();
                    dta.Fill(dst);
                    dt = dst.Tables[0];

                    dataGridView1.DataSource = dt;
                        if (dataGridView1.Rows[0].Cells[0].Value ==null)
                        {
                            MessageBox.Show("Fecha no encontrada");
                        }
                        btn = 1;
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

        private void button2_Click(object sender, EventArgs e)
        {
           /* Form3 llama = new Form3();
            llama.Show();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //textBox1.Text = this.dataGridView1.CurrentCell.Value.ToString();
            ConexionCapaDatos cone = new ConexionCapaDatos();
            
            DataGridViewRow row = dataGridView1.CurrentRow;
   
            string cadenaN, cadenaA,cadenaP;
            
            try
            {
                try
                {
                    if (btn == 1)
                    {
                        textBox6.ReadOnly = false;
                        textBox1.Text = row.Cells[0].Value.ToString();
                        textBox7.Text = row.Cells[2].Value.ToString();
                        textBox6.Text = row.Cells[3].Value.ToString();
                        ID_PER = row.Cells[1].Value.ToString();
                        ID_EMP = textBox1.Text;
                        DIA = textBox6.Text;


                        cadenaN = "select nombre from tbl_empleados where tbl_empleados.ID_Empleado=" + ID_EMP + ";";
>>>>>>> bc2179b49168c3f397d4fe38552d55e664ca5aab
                        OdbcCommand cmd = new OdbcCommand(cadenaN, cone.cnxOpen());
                        OdbcDataReader leer = cmd.ExecuteReader();
                        while (leer.Read())
                        {
                            textBox3.Text = leer.GetString(0);
                        }
                        cone.cnxClose();


                        cadenaA = "select tbl_empleados.ID_Empleado, tbl_areas.Nombre  from tbl_empleados" +
<<<<<<< HEAD
                        " inner join tbl_areas on tbl_areas.ID_Area = tbl_empleados.ID_Area" +
                        " WHERE tbl_empleados.ID_Empleado = " +
                        codigo_emp + "; ";
=======
                            " inner join tbl_areas on tbl_areas.ID_Area = tbl_empleados.ID_Area" +
                            " WHERE tbl_empleados.ID_Empleado = " +
                            ID_EMP + "; ";
>>>>>>> bc2179b49168c3f397d4fe38552d55e664ca5aab
                        OdbcCommand cmd1 = new OdbcCommand(cadenaA, cone.cnxOpen());
                        OdbcDataReader leer1 = cmd1.ExecuteReader();
                        while (leer1.Read())
                        {
                            textBox4.Text = leer1.GetString(1);
                        }
                        cone.cnxClose();

                        cadenaP = "select tbl_empleados.ID_Empleado, tbl_puestos.Nombre from tbl_empleados" +
<<<<<<< HEAD
                        " inner join tbl_puestos on tbl_puestos.ID_Puesto = tbl_empleados.ID_Puesto" +
                        " WHERE tbl_empleados.ID_Empleado =" +
                        codigo_emp + "; ";
=======
                           " inner join tbl_puestos on tbl_puestos.ID_Puesto = tbl_empleados.ID_Puesto" +
                           " WHERE tbl_empleados.ID_Empleado =" +
                           ID_EMP + "; ";
>>>>>>> bc2179b49168c3f397d4fe38552d55e664ca5aab
                        OdbcCommand cmd2 = new OdbcCommand(cadenaP, cone.cnxOpen());
                        OdbcDataReader leer2 = cmd2.ExecuteReader();
                        while (leer2.Read())
                        {
                            textBox2.Text = leer2.GetString(1);
                        }
                        cone.cnxClose();
<<<<<<< HEAD


                        cadenaP = "SELECT" +
                                    " SUM(tCR.importe) AS total" +
                                    " FROM tbl_empleados tE" +
                                    " INNER JOIN tbl_empleadoconcepto tEC ON" +
                                    " tE.ID_Empleado = tEC.ID_Empleado" +
                                    " INNER JOIN tbl_conceptosretributivos tCR ON" +
                                    " tCR.ID_ConceptosR = tEC.ID_ConceptosR" +
                                    " WHERE tCR.tipo = 'ABONO'" +
                                    "AND tE.ID_Empleado = " +
                                                codigo_emp + "; ";

                        OdbcCommand cmd3 = new OdbcCommand(cadenaP, cone.cnxOpen());
                        OdbcDataReader leer3 = cmd3.ExecuteReader();
                        while (leer3.Read())
                        {
                            percepcion = leer3.GetString(0);
                        }
                        cone.cnxClose();


                        cadenaP = "select tbl_empleados.ID_Empleado,tbl_contratos.salario" +
                        " from tbl_empleados" +
                        " inner join tbl_contratos on tbl_contratos.ID_Contrato = tbl_empleados.ID_Contrato" +
                        " WHERE tbl_empleados.ID_Empleado =" +
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
                    }

=======
                        btn = 1;
                        btn1 = 1;
                    }
                    else {
                        MessageBox.Show("Debe usar primero el boton de Seleccionar");
                        }
>>>>>>> bc2179b49168c3f397d4fe38552d55e664ca5aab
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show("Error en la base de datos \n" + ex);
<<<<<<< HEAD
                    cone.cnxClose();
=======

>>>>>>> bc2179b49168c3f397d4fe38552d55e664ca5aab
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la base de datos\n" + ex);
<<<<<<< HEAD
                cone.cnxClose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string aux;
            string auxi;
            try {
            

            if (textBox6.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Debe ingresar los dias devengados y el Año");
            }
            else
            {
                fecha = textBox5.Text;
                posicion = comboBox1.SelectedIndex;
                aux = textBox6.Text;
                dias = Int32.Parse(aux);
                if (dias > 31)
                {
                    MessageBox.Show("El numero de dias no debera superar los 31 dias");
                }
                else
                {
                        switch (posicion)
                        {
                            case 0:
                                salariomes = sal / 31;
                                salariototal = (salariomes * dias) + percibe;
                                auxi = String.Format("{0:0.00}", salariototal);
                                totalDevengado = auxi;
                                textBox7.Text = totalDevengado;
                                textBox9.Text = totalDevengado;
                                break;
                            case 1:
                                salariomes = sal / 28;
                                salariototal = (salariomes * dias) + percibe;
                                auxi = String.Format("{0:0.00}", salariototal);
                                totalDevengado = auxi;
                                textBox7.Text = totalDevengado;
                                textBox9.Text = totalDevengado;
                                break;
                            case 2:
                                salariomes = sal / 31;
                                salariototal = (salariomes * dias) + percibe;
                                auxi = String.Format("{0:0.00}", salariototal);
                                totalDevengado = auxi;
                                textBox7.Text = totalDevengado;
                                textBox9.Text = totalDevengado;
                                break;
                            case 3:
                                salariomes = sal / 30;
                                salariototal = (salariomes * dias) + percibe;
                                auxi = String.Format("{0:0.00}", salariototal);
                                totalDevengado = auxi;
                                textBox7.Text = totalDevengado;
                                textBox9.Text = totalDevengado;
                                break;
                            case 4:
                                salariomes = sal / 31;
                                salariototal = (salariomes * dias) + percibe;
                                auxi = String.Format("{0:0.00}", salariototal);
                                totalDevengado = auxi;
                                textBox7.Text = totalDevengado;
                                textBox9.Text = totalDevengado;
                                break;
                            case 5:
                                salariomes = sal / 30;
                                salariototal = (salariomes * dias) + percibe;
                                auxi = String.Format("{0:0.00}", salariototal);
                                totalDevengado = auxi;
                                textBox7.Text = totalDevengado;
                                textBox9.Text = totalDevengado;
                                break;
                            case 6:
                                salariomes = sal / 31;
                                salariototal = (salariomes * dias) + percibe;
                                auxi = String.Format("{0:0.00}", salariototal);
                                totalDevengado = auxi;
                                textBox7.Text = totalDevengado;
                                textBox9.Text = totalDevengado;
                                break;
                            case 7:
                                salariomes = sal / 30;
                                salariototal = (salariomes * dias) + percibe;
                                auxi = String.Format("{0:0.00}", salariototal);
                                totalDevengado = auxi;
                                textBox7.Text = totalDevengado;
                                textBox9.Text = totalDevengado;
                                break;
                            case 8:
                                salariomes = sal / 31;
                                salariototal = (salariomes * dias) + percibe;
                                auxi = String.Format("{0:0.00}", salariototal);
                                totalDevengado = auxi;
                                textBox7.Text = totalDevengado;
                                textBox9.Text = totalDevengado;
                                break;
                            case 9:
                                salariomes = sal / 30;
                                salariototal = (salariomes * dias) + percibe;
                                totalDevengado = salariototal.ToString();
                                textBox7.Text = totalDevengado;
                                totalpercibe = salariototal - 369;
                                textBox9.Text = totalpercibe.ToString();
                                break;
                            case 10:
                                salariomes = sal / 31;
                                salariototal = (salariomes * dias) + percibe;
                                totalDevengado = salariototal.ToString();
                                textBox7.Text = totalDevengado;
                                totalpercibe = salariototal - 369;
                                textBox9.Text = totalpercibe.ToString();
                                break;
                            case 11:
                                salariomes = sal / 30;
                                salariototal = (salariomes * dias) + percibe;
                                auxi = String.Format("{0:0.00}", salariototal);
                                totalDevengado = auxi;
                                textBox7.Text = totalDevengado;
                                textBox9.Text = totalDevengado;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR\n"+ex);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

            string auxi = "";
            string cadenaN = "";
            string mes, año;
            string mesid = "";
            string id = "";
            int contador = 1;
            auxi = String.Format("{0:0.00}", salariototal);
            string result = auxi.Replace(",", ".");
            if (textBox9.Text == "")
            {
                MessageBox.Show("Ingrese primero los datos y calcule los datos");
            }
            else
            {
                string aux;
                ConexionCapaDatos cone = new ConexionCapaDatos();
                posicion = comboBox1.SelectedIndex;
                mesid = posicion.ToString();
                aux = textBox6.Text;
                dias = Int32.Parse(aux);
                fecha = textBox5.Text;

                cadenaN = "select Mes, Año,ID_Empleado" +
                " from Percepciones" +
                " where Percepciones.ID_Empleado =" + codigo_emp + ";";
                OdbcCommand coman = new OdbcCommand(cadenaN, cone.cnxOpen());
                OdbcDataReader leer = coman.ExecuteReader();
                while (leer.Read())
                {
                    mes = leer.GetString(0);
                    año = leer.GetString(1);
                    id = leer.GetString(2);
                    if (mes == mesid && año == fecha && id == codigo_emp)
                    {
                        MessageBox.Show("FECHA YA INGRESADA");
                        contador = 0;
                    }
                    else
                    {
                        contador = 1;
                    }
                }
                cone.cnxClose();
                if (contador == 0)
                {
                }
                else { 
                    try
                    {
                        string cadena = "INSERT INTO Percepciones values(default," +
                            posicion + "," +
                            result + "," +
                            fecha + "," +
                            dias + "," +
                            codigo_emp + ");";

                        OdbcCommand cmd = new OdbcCommand(cadena, cone.cnxOpen());
                        cmd.ExecuteNonQuery();
                    }
                    catch (OdbcException ex)
                    {
                        MessageBox.Show("ERROR AL INSERTAR" + "\n" + ex);

                    }
                    cone.cnxClose();
                }
=======
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
            ConexionCapaDatos cone = new ConexionCapaDatos();
            double sueldoM;
            double sueldoD;
            string saldo;
            string dinero = "";
            
            try { 
                try{
                    string auxi;
                    int diastxt=Convert.ToInt32(textBox6.Text);
                    
                    if (btn1 == 1&&btn==1&&diastxt<=31&&diastxt>0) {
                        ////
                        string cadenaB = "SELECT  tE.ID_empleado, SUM(tCR.importe) AS total" +
                        " FROM tbl_empleados tE" +
                        " INNER JOIN tbl_empleadoconcepto tEC ON" +
                        " tE.ID_Empleado = tEC.ID_Empleado" +
                        " INNER JOIN tbl_conceptosretributivos tCR ON" +
                        " tCR.ID_ConceptosR = tEC.ID_ConceptosR" +
                        " WHERE tCR.tipo = 'ABONO' AND tE.ID_empleado=" + ID_EMP +
                        " group by 1;";
                        OdbcCommand cmd3 = new OdbcCommand(cadenaB, cone.cnxOpen());
                        OdbcDataReader leer3 = cmd3.ExecuteReader();
                        while (leer3.Read())
                        {
                            bono = leer3.GetDouble(1);
                        }

                        cone.cnxClose();

                        string cadenaA="SELECT tbl_empleados.ID_empleado ,tbl_empleados.nombre,tbl_contratos.salario " +
                        "FROM tbl_empleados " +
                        "INNER JOIN tbl_contratos ON tbl_empleados.ID_contrato = tbl_contratos.ID_contrato WHERE ID_Empleado="+ID_EMP+";";
                        OdbcCommand cmd1 = new OdbcCommand(cadenaA, cone.cnxOpen());
                        OdbcDataReader leer = cmd1.ExecuteReader();
                        while (leer.Read())
                        {
                            saldo = leer.GetString(2);
                            sueldo = Convert.ToDouble(saldo);
                            switch (mescmx)
                            {
                                case (1):
                                    sueldoM = (sueldo / 31);
                                    sueldoD = (sueldoM * diastxt);
                                    sueldo = sueldoD+bono;
                                    break;
                                case (2):
                                    sueldoM = (sueldo / 28);
                                    sueldoD = (sueldoM * diastxt);
                                    sueldo = sueldoD + bono;
                                    break;
                                case (3):
                                    sueldoM = (sueldo / 31);
                                    sueldoD = (sueldoM * diastxt);
                                    sueldo = sueldoD + bono;
                                    break;
                                case (4):
                                    sueldoM = (sueldo / 30);
                                    sueldoD = (sueldoM * diastxt);
                                    sueldo = sueldoD + bono;
                                    break;
                                case (5):
                                    sueldoM = (sueldo / 31);
                                    sueldoD = (sueldoM * diastxt);
                                    sueldo = sueldoD + bono;
                                    break;
                                case (6):
                                    sueldoM = (sueldo / 30);
                                    sueldoD = (sueldoM * diastxt);
                                    sueldo = sueldoD + bono;
                                    break;
                                case (7):
                                    sueldoM = (sueldo / 31);
                                    sueldoD = (sueldoM * diastxt);
                                    sueldo = sueldoD + bono;
                                    break;
                                case (8):
                                    sueldoM = (sueldo / 31);
                                    sueldoD = (sueldoM * diastxt);
                                    sueldo = sueldoD + bono;
                                    break;
                                case (9):
                                    sueldoM = (sueldo / 30);
                                    sueldoD = (sueldoM * diastxt);
                                    sueldo = sueldoD + bono;
                                    break;

                                case (10):
                                    sueldoM = (sueldo/ 31);
                                    sueldoD = (sueldoM * diastxt);
                                    sueldo = sueldoD + bono;
                                    break;
                                case (11):
                                    sueldoM = (sueldo / 30);
                                    sueldoD = (sueldoM * diastxt);
                                    sueldo = sueldoD + bono;
                                    break;
                                case (12):
                                    sueldoM = (sueldo / 31);
                                    sueldoD = (sueldoM * diastxt);
                                    sueldo = sueldoD + bono;
                                    break;
                                    
                            }
                            
                           
                        }
                        cone.cnxClose();
                        auxi = String.Format("{0:0.00}", sueldo);
                        string result = auxi.Replace(",", ".");
                        DIA = textBox6.Text;
                    string cadena = "UPDATE `Percepciones` SET `Dias` = " + "'" + DIA + "'" + ", `Total` = " + "'" + result + "'" + " WHERE (Percepciones.ID_Percepcion=" +
                            "\"" + ID_PER + "\"" + " and Percepciones.ID_Empleado=" + ID_EMP+ ");";
            OdbcCommand cmd = new OdbcCommand(cadena, cone.cnxOpen());
            cmd.ExecuteNonQuery();
         
            cone.cnxClose();

                        DataTable dt = new DataTable();
                        cadena = "SELECT  ID_Empleado, ID_Percepcion, Total, Dias FROM Percepciones" +
                           " WHERE ID_Percepcion=" + "\"" + ID_PER+ "\"" + ";";

                        OdbcDataAdapter dta = new OdbcDataAdapter(cadena, cone.cnxOpen());
                        DataSet dst = new DataSet();
                        dta.Fill(dst);
                        dt = dst.Tables[0];

                        dataGridView1.DataSource = dt;
                        MessageBox.Show("Actualizado");
                            cone.cnxClose();
                    }
                    else
                    {
                        MessageBox.Show("Debe usar primero el boton de Actualizar\n o Los dias no deben superar los 31 ni menor a 1");
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
>>>>>>> bc2179b49168c3f397d4fe38552d55e664ca5aab
            }
        }
    }
        
}

