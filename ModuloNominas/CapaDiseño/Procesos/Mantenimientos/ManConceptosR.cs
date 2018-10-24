using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaDiseno;
using CapaLogica;

namespace CapaDiseño
{
    public partial class ManConceptosR : Form
    {
        public ManConceptosR()
        {
            InitializeComponent();
            navegador1.ingresarTabla("conceptosR_view");
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
