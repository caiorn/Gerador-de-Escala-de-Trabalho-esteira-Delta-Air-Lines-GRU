namespace escalaDelta {
    partial class FormCalendarFolgas {
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
            this.monthCalendar1 = new CustomControls.MonthCalendar();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(3, 4);
            this.monthCalendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthCalendar1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.monthCalendar1.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.Text = "monthCalendar1";
            this.monthCalendar1.DateSelected += new System.EventHandler<System.Windows.Forms.DateRangeEventArgs>(this.monthCalendar1_DateSelected);
            // 
            // FormCalendarFolgas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(631, 648);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "FormCalendarFolgas";
            this.Text = "Folga";
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel2;
        private Panel panel3;
        private CustomControls.MonthCalendar monthCalendar1;
    }
}