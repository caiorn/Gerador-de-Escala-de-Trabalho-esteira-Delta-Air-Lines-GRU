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
            this.btnCadastrarSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerDataFolga = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerHoraEntrada = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHoraSaida = new System.Windows.Forms.DateTimePicker();
            this.dgvEscala = new System.Windows.Forms.DataGridView();
            this.dgvColaboradores = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEscala)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaboradores)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCadastrarSalvar
            // 
            this.btnCadastrarSalvar.Location = new System.Drawing.Point(10, 142);
            this.btnCadastrarSalvar.Name = "btnCadastrarSalvar";
            this.btnCadastrarSalvar.Size = new System.Drawing.Size(160, 23);
            this.btnCadastrarSalvar.TabIndex = 0;
            this.btnCadastrarSalvar.Text = "Cadastrar/Salvar";
            this.btnCadastrarSalvar.UseVisualStyleBackColor = true;
            this.btnCadastrarSalvar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(176, 142);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 23);
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
            this.dateTimePickerDataFolga.Location = new System.Drawing.Point(95, 110);
            this.dateTimePickerDataFolga.Name = "dateTimePickerDataFolga";
            this.dateTimePickerDataFolga.Size = new System.Drawing.Size(156, 23);
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
            this.dateTimePickerHoraEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerHoraEntrada.Location = new System.Drawing.Point(93, 46);
            this.dateTimePickerHoraEntrada.Name = "dateTimePickerHoraEntrada";
            this.dateTimePickerHoraEntrada.Size = new System.Drawing.Size(158, 23);
            this.dateTimePickerHoraEntrada.TabIndex = 9;
            // 
            // dateTimePickerHoraSaida
            // 
            this.dateTimePickerHoraSaida.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerHoraSaida.Location = new System.Drawing.Point(93, 78);
            this.dateTimePickerHoraSaida.Name = "dateTimePickerHoraSaida";
            this.dateTimePickerHoraSaida.Size = new System.Drawing.Size(158, 23);
            this.dateTimePickerHoraSaida.TabIndex = 10;
            // 
            // dgvEscala
            // 
            this.dgvEscala.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEscala.Location = new System.Drawing.Point(12, 377);
            this.dgvEscala.Name = "dgvEscala";
            this.dgvEscala.RowTemplate.Height = 25;
            this.dgvEscala.Size = new System.Drawing.Size(663, 195);
            this.dgvEscala.TabIndex = 11;
            // 
            // dgvColaboradores
            // 
            this.dgvColaboradores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColaboradores.Location = new System.Drawing.Point(12, 3);
            this.dgvColaboradores.Name = "dgvColaboradores";
            this.dgvColaboradores.RowTemplate.Height = 25;
            this.dgvColaboradores.Size = new System.Drawing.Size(663, 140);
            this.dgvColaboradores.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCadastrarSalvar);
            this.panel1.Controls.Add(this.dateTimePickerHoraSaida);
            this.panel1.Controls.Add(this.btnExcluir);
            this.panel1.Controls.Add(this.dateTimePickerHoraEntrada);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePickerDataFolga);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 180);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 171);
            this.panel1.TabIndex = 13;
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(12, 151);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 14;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(93, 151);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 15;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // FormColaborador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 584);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvColaboradores);
            this.Controls.Add(this.dgvEscala);
            this.Name = "FormColaborador";
            this.Text = "Colaborador";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEscala)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaboradores)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnCadastrarSalvar;
        private Button btnExcluir;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dateTimePickerDataFolga;
        private Label label4;
        private DateTimePicker dateTimePickerHoraEntrada;
        private DateTimePicker dateTimePickerHoraSaida;
        private DataGridView dgvEscala;
        private DataGridView dgvColaboradores;
        private Panel panel1;
        private Button btnNovo;
        private Button btnEditar;
    }
}