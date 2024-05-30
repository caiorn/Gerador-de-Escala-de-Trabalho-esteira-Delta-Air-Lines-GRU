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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace escalaDelta {
    public partial class FormCalendar : Form {

        private PrivateFontCollection privateFonts = new PrivateFontCollection();
        public static int _month, _year;

        public FormCalendar(int mes, int ano) {
            InitializeComponent();
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
            Font customFont1 = new Font(privateFonts.Families[0], 16F, FontStyle.Bold) ; // Tamanho 12, você pode ajustar conforme necessário
            Font customFont2 = new Font(privateFonts.Families[0], 12F); // Tamanho 12, você pode ajustar conforme necessário
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
    GROUP_CONCAT(DISTINCT CASE WHEN ct.local_trabalho = 'ATL' THEN ' ' || c.nome ELSE NULL END) AS ATL,
    GROUP_CONCAT(DISTINCT CASE WHEN ct.local_trabalho = 'JFK' THEN ' ' || c.nome ELSE NULL END) AS JFK,
    GROUP_CONCAT(DISTINCT CASE WHEN ct.local_trabalho = 'FOLGA' THEN c.nome ELSE NULL END) AS FOLGA
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
                                    string? folga = reader["FOLGA"].ToString()?.Replace(",", "\r\n");
                                    // Formata os valores para exibir somente a hora
                                    int dayEscala = Convert.ToInt32(DateTime.Parse(dataEscala).ToString("dd"));
                                    ucDay uc;
                                    if (i == dayEscala) {
                                        uc = new ucDay(i.ToString(), pier, atl, jfk, folga);
                                        flowLayoutPanel1.Controls.Add(uc);
                                    } else {
                                        while (i < dayEscala) {
                                            uc = new ucDay("");
                                            flowLayoutPanel1.Controls.Add(uc);
                                            i++;
                                        }
                                        if (i == dayEscala) {
                                            uc = new ucDay(i.ToString(), pier, atl, jfk, folga);
                                            flowLayoutPanel1.Controls.Add(uc);
                                        }
                                    }
                                }

                            }
                        }
                    }
                    // Fechar a conexão com o banco de dados
                    connection.Close();
                }
            } catch (Exception ex) {
                MessageBox.Show("Ocorreu um erro ao obter os dados dos colaboradores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
