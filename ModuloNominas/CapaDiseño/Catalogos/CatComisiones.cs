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
    public partial class CatComisiones : Form
    {
        public CatComisiones()
        {
            InitializeComponent();
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            /*Carga datos al inicializar el subModulo Comisiones*/
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Matches para validar el dato ingresado en ID */
            /*Filtra los datos segun los campos sean llenados*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
