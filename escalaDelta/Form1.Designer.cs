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
            this.checkedListBox1TrabalhaHoje = new System.Windows.Forms.CheckedListBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBox1TrabalhaHoje
            // 
            this.checkedListBox1TrabalhaHoje.FormattingEnabled = true;
            this.checkedListBox1TrabalhaHoje.Location = new System.Drawing.Point(245, 143);
            this.checkedListBox1TrabalhaHoje.Name = "checkedListBox1TrabalhaHoje";
            this.checkedListBox1TrabalhaHoje.Size = new System.Drawing.Size(108, 184);
            this.checkedListBox1TrabalhaHoje.TabIndex = 1;
            this.checkedListBox1TrabalhaHoje.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1TrabalhaHoje_ItemCheck);
            // 
            // lblInfoCheckbox
            // 
            this.lblInfoCheckbox.AutoSize = true;
            this.lblInfoCheckbox.Location = new System.Drawing.Point(245, 102);
            this.lblInfoCheckbox.Name = "lblInfoCheckbox";
            this.lblInfoCheckbox.Size = new System.Drawing.Size(120, 15);
            this.lblInfoCheckbox.TabIndex = 2;
            this.lblInfoCheckbox.Text = "Quem Trabalha Hoje?";
            // 
            // btnSalvarEscala
            // 
            this.btnSalvarEscala.Location = new System.Drawing.Point(357, 333);
            this.btnSalvarEscala.Name = "btnSalvarEscala";
            this.btnSalvarEscala.Size = new System.Drawing.Size(160, 23);
            this.btnSalvarEscala.TabIndex = 3;
            this.btnSalvarEscala.Text = "OK (Salvar)";
            this.btnSalvarEscala.UseVisualStyleBackColor = true;
            this.btnSalvarEscala.Click += new System.EventHandler(this.btnSalvarEscala_Click);
            // 
            // lblFilaAtl
            // 
            this.lblFilaAtl.AutoSize = true;
            this.lblFilaAtl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblFilaAtl.Location = new System.Drawing.Point(38, 23);
            this.lblFilaAtl.Name = "lblFilaAtl";
            this.lblFilaAtl.Size = new System.Drawing.Size(29, 17);
            this.lblFilaAtl.TabIndex = 4;
            this.lblFilaAtl.Text = "ATL";
            // 
            // lblFilaPier
            // 
            this.lblFilaPier.AutoSize = true;
            this.lblFilaPier.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblFilaPier.Location = new System.Drawing.Point(141, 23);
            this.lblFilaPier.Name = "lblFilaPier";
            this.lblFilaPier.Size = new System.Drawing.Size(35, 17);
            this.lblFilaPier.TabIndex = 5;
            this.lblFilaPier.Text = "PIER";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(390, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Texto p/ Copiar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 340);
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
            this.dataGridView1.Location = new System.Drawing.Point(20, 358);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(723, 210);
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
            this.menuStrip1.Size = new System.Drawing.Size(760, 24);
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
            this.richTextBoxFILAATL.Size = new System.Drawing.Size(92, 162);
            this.richTextBoxFILAATL.TabIndex = 21;
            this.richTextBoxFILAATL.Text = "Nome1\nNome2\n";
            // 
            // richTextBoxFILAPIER
            // 
            this.richTextBoxFILAPIER.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxFILAPIER.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxFILAPIER.Location = new System.Drawing.Point(107, 44);
            this.richTextBoxFILAPIER.Name = "richTextBoxFILAPIER";
            this.richTextBoxFILAPIER.ReadOnly = true;
            this.richTextBoxFILAPIER.Size = new System.Drawing.Size(88, 162);
            this.richTextBoxFILAPIER.TabIndex = 22;
            this.richTextBoxFILAPIER.Text = "Nome1\nNome2\n";
            // 
            // rtxtFuturaFilaPIER
            // 
            this.rtxtFuturaFilaPIER.BackColor = System.Drawing.SystemColors.Control;
            this.rtxtFuturaFilaPIER.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtFuturaFilaPIER.ForeColor = System.Drawing.Color.DarkGreen;
            this.rtxtFuturaFilaPIER.Location = new System.Drawing.Point(118, 44);
            this.rtxtFuturaFilaPIER.Name = "rtxtFuturaFilaPIER";
            this.rtxtFuturaFilaPIER.ReadOnly = true;
            this.rtxtFuturaFilaPIER.Size = new System.Drawing.Size(88, 162);
            this.rtxtFuturaFilaPIER.TabIndex = 26;
            this.rtxtFuturaFilaPIER.Text = "Nome1\nNome2\n";
            // 
            // rtxtFuturaFilaATL
            // 
            this.rtxtFuturaFilaATL.BackColor = System.Drawing.SystemColors.Control;
            this.rtxtFuturaFilaATL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtFuturaFilaATL.ForeColor = System.Drawing.Color.DarkGreen;
            this.rtxtFuturaFilaATL.Location = new System.Drawing.Point(16, 44);
            this.rtxtFuturaFilaATL.Name = "rtxtFuturaFilaATL";
            this.rtxtFuturaFilaATL.ReadOnly = true;
            this.rtxtFuturaFilaATL.Size = new System.Drawing.Size(84, 162);
            this.rtxtFuturaFilaATL.TabIndex = 25;
            this.rtxtFuturaFilaATL.Text = "Nome1\nNome2\n";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Location = new System.Drawing.Point(112, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Prox. Fila PIER";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(12, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Prox. Fila ATL";
            // 
            // rtxtProximaEscala
            // 
            this.rtxtProximaEscala.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtxtProximaEscala.Location = new System.Drawing.Point(357, 125);
            this.rtxtProximaEscala.Name = "rtxtProximaEscala";
            this.rtxtProximaEscala.Size = new System.Drawing.Size(160, 199);
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
            this.groupBox1.Location = new System.Drawing.Point(23, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 225);
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
            this.groupBox2.Location = new System.Drawing.Point(523, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 222);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filas Futuras";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(121)))));
            this.label2.Location = new System.Drawing.Point(267, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "ESCALA AUXILIARES DE ESTEIRA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(278, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(664, 582);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(687, 582);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "Futuro";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 611);
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
            this.Controls.Add(this.checkedListBox1TrabalhaHoje);
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

        private CheckedListBox checkedListBox1TrabalhaHoje;
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
    }
}