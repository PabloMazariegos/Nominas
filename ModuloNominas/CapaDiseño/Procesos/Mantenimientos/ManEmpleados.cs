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
using CapaDiseno;

namespace CapaDiseño
{
    public partial class ManEmpleados : Form
    {
        Navegador nv = new Navegador();
        CapaDatosNominas.ConexionCapaDatos cnx = new ConexionCapaDatos();
        public ManEmpleados()
        {
            
            InitializeComponent();
            nv.nombreForm(this);
            nv.ingresarTabla("empleadosVW");
            nv.NumeroAplicacion("3100");

            OdbcDataAdapter dta = new OdbcDataAdapter("SELECT tbl_areas.ID_Area, tbl_areas.Nombre FROM tbl_areas", cnx.cnxOpen());
            DataSet dst = new DataSet();
            dta.Fill(dst, "tbl_areas");
            cbx_area.DisplayMember = "id_area";
            cbx_area.ValueMember = "Nombre";
            cbx_area.DataSource = dst.Tables["tbl_areas"];
            cnx.cnxClose();

            dta = new OdbcDataAdapter("SELECT tbl_contratos.id_contrato, tbl_contratos.nombre FROM tbl_contratos", cnx.cnxOpen());
            dta.Fill(dst, "tbl_contratos");
            cbx_contrato.DisplayMember = "id_contrato";
            cbx_contrato.ValueMember = "Nombre";
            cbx_contrato.DataSource = dst.Tables["tbl_contratos"];
            cnx.cnxClose();

            lbl_nombreArea.Text = "";
            lbl_descriparea.Text = "";
            lbl_descrippuesto.Text = "";
            lbl_nombrepuesto.Text = "";
            lbl_contratodes.Text = "";
            lbl_jornada.Text = "";
            lbl_salario.Text = "";
            lbl_contrato.Text = "";


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_dpi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_direccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void txt_telefono2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_estadocivil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbx_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            String value = cbx_area.Text;
            lbl_nombrepuesto.Text = "";
            cbx_puesto.Text = "";
            lbl_descriparea.Text = "";
            lbl_nombreArea.Text = "";
            cnx.cnxClose();

            OdbcCommand dta = new OdbcCommand("SELECT  tbl_areas.nombre, tbl_areas.descripcion FROM tbl_areas WHERE tbl_areas.id_area=" + value, cnx.cnxOpen());
            OdbcDataReader dr = dta.ExecuteReader();
            while (dr.Read())
            {
               
                lbl_nombreArea.Text = "NOMBRE:  " + dr.GetString(0).ToLower();
                lbl_descriparea.Text = "DESCRIPCION:  " + dr.GetString(1).ToLower();

            }


            cbx_puesto.Refresh();
            cnx.cnxClose();
            OdbcDataAdapter dtaPuesto = new OdbcDataAdapter("SELECT tbl_puestos.id_puesto, tbl_puestos.nombre FROM tbl_puestos where tbl_puestos.id_area=" + value, cnx.cnxOpen());
            DataSet ds = new DataSet();
            dtaPuesto.Fill(ds, "tbl_puestos");
            cbx_puesto.DisplayMember = "id_puesto";
            cbx_puesto.ValueMember = "nombre";
            cbx_puesto.DataSource = ds.Tables["tbl_puestos"];
            cnx.cnxClose();
        }

        private void cbx_puesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            String c = cbx_puesto.Text;
            lbl_nombrepuesto.Text = "";
            lbl_descrippuesto.Text = "";
            cbx_puesto.Refresh();
            cnx.cnxClose();

            OdbcCommand dta = new OdbcCommand("SELECT  tbl_puestos.nombre, tbl_puestos.descripcion FROM tbl_puestos WHERE tbl_puestos.id_puesto=" + c, cnx.cnxOpen());
            OdbcDataReader dr = dta.ExecuteReader();
            while (dr.Read())
            {
                lbl_nombrepuesto.Text = "NOMBRE:  " + dr.GetString(0).ToLower();
                lbl_descrippuesto.Text = "DESCRIPCION:  " + dr.GetString(1).ToLower();
                
            }

        }

        private void cbx_contrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            String c = cbx_contrato.Text;
            lbl_contrato.Text = "";
            lbl_contratodes.Text = "";
            lbl_jornada.Text = "";
            lbl_salario.Text = "";
            cbx_contrato.Refresh();

            cnx.cnxClose();
            OdbcCommand dta = new OdbcCommand("SELECT  tbl_contratos.nombre, tbl_contratos.descripcion, tbl_contratos.jornada, tbl_contratos.salario FROM tbl_contratos WHERE tbl_contratos.id_contrato="+c, cnx.cnxOpen());
            OdbcDataReader dr = dta.ExecuteReader();
            while (dr.Read())
            {
                lbl_contrato.Text = "NOMBRE:  "+dr.GetString(0).ToLower() ;
                lbl_contratodes.Text = "DESCRIPCION:  "+dr.GetString(1).ToLower() ;
                lbl_jornada.Text = "JORNADA:  "+dr.GetString(2).ToLower() ;
                lbl_salario.Text = "SALARIO:  "+dr.GetString(3);
            }            
            cnx.cnxClose();
        }

        private void lbl_descrippuesto_Click(object sender, EventArgs e)
        {

        }

        private void lbl_nombrepuesto_Click(object sender, EventArgs e)
        {

        }

        private void cbx_area_EnabledChanged(object sender, EventArgs e)
        {
            if (cbx_area.Enabled == false)
            {
                lbl_nombreArea.Text = "";
                lbl_descriparea.Text = "";
            }
        }

        private void cbx_puesto_EnabledChanged(object sender, EventArgs e)
        {
            if (cbx_puesto.Enabled == false)
            {
                lbl_descrippuesto.Text = "";
                lbl_nombrepuesto.Text = "";
            }
        }

        private void cbx_contrato_EnabledChanged(object sender, EventArgs e)
        {
            if (cbx_contrato.Enabled == false)
            {
                lbl_contratodes.Text = "";
                lbl_jornada.Text = "";
                lbl_salario.Text = "";
                lbl_contrato.Text = "";
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txt_fecha.Text= dateTimePicker1.Value.ToString("yyyy/MM/dd");
        }

        private void txt_fecha_TextChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Text = txt_fecha.Text;
        }

        private void cbx_area_TextUpdate(object sender, EventArgs e)
        {
            
        }
    }
}
