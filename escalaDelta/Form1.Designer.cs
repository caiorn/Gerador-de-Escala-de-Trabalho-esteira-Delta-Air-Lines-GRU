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
            this.btnSalvarEscala = new System.Windows.Forms.Button();
            this.lblFilaAtl = new System.Windows.Forms.Label();
            this.lblFilaPier = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrarFuncionarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBoxFILAATL = new System.Windows.Forms.RichTextBox();
            this.richTextBoxFILAPIER = new System.Windows.Forms.RichTextBox();
            this.rtxtFuturaFilaPIER = new System.Windows.Forms.RichTextBox();
            this.rtxtFuturaFilaATL = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.btnGerarAte = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnShowInCalendar = new System.Windows.Forms.Button();
            this.gbAuxiliares = new System.Windows.Forms.GroupBox();
            this.listBox3JFK = new System.Windows.Forms.ListBox();
            this.listBox2ATL = new System.Windows.Forms.ListBox();
            this.listBox1Pier = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox1Operadores = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.listBox1LideresON = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbAuxiliares.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvarEscala
            // 
            this.btnSalvarEscala.Location = new System.Drawing.Point(238, 366);
            this.btnSalvarEscala.Name = "btnSalvarEscala";
            this.btnSalvarEscala.Size = new System.Drawing.Size(110, 23);
            this.btnSalvarEscala.TabIndex = 3;
            this.btnSalvarEscala.Text = "Salvar";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 376);
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
            this.dataGridView1.Location = new System.Drawing.Point(20, 395);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(904, 173);
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
            this.cadastrarFuncionarioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(940, 24);
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
            // richTextBoxFILAATL
            // 
            this.richTextBoxFILAATL.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxFILAATL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxFILAATL.Location = new System.Drawing.Point(9, 44);
            this.richTextBoxFILAATL.Name = "richTextBoxFILAATL";
            this.richTextBoxFILAATL.ReadOnly = true;
            this.richTextBoxFILAATL.Size = new System.Drawing.Size(80, 232);
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
            this.richTextBoxFILAPIER.Size = new System.Drawing.Size(80, 232);
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
            this.rtxtFuturaFilaPIER.Size = new System.Drawing.Size(80, 231);
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
            this.rtxtFuturaFilaATL.Size = new System.Drawing.Size(80, 231);
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
            this.groupBox1.Size = new System.Drawing.Size(198, 289);
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
            this.groupBox2.Location = new System.Drawing.Point(724, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 289);
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
            this.label1.Location = new System.Drawing.Point(810, 578);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(833, 578);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "Futuro";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // listBoxFolga
            // 
            this.listBoxFolga.AllowDrop = true;
            this.listBoxFolga.FormattingEnabled = true;
            this.listBoxFolga.ItemHeight = 15;
            this.listBoxFolga.Location = new System.Drawing.Point(17, 37);
            this.listBoxFolga.Name = "listBoxFolga";
            this.listBoxFolga.Size = new System.Drawing.Size(108, 109);
            this.listBoxFolga.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 36;
            this.label5.Text = "Folga:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 157);
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
            this.listBoxOutros.Location = new System.Drawing.Point(17, 196);
            this.listBoxOutros.Name = "listBoxOutros";
            this.listBoxOutros.Size = new System.Drawing.Size(108, 79);
            this.listBoxOutros.TabIndex = 38;
            // 
            // btnGerarAte
            // 
            this.btnGerarAte.Location = new System.Drawing.Point(432, 368);
            this.btnGerarAte.Name = "btnGerarAte";
            this.btnGerarAte.Size = new System.Drawing.Size(124, 23);
            this.btnGerarAte.TabIndex = 40;
            this.btnGerarAte.Text = "Gerar + Salvar Até";
            this.btnGerarAte.UseVisualStyleBackColor = true;
            this.btnGerarAte.Click += new System.EventHandler(this.btnGerarAte_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(565, 366);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(86, 23);
            this.dateTimePicker1.TabIndex = 41;
            // 
            // btnShowInCalendar
            // 
            this.btnShowInCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowInCalendar.Location = new System.Drawing.Point(250, 574);
            this.btnShowInCalendar.Name = "btnShowInCalendar";
            this.btnShowInCalendar.Size = new System.Drawing.Size(141, 23);
            this.btnShowInCalendar.TabIndex = 42;
            this.btnShowInCalendar.Text = "Exibir em Calendário";
            this.btnShowInCalendar.UseVisualStyleBackColor = true;
            this.btnShowInCalendar.Click += new System.EventHandler(this.btnShowInCalendar_Click);
            // 
            // gbAuxiliares
            // 
            this.gbAuxiliares.Controls.Add(this.listBox3JFK);
            this.gbAuxiliares.Controls.Add(this.listBox2ATL);
            this.gbAuxiliares.Controls.Add(this.listBox1Pier);
            this.gbAuxiliares.Controls.Add(this.label10);
            this.gbAuxiliares.Controls.Add(this.label11);
            this.gbAuxiliares.Controls.Add(this.label12);
            this.gbAuxiliares.Location = new System.Drawing.Point(12, 23);
            this.gbAuxiliares.Name = "gbAuxiliares";
            this.gbAuxiliares.Size = new System.Drawing.Size(156, 253);
            this.gbAuxiliares.TabIndex = 43;
            this.gbAuxiliares.TabStop = false;
            this.gbAuxiliares.Text = "Auxiliares";
            // 
            // listBox3JFK
            // 
            this.listBox3JFK.FormattingEnabled = true;
            this.listBox3JFK.ItemHeight = 15;
            this.listBox3JFK.Location = new System.Drawing.Point(19, 173);
            this.listBox3JFK.Name = "listBox3JFK";
            this.listBox3JFK.Size = new System.Drawing.Size(122, 64);
            this.listBox3JFK.TabIndex = 35;
            // 
            // listBox2ATL
            // 
            this.listBox2ATL.FormattingEnabled = true;
            this.listBox2ATL.ItemHeight = 15;
            this.listBox2ATL.Location = new System.Drawing.Point(19, 92);
            this.listBox2ATL.Name = "listBox2ATL";
            this.listBox2ATL.Size = new System.Drawing.Size(122, 64);
            this.listBox2ATL.TabIndex = 34;
            // 
            // listBox1Pier
            // 
            this.listBox1Pier.FormattingEnabled = true;
            this.listBox1Pier.ItemHeight = 15;
            this.listBox1Pier.Location = new System.Drawing.Point(19, 37);
            this.listBox1Pier.Name = "listBox1Pier";
            this.listBox1Pier.Size = new System.Drawing.Size(122, 34);
            this.listBox1Pier.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 15);
            this.label10.TabIndex = 32;
            this.label10.Text = "ATL";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 15);
            this.label11.TabIndex = 31;
            this.label11.Text = "JFK";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 15);
            this.label12.TabIndex = 30;
            this.label12.Text = "Pier";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox1Operadores);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.listBox1LideresON);
            this.groupBox3.Controls.Add(this.gbAuxiliares);
            this.groupBox3.Location = new System.Drawing.Point(238, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 289);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Trabalha";
            // 
            // listBox1Operadores
            // 
            this.listBox1Operadores.FormattingEnabled = true;
            this.listBox1Operadores.ItemHeight = 15;
            this.listBox1Operadores.Location = new System.Drawing.Point(183, 182);
            this.listBox1Operadores.Name = "listBox1Operadores";
            this.listBox1Operadores.Size = new System.Drawing.Size(119, 94);
            this.listBox1Operadores.TabIndex = 47;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(183, 157);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 15);
            this.label14.TabIndex = 46;
            this.label14.Text = "Operadores";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(183, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 15);
            this.label13.TabIndex = 45;
            this.label13.Text = "Lideres";
            // 
            // listBox1LideresON
            // 
            this.listBox1LideresON.FormattingEnabled = true;
            this.listBox1LideresON.ItemHeight = 15;
            this.listBox1LideresON.Location = new System.Drawing.Point(183, 37);
            this.listBox1LideresON.Name = "listBox1LideresON";
            this.listBox1LideresON.Size = new System.Drawing.Size(119, 109);
            this.listBox1LideresON.TabIndex = 44;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.listBoxFolga);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.listBoxOutros);
            this.groupBox4.Location = new System.Drawing.Point(565, 71);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(138, 289);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Não Trabalha";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 611);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnShowInCalendar);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnGerarAte);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSalvarEscala);
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
            this.gbAuxiliares.ResumeLayout(false);
            this.gbAuxiliares.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnSalvarEscala;
        private Label lblFilaAtl;
        private Label lblFilaPier;
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
        private Button btnGerarAte;
        private DateTimePicker dateTimePicker1;
        private Button btnShowInCalendar;
        private GroupBox gbAuxiliares;
        private ListBox listBox3JFK;
        private ListBox listBox2ATL;
        private ListBox listBox1Pier;
        private Label label10;
        private Label label11;
        private Label label12;
        private GroupBox groupBox3;
        private ListBox listBox1Operadores;
        private Label label14;
        private Label label13;
        private ListBox listBox1LideresON;
        private GroupBox groupBox4;
    }
}