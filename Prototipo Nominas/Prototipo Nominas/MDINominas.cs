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
    public partial class MDINominas : Form
    {
        private int childFormNumber = 0;


        public MDINominas()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ingresoDeEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoEmpleado chld = new IngresoEmpleado();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();   
        }

        private void ingresoPrestacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoPrestacionescs chld = new IngresoPrestacionescs();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void MDINominas_Load(object sender, EventArgs e)
        {
            MdiClient mdi;
            foreach(Control ctl in this.Controls)
            {
                try
                {
                    mdi = (MdiClient)ctl;
                    mdi.BackColor = this.BackColor;
                }catch(Exception ex)
                {
                    Console.Write(ex);
                }
            }

            Login chld = new Login();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();

            



        }

        private void cambioDeServidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambioServer chld = new CambioServer();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult salida;
            salida = MessageBox.Show("Esta seguro de salir", "Cerrar Sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (salida == DialogResult.Yes){
                cerrarAplicacionToolStripMenuItem.PerformClick();
                Login chld = new Login();
                chld.MdiParent = this;
                chld.StartPosition = FormStartPosition.CenterScreen;
                chld.Show();
            }
        }

        public void OpcionesMenu(bool op)
        {
            menuStrip.Items[0].Enabled = op;      //inicio
            menuStrip.Items[1].Enabled = op;     //catalogos
            menuStrip.Items[2].Enabled = op;     //procesos
            menuStrip.Items[3].Enabled = op;     //reportes
            menuStrip.Items[4].Enabled = op;     //herramientas
            menuStrip.Items[5].Enabled = op;     //ayuda
        }

        private void cerrarAplicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Form chld in this.MdiChildren){
                chld.Close();
            }
        }

        private void mantenimientoDeEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mantenimientoEmpleado chld = new mantenimientoEmpleado();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void mantenimientoDeConceptosRetributivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantenimientoConceptosR chld = new MantenimientoConceptosR();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void mantenimientoDeAreasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mantenimientoAreas chld = new mantenimientoAreas();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }



        private void asignacionDeConceptosRetributivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Asignacion_de_area chld = new Asignacion_de_area();
            chld.MdiParent = this;
            chld.StartPosition = FormStartPosition.CenterScreen;
            chld.Show();
        }

        private void liquidacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Liquidacion pago = new Liquidacion();
            pago.MdiParent = this;
            pago.StartPosition = FormStartPosition.CenterScreen;
            pago.Show();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cierre_de_nominas nomina = new Cierre_de_nominas();
            nomina.MdiParent = this;
            nomina.StartPosition = FormStartPosition.CenterScreen;
            nomina.Show();
        }

        private void reporteDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cierre_de_nominas empleado = new Cierre_de_nominas();
            empleado.MdiParent = this;
            empleado.StartPosition = FormStartPosition.CenterScreen;
            empleado.Show();
        }

        private void reporteDeSueldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cierre_de_nominas sueldos = new Cierre_de_nominas();
            sueldos.MdiParent = this;
            sueldos.StartPosition = FormStartPosition.CenterScreen;
            sueldos.Show();
        }
    }
}
