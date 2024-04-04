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
            this.btnCancel = new System.Windows.Forms.Button();
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
            this.btnNewAndSave = new System.Windows.Forms.Button();
            this.btnEditAndDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaboradores)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(220, 410);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 23);
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
            this.dateTimePickerDataFolga.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerDataFolga.Location = new System.Drawing.Point(95, 110);
            this.dateTimePickerDataFolga.Name = "dateTimePickerDataFolga";
            this.dateTimePickerDataFolga.Size = new System.Drawing.Size(175, 23);
            this.dateTimePickerDataFolga.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Data Folga:";
            // 
            // dateTimePickerHoraEntrada
            // 
            this.dateTimePickerHoraEntrada.CustomFormat = "HH:mm";
            this.dateTimePickerHoraEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHoraEntrada.Location = new System.Drawing.Point(93, 46);
            this.dateTimePickerHoraEntrada.Name = "dateTimePickerHoraEntrada";
            this.dateTimePickerHoraEntrada.Size = new System.Drawing.Size(177, 23);
            this.dateTimePickerHoraEntrada.TabIndex = 9;
            // 
            // dateTimePickerHoraSaida
            // 
            this.dateTimePickerHoraSaida.CustomFormat = "HH:mm";
            this.dateTimePickerHoraSaida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerHoraSaida.Location = new System.Drawing.Point(93, 78);
            this.dateTimePickerHoraSaida.Name = "dateTimePickerHoraSaida";
            this.dateTimePickerHoraSaida.Size = new System.Drawing.Size(177, 23);
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
            this.panel1.Size = new System.Drawing.Size(430, 150);
            this.panel1.TabIndex = 13;
            // 
            // btnNewAndSave
            // 
            this.btnNewAndSave.Location = new System.Drawing.Point(12, 410);
            this.btnNewAndSave.Name = "btnNewAndSave";
            this.btnNewAndSave.Size = new System.Drawing.Size(98, 23);
            this.btnNewAndSave.TabIndex = 14;
            this.btnNewAndSave.Text = "New/Add/Save";
            this.btnNewAndSave.UseVisualStyleBackColor = true;
            this.btnNewAndSave.Click += new System.EventHandler(this.btnNewAndEdit_Click);
            // 
            // btnEditAndDelete
            // 
            this.btnEditAndDelete.Location = new System.Drawing.Point(116, 410);
            this.btnEditAndDelete.Name = "btnEditAndDelete";
            this.btnEditAndDelete.Size = new System.Drawing.Size(98, 23);
            this.btnEditAndDelete.TabIndex = 15;
            this.btnEditAndDelete.Text = "Edit/Delete";
            this.btnEditAndDelete.UseVisualStyleBackColor = true;
            this.btnEditAndDelete.Click += new System.EventHandler(this.btnEditAndDelete_Click);
            // 
            // FormColaborador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 443);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEditAndDelete);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNewAndSave);
            this.Controls.Add(this.dgvColaboradores);
            this.Name = "FormColaborador";
            this.Text = "Colaborador";
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaboradores)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnCancel;
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
        private Button btnNewAndSave;
        private Button btnEditAndDelete;
    }
}