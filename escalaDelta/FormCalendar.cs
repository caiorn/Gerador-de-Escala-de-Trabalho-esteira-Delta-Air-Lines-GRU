using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace escalaDelta {
    public partial class FormCalendar : Form {

        private PrivateFontCollection privateFonts = new PrivateFontCollection();
        public static int _year, _month;

        public FormCalendar() {
            InitializeComponent();

            /* size form 1303; 938 
               size panel 1256; 734
             */
            LoadCustomFont();
            showDays(DateTime.Now.Month, DateTime.Now.Year); 
        
        
        }

        private void LoadCustomFont() {
            // O caminho do arquivo da fonte deve ser relativo ao diretório de saída (Output Directory)
            string fontPath = Path.Combine(Application.StartupPath, "Poppins-Regular.ttf");

            // Carrega a fonte privada
            privateFonts.AddFontFile(fontPath);

            // Atribui a fonte personalizada a um controle específico, por exemplo, um Label
            Font customFont = new Font(privateFonts.Families[0], 12F); // Tamanho 12, você pode ajustar conforme necessário
            lblMonth.Font = customFont;
            label1.Font = customFont;
            label2.Font = customFont;
            label3.Font = customFont;
            label4.Font = customFont;
            label5.Font = customFont;
            label6.Font = customFont;
            label7.Font = customFont;
        }

        private void picNext_Click(object sender, EventArgs e) {
            _month += 1;
            if (_month > 12) {
                _month = 1;
                _year += 1;
            }
            showDays(_month, _year);
        }

        private void picPrev_Click(object sender, EventArgs e) {
            _month -= 1;
            if (_month < 1) {
                _month = 12;
                _year -= 1;
            }
            showDays(_month, _year);
        }

        private void showDays(int month, int year) {
            _month = month;
            _year = year;

            flowLayoutPanel1.Controls.Clear();

            string monthName = new DateTimeFormatInfo().GetMonthName(month);
            lblMonth.Text = monthName.ToUpper() + " "+ year;
            DateTime startodTheMonth = new DateTime(year, month, 1);
            int day = DateTime.DaysInMonth(year, month);
            int week = Convert.ToInt32(startodTheMonth.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < week; i++) {
                ucDay uc = new ucDay("");
                flowLayoutPanel1.Controls.Add(uc);
            }
            for (int i = 1; i < day; i++) {
                ucDay uc = new ucDay(i+"");
                flowLayoutPanel1.Controls.Add(uc);
            }
        }
    }
}
