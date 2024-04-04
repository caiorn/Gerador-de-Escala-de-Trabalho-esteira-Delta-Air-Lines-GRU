using escalaDelta.Utils;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace escalaDelta {
    public partial class FormColaborador : Form {

        public enum state { INITIAL, NEW, EDIT }
        private state _stateForm;
        public state StateForm {
            get { return _stateForm; }
            set {
                _stateForm = value;

                if (value == state.INITIAL) {
                    btnNewAndSave.Text = "New";
                    btnEditAndDelete.Text = "Edit";
                    btnEditAndDelete.Visible = true;
                    btnCancel.Visible = false;
                    EnableDisableEdits(false);
                } else {
                    if (value == state.NEW) {
                        btnNewAndSave.Text = "Add";
                        btnEditAndDelete.Visible = false;
                    } else if (value == state.EDIT) {
                        btnNewAndSave.Text = "Save";
                        btnEditAndDelete.Text = "Delete";
                    }
                    btnCancel.Visible = true;
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
            dgvColaboradores.Columns["Entrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvColaboradores.Columns["Saída"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvColaboradores.DefinirTamanhoPercentualColunasModeFILL(
                           ("Cód", 5),
                           ("Nome", 20),
                           ("Entrada", 10),
                           ("Saída", 10)
                           );
            CarregarConsultaDataGridView();
            EnableDisableEdits(false);
        }

        private void CarregarConsultaDataGridView() {
            try {
                using (SQLiteConnection connection = new SQLiteConnection(Form1.connectionString)) {
                    // Abrir a conexão com o banco de dados
                    connection.Open();

                    // Comando SQL para selecionar todos os colaboradores
                    string query = "SELECT id, nome, hora_entrada, hora_saida FROM Colaborador";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection)) {
                        using (SQLiteDataReader reader = command.ExecuteReader()) {

                            // Lê os dados do SQLiteDataReader e os adiciona ao DataGridView
                            while (reader.Read()) {
                                // Extrai os valores das colunas "Entrada" e "Saída"
                                string id = reader["id"].ToString();
                                string nome = reader["nome"].ToString();
                                string entrada = reader["hora_entrada"].ToString();
                                string saida = reader["hora_saida"].ToString();

                                // Formata os valores para exibir somente a hora
                                entrada = DateTime.Parse(entrada).ToString("HH:mm");
                                saida = DateTime.Parse(saida).ToString("HH:mm");

                                // Adiciona uma nova linha ao DataGridView com os valores formatados
                                dgvColaboradores.Rows.Add(id, nome, entrada, saida);
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

        private void button1_Click(object sender, EventArgs e) {
            // Aqui você pode obter os dados do colaborador a partir dos campos do formulário ou de qualquer outra fonte
            string nome = textBox1.Text;
            DateTime horaEntrada = dateTimePickerHoraEntrada.Value;
            DateTime horaSaida = dateTimePickerHoraSaida.Value;
            DateTime ultimoDiaFolga = dateTimePickerDataFolga.Value;

            InserirColaborador(nome, horaEntrada, horaSaida, ultimoDiaFolga);

            MessageBox.Show("Colaborador inserido com sucesso!");
        }


        private void InserirColaborador(string nome, DateTime horaEntrada, DateTime horaSaida, DateTime ultimoDiaFolga) {
            string caminhoBancoDados = "database.db";

            using (var conexao = new SQLiteConnection($"Data Source={caminhoBancoDados}")) {
                conexao.Open();

                using (var cmd = new SQLiteCommand(
                    "INSERT INTO Colaborador (nome, hora_entrada, hora_saida, ultimo_dia_folga) " +
                    "VALUES (@nome, @horaEntrada, @horaSaida, @ultimoDiaFolga)", conexao)) {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@horaEntrada", horaEntrada);
                    cmd.Parameters.AddWithValue("@horaSaida", horaSaida);
                    cmd.Parameters.AddWithValue("@ultimoDiaFolga", ultimoDiaFolga);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnNewAndEdit_Click(object sender, EventArgs e) {
            switch (StateForm) {
                case state.INITIAL:
                    StateForm = state.NEW;
                    break;
                case state.NEW:
                    //Insert
                    StateForm = state.INITIAL;
                    break;
                case state.EDIT:
                    //Update
                    StateForm = state.INITIAL;                    
                    break;
                default:
                    break;
            }
        }

        private void btnEditAndDelete_Click(object sender, EventArgs e) {
            switch (StateForm) {
                case state.INITIAL:
                    StateForm = state.EDIT;
                    break;
                case state.EDIT:
                    //Delete
                    StateForm = state.INITIAL;
                    break;
                default:
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            StateForm = state.INITIAL;
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

                // Define o valor do DateTimePicker customizado para hora de entrada
                dateTimePickerHoraEntrada.Value = DateTime.ParseExact(horaEntrada, "HH:mm", CultureInfo.InvariantCulture);
                dateTimePickerHoraSaida.Value = DateTime.ParseExact(horaSaida, "HH:mm", CultureInfo.InvariantCulture);
            }
        }
    }
}
