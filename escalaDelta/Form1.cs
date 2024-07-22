using escalaDelta.Utils;
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
           [x] O Pier é Rotativo
           [x] O Voo ATL é Rotativo
           [ ] Quem entrar as 19h só irá trabalhar no Pier ou ATL           

        Algoritimo:
            O algoritimo se baseia em filas,
            Foi criado 2 filas ATL e PIER
            O primeiro da fila do PIER fará o pier e irá para o fim da fila.
             Salvo se o primeiro da fila, somente se for o único de 6h para fazer o ATL.
            Os primeiros da fila ATL farão o VOO
     */

    public partial class Form1 : Form {

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

        private ListBox listBoxOrigem;


        public Form1() {
            InitializeComponent();

            CriarBancoDados();
            loadColaboradores();

            //configuração listbox
            listBoxTrabalha.AllowDrop = true;
            listBoxFolga.AllowDrop = true;
            listBoxOutros.AllowDrop = true;
            listBoxTrabalha.DisplayMember = "Nome";
            listBoxFolga.DisplayMember = "Nome";
            listBoxOutros.DisplayMember = "Nome";

            ExtensionsDataGridView.configurePropertiesDataGridView(dataGridView1);

            //atualiza a propriedade Trabalha de cada colaborador de acordo com a ultima folga
            refreshDatas();
            //Após carregar os dados no datagrid view definindo largura colunas
            dataGridView1.Columns["Data"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Data"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefinirTamanhoPercentualColunasModeFILL(
                           ("Dia", 8),
                           ("Data", 12),
                           ("PIER", 12),
                           ("ATL", 30),
                           ("JFK", 30),
                           ("FOLGA", 25)
           );
        }

        private void refreshDatas() {
            loadUltimasEscalasDataGridView();
            buscarDataUltimaEscalaGerada();
            //passar datas por parametro. +mais controle;
            definirColaboraderesAusenteFolga();
            definirColaboradoresAusenteOutros();
            popularListsBoxes();

            loadSetUpQueueATLandPIER();
            definirEscalaHojeEAtualizarProximaEscalaFutura();
            atualizarRithTextBoxFilasPresent();
            atualizarRichTextBoxFuturasFilas();
            PintarTrabalhadoresENaoTrabalhadores();
        }

        private void popularListsBoxes() {
            // Configurando o listboxes
            listBoxTrabalha.Items.Clear();
            listBoxFolga.Items.Clear();
            listBoxOutros.Items.Clear();
            foreach (var colaborador in colaboradores) {
                if (colaborador.NaoTrabalhaPorOutrosMotivos) {
                    listBoxOutros.Items.Add(colaborador);
                } else if (colaborador.Folga) {
                    listBoxFolga.Items.Add(colaborador);
                } else {
                    listBoxTrabalha.Items.Add(colaborador);
                }
            }
        }
                

        private void definirColaboradoresAusenteOutros() {
            foreach (Colaborador colaborador in colaboradores) {
                using (SQLiteConnection connection = new SQLiteConnection(Form1.connectionString)) {
                    connection.Open();
                    string query = $"select local_trabalho from ColaboradorTrabalho where id_colaborador = {colaborador.Id} order by data desc limit 1";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection)) {
                        string ultimoLocalTrabalho = (string)command.ExecuteScalar();
                        colaborador.NaoTrabalhaPorOutrosMotivos = ultimoLocalTrabalho == "OUTROS";
                    }
                }
            }
        }

        private void definirColaboraderesAusenteFolga() {
            //verificar quem folga na escala a ser gerada
            foreach (Colaborador colaborador in colaboradores) {
                colaborador.Folga = EstaDeFolga6x16x2(dataProximaEscala, colaborador.DataBaseFolga1Dia);
            };
        }

        private void definirEscalaHojeEAtualizarProximaEscalaFutura() {

            //deve ter ao menos 1 colaborador de 6h no ATL e JFK
            PIER_work = null;
            ATL_work = new List<Colaborador>();
            JFK_work = new List<Colaborador>();

            fila_PIER_Future = fila_PIER_Present.ToList();
            fila_ATL_Future = fila_ATL_Present.ToList();

                        
            var todosDe6hQueTrabalhara = colaboradores.Where(c => c.Trabalha && c.HorasTrabalho == 6);
            Colaborador? HojeATLde6h = null;
            Colaborador? HojeJFKde6h = null;
            TimeOnly h17m00 = new TimeOnly(17, 0);

            if (colaboradores.Count(c => c.Trabalha) >= 7) {
                //antes, pq se for o dia dele do pier, dar preferencia para ele ficar no JFK neste dia coitado.
                TimeOnly h18m30 = new TimeOnly(18, 30);
                Colaborador? coitadoQueFicaMaisNoAtl = colaboradores.LastOrDefault(c => c.Trabalha && c.Entrada >= h18m30);
                if (coitadoQueFicaMaisNoAtl != null) {
                    JFK_work.Add(coitadoQueFicaMaisNoAtl);
                }
            }

            if (todosDe6hQueTrabalhara.Count() > 2) {
                //se ao menos 3 de 6h trabalharao, definir primeiro o pier Justamente.
                PIER_work = fila_PIER_Present.First(c => c.Trabalha && !JFK_work.Contains(c)); ;                
                HojeATLde6h = fila_ATL_Present.FirstOrDefault(c => c.Trabalha && c.HorasTrabalho == 6 && c.Nome != PIER_work.Nome);
                HojeJFKde6h = fila_ATL_Present.LastOrDefault(c => c.Trabalha && c.HorasTrabalho == 6 && c.Nome != HojeATLde6h?.Nome && c.Nome != PIER_work.Nome);                    
            } else {
                HojeATLde6h = fila_ATL_Present.FirstOrDefault(c => c.Trabalha && c.HorasTrabalho == 6);
                HojeJFKde6h = fila_ATL_Present.LastOrDefault(c => c.Trabalha && c.Entrada <= h17m00 && c.Nome != HojeATLde6h?.Nome);
                PIER_work = fila_PIER_Present.FirstOrDefault(c => c.Trabalha && c.Nome != HojeATLde6h?.Nome && c.Nome != HojeJFKde6h?.Nome);
            }
            if (HojeATLde6h != null) {
                ATL_work.Add(HojeATLde6h);
            }
            if (HojeJFKde6h != null) {
                JFK_work.Add(HojeJFKde6h);
            }

            //se tiver alguem que trabalha depois da 18:30h, só fara o pier ou 104
            var colaboradorQueEntraApos19hDisponivel = colaboradores.Where(c =>
                c.Entrada?.Hour >= 18 && c.Entrada?.Minute >= 30 &&
                c.Trabalha &&
                c.Nome != PIER_work.Nome &&
                !ATL_work.Contains(c) &&
                !JFK_work.Contains(c));

            if (colaboradorQueEntraApos19hDisponivel.Count() == 1) {
                ATL_work.Add(colaboradorQueEntraApos19hDisponivel.First());
            }
            //calculo para dividir a equipe caso ultrapasse de 3 colaborador pra cada
            int qtnTrabalhara = colaboradores.Count(c => c.Trabalha);
            int qtdSobra = qtnTrabalhara % 2;
           
            //adiciona o restante da fila para trabalhar no voo 104 quem nao está no ATL, JFK e Pier
            var doisPrimeirosFilaATL = fila_ATL_Future.Where(c =>
                c.Trabalha &&
                c.Nome != PIER_work?.Nome &&
                !ATL_work.Contains(c) &&
                !JFK_work.Contains(c) 
                ).Take(((qtnTrabalhara - qtdSobra) / 2) - ATL_work.Count); //divisao de turma, caso impar ATL ficará 1 a mais.
            ATL_work.AddRange(doisPrimeirosFilaATL);

            // Movendo quem ta trabalhando no ATL para o final da fila ATL pela sequencia
            var ATL_work_sequence = fila_ATL_Future.ToList();
            ATL_work_sequence.RemoveAll(colaborador => !ATL_work.Contains(colaborador));
            fila_ATL_Future.RemoveAll(colaborador => ATL_work.Contains(colaborador));
            fila_ATL_Future.AddRange(ATL_work_sequence);

            //adiciona o restante pela sequencia para trabalhar no voo 226
            var sobra_JFK = fila_ATL_Future.Where(c =>
                c.Trabalha &&
                c.Nome != PIER_work?.Nome &&
                !JFK_work.Contains(c) &&
                !ATL_work.Contains(c)
                );
            JFK_work.AddRange(sobra_JFK);

            //o pier vai para o final da fila PIER
            fila_PIER_Future.Remove(PIER_work);
            fila_PIER_Future.Add(PIER_work);

            string saudacao = DateTime.Now.Hour < 12 ? "Bom dia" : (DateTime.Now.Hour < 18 ? "Boa tarde" : "Boa noite");            string texto =
$@"Escala de {dataProximaEscala.ToString("ddd", new CultureInfo("pt-BR"))} {dataProximaEscala.ToString("dd/MM")}
Pier: 
  {PIER_work.Nome}
226: 
  {string.Join("\r\n  ", JFK_work.Select(c => c.Nome))}
104: 
  {string.Join("\r\n  ", ATL_work.Select(c => c.Nome))}
";
            rtxtProximaEscala.Text = texto;
            atualizarRichTextBoxFuturasFilas();
        }

        private void atualizarRichTextBoxFuturasFilas() {
            rtxtFuturaFilaATL.Text = string.Join("\r\n", fila_ATL_Future.Select(c => c.Nome));
            rtxtFuturaFilaPIER.Text = string.Join("\r\n", fila_PIER_Future.Select(c => c.Nome));
        }

        private void atualizarRithTextBoxFilasPresent() {
            richTextBoxFILAATL.Text = string.Join("\r\n", fila_ATL_Present.Select(c => c.Nome));
            richTextBoxFILAPIER.Text = string.Join("\r\n", fila_PIER_Present.Select(c => c.Nome));
        }

        private void ListBox_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        // Evento DragDrop para todos os ListBoxes
        private void ListBox_DragDrop(object sender, DragEventArgs e) {
            ListBox listBoxDestino = sender as ListBox;
            Colaborador colaboradorItem = e.Data.GetData(typeof(Colaborador)) as Colaborador;                      

            // Move o item da ListBox de origem para a ListBox de destino
            listBoxOrigem.Items.Remove(colaboradorItem);
            listBoxDestino.Items.Add(colaboradorItem);


            colaboradorItem.Folga = listBoxDestino == listBoxFolga;
            colaboradorItem.NaoTrabalhaPorOutrosMotivos = listBoxDestino == listBoxOutros;
            PintarTrabalhadoresENaoTrabalhadores();
            definirEscalaHojeEAtualizarProximaEscalaFutura();

        }

        // Evento MouseDown para iniciar o arrastar para todos os ListBoxes
        private void listBox_MouseDown(object sender, MouseEventArgs e) {
            ListBox listBox = sender as ListBox;
            int index = listBox.IndexFromPoint(e.X, e.Y);
            if (index != ListBox.NoMatches) {
                object selectedItem = listBox.Items[index];

                // Armazena a ListBox de origem
                listBoxOrigem = listBox;

                // Define os dados de arrastar e soltar
                listBox.DoDragDrop(selectedItem, DragDropEffects.Move);
            }
        }

        private void listBoxFolga_SelectedIndexChanged(object sender, EventArgs e) {
            //MessageBox.Show("SelectedIndexChanged");
            
        }

        private void PintarTrabalhadoresENaoTrabalhadores() {
            foreach (Colaborador colaborador in colaboradores) {
                if (colaborador.Trabalha) {
                    HighlightSearchText(colaborador.Nome, richTextBoxFILAATL, richTextBoxFILAPIER.ForeColor);
                    HighlightSearchText(colaborador.Nome, richTextBoxFILAPIER, richTextBoxFILAPIER.ForeColor);
                } else {
                    HighlightSearchText(colaborador.Nome, richTextBoxFILAATL, Color.Red);
                    HighlightSearchText(colaborador.Nome, richTextBoxFILAPIER, Color.Red);
                }
            }
        }

        //private void checkedListBox1TrabalhaHoje_ItemCheck(object sender, ItemCheckEventArgs e) {
        //    // Atualizando a propriedade Ativo da Pessoa quando o estado do item é alterado
        //    if (e.Index >= 0 && e.Index < colaboradores.Count) {
        //        bool trampaHoje = e.NewValue == CheckState.Checked;
        //        colaboradores[e.Index].Trabalha = trampaHoje;
        //        if (!trampaHoje) {
        //            HighlightSearchText(colaboradores[e.Index].Nome, richTextBoxFILAATL, Color.Red);
        //            HighlightSearchText(colaboradores[e.Index].Nome, richTextBoxFILAPIER, Color.Red);
        //        } else {
        //            HighlightSearchText(colaboradores[e.Index].Nome, richTextBoxFILAATL, richTextBoxFILAPIER.ForeColor);
        //            HighlightSearchText(colaboradores[e.Index].Nome, richTextBoxFILAPIER, richTextBoxFILAPIER.ForeColor);
        //        }
        //    }

        //    definirEscalaHojeEAtualizarProximaEscalaFutura();
        //}

        private void cadastrarFuncionarioToolStripMenuItem_Click(object sender, EventArgs e) {
            FormColaborador frmColaborador = new FormColaborador();
            frmColaborador.ShowDialog();
            loadColaboradores();
            refreshDatas();
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
                    string query = "SELECT * FROM Colaborador WHERE deletado IS NULL;";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection)) {
                        using (SQLiteDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                DateTime entrada = (DateTime)reader["hora_entrada"];
                                DateTime saida = (DateTime)reader["hora_saida"];
                                DateOnly dataFolgaBase =  DateOnly.FromDateTime((DateTime)reader["data_dia_folga_unica"]);
                                //DateTime ultimoDiaFolga = (DateTime)reader["ultimo_dia_folga"];

                                Colaborador colaborador = new Colaborador();
                                colaborador.Id = Convert.ToInt32(reader["id"]);
                                colaborador.Nome = (string)reader["nome"];
                                colaborador.Entrada = new TimeOnly(entrada.Hour, entrada.Minute);
                                colaborador.Saida = new TimeOnly(saida.Hour, saida.Minute);
                                colaborador.DataBaseFolga1Dia = dataFolgaBase;
                                //colaborador.UltimoDiaFolga = new DateOnly(ultimoDiaFolga.Year, ultimoDiaFolga.Month, ultimoDiaFolga.Day);

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
            DataTable dataTable = new DataTable();
            try {
                using (SQLiteConnection connection = new SQLiteConnection(Form1.connectionString)) {
                    // Abrir a conexão com o banco de dados
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
                                        WHEN '6' THEN 'Sáb'
                                        ELSE NULL
                                    END AS Dia,
                                strftime('%d/%m/%Y', ct.data) AS Data,
                                GROUP_CONCAT(DISTINCT CASE WHEN ct.local_trabalho = 'PIER' THEN c.nome ELSE NULL END) AS PIER,
                                GROUP_CONCAT(DISTINCT CASE WHEN ct.local_trabalho = 'ATL' THEN ' ' || c.nome  ELSE NULL END) AS ATL,
                                GROUP_CONCAT(DISTINCT CASE WHEN ct.local_trabalho = 'JFK' THEN ' ' || c.nome ELSE NULL END) AS JFK,
                                GROUP_CONCAT(DISTINCT CASE WHEN ct.local_trabalho = 'FOLGA' THEN c.nome  ELSE NULL END) AS FOLGA
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
                    // Fechar a conexão com o banco de dados
                    connection.Close();

                    dataGridView1.DataSource = dataTable;                    
                }
            } catch (Exception ex) {
                MessageBox.Show("Ocorreu um erro ao obter os dados dos colaboradores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Define a fila recente com base nos ultimos registros.
        private void loadSetUpQueueATLandPIER() {
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
                                        AND colaborador.deletado IS NULL
                                    ORDER BY ultimos_registros.data ASC;
                                    ";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection)) {
                        using (SQLiteDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                string nome = (string)reader["nome"];
                                string local_trabalhou = (string)reader["local_trabalho"];

                                Colaborador? colaborador = colaboradores.Find(c => c.Nome == nome);
                                if (colaborador != null) {
                                    //quem já trabalhou nestes vai para o fim da fila.                                    
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
            // Conexão com o banco de dados
            using (var conexao = new SQLiteConnection(connectionString)) {
                conexao.Open();

                // Criação da tabela Colaborador
                using (var cmd = new SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS Colaborador (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "nome TEXT," +
                    "hora_entrada DATETIME," +
                    "hora_saida DATETIME," +
                    "data_dia_folga_unica DATE," +
                    "deletado DATE)", conexao)) {
                    cmd.ExecuteNonQuery();
                }

                // Criação da tabela ColaboradorTrabalho
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
INSERT OR IGNORE INTO Colaborador (id, nome, hora_entrada, hora_saida, data_dia_folga_unica) 
    VALUES 
    (1, 'CAIO', '18:30', '22:30', '2024-03-16'),
    (2, 'LUCIUS', '18:30', '22:30', '2024-03-17'),
    (3, 'ROMARIO', '18:00', '22:00', '2024-03-18'),
    (4, 'LEONARDO', '19:00', '23:00', '2024-03-19'),
    (5, 'WESLEY', '17:50', '21:50', '2024-03-20'),
    (6, 'AZEVEDO', '17:00', '23:00', '2024-03-21'),
    (7, 'RUBENS', '17:00', '23:00', '2024-03-22'),
    (8, 'IGOR', '17:00', '23:00', '2024-03-23')
", conexao)) {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void buscarDataUltimaEscalaGerada() {
            string query = "SELECT MAX(data) FROM ColaboradorTrabalho";
            using (SQLiteConnection connection = new SQLiteConnection(Form1.connectionString)) {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection)) {
                    string dateTimeString = command.ExecuteScalar().ToString();
                    if (string.IsNullOrEmpty(dateTimeString)) {
                        dataProximaEscala = DateOnly.FromDateTime(DateTime.Today);
                    } else {
                        DateOnly dataUltimaEscala = DateOnly.ParseExact(dateTimeString, "yyyy-MM-dd", null);
                        dataProximaEscala = dataUltimaEscala.AddDays(1);
                    }
                    DateOnly hoje = DateOnly.FromDateTime(DateTime.Today);
                    lblInfoCheckbox.Text = $"Quem trabalha {(dataProximaEscala == hoje ? "Hoje" : "")}\r\n{dataProximaEscala}";
                }
            }
        }

        private void InserirEscala() {
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

                    foreach (Colaborador colaborador in listBoxFolga.Items) {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idColaborador", colaborador.Id);
                        cmd.Parameters.AddWithValue("@localTrabalho", "FOLGA");
                        cmd.Parameters.AddWithValue("@data", dataProximaEscalaStr);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (Colaborador colaborador in listBoxOutros.Items) {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idColaborador", colaborador.Id);
                        cmd.Parameters.AddWithValue("@localTrabalho", "OUTROS");
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

                // Obtém a linha da célula selecionada
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            // Verifica se a célula atual pertence à coluna de data (substitua "DataColumnIndex" pelo índice da sua coluna de data)
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Data") {
                // Verifica se o valor da célula é uma data válida
                if (e.Value != null && DateTime.TryParse(e.Value.ToString(), out DateTime data)) {
                    // Verifica se a data é no futuro
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
            // HashSet não irá duplicar o valor.
            HashSet<DateOnly> datasSelecionadas = new HashSet<DateOnly>();
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells) {
                // Obtém a linha da célula selecionada
                DataGridViewRow selectedRow = cell.OwningRow;
                var cellDate = selectedRow.Cells["Data"];
                //Obtém o valor da célula como uma data e adiciona em hashSet
                if (cellDate.Value != null && DateOnly.TryParse(cellDate.Value.ToString(), out DateOnly data)) {
                    datasSelecionadas.Add(data);
                }
            }
            //ordenando
            List<DateOnly> datasList = new List<DateOnly>(datasSelecionadas);
            datasList.Sort();
            
            int numColunas = datasList.Count > 100 ? 5 : 
                             (datasList.Count > 50 ? 4 : 
                             (datasList.Count > 30 ? 3 : 2) ); 
            string message = FormatItems(datasList, numColunas);

            //var datasStr = string.Join(Environment.NewLine, datasSelecionadas);

            var dialogResult = MessageBox.Show($"Certeza que deseja excluir a escalas seguintes:\r\n{message}", "Confirme", MessageBoxButtons.YesNo);
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

        private void btnGerarAte_Click(object sender, EventArgs e) {
            DateOnly dataGerarAte = DateOnly.FromDateTime(dateTimePicker1.Value);
            DateOnly ultimaEscalaGerada = dataProximaEscala;
            while (ultimaEscalaGerada <= dataGerarAte) {
                ultimaEscalaGerada = ultimaEscalaGerada.AddDays(1);
                btnSalvarEscala.PerformClick();
            }
            //DateOnly ultimaFolgaUnica = new DateOnly(2024, 04, 12);
            //if (EstaDeFolga6x16x2(DateOnly.FromDateTime(dateTimePicker1.Value), ultimaFolgaUnica)) {
            //    MessageBox.Show("Está de folga");
            //}
            //dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
        }

        /// <summary>
        /// Verifica se em determinada data seria folga na escala 6x1 6x2 com base em uma data Inicial.
        /// </summary>
        /// <param name="dataAVerificar"></param>
        /// <param name="ultimaFolgaUnica">Data de uma folga sozinha, sem dobradinha</param>
        /// <returns></returns>
        static bool EstaDeFolga6x16x2(DateOnly dataAVerificar, DateOnly ultimaFolgaUnica) {
            var diferencaDias = Math.Abs(dataAVerificar.DayNumber - ultimaFolgaUnica.DayNumber);
            // A cada 15 dias ele folgara 1x denovo
            int diasFuturoSobra = diferencaDias % 15;
            //  A folga dobrada dele é no 7º e 8º Dia.
            if (diasFuturoSobra == 0 || diasFuturoSobra == 7 || diasFuturoSobra == 8) {
                //está de folga
                return true;
            } else { return false; }

        }

        private void calendarioToolStripMenuItem_Click(object sender, EventArgs e) {
            
        }

        private void btnShowInCalendar_Click(object sender, EventArgs e) {
            //Pega o ultimo mes do datagridview.

            // Verifica se há registros no DataGridView
            if (dataGridView1.Rows.Count > 0) {
                // Obtém o valor da primeira célula da coluna 'Data'
                string dataTexto = dataGridView1.Rows[0].Cells["Data"].Value.ToString();

                // Converte o texto da data para DateTime
                DateTime data;
                if (DateTime.TryParseExact(dataTexto, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out data)) {
                    FormCalendar fc = new FormCalendar(data.Month, data.Year);
                    fc.Show();
                }
            }
        }

        private static string FormatItems<T>(IEnumerable<T> items, int numColunas) {
            List<T> itemList = new List<T>(items);
            int partSize = (itemList.Count + numColunas - 1) / numColunas; // Arredondar para cima

            // Criação de listas de sublistas
            List<List<T>> colunas = new List<List<T>>();
            for (int i = 0; i < numColunas; i++) {
                int startIndex = i * partSize;
                int count = Math.Min(partSize, itemList.Count - startIndex);
                colunas.Add(itemList.GetRange(startIndex, count));
            }

            string formattedString = "";
            for (int i = 0; i < partSize; i++) {
                List<string> row = new List<string>();
                for (int j = 0; j < numColunas; j++) {
                    if (i < colunas[j].Count) {
                        row.Add(colunas[j][i]?.ToString() ?? "");
                    } else {
                        row.Add("");
                    }
                }
                formattedString += string.Join("\t", row) + "\n";
            }

            return formattedString;
        }
    }
}