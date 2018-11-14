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
using CapaDiseno;

namespace CapaDiseño
{
    public partial class ManAreas : Form
    {
        Navegador nv = new Navegador();
        public ManAreas()
        {
            InitializeComponent();
            nv.nombreForm(this);
            nv.ingresarTabla("areasVW");
            nv.NumeroAplicacion("3102");
            
                    
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

        private void txt_codArea_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, @"C:/ayuda/Mantenimientos.chm", "MantenimientoAreas.html#codigo");
        }
    }
}
