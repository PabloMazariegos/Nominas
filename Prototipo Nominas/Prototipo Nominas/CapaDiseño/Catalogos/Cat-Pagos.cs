﻿using System;
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
    public partial class IngresoPago : Form
    {
        public IngresoPago()
        {
            InitializeComponent();
        }

        private void IngresoPago_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selecciona = 0;
            selecciona = comboBox1.SelectedIndex;
            if (selecciona==0 || selecciona==1)
            {
                txt_cuen.ReadOnly = true;
            }else
            {
                txt_cuen.ReadOnly = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
