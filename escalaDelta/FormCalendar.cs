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
    public partial class FormCalendar : Form {

        private PrivateFontCollection privateFonts = new PrivateFontCollection();
        public static int _month, _year;
        private Size bestSizePrint;

        public FormCalendar(int mes, int ano) {
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
            Font customFont1 = new Font(privateFonts.Families[0], 16F, FontStyle.Bold) ; 
            Font customFont2 = new Font(privateFonts.Families[0], 14F); 
            lblMonth.Font = customFont1;
            label1.Font = customFont2;
            label2.Font = customFont2;
            label3.Font = customFont2;
            label4.Font = customFont2;
            label5.Font = customFont2;
            label6.Font = customFont2;
            label7.Font = customFont2;
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
                flowLayoutPanel1.AutoScroll = true ;

            }
        }

        private void FormCalendar_Load(object sender, EventArgs e) {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Top = Screen.PrimaryScreen.WorkingArea.Top;
        }

        private void loadUltimasEscalasCalendario() {
            flowLayoutPanel1.Controls.Clear();
            string monthName = new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(_month);
            lblMonth.Text = monthName.ToUpper() + " " + _year;

            DateTime startodTheMonth = new DateTime(_year, _month, 1);
            int day = DateTime.DaysInMonth(_year, _month);
            int week = Convert.ToInt32(startodTheMonth.DayOfWeek.ToString("d")) + 1;
           

            try {
                using (SQLiteConnection connection = new SQLiteConnection(Form1.connectionString)) {
                    // Abrir a conexão com o banco de dados
                    connection.Open();
                    // Comando SQL de todas escala do ultimo mes gerado
                    string query = @"
SELECT 
    ct.data,
    GROUP_CONCAT(DISTINCT CASE WHEN ct.local_trabalho = 'PIER' THEN c.nome ELSE NULL END) AS PIER,
    GROUP_CONCAT(DISTINCT CASE WHEN ct.local_trabalho = 'ATL' THEN ' ' || c.nome  ELSE NULL END) AS ATL,
    GROUP_CONCAT(DISTINCT CASE WHEN ct.local_trabalho = 'JFK' THEN ' ' || c.nome ELSE NULL END) AS JFK,
    GROUP_CONCAT(DISTINCT CASE WHEN (ct.local_trabalho LIKE 'FOLGA%' AND c.id_cargo = 1) THEN c.nome  ELSE NULL END) AS FOLGA_AUXILIARES,
    GROUP_CONCAT(DISTINCT CASE WHEN (ct.local_trabalho = '' AND c.id_cargo = 2 ) THEN ' ' || c.nome ELSE NULL END) AS LIDERES,
    GROUP_CONCAT(DISTINCT CASE WHEN (ct.local_trabalho LIKE 'FOLGA%' AND c.id_cargo = 2) THEN c.nome  ELSE NULL END) AS FOLGA_LIDERES,
        GROUP_CONCAT(DISTINCT CASE WHEN (ct.local_trabalho = '' AND c.id_cargo = 7 ) THEN ' ' || c.nome ELSE NULL END) AS OPERADORES,
    GROUP_CONCAT(DISTINCT CASE WHEN (ct.local_trabalho LIKE 'FOLGA%' AND c.id_cargo = 7) THEN c.nome  ELSE NULL END) AS FOLGA_OPERADORES
FROM 
    ColaboradorTrabalho ct
LEFT JOIN 
    Colaborador c ON ct.id_colaborador = c.id
WHERE 
    strftime('%Y-%m', ct.data) = (
        SELECT strftime('%Y-%m', MAX(data))
        FROM ColaboradorTrabalho
    )
GROUP BY 
    DATE(ct.data)
ORDER BY 
    ct.data ASC
";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection)) {
                        using (SQLiteDataReader reader = command.ExecuteReader()) {
                            //add blank initial calendar
                            for (int i = 1; i < week; i++) {
                                ucDay uc = new ucDay("");
                                flowLayoutPanel1.Controls.Add(uc);
                            }
                            for (int i = 1; i <= day; i++) {

                                if (reader.Read()) {
                                    string? dataEscala = reader["data"].ToString();
                                    string? pier = reader["PIER"].ToString()?.Replace(",", "\r\n");
                                    string? atl = reader["ATL"].ToString()?.Replace(",", "\r\n");
                                    string? jfk = reader["JFK"].ToString()?.Replace(",", "\r\n");
                                    string? folga_auxiliares = reader["FOLGA_AUXILIARES"].ToString()?.Replace(",", "\r\n");
                                    string? lideres = reader["LIDERES"].ToString();
                                    string? folga_lideres = reader["FOLGA_LIDERES"].ToString()?.Replace(",", "\r\n");
                                    string? operadores = reader["OPERADORES"].ToString();
                                    string? folga_operadores = reader["FOLGA_OPERADORES"].ToString()?.Replace(",", "\r\n");
                                    // Formata os valores para exibir somente a hora
                                    int dayEscala = Convert.ToInt32(DateTime.Parse(dataEscala).ToString("dd"));
                                    ucDay uc;
                                    if (i == dayEscala) {
                                        uc = new ucDay(i.ToString(), pier, atl, jfk, folga_auxiliares, lideres, folga_lideres, operadores, folga_operadores);
                                        flowLayoutPanel1.Controls.Add(uc);
                                    } else {
                                        while (i < dayEscala) {
                                            uc = new ucDay("");
                                            flowLayoutPanel1.Controls.Add(uc);
                                            i++;
                                        }
                                        if (i == dayEscala) {
                                            uc = new ucDay(i.ToString(), pier, atl, jfk, folga_auxiliares, lideres, folga_lideres, operadores, folga_operadores);
                                            flowLayoutPanel1.Controls.Add(uc);
                                        }
                                    }
                                }
                            }

                            //obtem o tamanho perfeito para printscreen no formulário
                            Control cardExample = flowLayoutPanel1.Controls[0];
                            int totalCards = flowLayoutPanel1.Controls.Count;
                            int tuplas = (int)Math.Ceiling(totalCards / 7.0);
                            int marginHeight = tuplas * (cardExample.Margin.Top + cardExample.Margin.Bottom);
                            int bestHeight = Height + ((tuplas* cardExample.Height) +marginHeight)-flowLayoutPanel1.Height;
                            bestSizePrint = new Size(Width, bestHeight);  
                            

                        }
                    }
                    // Fechar a conexão com o banco de dados
                    connection.Close();
                }
            } catch (Exception ex) {
                MessageBox.Show("Ocorreu um erro ao obter os dados dos colaboradores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        [DllImport("User32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool Repaint);

    }
}
