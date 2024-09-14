namespace escalaDelta {
    partial class FormColaborador {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerDataFolga = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerHoraEntrada = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHoraSaida = new System.Windows.Forms.DateTimePicker();
            this.dgvColaboradores = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelCargo = new System.Windows.Forms.Button();
            this.btnDeleteCargo = new System.Windows.Forms.Button();
            this.btnUpdateCargo = new System.Windows.Forms.Button();
            this.btnNewCargo = new System.Windows.Forms.Button();
            this.txtEditCargo = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNewInsertUpdate = new System.Windows.Forms.Button();
            this.btnEditCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaboradores)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 23);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hora Entrada:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hora Saída:";
            // 
            // dateTimePickerDataFolga
            // 
            this.dateTimePickerDataFolga.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDataFolga.Location = new System.Drawing.Point(234, 125);
            this.dateTimePickerDataFolga.Name = "dateTimePickerDataFolga";
            this.dateTimePickerDataFolga.Size = new System.Drawing.Size(85, 23);
            this.dateTimePickerDataFolga.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Data que Folgou 1x (sem dobradinha):";
            // 
            // dateTimePickerHoraEntrada
            // 
            this.dateTimePickerHoraEntrada.CustomFormat = "HH:mm";
            this.dateTimePickerHoraEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHoraEntrada.Location = new System.Drawing.Point(93, 46);
            this.dateTimePickerHoraEntrada.Name = "dateTimePickerHoraEntrada";
            this.dateTimePickerHoraEntrada.Size = new System.Drawing.Size(121, 23);
            this.dateTimePickerHoraEntrada.TabIndex = 9;
            // 
            // dateTimePickerHoraSaida
            // 
            this.dateTimePickerHoraSaida.CustomFormat = "HH:mm";
            this.dateTimePickerHoraSaida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHoraSaida.Location = new System.Drawing.Point(93, 78);
            this.dateTimePickerHoraSaida.Name = "dateTimePickerHoraSaida";
            this.dateTimePickerHoraSaida.Size = new System.Drawing.Size(121, 23);
            this.dateTimePickerHoraSaida.TabIndex = 10;
            // 
            // dgvColaboradores
            // 
            this.dgvColaboradores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColaboradores.Location = new System.Drawing.Point(12, 3);
            this.dgvColaboradores.Name = "dgvColaboradores";
            this.dgvColaboradores.RowTemplate.Height = 25;
            this.dgvColaboradores.Size = new System.Drawing.Size(430, 245);
            this.dgvColaboradores.TabIndex = 12;
            this.dgvColaboradores.SelectionChanged += new System.EventHandler(this.dgvColaboradores_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePickerHoraSaida);
            this.panel1.Controls.Add(this.dateTimePickerHoraEntrada);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePickerDataFolga);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 254);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 159);
            this.panel1.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelCargo);
            this.groupBox1.Controls.Add(this.btnDeleteCargo);
            this.groupBox1.Controls.Add(this.btnUpdateCargo);
            this.groupBox1.Controls.Add(this.btnNewCargo);
            this.groupBox1.Controls.Add(this.txtEditCargo);
            this.groupBox1.Location = new System.Drawing.Point(248, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 80);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edição Cargo";
            this.groupBox1.Visible = false;
            // 
            // btnCancelCargo
            // 
            this.btnCancelCargo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelCargo.Location = new System.Drawing.Point(123, 47);
            this.btnCancelCargo.Name = "btnCancelCargo";
            this.btnCancelCargo.Size = new System.Drawing.Size(50, 23);
            this.btnCancelCargo.TabIndex = 23;
            this.btnCancelCargo.Text = "cancel";
            this.btnCancelCargo.UseVisualStyleBackColor = true;
            this.btnCancelCargo.Click += new System.EventHandler(this.btnCancelCargo_Click);
            // 
            // btnDeleteCargo
            // 
            this.btnDeleteCargo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteCargo.Location = new System.Drawing.Point(69, 47);
            this.btnDeleteCargo.Name = "btnDeleteCargo";
            this.btnDeleteCargo.Size = new System.Drawing.Size(50, 23);
            this.btnDeleteCargo.TabIndex = 22;
            this.btnDeleteCargo.Text = "delete";
            this.btnDeleteCargo.UseVisualStyleBackColor = true;
            this.btnDeleteCargo.Click += new System.EventHandler(this.btnDeleteCargo_Click);
            // 
            // btnUpdateCargo
            // 
            this.btnUpdateCargo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateCargo.Location = new System.Drawing.Point(6, 47);
            this.btnUpdateCargo.Name = "btnUpdateCargo";
            this.btnUpdateCargo.Size = new System.Drawing.Size(61, 23);
            this.btnUpdateCargo.TabIndex = 21;
            this.btnUpdateCargo.Text = "update";
            this.btnUpdateCargo.UseVisualStyleBackColor = true;
            this.btnUpdateCargo.Click += new System.EventHandler(this.btnUpdateCargo_Click);
            // 
            // btnNewCargo
            // 
            this.btnNewCargo.Location = new System.Drawing.Point(123, 18);
            this.btnNewCargo.Name = "btnNewCargo";
            this.btnNewCargo.Size = new System.Drawing.Size(50, 23);
            this.btnNewCargo.TabIndex = 20;
            this.btnNewCargo.Text = "new";
            this.btnNewCargo.UseVisualStyleBackColor = true;
            this.btnNewCargo.Click += new System.EventHandler(this.btnNewCargo_Click);
            // 
            // txtEditCargo
            // 
            this.txtEditCargo.Location = new System.Drawing.Point(6, 18);
            this.txtEditCargo.Name = "txtEditCargo";
            this.txtEditCargo.Size = new System.Drawing.Size(113, 23);
            this.txtEditCargo.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::escalaDelta.Properties.Resources.icons8_edit_16;
            this.pictureBox1.Location = new System.Drawing.Point(396, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(293, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(97, 23);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cargo";
            // 
            // btnNewInsertUpdate
            // 
            this.btnNewInsertUpdate.Location = new System.Drawing.Point(3, 3);
            this.btnNewInsertUpdate.Name = "btnNewInsertUpdate";
            this.btnNewInsertUpdate.Size = new System.Drawing.Size(98, 23);
            this.btnNewInsertUpdate.TabIndex = 14;
            this.btnNewInsertUpdate.Text = "New/Insert/Update";
            this.btnNewInsertUpdate.UseVisualStyleBackColor = true;
            this.btnNewInsertUpdate.Click += new System.EventHandler(this.btnNewInsertUpdate_Click);
            // 
            // btnEditCancel
            // 
            this.btnEditCancel.Location = new System.Drawing.Point(107, 3);
            this.btnEditCancel.Name = "btnEditCancel";
            this.btnEditCancel.Size = new System.Drawing.Size(98, 23);
            this.btnEditCancel.TabIndex = 15;
            this.btnEditCancel.Text = "Edit/Cancel";
            this.btnEditCancel.UseVisualStyleBackColor = true;
            this.btnEditCancel.Click += new System.EventHandler(this.btnEditCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(211, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNewInsertUpdate);
            this.flowLayoutPanel1.Controls.Add(this.btnEditCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 419);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(430, 32);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // FormColaborador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 463);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvColaboradores);
            this.Name = "FormColaborador";
            this.Text = "Colaborador";
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaboradores)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dateTimePickerDataFolga;
        private Label label4;
        private DateTimePicker dateTimePickerHoraEntrada;
        private DateTimePicker dateTimePickerHoraSaida;
        private DataGridView dgvColaboradores;
        private Panel panel1;
        private Button btnNewInsertUpdate;
        private Button btnEditCancel;
        private Button btnDelete;
        private FlowLayoutPanel flowLayoutPanel1;
        private ComboBox comboBox1;
        private Label label5;
        private GroupBox groupBox1;
        private Button btnCancelCargo;
        private Button btnDeleteCargo;
        private Button btnUpdateCargo;
        private Button btnNewCargo;
        private TextBox txtEditCargo;
        private PictureBox pictureBox1;
    }
}