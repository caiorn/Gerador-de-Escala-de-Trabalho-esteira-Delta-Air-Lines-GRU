using escalaDelta.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace escalaDelta {
    public partial class FormCalendar2 : Form {

        private PrivateFontCollection privateFonts = new PrivateFontCollection();
        public static int _month, _year;
        private Size bestSizePrint;

        public FormCalendar2(int mes, int ano) {
            InitializeComponent();
            flowLayoutPanel1.WrapContents = true; // Permite que os controles quebrem linha

            _month = mes;
            _year = ano;
            /* size form 1303; 938 
               size panel 1256; 734
             */
            LoadCustomFont();
            //showDays(DateTime.Now.Month, DateTime.Now.Year);
            loadUltimasEscalasCalendario();

        }

        private void LoadCustomFont() {
            // O caminho do arquivo da fonte deve ser relativo ao diretório de saída (Output Directory)
            string fontPath = Path.Combine(Application.StartupPath, "Poppins-Regular.ttf");

            // Carrega a fonte privada
            privateFonts.AddFontFile(fontPath);

            // Atribui a fonte personalizada a um controle específico, por exemplo, um Label
            Font customFont1 = new Font(privateFonts.Families[0], 16F, FontStyle.Bold);
            Font customFont2 = new Font(privateFonts.Families[0], 14F);
            lblMonth.Font = customFont1;
            label1.Font = customFont2;
            label2.Font = customFont2;
            label3.Font = customFont2;
            label4.Font = customFont2;
            label5.Font = customFont2;
            label7.Font = customFont2;

            DateTime today = DateTime.Today;

            // Add dates to BoldedDates array.
            this.monthCalendar1.BoldedDates = new System.DateTime[] {
                                    today.AddDays(2), 
                                    today.AddDays(4), 
                                    today.AddDays(-2)};

            
        }



        private void lblMonth_Click(object sender, EventArgs e) {
            MessageBox.Show(this.Height.ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            var oldFormBorderStyle = FormBorderStyle;
            this.FormBorderStyle = FormBorderStyle.None;

            Size oldSize = Size;
            this.MaximumSize = bestSizePrint;
            bool Result = MoveWindow(this.Handle, this.Left, this.Top, bestSizePrint.Width, bestSizePrint.Height, true);
            flowLayoutPanel1.AutoScroll = false;

            try {
                var image = this.CaptureScreenFullForm();
                Clipboard.SetImage(image);
                if (image == null) {
                    MessageBox.Show("Não foi possível capturar a imagem do formulário.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Clipboard.SetImage(image);
            } catch (Exception ex) {
                MessageBox.Show($"Erro ao copiar para a área de transferência: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                this.FormBorderStyle = oldFormBorderStyle;
                this.Size = oldSize;
                flowLayoutPanel1.AutoScroll = true;

            }
        }

        private void FormCalendar_Load(object sender, EventArgs e) {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Top = Screen.PrimaryScreen.WorkingArea.Top;
        }

        private void loadUltimasEscalasCalendario() {
            //flowLayoutPanel1.Controls.Clear();
            //string monthName = new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(_month);
            //lblMonth.Text = monthName.ToUpper() + " " + _year;

            //DateTime startodTheMonth = new DateTime(_year, _month, 1);
            //int day = DateTime.DaysInMonth(_year, _month);
            //int week = Convert.ToInt32(startodTheMonth.DayOfWeek.ToString("d")) + 1;

            ////add blank initial calendar
            //for (int i = 1; i < week; i++) {
            //    ucDay uc = new ucDay("");
            //    flowLayoutPanel1.Controls.Add(uc);
            //}
            //for (int i = 1; i <= day; i++) {

            //    // Formata os valores para exibir somente a hora
            //    int dayEscala = Convert.ToInt32(DateTime.Parse(dataEscala).ToString("dd"));
            //    Label uc;
            //    uc = new Label();
            //    if (i == dayEscala) {
            //        flowLayoutPanel2.Controls.Add(uc);
            //    } else {
            //        while (i < dayEscala) {
            //            flowLayoutPanel2.Controls.Add(uc);
            //            i++;
            //        }
            //        if (i == dayEscala) {
            //            flowLayoutPanel2.Controls.Add(uc);
            //        }

            //    }
            //}



            //    //obtem o tamanho perfeito para printscreen no formulário
            //    Control cardExample = flowLayoutPanel1.Controls[0];
            //    int totalCards = flowLayoutPanel1.Controls.Count;
            //    int tuplas = (int)Math.Ceiling(totalCards / 7.0);
            //    int marginHeight = tuplas * (cardExample.Margin.Top + cardExample.Margin.Bottom);
            //    int bestHeight = Height + ((tuplas* cardExample.Height) +marginHeight)-flowLayoutPanel1.Height;
            //  bestSizePrint = new Size(Width, bestHeight);
        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void label5_Click(object sender, EventArgs e) {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e) {

        }

        private void label15_Click(object sender, EventArgs e) {

        }

        private void label15_Click_1(object sender, EventArgs e) {

        }

        [DllImport("User32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool Repaint);

    }
}
