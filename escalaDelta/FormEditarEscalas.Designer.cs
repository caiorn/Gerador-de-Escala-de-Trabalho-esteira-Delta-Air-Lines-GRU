namespace escalaDelta {
    partial class FormEditarEscalas {
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
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.listBox1Pier = new System.Windows.Forms.ListBox();
            this.listBox2ATL = new System.Windows.Forms.ListBox();
            this.listBox3JFK = new System.Windows.Forms.ListBox();
            this.listBox4Ntrampou = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "ATL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "JFK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Pier";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(89, 337);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(161, 23);
            this.btnSalvar.TabIndex = 19;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(284, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Arraste para definir onde os colaboradores trabalhou";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(40, 40);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(284, 23);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // listBox1Pier
            // 
            this.listBox1Pier.FormattingEnabled = true;
            this.listBox1Pier.ItemHeight = 15;
            this.listBox1Pier.Location = new System.Drawing.Point(43, 95);
            this.listBox1Pier.Name = "listBox1Pier";
            this.listBox1Pier.Size = new System.Drawing.Size(145, 64);
            this.listBox1Pier.TabIndex = 27;
            // 
            // listBox2ATL
            // 
            this.listBox2ATL.FormattingEnabled = true;
            this.listBox2ATL.ItemHeight = 15;
            this.listBox2ATL.Location = new System.Drawing.Point(43, 180);
            this.listBox2ATL.Name = "listBox2ATL";
            this.listBox2ATL.Size = new System.Drawing.Size(145, 64);
            this.listBox2ATL.TabIndex = 28;
            // 
            // listBox3JFK
            // 
            this.listBox3JFK.FormattingEnabled = true;
            this.listBox3JFK.ItemHeight = 15;
            this.listBox3JFK.Location = new System.Drawing.Point(43, 265);
            this.listBox3JFK.Name = "listBox3JFK";
            this.listBox3JFK.Size = new System.Drawing.Size(145, 64);
            this.listBox3JFK.TabIndex = 29;
            // 
            // listBox4Ntrampou
            // 
            this.listBox4Ntrampou.FormattingEnabled = true;
            this.listBox4Ntrampou.ItemHeight = 15;
            this.listBox4Ntrampou.Location = new System.Drawing.Point(198, 95);
            this.listBox4Ntrampou.Name = "listBox4Ntrampou";
            this.listBox4Ntrampou.Size = new System.Drawing.Size(145, 229);
            this.listBox4Ntrampou.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 31;
            this.label1.Text = "Não trabalhou";
            // 
            // FormEditarEscalas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 372);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox4Ntrampou);
            this.Controls.Add(this.listBox3JFK);
            this.Controls.Add(this.listBox2ATL);
            this.Controls.Add(this.listBox1Pier);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label5);
            this.Name = "FormEditarEscalas";
            this.Text = "FormEditarEscalas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label6;
        private Label label3;
        private Label label2;
        private Button btnSalvar;
        private Label label5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DateTimePicker dateTimePicker1;
        private ListBox listBox1Pier;
        private ListBox listBox2ATL;
        private ListBox listBox3JFK;
        private ListBox listBox4Ntrampou;
        private Label label1;
    }
}