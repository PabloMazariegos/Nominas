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
    public partial class MDI : Form
    {

        public MDI()
        {
            InitializeComponent();
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            MdiClient mdi;
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    mdi = (MdiClient)ctl;
                    mdi.BackColor = this.BackColor;
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        private void nuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatEmpleados chld = new CatEmpleados();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void prestacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatPrestaciones chld = new CatPrestaciones();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void pagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatPagos chld = new CatPagos();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void deduccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatDeducciones chld = new CatDeducciones();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatComisiones chld = new CatComisiones();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void empleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManEmpleados chld = new ManEmpleados();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void areasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManAreas chld = new ManAreas();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void conceptosRetributivosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManConceptosR chld = new ManConceptosR();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void areasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AsigAreas chld = new AsigAreas();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void nominasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepCierre chld = new RepCierre();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void empleadosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RepEmpleados chld = new RepEmpleados();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void sueldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepSueldos chld = new RepSueldos();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void cambioDeServidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HerCambioServidor chld = new HerCambioServidor();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void cerrarAplicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form chld in this.MdiChildren)
            {
                chld.Close();
            }
        }
    }
}
