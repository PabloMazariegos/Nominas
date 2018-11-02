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
    public partial class AsigAreas : Form
    {
        public AsigAreas()
        {
            InitializeComponent();
            
        }

        private void Asignacion_de_area_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           if(e.ColumnIndex==6)
            {
                bool value =(bool) dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value == true)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value=false;
                }else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
