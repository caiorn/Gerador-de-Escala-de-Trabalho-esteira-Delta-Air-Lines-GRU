using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace escalaDelta {
    public partial class ucDay : UserControl {

        string _day, date, weekday;

        private void panel1_Click(object sender, EventArgs e) {

            if (checkBox1.Checked) {
                this.BackColor = Color.FromArgb(255, 150, 79);
            } else {
                this.BackColor = Color.White;
            }
            checkBox1.Checked = !checkBox1.Checked;
        }

        public ucDay(string day, string pier = "", string atl = "", string jfk = "", string folga = "") {
            InitializeComponent();
            checkBox1.Hide();
            LoadCustomFont();

            _day = day;
            if (day == "") {
                panel1.Visible = false;
            }

            label1.Text = day;
            lblPier.Text = pier;
            lblListAtl.Text = atl;
            lblListJfk.Text = jfk;
            lblListFolga.Text = folga;
            //rever isto pode ser um futuro bug
            date = _day + "/" + FormCalendar._month + "/" + FormCalendar._year;
        }

        private PrivateFontCollection privateFonts = new PrivateFontCollection();
        private void LoadCustomFont() {
            // O caminho do arquivo da fonte deve ser relativo ao diretório de saída (Output Directory)
            string fontPath = Path.Combine(Application.StartupPath, "Poppins-Regular.ttf");

            // Carrega a fonte privada
            privateFonts.AddFontFile(fontPath);

            // Atribui a fonte personalizada a um controle específico, por exemplo, um Label
            Font customFont1 = new Font(privateFonts.Families[0], 14F); // Tamanho 12, você pode ajustar conforme necessário
            Font customFont2 = new Font(privateFonts.Families[0], 10F); // Tamanho 12, você pode ajustar conforme necessário
            Font customFont3 = new Font(privateFonts.Families[0], 9F); // Tamanho 12, você pode ajustar conforme necessário
            
            label1.Font = customFont1;
            label2.Font = customFont2;
            label3.Font = customFont2;
            label4.Font = customFont2;
            label5.Font = customFont3;
            lblListAtl.Font = customFont3;
            lblListJfk.Font = customFont3;
            lblListFolga.Font = customFont3;
            lblPier.Font = customFont3;
        }

        private void PaintSundays() {
            //rever isto pode ser um futuro bug

            try {
                DateTime Day = DateTime.Parse(date);
                weekday = Day.ToString("ddd");

                if (weekday == "dom") {
                    label1.ForeColor = Color.FromArgb(255, 128, 128);
                } else {
                    label1.ForeColor = Color.FromArgb(64, 64, 64);

                }
            } catch (Exception) {

            }
        }

        private void ucDay_Load(object sender, EventArgs e) {
            PaintSundays();
        }
    }
}
