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

        Dictionary<DateTime, string> feriadosNacionais = new Dictionary<DateTime, string>
          {
                { new DateTime(DateTime.Now.Year, 1, 1), "Confraternização Universal" },
                { new DateTime(DateTime.Now.Year, 4, 21), "Tiradentes" },
                { new DateTime(DateTime.Now.Year, 5, 1), "Dia do Trabalhador" },
                { new DateTime(DateTime.Now.Year, 9, 7), "Independência do Brasil" },
                { new DateTime(DateTime.Now.Year, 10, 12), "Nossa Senhora Aparecida" },
                { new DateTime(DateTime.Now.Year, 11, 2), "Finados" },
                { new DateTime(DateTime.Now.Year, 11, 15), "Proclamação da República" },
                { new DateTime(DateTime.Now.Year, 12, 25), "Natal" }
            };

        private void panel1_Click(object sender, EventArgs e) {

            if (checkBox1.Checked) {
                this.BackColor = Color.FromArgb(255, 150, 79);
            } else {
                this.BackColor = Color.White;
            }
            checkBox1.Checked = !checkBox1.Checked;
        }

        public ucDay(string day, string pier = "", string atl = "", string jfk = "", string folga_auxiliares = "", string lideres = "", string folga_lideres = "", string operadores = "", string folgao_peradores = "") {
            InitializeComponent();
            checkBox1.Hide();
            //LoadCustomFont();

            _day = day;
            if (day == "") {
                panel1.Visible = false;
            }

            label1.Text = day;
            lblPier.Text = pier;
            lblListAtl.Text = atl;
            lblListJfk.Text = jfk;
            lblListFolga.Text = folga_auxiliares;
            lblLideres.Text = lideres;
            lblFolgaLideres.Text = folga_lideres;
            lblOperadores.Text = operadores;
            lblFolgaOperadores.Text = folgao_peradores;

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

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void PintarDomingosEFeriados() {
            //rever isto pode ser um futuro bug

            try {
                DateTime datee = DateTime.Parse(date);
                string feriado = VerificarFeriado(datee, feriadosNacionais);
                weekday = datee.ToString("ddd");

                if (feriado != null) {
                    lblFeriado.Visible = true;
                    lblFeriado.Text = feriado;
                    label1.ForeColor = Color.FromArgb(255, 0, 0);
                    panel1.BackColor = Color.FromArgb(255, 235, 235);
                } else if (weekday == "dom") {
                    label1.ForeColor = Color.FromArgb(255, 0, 0);
                    panel1.BackColor = Color.FromArgb(255, 235, 235);
                } else {
                  label1.ForeColor = Color.FromArgb(64, 64, 64);

                }
            } catch (Exception) {

            }
        }

        private void ucDay_Load(object sender, EventArgs e) {
            PintarDomingosEFeriados();
        }

        static string VerificarFeriado(DateTime data, Dictionary<DateTime, string> feriados) {
            // Verifica se a data é um feriado, ignorando o ano
            var dataSemAno = new DateTime(1, data.Month, data.Day);

            if (IsSextaSanta(data)) {
                return "Paixão de Cristo";
            } else {
                var feriado = feriados.FirstOrDefault(f => f.Key.Month == dataSemAno.Month && f.Key.Day == dataSemAno.Day);
                return feriado.Value;
            }            
        }

        static bool IsSextaSanta(DateTime date) {
            // Verifica se a data está nos meses de março ou abril
            if (date.Month < 3 || date.Month > 4) {
                return false;
            }

            int year = date.Year;
            DateTime easterSunday = ObterDomingoDePascoa(year);
            DateTime goodFriday = easterSunday.AddDays(-2);
            return date.Date == goodFriday.Date;
        }

        static DateTime ObterDomingoDePascoa(int year) {
            // Algoritmo de computação da data da Páscoa (baseado no algoritmo de Meeus/Jones/Butcher)
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int month = (h + l - 7 * m + 114) / 31;
            int day = ((h + l - 7 * m + 114) % 31) + 1;

            return new DateTime(year, month, day);
        }
    }
}
