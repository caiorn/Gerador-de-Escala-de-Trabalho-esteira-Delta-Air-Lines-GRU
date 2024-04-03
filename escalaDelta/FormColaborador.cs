using escalaDelta.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace escalaDelta {
    public partial class FormColaborador : Form {
        public FormColaborador() {
            InitializeComponent();
            ExtensionsDataGridView.configurePropertiesDataGridView(dgvColaboradores);
            dgvColaboradores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvColaboradores.MultiSelect = false;

            dgvColaboradores.DataSource =  ObterDadosColaboradores();
            //Após carregar os dados no datagrid view definindo largura colunas
            dgvColaboradores.Columns["Entrada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvColaboradores.Columns["Saída"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvColaboradores.DefinirTamanhoPercentualColunasModeFILL(
                           ("Cód", 5),
                           ("Nome", 20),
                           ("Entrada", 10),
                           ("Saída", 10)
                           );
        }

        private DataTable ObterDadosColaboradores() {
            DataTable dataTable = new DataTable();
            try {
                using (SQLiteConnection connection = new SQLiteConnection(Form1.connectionString)) {
                    // Abrir a conexão com o banco de dados
                    connection.Open();

                    // Comando SQL para selecionar todos os colaboradores
                    string query = "SELECT id AS [Cód], nome AS [Nome], hora_entrada as [Entrada], hora_saida as [Saída]  FROM Colaborador";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection)) {
                        using (SQLiteDataReader reader = command.ExecuteReader()) {
                            // Carregar os dados do DataReader para o DataTable
                            dataTable.Load(reader);
                        }
                    }

                    // Fechar a conexão com o banco de dados
                    connection.Close();
                }
            } catch (Exception ex) {
                MessageBox.Show("Ocorreu um erro ao obter os dados dos colaboradores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
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
    }
}
