using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace escalaDelta {
    /*
        REGRAS:
           [x] Deve haver sempre que possivel ao menos um colaborador de 6h no ATL e JFK
           [x] O Pier � Rotativo
           [x] O Voo ATL � Rotativo
           [ ] Quem entrar as 19h s� ir� trabalhar no Pier ou ATL
            

        Algoritimo:
            O algoritimo se baseia em filas,
            Foi criado 2 filas ATL e PIER
            O primeiro da fila do PIER far� o pier e ir� para o fim da fila.
             Salvo se o primeiro da fila, somente se for o �nico de 6h para fazer o ATL.
            Os primeiros da fila ATL far�o o VOO,

     */


    public partial class Form1 : Form {

        //[] arrumar o vinculo de quem trabalha hoje
        //[] armazenar no banco de dados.

        // Caminho do banco de dados
        public static string caminhoBancoDados = "database.db";
        public static string connectionString = $"Data Source={caminhoBancoDados}";
        public static List<Colaborador> colaboradores { get; set; }
        public List<Colaborador> fila_ATL_Present { get; set; }
        public List<Colaborador> fila_PIER_Present { get; set; }
        public List<Colaborador> fila_ATL_Future { get; set; }
        public List<Colaborador> fila_PIER_Future { get; set; }

        public Colaborador PIER_work { get; set; }
        public List<Colaborador> ATL_work { get; set; }
        public List<Colaborador> JFK_work { get; set; }

        public DateOnly dataProximaEscala { get; set; }

        public Form1() {
            InitializeComponent();

            CriarBancoDados();
            loadColaboradores();

            refreshDatas();

            // Configurando o CheckedListBox
            foreach (var colaborador in colaboradores) {
                checkedListBox1TrabalhaHoje.Items.Add(colaborador.Nome, colaborador.TrabalhaHoje);
            }
        }

        private void refreshDatas() {
            loadUltimasEscalasDataGridView();
            buscarDataUltimaEscalaGerada();
            loadAndProcessFilasRecent();
            definirEscalaHojeEAtualizarProximaEscalaFutura();
            atualizarLabelFilasPresent();
            atualizarLabelFuturasFilas();
        }

        private void configurePropertiesDataGridView(DataGridView dgv) {
            // Oculta a coluna de cabe�alho de linha (seletor)
            dgv.RowHeadersVisible = false;
            // Definir a altura das linhas
            dgv.RowTemplate.Height = 20; // Altere para a altura desejada
            // Dados preencher todo espa�o do grid
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // N�o permitir alterar a altura das linhas
            dgv.AllowUserToResizeRows = false;

            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = true;

            // Definir o estilo de c�lula para cabe�alhos em negrito
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);


            // Definir o estilo de c�lula para linhas com cores alternadas
            dgv.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // Definir a cor da borda do DataGridView
            dgv.GridColor = Color.LightGray;

            // Definir o estilo de borda para c�lulas
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        private void definirEscalaHojeEAtualizarProximaEscalaFutura() {
            //deve ter ao menos 1 colaborador de 6h no ATL e JFK
            ATL_work = new List<Colaborador>();
            JFK_work = new List<Colaborador>();

            fila_PIER_Future = fila_PIER_Present.ToList();
            fila_ATL_Future = fila_ATL_Present.ToList();

            Colaborador? HojeATLde6h = fila_ATL_Present.FirstOrDefault(c => c.TrabalhaHoje && c.HorasTrabalho == 6);
            if (HojeATLde6h != null)
                ATL_work.Add(HojeATLde6h);

            Colaborador HojeJFKde6h;
            //se tiver mais de 2 cara de 6h, definir o pier de forma justa e jogar o outro no JFK
            if (colaboradores.Where(c => c.TrabalhaHoje && c.HorasTrabalho == 6).Count() > 2) {
                PIER_work = fila_PIER_Future.First(c => c.TrabalhaHoje && !ATL_work.Contains(c));
                //b.o aqui duplicando rubbens
                HojeJFKde6h = fila_ATL_Future.Last(c => c.TrabalhaHoje && c.HorasTrabalho == 6 && c.Nome != HojeATLde6h.Nome && c.Nome != PIER_work.Nome);
            } else { //senao joga o que sobrou no JFK e o pier � o proximo da fila que nao seja ele.
                HojeJFKde6h = fila_ATL_Future.Last(c => c.TrabalhaHoje && c.HorasTrabalho == 6 && c.Nome != HojeATLde6h.Nome);
                PIER_work = fila_PIER_Future.First(c => c.TrabalhaHoje && !ATL_work.Contains(c) && c.Nome != HojeJFKde6h.Nome);
            }
            JFK_work.Add(HojeJFKde6h);

            //se tiver alguem que trabalha depois da 19h, s� fara o pier ou 104
            var colaboradorQueEntraApos19hDisponivel = colaboradores.Where(c =>
                c.Entrada.Value.Hour >= 19 &&
                c.TrabalhaHoje &&
                c.Nome != PIER_work.Nome);

            if (colaboradorQueEntraApos19hDisponivel.Count() == 1) {
                ATL_work.Add(colaboradorQueEntraApos19hDisponivel.First());
            }

            //adiciona o restante da fila para trabalhar no voo 104 quem nao est� no ATL, JFK e Pier
            var doisPrimeirosFilaATL = fila_ATL_Future.Where(c =>
                c.TrabalhaHoje &&
                c.Nome != HojeATLde6h.Nome &&
                c.Nome != HojeJFKde6h.Nome &&
                c.Nome != PIER_work.Nome
                ).Take(2);
            ATL_work.AddRange(doisPrimeirosFilaATL);

            // Movendo quem ta trabalhando no ATL para o final da fila ATL pela sequencia
            var ATL_work_sequence = fila_ATL_Future.ToList();
            ATL_work_sequence.RemoveAll(colaborador => !ATL_work.Contains(colaborador));
            fila_ATL_Future.RemoveAll(colaborador => ATL_work.Contains(colaborador));
            fila_ATL_Future.AddRange(ATL_work_sequence);

            //adiciona o restante pela sequencia para trabalhar no voo 226
            var sobra_JFK = fila_ATL_Future.Where(c =>
            c.TrabalhaHoje &&
            c.Nome != HojeJFKde6h.Nome &&
            c.Nome != PIER_work.Nome &&
            !ATL_work.Contains(c)
            );

            JFK_work.AddRange(sobra_JFK);
            //o pier vai para o final da fila PIER
            fila_PIER_Future.Remove(PIER_work);
            fila_PIER_Future.Add(PIER_work);


            string saudacao = DateTime.Now.Hour < 12 ? "Bom dia" : (DateTime.Now.Hour < 18 ? "Boa tarde" : "Boa noite");

            string texto = $@"{saudacao} senhores.
Escala de {DateTime.Now.ToString("dddd", new CultureInfo("pt-BR"))} {dataProximaEscala.ToString("dd/MM")}
Pier: 
  {PIER_work.Nome}
226: 
  {string.Join("\r\n  ", JFK_work.Select(c => c.Nome))}
104: 
  {string.Join("\r\n  ", ATL_work.Select(c => c.Nome))}
";
            rtxtProximaEscala.Text = texto;

            atualizarLabelFuturasFilas();

        }

        private void atualizarLabelFuturasFilas() {
            rtxtFuturaFilaATL.Text = string.Join("\r\n", fila_ATL_Future.Select(c => c.Nome));
            rtxtFuturaFilaPIER.Text = string.Join("\r\n", fila_PIER_Future.Select(c => c.Nome));
        }

        private void atualizarLabelFilasPresent() {
            richTextBoxFILAATL.Text = string.Join("\r\n", fila_ATL_Present.Select(c => c.Nome));
            richTextBoxFILAPIER.Text = string.Join("\r\n", fila_PIER_Present.Select(c => c.Nome));
        }

        private void checkedListBox1TrabalhaHoje_ItemCheck(object sender, ItemCheckEventArgs e) {
            // Atualizando a propriedade Ativo da Pessoa quando o estado do item � alterado
            if (e.Index >= 0 && e.Index < colaboradores.Count) {
                bool trampaHoje = e.NewValue == CheckState.Checked;
                colaboradores[e.Index].TrabalhaHoje = trampaHoje;
                if (!trampaHoje) {
                    HighlightSearchText(colaboradores[e.Index].Nome, richTextBoxFILAATL, Color.Red);
                    HighlightSearchText(colaboradores[e.Index].Nome, richTextBoxFILAPIER, Color.Red);
                } else {
                    HighlightSearchText(colaboradores[e.Index].Nome, richTextBoxFILAATL, richTextBoxFILAPIER.ForeColor);
                    HighlightSearchText(colaboradores[e.Index].Nome, richTextBoxFILAPIER, richTextBoxFILAPIER.ForeColor);
                }
            }

            definirEscalaHojeEAtualizarProximaEscalaFutura();
        }

        private void cadastrarFuncionarioToolStripMenuItem_Click(object sender, EventArgs e) {
            FormColaborador frmColaborador = new FormColaborador();
            frmColaborador.Show();
        }

        private void HighlightSearchText(string searchText, RichTextBox control, Color color) {
            // Make all text black first
            //control.SelectionStart = 0;
            //control.SelectionLength = control.Text.Length;
            //control.SelectionColor = System.Drawing.SystemColors.ControlText;

            // Return if search text isn't found
            var selStart = control.Text.IndexOf(searchText);
            if (selStart < 0 || searchText.Length == 0) return;

            // Otherwise, highlight the search text
            control.SelectionStart = selStart;
            control.SelectionLength = searchText.Length;
            control.SelectionColor = color;
        }

        private void loadColaboradores() {
            colaboradores = new List<Colaborador>();
            try {
                using (SQLiteConnection connection = new SQLiteConnection(Form1.connectionString)) {
                    connection.Open();
                    string query = "SELECT * FROM Colaborador;";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection)) {
                        using (SQLiteDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                DateTime entrada = (DateTime)reader["hora_entrada"];
                                DateTime saida = (DateTime)reader["hora_saida"];
                                DateTime ultimoDiaFolga = (DateTime)reader["ultimo_dia_folga"];

                                Colaborador colaborador = new Colaborador();
                                colaborador.Id = Convert.ToInt32(reader["id"]);
                                colaborador.Nome = (string)reader["nome"];
                                colaborador.Entrada = new TimeOnly(entrada.Hour, entrada.Minute);
                                colaborador.Saida = new TimeOnly(saida.Hour, saida.Minute);
                                colaborador.UltimoDiaFolga = new DateOnly(ultimoDiaFolga.Year, ultimoDiaFolga.Month, ultimoDiaFolga.Day);

                                colaboradores.Add(colaborador);
                            }
                        }
                    }
                    connection.Close();
                }
            } catch (Exception ex) {
                MessageBox.Show("Ocorreu um erro ao obter os dados dos colaboradores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadUltimasEscalasDataGridView() {
            configurePropertiesDataGridView(dataGridView1);



            DataTable dataTable = new DataTable();
            try {
                using (SQLiteConnection connection = new SQLiteConnection(Form1.connectionString)) {
                    // Abrir a conex�o com o banco de dados
                    connection.Open();

                    // Comando SQL para selecionar todos os colaboradores
                    string query = @"
                            SELECT 
                                CASE strftime('%w', ct.data)
                                        WHEN '0' THEN 'Dom'
                                        WHEN '1' THEN 'Seg'
                                        WHEN '2' THEN 'Ter'
                                        WHEN '3' THEN 'Qua'
                                        WHEN '4' THEN 'Qui'
                                        WHEN '5' THEN 'Sex'
                                        WHEN '6' THEN 'S�b'
                                        ELSE NULL
                                    END AS Dia,
                                strftime('%d/%m/%Y', ct.data) AS Data,
                                GROUP_CONCAT(DISTINCT CASE WHEN ct.local_trabalho = 'PIER' THEN c.nome ELSE NULL END) AS PIER,
                                GROUP_CONCAT(DISTINCT CASE WHEN ct.local_trabalho = 'ATL' THEN ' ' || c.nome  ELSE NULL END) AS ATL,
                                GROUP_CONCAT(DISTINCT CASE WHEN ct.local_trabalho = 'JFK' THEN ' ' || c.nome ELSE NULL END) AS JFK
                            FROM 
                                ColaboradorTrabalho ct
                            LEFT JOIN 
                                Colaborador c ON ct.id_colaborador = c.id
                            GROUP BY 
                                DATE(ct.data)
                            ORDER BY 
                                ct.data DESC;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection)) {
                        using (SQLiteDataReader reader = command.ExecuteReader()) {
                            // Carregar os dados do DataReader para o DataTable
                            dataTable.Load(reader);
                        }
                    }

                    // Fechar a conex�o com o banco de dados
                    connection.Close();

                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns["Data"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns["Data"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DefinirTamanhoPercentualColunasModeFILL(dataGridView1,
                                   ("Dia", 8),
                                   ("Data", 12),
                                   ("PIER", 12),
                                   ("ATL", 30),
                                   ("JFK", 30)
                               );
                }
            } catch (Exception ex) {
                MessageBox.Show("Ocorreu um erro ao obter os dados dos colaboradores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Define a fila recente com base nos ultimos registros.
        private void loadAndProcessFilasRecent() {
            fila_ATL_Present = colaboradores.ToList();
            fila_PIER_Present = colaboradores.ToList();
            try {
                using (SQLiteConnection connection = new SQLiteConnection(Form1.connectionString)) {
                    connection.Open();
                    //os 100 ultimos registros da data mais recente para o passado.
                    string query = @"
                                    SELECT ultimos_registros.*, colaborador.nome
                                    FROM (
                                        SELECT *
                                        FROM ColaboradorTrabalho
                                        ORDER BY data DESC
                                        LIMIT 100
                                    ) AS ultimos_registros
                                    INNER JOIN Colaborador ON ultimos_registros.id_colaborador = colaborador.id
                                    ORDER BY ultimos_registros.data ASC;
                                    ";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection)) {
                        using (SQLiteDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                string nome = (string)reader["nome"];
                                string local_trabalhou = (string)reader["local_trabalho"];

                                Colaborador? colaborador = colaboradores.Find(c => c.Nome == nome);
                                if (colaborador != null) {
                                    //quem j� trabalhou nestes vai para o fim da fila.                                    
                                    if (local_trabalhou.Equals("PIER")) {
                                        fila_PIER_Present.Remove(colaborador);
                                        fila_PIER_Present.Add(colaborador);
                                    } else if (local_trabalhou.Equals("ATL")) {
                                        fila_ATL_Present.Remove(colaborador);
                                        fila_ATL_Present.Add(colaborador);
                                    }
                                }
                            }
                        }
                    }
                    connection.Close();
                }
            } catch (Exception ex) {
                MessageBox.Show("Ocorreu um erro ao obter os dados dos colaboradores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CriarBancoDados() {
            // Conex�o com o banco de dados
            using (var conexao = new SQLiteConnection(connectionString)) {
                conexao.Open();

                // Cria��o da tabela Colaborador
                using (var cmd = new SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS Colaborador (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "nome TEXT," +
                    "hora_entrada DATETIME," +
                    "hora_saida DATETIME," +
                    "ultimo_dia_folga DATE)", conexao)) {
                    cmd.ExecuteNonQuery();
                }

                // Cria��o da tabela ColaboradorTrabalho
                using (var cmd = new SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS ColaboradorTrabalho (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "id_colaborador INTEGER," +
                    "local_trabalho TEXT," +
                    "data DATE," +
                    "FOREIGN KEY (id_colaborador) REFERENCES Colaborador(id))", conexao)) {
                    cmd.ExecuteNonQuery();
                }

                //default insert
                using (var cmd = new SQLiteCommand(@"
INSERT OR IGNORE INTO Colaborador (id, nome, hora_entrada, hora_saida, ultimo_dia_folga) 
    VALUES 
    (1, 'CAIO', '18:30', '22:30', '2024-03-16'),
    (2, 'LUCIUS', '18:30', '22:30', '2024-03-18'),
    (3, 'ROMARIO', '18:00', '22:00', '2024-03-18'),
    (4, 'LEONARDO', '19:00', '23:00', '2024-03-16'),
    (5, 'WESLEY', '17:50', '21:50', '2024-03-16'),
    (6, 'AZEVEDO', '17:00', '23:00', '2024-03-16'),
    (7, 'RUBENS', '17:00', '23:00', '2024-03-16'),
    (8, 'IGOR', '17:00', '23:00', '2024-03-16')
", conexao)) {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private DateOnly buscarDataUltimaEscalaGerada() {
            string query = "SELECT MAX(data) FROM ColaboradorTrabalho";
            using (SQLiteConnection connection = new SQLiteConnection(Form1.connectionString)) {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection)) {
                    string dateTimeString = (string)command.ExecuteScalar();
                    DateOnly dataUltimaEscala = DateOnly.ParseExact(dateTimeString, "yyyy-MM-dd", null);
                    dataProximaEscala = dataUltimaEscala.AddDays(1);
                    DateOnly hoje = DateOnly.FromDateTime(DateTime.Today);
                    lblInfoCheckbox.Text = $"Quem trabalha {(dataProximaEscala == hoje ? "Hoje" : "")}\r\n{dataProximaEscala}";

                    return dataUltimaEscala;
                }
            }
        }

        private void InserirEscala() {
            DateOnly dataUltimaEscalaGerada = buscarDataUltimaEscalaGerada();
            DateOnly dataProximaEscala = dataUltimaEscalaGerada.AddDays(1);

            using (var conexao = new SQLiteConnection(connectionString)) {
                conexao.Open();

                using (var cmd = new SQLiteCommand(
                    "INSERT INTO ColaboradorTrabalho (id_colaborador, local_trabalho, data) " +
                    "VALUES (@idColaborador, @localTrabalho, @data)", conexao)) {

                    string dataProximaEscalaStr = dataProximaEscala.ToString("yyyy-MM-dd");

                    cmd.Parameters.AddWithValue("@idColaborador", PIER_work.Id);
                    cmd.Parameters.AddWithValue("@localTrabalho", "PIER");
                    cmd.Parameters.AddWithValue("@data", dataProximaEscalaStr);
                    cmd.ExecuteNonQuery();

                    foreach (var colaboradorTrabalhou in ATL_work) {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idColaborador", colaboradorTrabalhou.Id);
                        cmd.Parameters.AddWithValue("@localTrabalho", "ATL");
                        cmd.Parameters.AddWithValue("@data", dataProximaEscalaStr);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (var colaboradorTrabalhou in JFK_work) {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idColaborador", colaboradorTrabalhou.Id);
                        cmd.Parameters.AddWithValue("@localTrabalho", "JFK");
                        cmd.Parameters.AddWithValue("@data", dataProximaEscalaStr);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }
        private void btnSalvarEscala_Click(object sender, EventArgs e) {
            InserirEscala();
            refreshDatas();
        }

        private void btnEditar_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedCells.Count > 0) {
                DataGridViewCell firstCell = dataGridView1.SelectedCells[0];

                // Obt�m a linha da c�lula selecionada
                DataGridViewRow selectedRow = firstCell.OwningRow;
                string celulaData = (string)selectedRow.Cells["Data"].Value;
                DateOnly dataEscala = DateOnly.ParseExact(celulaData, "dd/MM/yyyy", null);

                FormEditarEscalas formEditarEscalas = new FormEditarEscalas(dataEscala);
                var dialogResult = formEditarEscalas.ShowDialog();
                if (dialogResult == DialogResult.OK) {
                    refreshDatas();
                }
            }
        }

        public void DefinirTamanhoPercentualColunasModeFILL(DataGridView dataGridView, params (string columnName, int percent)[] colunas) {
            //dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (var coluna in colunas) {
                if (dataGridView.Columns.Contains(coluna.columnName)) {
                    var dgvColumn = dataGridView.Columns[coluna.columnName];
                    dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvColumn.FillWeight = coluna.percent;
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            // Verifica se a c�lula atual pertence � coluna de data (substitua "DataColumnIndex" pelo �ndice da sua coluna de data)
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Data") {
                // Verifica se o valor da c�lula � uma data v�lida
                if (e.Value != null && DateTime.TryParse(e.Value.ToString(), out DateTime data)) {
                    // Verifica se a data � no futuro
                    if (data > DateTime.Now) {
                        // Aplica a cor da letra verde escuro
                        //e.CellStyle.ForeColor = Color.DarkGreen;
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedCells.Count < 1) {
                return;
            }
            // HashSet n�o ir� duplicar o valor.
            HashSet<DateOnly> datasSelecionadas = new HashSet<DateOnly>();
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells) {
                // Obt�m a linha da c�lula selecionada
                DataGridViewRow selectedRow = cell.OwningRow;
                var cellDate = selectedRow.Cells["Data"];
                //Obt�m o valor da c�lula como uma data e adiciona em hashSet
                if (cellDate.Value != null && DateOnly.TryParse(cellDate.Value.ToString(), out DateOnly data)) {
                    datasSelecionadas.Add(data);
                }
            }
            var datasStr = string.Join(Environment.NewLine, datasSelecionadas);

            var dialogResult = MessageBox.Show($"Certeza que deseja excluir a escalas seguintes:\r\n{datasStr}", "Confirme", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) {
                return;
            }


            using (var conexao = new SQLiteConnection(Form1.connectionString)) {
                conexao.Open();
                string query = $"DELETE FROM ColaboradorTrabalho WHERE data = @data";
                using (var cmd = new SQLiteCommand(query, conexao)) {
                    foreach (var dataEscala in datasSelecionadas) {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@data", dataEscala.ToString("yyyy-MM-dd"));
                            cmd.ExecuteNonQuery();                       
                    }
                }
                refreshDatas();
            }
        }
    }
}