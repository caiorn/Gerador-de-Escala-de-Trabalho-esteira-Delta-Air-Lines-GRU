using escalaDelta.Utils;
using System.Data.SQLite;
using System.Globalization;
using System.Transactions;

namespace escalaDelta {
    public partial class FormColaborador : Form {


        public int idEditing { get; set; }
        public enum state { INITIAL, NEW, EDIT }
        private state _stateForm;
        public state StateForm {
            get { return _stateForm; }
            set {
                _stateForm = value;
                dgvColaboradores.Enabled = value == state.INITIAL;

                if (value == state.INITIAL) {//New,Add,Save
                    idEditing = 0;
                    dgvColaboradores_SelectionChanged(dgvColaboradores, EventArgs.Empty);

                    btnNewInsertUpdate.Text = "New";
                    btnEditCancel.Text = "Edit";
                    btnNewInsertUpdate.Visible = true;
                    btnDelete.Visible = false;
                    EnableDisableEdits(false);

                } else {
                    btnEditCancel.Text = "Cancel";
                    if (value == state.NEW) {
                        textBox1.Clear();
                        btnNewInsertUpdate.Text = "Insert";
                    } else if (value == state.EDIT) {
                        if (idEditing == 0) {
                            throw new Exception("Atribua o id antes de mudar o estado do Grupo para Edicao");
                        }
                        btnNewInsertUpdate.Text = "Update";
                        btnDelete.Visible = true;
                    }
                    EnableDisableEdits(true);
                }
            }
        }

        public FormColaborador() {
            InitializeComponent();
            StateForm = state.INITIAL;

            dateTimePickerHoraEntrada.ShowUpDown = true;
            dateTimePickerHoraSaida.ShowUpDown = true;

            ExtensionsDataGridView.configurePropertiesDataGridView(dgvColaboradores);
            dgvColaboradores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvColaboradores.MultiSelect = false;

            dgvColaboradores.Columns.Add("Cód", "Cód");
            dgvColaboradores.Columns.Add("Nome", "Nome");
            dgvColaboradores.Columns.Add("Entrada", "Entrada");
            dgvColaboradores.Columns.Add("Saída", "Saída");
            dgvColaboradores.Columns.Add("Folga", "Folga");
            dgvColaboradores.Columns["Entrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvColaboradores.Columns["Saída"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvColaboradores.DefinirTamanhoPercentualColunasModeFILL(
                           ("Cód", 5),
                           ("Nome", 20),
                           ("Entrada", 10),
                           ("Saída", 10),
                           ("Folga", 10)
                           );
            CarregarConsultaDataGridView(dgvColaboradores);
            EnableDisableEdits(false);
        }

