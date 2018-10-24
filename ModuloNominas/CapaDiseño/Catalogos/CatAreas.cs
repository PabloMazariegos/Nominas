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


namespace CapaDiseño
{
    public partial class CatAreas : Form
    {
        public CatAreas()
        {
            InitializeComponent();
        }

        private void CatAreas_Load(object sender, EventArgs e)
        {
            ConexionCapaDatos CapaDatos = new ConexionCapaDatos();
            OdbcCommand cmd = new OdbcCommand("Select * from areas_view", CapaDatos.cnxOpen());
            OdbcDataAdapter adp = new OdbcDataAdapter(cmd);
            try
            {
                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                dt_catAreas.DataSource = tbl;
                dt_catAreas.Refresh();
                dt_catAreas.Update();

            }catch(OdbcException ex)
            {
                MessageBox.Show("Error, tabla inexistente" + ex);
            }

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
