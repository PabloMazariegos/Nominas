using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDiseño.Procesos;
using CapaDiseño.Procesos.Liquidacion;
using InicioSesion;

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
            timer1.Start();
            lbl_fecha.Text = DateTime.Now.ToLongDateString();
            lbl_hora.Text = DateTime.Now.ToLongTimeString();

            InicioSesionForm login = new InicioSesionForm();
            login.BringToFront();
            login.ShowDialog();
            Usuario user = new Usuario();
            lbl_user.Text = user.obtenerUsuario();

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

        private void puestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManPuestos chld = new ManPuestos();
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
            
        }

        private void puestosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
             
        }

        private void conceptosRetributivosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AsigAreas chld = new AsigAreas();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void liquidacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
                
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

        private void areasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatAreas chld = new CatAreas();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_hora.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void polizasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Polizas.Polizas chld = new Polizas.Polizas();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void contratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManContratos chld = new ManContratos();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicioSesionForm login = new InicioSesionForm();
            login.BringToFront();
            login.ShowDialog();
            Usuario user = new Usuario();
            lbl_user.Text = user.obtenerUsuario();
        }


        private void maestroPercepcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 chld = new Form2();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void cambioPercepcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 chld = new Form1();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();

        }

    }
}
