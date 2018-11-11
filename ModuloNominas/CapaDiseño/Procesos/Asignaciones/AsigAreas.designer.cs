namespace CapaDiseño
{
    partial class AsigAreas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_excepcion = new System.Windows.Forms.CheckBox();
            this.chk_todos = new System.Windows.Forms.CheckBox();
            this.chk_area = new System.Windows.Forms.CheckBox();
            this.chk_individual = new System.Windows.Forms.CheckBox();
            this.groupArea = new System.Windows.Forms.GroupBox();
            this.lbl_decripArea = new System.Windows.Forms.Label();
            this.lbl_nomArea = new System.Windows.Forms.Label();
            this.lbl_codArea = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxArea = new System.Windows.Forms.ComboBox();
            this.groupEmpleado = new System.Windows.Forms.GroupBox();
            this.dtEmpleados = new System.Windows.Forms.DataGridView();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupArea.SuspendLayout();
            this.groupEmpleado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(135)))), ((int)(((byte)(96)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(917, 42);
            this.panel2.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(272, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "3200- AsignacionConceptos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_excepcion);
            this.groupBox1.Controls.Add(this.chk_todos);
            this.groupBox1.Controls.Add(this.chk_area);
            this.groupBox1.Controls.Add(this.chk_individual);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 136);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TIPO DE ASIGNACION";
            // 
            // chk_excepcion
            // 
            this.chk_excepcion.AutoSize = true;
            this.chk_excepcion.Location = new System.Drawing.Point(28, 107);
            this.chk_excepcion.Name = "chk_excepcion";
            this.chk_excepcion.Size = new System.Drawing.Size(104, 19);
            this.chk_excepcion.TabIndex = 31;
            this.chk_excepcion.Text = "Por excepcion";
            this.chk_excepcion.UseVisualStyleBackColor = true;
            this.chk_excepcion.CheckStateChanged += new System.EventHandler(this.chk_excepcion_CheckStateChanged);
            // 
            // chk_todos
            // 
            this.chk_todos.AutoSize = true;
            this.chk_todos.Location = new System.Drawing.Point(28, 82);
            this.chk_todos.Name = "chk_todos";
            this.chk_todos.Size = new System.Drawing.Size(144, 19);
            this.chk_todos.TabIndex = 30;
            this.chk_todos.Text = "Todos los empleados";
            this.chk_todos.UseVisualStyleBackColor = true;
            this.chk_todos.CheckedChanged += new System.EventHandler(this.chk_todos_CheckedChanged);
            // 
            // chk_area
            // 
            this.chk_area.AutoSize = true;
            this.chk_area.Location = new System.Drawing.Point(28, 57);
            this.chk_area.Name = "chk_area";
            this.chk_area.Size = new System.Drawing.Size(73, 19);
            this.chk_area.TabIndex = 1;
            this.chk_area.Text = "Por Area";
            this.chk_area.UseVisualStyleBackColor = true;
            this.chk_area.CheckStateChanged += new System.EventHandler(this.chk_area_CheckStateChanged);
            // 
            // chk_individual
            // 
            this.chk_individual.AutoSize = true;
            this.chk_individual.Location = new System.Drawing.Point(28, 32);
            this.chk_individual.Name = "chk_individual";
            this.chk_individual.Size = new System.Drawing.Size(78, 19);
            this.chk_individual.TabIndex = 0;
            this.chk_individual.Text = "Individual";
            this.chk_individual.UseVisualStyleBackColor = true;
            this.chk_individual.CheckStateChanged += new System.EventHandler(this.chk_individual_CheckStateChanged);
            // 
            // groupArea
            // 
            this.groupArea.Controls.Add(this.lbl_decripArea);
            this.groupArea.Controls.Add(this.lbl_nomArea);
            this.groupArea.Controls.Add(this.lbl_codArea);
            this.groupArea.Controls.Add(this.label2);
            this.groupArea.Controls.Add(this.cbxArea);
            this.groupArea.Enabled = false;
            this.groupArea.Location = new System.Drawing.Point(255, 67);
            this.groupArea.Name = "groupArea";
            this.groupArea.Size = new System.Drawing.Size(641, 136);
            this.groupArea.TabIndex = 30;
            this.groupArea.TabStop = false;
            this.groupArea.Text = "ASIGNACION POR AREA";
            // 
            // lbl_decripArea
            // 
            this.lbl_decripArea.AutoSize = true;
            this.lbl_decripArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_decripArea.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_decripArea.Location = new System.Drawing.Point(281, 85);
            this.lbl_decripArea.Name = "lbl_decripArea";
            this.lbl_decripArea.Size = new System.Drawing.Size(139, 16);
            this.lbl_decripArea.TabIndex = 4;
            this.lbl_decripArea.Text = "DESCRIPCION AREA";
            // 
            // lbl_nomArea
            // 
            this.lbl_nomArea.AutoSize = true;
            this.lbl_nomArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nomArea.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_nomArea.Location = new System.Drawing.Point(281, 51);
            this.lbl_nomArea.Name = "lbl_nomArea";
            this.lbl_nomArea.Size = new System.Drawing.Size(107, 16);
            this.lbl_nomArea.TabIndex = 3;
            this.lbl_nomArea.Text = "NOMBRE AREA";
            // 
            // lbl_codArea
            // 
            this.lbl_codArea.AutoSize = true;
            this.lbl_codArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_codArea.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_codArea.Location = new System.Drawing.Point(281, 16);
            this.lbl_codArea.Name = "lbl_codArea";
            this.lbl_codArea.Size = new System.Drawing.Size(100, 16);
            this.lbl_codArea.TabIndex = 2;
            this.lbl_codArea.Text = "CODIGO AREA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Area:";
            // 
            // cbxArea
            // 
            this.cbxArea.FormattingEnabled = true;
            this.cbxArea.Location = new System.Drawing.Point(67, 46);
            this.cbxArea.Name = "cbxArea";
            this.cbxArea.Size = new System.Drawing.Size(167, 21);
            this.cbxArea.TabIndex = 0;
            this.cbxArea.SelectedIndexChanged += new System.EventHandler(this.cbxArea_SelectedIndexChanged);
            // 
            // groupEmpleado
            // 
            this.groupEmpleado.Controls.Add(this.dtEmpleados);
            this.groupEmpleado.Controls.Add(this.checkBox6);
            this.groupEmpleado.Controls.Add(this.checkBox5);
            this.groupEmpleado.Controls.Add(this.checkBox4);
            this.groupEmpleado.Controls.Add(this.textBox1);
            this.groupEmpleado.Enabled = false;
            this.groupEmpleado.Location = new System.Drawing.Point(26, 224);
            this.groupEmpleado.Name = "groupEmpleado";
            this.groupEmpleado.Size = new System.Drawing.Size(870, 294);
            this.groupEmpleado.TabIndex = 31;
            this.groupEmpleado.TabStop = false;
            this.groupEmpleado.Text = "ASIGNACION POR EMPLEADO";
            // 
            // dtEmpleados
            // 
            this.dtEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtEmpleados.Location = new System.Drawing.Point(0, 94);
            this.dtEmpleados.Name = "dtEmpleados";
            this.dtEmpleados.Size = new System.Drawing.Size(870, 194);
            this.dtEmpleados.TabIndex = 7;
            this.dtEmpleados.Visible = false;
            this.dtEmpleados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtEmpleados_CellDoubleClick);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(311, 60);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(115, 17);
            this.checkBox6.TabIndex = 6;
            this.checkBox6.Text = "Buscar por nombre";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(172, 60);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(94, 17);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Text = "Buscar por dpi";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(28, 60);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(101, 17);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Text = "Buscar por area";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(398, 20);
            this.textBox1.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Image = global::CapaDiseño.Properties.Resources.aceptar;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(351, 539);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 58);
            this.button4.TabIndex = 33;
            this.button4.Text = "Confirmar";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Image = global::CapaDiseño.Properties.Resources.Cancelar;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(473, 539);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 58);
            this.button1.TabIndex = 32;
            this.button1.Text = "Cancelar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(135)))), ((int)(((byte)(96)))));
            this.button2.Image = global::CapaDiseño.Properties.Resources.Cancelar2;
            this.button2.Location = new System.Drawing.Point(875, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 36);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Cursor = System.Windows.Forms.Cursors.Default;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(135)))), ((int)(((byte)(96)))));
            this.button3.Image = global::CapaDiseño.Properties.Resources.minimize;
            this.button3.Location = new System.Drawing.Point(839, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 36);
            this.button3.TabIndex = 0;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AsigAreas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 661);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupEmpleado);
            this.Controls.Add(this.groupArea);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AsigAreas";
            this.Text = "Asignacion_de_area";
            this.Load += new System.EventHandler(this.Asignacion_de_area_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupArea.ResumeLayout(false);
            this.groupArea.PerformLayout();
            this.groupEmpleado.ResumeLayout(false);
            this.groupEmpleado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chk_todos;
        private System.Windows.Forms.CheckBox chk_area;
        private System.Windows.Forms.CheckBox chk_individual;
        private System.Windows.Forms.CheckBox chk_excepcion;
        private System.Windows.Forms.GroupBox groupArea;
        private System.Windows.Forms.Label lbl_decripArea;
        private System.Windows.Forms.Label lbl_nomArea;
        private System.Windows.Forms.Label lbl_codArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxArea;
        private System.Windows.Forms.GroupBox groupEmpleado;
        private System.Windows.Forms.DataGridView dtEmpleados;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
    }
}