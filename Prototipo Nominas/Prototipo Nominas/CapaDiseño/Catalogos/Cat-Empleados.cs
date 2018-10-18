using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo_Nominas
{
    public partial class EmpleadoIngreso : Form
    {
        public EmpleadoIngreso()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IngresoPago chld = new IngresoPago();
            chld.Show();
        }
    }
}
