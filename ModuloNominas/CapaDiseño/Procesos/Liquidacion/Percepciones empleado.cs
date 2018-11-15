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
        public int btn1 = 0, btn = 0;
        public int mescmx;
        public double sueldo,bono;

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
                        ID_PER = mes +"-"+ año;
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

        private void button7_Click(object sender, EventArgs e)
        {
            string auxi;
            ConexionCapaDatos cone = new ConexionCapaDatos();
            int contador = 1;
            double sueldoM;
            double sueldoD;
            string saldo;
            try {
                try {
                    int x=1;
                    
                    string[] vector = new string[1024];
            string nuevo_emp =Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nuevo id del empleado","Ingreso");
                    string cadena = "select ID_Empleado from Percepciones";/* where ID_Empleado="+
                          // nuevo_emp +" and ID_Percepcion=" +"'"+ID_PER+"'"+"; ";*/
            
            OdbcCommand cmd = new OdbcCommand(cadena, cone.cnxOpen());
            OdbcDataReader leer = cmd.ExecuteReader();
            while (leer.Read())
            {
                        vector[x] = leer.GetString(0);
                        x++;
            }
            cone.cnxClose();

                    for (int y = 1; y < x; y++)
                    {
                        string cadenaA = "select ID_Empleado from Percepciones where ID_Empleado=" +
                               nuevo_emp + " and ID_Percepcion=" + "'" + ID_PER + "'" + "; ";
                       
                        OdbcCommand cmd1 = new OdbcCommand(cadenaA, cone.cnxOpen());
                        OdbcDataReader leer1 = cmd1.ExecuteReader();
                        while (leer1.Read())
                        {
                            if (vector[y] == nuevo_emp)
                            {
                                contador = 1;
                            }
                            else
                            {
                                contador = 0;
                            }
                        }
                        cone.cnxClose();

                    }
                    if (contador == 1)
                    {
                        MessageBox.Show("EMPLEADO YA INGRESADO");
                    }
                    else { 
                        string nuevo_dias = Microsoft.VisualBasic.Interaction.InputBox("Ingrese los dias", "Ingreso");

                        ///////////////////
                        int diastxt = Convert.ToInt32(nuevo_dias);
                        string cadenaB = "SELECT tbl_empleados.ID_empleado ,tbl_empleados.nombre,tbl_contratos.salario " +
                        "FROM tbl_empleados " +
                        "INNER JOIN tbl_contratos ON tbl_empleados.ID_contrato = tbl_contratos.ID_contrato WHERE ID_Empleado=" + nuevo_emp + ";";
                        MessageBox.Show(cadenaB);
                        OdbcCommand cmd2 = new OdbcCommand(cadenaB, cone.cnxOpen());
                        OdbcDataReader leer1 = cmd2.ExecuteReader();
                       
                        while (leer1.Read())
                        {
                            saldo = leer.GetString(2);
                            sueldo = Convert.ToDouble(saldo);
                            switch (mescmx)
                            {
                                case (1):
                                    sueldoM = (sueldo / 31);
                                    sueldoD = (sueldoM * diastxt);
                                    sueldo = sueldoD + bono;
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
                                    sueldoM = (sueldo / 31);
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
                        auxi = String.Format("{0:0.00}", sueldo);
                        string result = auxi.Replace(",", ".");
                        DIA = textBox6.Text;
                        string cadenaC = "insert into Percepciones value("+
                            "\""+ID_PER+"\","+ID_EMP+"," +result+"," + diastxt+");";
                        OdbcCommand cmd3 = new OdbcCommand(cadena, cone.cnxOpen());
                        cmd.ExecuteNonQuery();

                        cone.cnxClose();

                        DataTable dt = new DataTable();
                       cadena = "SELECT  ID_Empleado, ID_Percepcion, Total, Dias FROM Percepciones" +
                           " WHERE ID_Percepcion=" + "\"" + ID_PER + "\"" + ";";

                        OdbcDataAdapter dta = new OdbcDataAdapter(cadena, cone.cnxOpen());
                        DataSet dst = new DataSet();
                        dta.Fill(dst);
                        dt = dst.Tables[0];

                        dataGridView1.DataSource = dt;
                        MessageBox.Show("EMPLEADO INSERTADO");
                        cone.cnxClose();
                        ////////////////


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

        private void Borrar_Click(object sender, EventArgs e)
        {
            ConexionCapaDatos cone = new ConexionCapaDatos();
            try {
                try
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Debe seleccionar un Empleado primero");
                    }
                    else {
                        string cadena = "DELETE FROM `Percepciones` WHERE(`ID_Percepcion` ="
                        + "\"" + ID_PER + "\"" + " and `ID_Empleado`= " + ID_EMP + ");";

                    OdbcCommand cmd = new OdbcCommand(cadena, cone.cnxOpen());
                    cmd.ExecuteNonQuery();
                    cone.cnxClose();

                    DataTable dt = new DataTable();
                    string cadenaA = "SELECT  ID_Empleado, ID_Percepcion, Total, Dias FROM Percepciones" +
                       " WHERE ID_Percepcion=" + "\"" + ID_PER + "\"" + ";";

                    OdbcDataAdapter dta = new OdbcDataAdapter(cadenaA, cone.cnxOpen());
                    DataSet dst = new DataSet();
                    dta.Fill(dst);
                    dt = dst.Tables[0];

                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Se ha borrado el usuario");
                    cone.cnxClose();
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
                        btn = 1;
                        btn1 = 1;
                    }
                    else {
                        MessageBox.Show("Debe usar primero el boton de Seleccionar");
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
            }
        }
    }
        
}