        private void CarregarConsultaDataGridView(DataGridView dgv) {
            dgv.Rows.Clear();
            try {
                using (SQLiteConnection connection = new SQLiteConnection(Form1.connectionString)) {
                    // Abrir a conexão com o banco de dados
                    connection.Open();

                    // Comando SQL para selecionar todos os colaboradores
                    string query = "SELECT id, nome, hora_entrada, hora_saida, strftime('%d/%m/%Y', data_dia_folga_unica) as data_dia_folga_unica FROM Colaborador WHERE deletado IS NULL";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection)) {
                        using (SQLiteDataReader reader = command.ExecuteReader()) {

                            // Lê os dados do SQLiteDataReader e os adiciona ao DataGridView
                            while (reader.Read()) {
                                // Extrai os valores das colunas "Entrada" e "Saída"
                                string id = reader["id"].ToString();
                                string nome = reader["nome"].ToString();
                                string entrada = reader["hora_entrada"].ToString();
                                string saida = reader["hora_saida"].ToString();
                                string folga = reader["data_dia_folga_unica"].ToString();

                                // Formata os valores para exibir somente a hora
                                entrada = DateTime.Parse(entrada).ToString("HH:mm");
                                saida = DateTime.Parse(saida).ToString("HH:mm");

                                // Adiciona uma nova linha ao DataGridView com os valores formatados
                                dgv.Rows.Add(id, nome, entrada, saida, folga);
                                dgv.ClearSelection();
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

 

        private void btnNewInsertUpdate_Click(object sender, EventArgs e) {
            try {
                switch (StateForm) {
                    case state.INITIAL:
                        StateForm = state.NEW;
                        break;
                    case state.NEW:
                        if (Insert()) {
                            CarregarConsultaDataGridView(dgvColaboradores);
                        }
                        StateForm = state.INITIAL;
                        break;
                    case state.EDIT:
                        if (Update()) {
                            CarregarConsultaDataGridView(dgvColaboradores);
                        }
                        StateForm = state.INITIAL;
                        break;
                    default:
                        break;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnEditCancel_Click(object sender, EventArgs e) {
            switch (StateForm) {
                case state.INITIAL:
                    idEditing = Convert.ToInt32(dgvColaboradores.CurrentRow.Cells["Cód"].Value);
                    StateForm = state.EDIT;
                    break;
                default:
                    StateForm = state.INITIAL;
                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var confirmDelete = MessageBox.Show("Certeza que deseja deletar ?", "Confirmação", MessageBoxButtons.YesNo);
            if (confirmDelete == DialogResult.Yes) {
                if (Delete()) {
                    CarregarConsultaDataGridView(dgvColaboradores);
                    StateForm = state.INITIAL;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            StateForm = state.INITIAL;
        }

        private bool Insert() {
            using (var conexao = new SQLiteConnection(Form1.connectionString)) {
                conexao.Open();
                using (var cmd = new SQLiteCommand(
                    "INSERT INTO Colaborador (nome, hora_entrada, hora_saida, data_dia_folga_unica) " +
                    "VALUES (@nome, @horaEntrada, @horaSaida, @dataUltimaFolga)", conexao)) {
                    cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                    cmd.Parameters.AddWithValue("@horaEntrada", dateTimePickerHoraEntrada.Text);
                    cmd.Parameters.AddWithValue("@horaSaida", dateTimePickerHoraSaida.Text);
                    cmd.Parameters.AddWithValue("@dataUltimaFolga", dateTimePickerDataFolga.Value.ToString("yyyy-MM-dd"));

                    int totalInserted = cmd.ExecuteNonQuery();
                    return totalInserted == 1;                    
                }
            }
        }
        private bool Update() {
            if (idEditing <= 0) {
                throw new Exception("Id não atribuido no método Update");
            }

            using (var conexao = new SQLiteConnection(Form1.connectionString)) {
                conexao.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE Colaborador SET nome = @nome, hora_entrada = @horaEntrada, hora_saida = @horaSaida, data_dia_folga_unica = @dataUltimaFolga WHERE id = @id", conexao)) {
                    cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                    cmd.Parameters.AddWithValue("@horaEntrada", dateTimePickerHoraEntrada.Text);
                    cmd.Parameters.AddWithValue("@horaSaida", dateTimePickerHoraSaida.Text);
                    cmd.Parameters.AddWithValue("@dataUltimaFolga", dateTimePickerDataFolga.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@id", idEditing);
                    int totalUpdated = cmd.ExecuteNonQuery();
                    return totalUpdated == 1;
                }
            }
        }

        private bool Delete() {
            if (idEditing <= 0) {
                throw new Exception("Id não atribuido no método Delete");
            }

            using (var conexao = new SQLiteConnection(Form1.connectionString)) {
                conexao.Open();
                using (var cmd = new SQLiteCommand(
                    "UPDATE Colaborador SET deletado = @data WHERE id = @id", conexao)) {
                    cmd.Parameters.AddWithValue("@id", idEditing);
                    cmd.Parameters.AddWithValue("@data", DateTime.Now.ToString("yyyy-MM-dd"));
                    int totalDeleted = cmd.ExecuteNonQuery();
                    return totalDeleted == 1;
                }
            }
        }

        private void EnableDisableEdits(bool enable) {
            textBox1.ReadOnly = !enable;
            dateTimePickerHoraEntrada.Enabled = enable;
            dateTimePickerHoraSaida.Enabled = enable;
        }

        private void dgvColaboradores_SelectionChanged(object sender, EventArgs e) {
            DataGridView currentDgv = sender as DataGridView;
            // Verifica se alguma linha está selecionada no DataGridView
            if (currentDgv.SelectedRows.Count > 0) {
                // Obtém a linha selecionada
                DataGridViewRow linhaSelecionada = currentDgv.SelectedRows[0];

                // Atualiza os campos "nome", "hora de entrada" e "hora de saída" com os valores da linha selecionada
                textBox1.Text = linhaSelecionada.Cells["Nome"].Value.ToString();
                // Obtém o valor do DateTimePicker customizado para hora de entrada
                string horaEntrada = linhaSelecionada.Cells["Entrada"].Value.ToString();
                string horaSaida = linhaSelecionada.Cells["Saída"].Value.ToString();
                string dataFolga = linhaSelecionada.Cells["Folga"].Value.ToString();

                // Define o valor do DateTimePicker customizado para hora de entrada
                dateTimePickerHoraEntrada.Value = DateTime.ParseExact(horaEntrada, "HH:mm", CultureInfo.InvariantCulture);
                dateTimePickerHoraSaida.Value = DateTime.ParseExact(horaSaida, "HH:mm", CultureInfo.InvariantCulture);
                dateTimePickerDataFolga.Value = DateTime.ParseExact(dataFolga, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            } else {
                textBox1.Clear();
            }
        }        
    }
}
