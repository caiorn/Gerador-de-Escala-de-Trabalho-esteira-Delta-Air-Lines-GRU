namespace escalaDelta {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblInfoCheckbox = new System.Windows.Forms.Label();
            this.btnSalvarEscala = new System.Windows.Forms.Button();
            this.lblFilaAtl = new System.Windows.Forms.Label();
            this.lblFilaPier = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrarFuncionarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBoxFILAATL = new System.Windows.Forms.RichTextBox();
            this.richTextBoxFILAPIER = new System.Windows.Forms.RichTextBox();
            this.rtxtFuturaFilaPIER = new System.Windows.Forms.RichTextBox();
            this.rtxtFuturaFilaATL = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rtxtProximaEscala = new System.Windows.Forms.RichTextBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxFolga = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxOutros = new System.Windows.Forms.ListBox();
            this.listBoxTrabalha = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnShowInCalendar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfoCheckbox
            // 
            this.lblInfoCheckbox.AutoSize = true;
            this.lblInfoCheckbox.Location = new System.Drawing.Point(224, 77);
            this.lblInfoCheckbox.Name = "lblInfoCheckbox";
            this.lblInfoCheckbox.Size = new System.Drawing.Size(90, 30);
            this.lblInfoCheckbox.TabIndex = 2;
            this.lblInfoCheckbox.Text = "Quem Trabalha \r\nHoje?";
            // 
            // btnSalvarEscala
            // 
            this.btnSalvarEscala.Location = new System.Drawing.Point(416, 273);
            this.btnSalvarEscala.Name = "btnSalvarEscala";
            this.btnSalvarEscala.Size = new System.Drawing.Size(110, 23);
            this.btnSalvarEscala.TabIndex = 3;
            this.btnSalvarEscala.Text = "OK (Salvar)";
            this.btnSalvarEscala.UseVisualStyleBackColor = true;
            this.btnSalvarEscala.Click += new System.EventHandler(this.btnSalvarEscala_Click);
            // 
            // lblFilaAtl
            // 
            this.lblFilaAtl.AutoSize = true;
            this.lblFilaAtl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblFilaAtl.Location = new System.Drawing.Point(29, 23);
            this.lblFilaAtl.Name = "lblFilaAtl";
            this.lblFilaAtl.Size = new System.Drawing.Size(29, 17);
            this.lblFilaAtl.TabIndex = 4;
            this.lblFilaAtl.Text = "ATL";
            // 
            // lblFilaPier
            // 
            this.lblFilaPier.AutoSize = true;
            this.lblFilaPier.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblFilaPier.Location = new System.Drawing.Point(122, 23);
            this.lblFilaPier.Name = "lblFilaPier";
            this.lblFilaPier.Size = new System.Drawing.Size(35, 17);
            this.lblFilaPier.TabIndex = 5;
            this.lblFilaPier.Text = "PIER";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Proxima Escala";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 299);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Escalas anteriores:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 317);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(712, 251);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.Location = new System.Drawing.Point(20, 574);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 19;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarFuncionarioToolStripMenuItem,
            this.calendarioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(839, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrarFuncionarioToolStripMenuItem
            // 
            this.cadastrarFuncionarioToolStripMenuItem.Name = "cadastrarFuncionarioToolStripMenuItem";
            this.cadastrarFuncionarioToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.cadastrarFuncionarioToolStripMenuItem.Text = "Funcionario";
            this.cadastrarFuncionarioToolStripMenuItem.Click += new System.EventHandler(this.cadastrarFuncionarioToolStripMenuItem_Click);
            // 
            // calendarioToolStripMenuItem
            // 
            this.calendarioToolStripMenuItem.Name = "calendarioToolStripMenuItem";
            this.calendarioToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.calendarioToolStripMenuItem.Text = "Calendario";
            this.calendarioToolStripMenuItem.Click += new System.EventHandler(this.calendarioToolStripMenuItem_Click);
            // 
            // richTextBoxFILAATL
            // 
            this.richTextBoxFILAATL.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxFILAATL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxFILAATL.Location = new System.Drawing.Point(9, 44);
            this.richTextBoxFILAATL.Name = "richTextBoxFILAATL";
            this.richTextBoxFILAATL.ReadOnly = true;
            this.richTextBoxFILAATL.Size = new System.Drawing.Size(80, 162);
            this.richTextBoxFILAATL.TabIndex = 21;
            this.richTextBoxFILAATL.Text = "Nome1\nNome2\n";
            // 
            // richTextBoxFILAPIER
            // 
            this.richTextBoxFILAPIER.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxFILAPIER.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxFILAPIER.Location = new System.Drawing.Point(104, 44);
            this.richTextBoxFILAPIER.Name = "richTextBoxFILAPIER";
            this.richTextBoxFILAPIER.ReadOnly = true;
            this.richTextBoxFILAPIER.Size = new System.Drawing.Size(80, 162);
            this.richTextBoxFILAPIER.TabIndex = 22;
            this.richTextBoxFILAPIER.Text = "Nome1\nNome2\n";
            // 
            // rtxtFuturaFilaPIER
            // 
            this.rtxtFuturaFilaPIER.BackColor = System.Drawing.SystemColors.Control;
            this.rtxtFuturaFilaPIER.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtFuturaFilaPIER.ForeColor = System.Drawing.Color.DarkGreen;
            this.rtxtFuturaFilaPIER.Location = new System.Drawing.Point(107, 44);
            this.rtxtFuturaFilaPIER.Name = "rtxtFuturaFilaPIER";
            this.rtxtFuturaFilaPIER.ReadOnly = true;
            this.rtxtFuturaFilaPIER.Size = new System.Drawing.Size(80, 162);
            this.rtxtFuturaFilaPIER.TabIndex = 26;
            this.rtxtFuturaFilaPIER.Text = "Nome1\nNome2\n";
            // 
            // rtxtFuturaFilaATL
            // 
            this.rtxtFuturaFilaATL.BackColor = System.Drawing.SystemColors.Control;
            this.rtxtFuturaFilaATL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtFuturaFilaATL.ForeColor = System.Drawing.Color.DarkGreen;
            this.rtxtFuturaFilaATL.Location = new System.Drawing.Point(11, 44);
            this.rtxtFuturaFilaATL.Name = "rtxtFuturaFilaATL";
            this.rtxtFuturaFilaATL.ReadOnly = true;
            this.rtxtFuturaFilaATL.Size = new System.Drawing.Size(80, 162);
            this.rtxtFuturaFilaATL.TabIndex = 25;
            this.rtxtFuturaFilaATL.Text = "Nome1\nNome2\n";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Location = new System.Drawing.Point(123, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "PIER";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(33, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "ATL";
            // 
            // rtxtProximaEscala
            // 
            this.rtxtProximaEscala.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtxtProximaEscala.Location = new System.Drawing.Point(416, 95);
            this.rtxtProximaEscala.Name = "rtxtProximaEscala";
            this.rtxtProximaEscala.Size = new System.Drawing.Size(110, 172);
            this.rtxtProximaEscala.TabIndex = 27;
            this.rtxtProximaEscala.Text = "";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcluir.Location = new System.Drawing.Point(101, 574);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(76, 23);
            this.btnExcluir.TabIndex = 28;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBoxFILAPIER);
            this.groupBox1.Controls.Add(this.lblFilaAtl);
            this.groupBox1.Controls.Add(this.lblFilaPier);
            this.groupBox1.Controls.Add(this.richTextBoxFILAATL);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(20, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 225);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filas ATUAL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtxtFuturaFilaATL);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.rtxtFuturaFilaPIER);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(627, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 222);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Prox. Fila FUTURA";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(121)))));
            this.label2.Location = new System.Drawing.Point(394, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 31);
            this.label2.TabIndex = 31;
            this.label2.Text = "ESCALA AUXILIARES DE ESTEIRA";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(179, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(664, 582);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(687, 582);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "Futuro";
            // 
            // listBoxFolga
            // 
            this.listBoxFolga.AllowDrop = true;
            this.listBoxFolga.FormattingEnabled = true;
            this.listBoxFolga.ItemHeight = 15;
            this.listBoxFolga.Location = new System.Drawing.Point(320, 95);
            this.listBoxFolga.Name = "listBoxFolga";
            this.listBoxFolga.Size = new System.Drawing.Size(90, 79);
            this.listBoxFolga.TabIndex = 35;
            this.listBoxFolga.SelectedIndexChanged += new System.EventHandler(this.listBoxFolga_SelectedIndexChanged);
            this.listBoxFolga.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBox_DragDrop);
            this.listBoxFolga.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBox_DragEnter);
            this.listBoxFolga.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 36;
            this.label5.Text = "Folga:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 30);
            this.label6.TabIndex = 37;
            this.label6.Text = "Outros(ferias,\r\natestado,falta)";
            // 
            // listBoxOutros
            // 
            this.listBoxOutros.AllowDrop = true;
            this.listBoxOutros.FormattingEnabled = true;
            this.listBoxOutros.ItemHeight = 15;
            this.listBoxOutros.Location = new System.Drawing.Point(320, 217);
            this.listBoxOutros.Name = "listBoxOutros";
            this.listBoxOutros.Size = new System.Drawing.Size(90, 79);
            this.listBoxOutros.TabIndex = 38;
            this.listBoxOutros.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBox_DragDrop);
            this.listBoxOutros.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBox_DragEnter);
            this.listBoxOutros.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
            // 
            // listBoxTrabalha
            // 
            this.listBoxTrabalha.AllowDrop = true;
            this.listBoxTrabalha.FormattingEnabled = true;
            this.listBoxTrabalha.ItemHeight = 15;
            this.listBoxTrabalha.Location = new System.Drawing.Point(224, 112);
            this.listBoxTrabalha.Name = "listBoxTrabalha";
            this.listBoxTrabalha.Size = new System.Drawing.Size(90, 184);
            this.listBoxTrabalha.TabIndex = 39;
            this.listBoxTrabalha.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBox_DragDrop);
            this.listBoxTrabalha.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBox_DragEnter);
            this.listBoxTrabalha.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(532, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Gerar Até";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(532, 124);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(86, 23);
            this.dateTimePicker1.TabIndex = 41;
            // 
            // btnShowInCalendar
            // 
            this.btnShowInCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowInCalendar.Location = new System.Drawing.Point(351, 576);
            this.btnShowInCalendar.Name = "btnShowInCalendar";
            this.btnShowInCalendar.Size = new System.Drawing.Size(141, 23);
            this.btnShowInCalendar.TabIndex = 42;
            this.btnShowInCalendar.Text = "Exibir em Calendário";
            this.btnShowInCalendar.UseVisualStyleBackColor = true;
            this.btnShowInCalendar.Click += new System.EventHandler(this.btnShowInCalendar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 611);
            this.Controls.Add(this.btnShowInCalendar);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxTrabalha);
            this.Controls.Add(this.listBoxOutros);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxFolga);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.rtxtProximaEscala);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSalvarEscala);
            this.Controls.Add(this.lblInfoCheckbox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Gerador de Escalas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblInfoCheckbox;
        private Button btnSalvarEscala;
        private Label lblFilaAtl;
        private Label lblFilaPier;
        private Label label4;
        private Label label7;
        private DataGridView dataGridView1;
        private Button btnEditar;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastrarFuncionarioToolStripMenuItem;
        private RichTextBox richTextBoxFILAATL;
        private RichTextBox richTextBoxFILAPIER;
        private RichTextBox rtxtFuturaFilaPIER;
        private RichTextBox rtxtFuturaFilaATL;
        private Label label8;
        private Label label9;
        private RichTextBox rtxtProximaEscala;
        private Button btnExcluir;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label3;
        private ListBox listBoxFolga;
        private Label label5;
        private Label label6;
        private ListBox listBoxOutros;
        private ListBox listBoxTrabalha;
        private Button button1;
        private DateTimePicker dateTimePicker1;
        private ToolStripMenuItem calendarioToolStripMenuItem;
        private Button btnShowInCalendar;
    }
}