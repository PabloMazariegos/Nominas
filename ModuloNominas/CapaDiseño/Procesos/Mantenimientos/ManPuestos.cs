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
using CapaDiseno;

namespace CapaDiseño
{
    public partial class ManPuestos : Form
    {
        CapaDatosNominas.ConexionCapaDatos cnx = new ConexionCapaDatos();
        Navegador nv2 = new Navegador();

        public ManPuestos()
        {
            InitializeComponent();
            nv2.nombreForm(this);
            nv2.ingresarTabla("puestosVW");
            nv2.NumeroAplicacion("3103");

            OdbcDataAdapter dta = new OdbcDataAdapter("SELECT tbl_areas.ID_Area, tbl_areas.Nombre FROM tbl_areas", cnx.cnxOpen());
            DataSet dst = new DataSet();
            dta.Fill(dst, "tbl_areas");
            cbx_areas.DisplayMember = "id_area" ;
            cbx_areas.ValueMember = "Nombre";
            cbx_areas.DataSource = dst.Tables["tbl_areas"];
            
           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void navegador1_Load(object sender, EventArgs e)
        {
            
        }

        private void cbx_areas_SelectedIndexChanged(object sender, EventArgs e)
        {
            String value = System.Convert.ToString(cbx_areas.SelectedValue);
            lbl_nombreArea.Text = value;
        }

        private void txt_codArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void txt_descripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
