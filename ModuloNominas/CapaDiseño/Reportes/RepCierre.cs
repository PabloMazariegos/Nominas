using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDiseño

{
    public partial class RepCierre : Form
    {

        //VARIABLES FECHA
        string fecha_inicio, fecha_final;
        public RepCierre()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            fecha_final = dateTimePicker1.Value.Date.ToShortDateString();
        }

        private void panel2_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, "C:/ayuda_cierre de nominas.chm");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fecha_inicio = dateTimePicker1.Value.Date.ToShortDateString();
        }
    }
}
