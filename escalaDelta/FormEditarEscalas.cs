using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace escalaDelta {
    public partial class FormEditarEscalas : Form {

        private ListBox listBoxOrigem;

        public FormEditarEscalas(DateOnly dataEdicao) {
            InitializeComponent();
            dateTimePicker1.Value = dataEdicao.ToDateTime(TimeOnly.MinValue);

            loadListBoxes();

            // Habilita a funcionalidade de arrastar e soltar para cada ListBox
            listBox1Pier.AllowDrop = true;
            listBox2ATL.AllowDrop = true;
            listBox3JFK.AllowDrop = true;
            listBox4NtrampouFolga.AllowDrop = true;
            listBox1NtrampoOutros.AllowDrop = true;

            listBox1Pier.DisplayMember = "Nome";
            listBox2ATL.DisplayMember = "Nome";
            listBox3JFK.DisplayMember = "Nome";
            listBox4NtrampouFolga.DisplayMember = "Nome";
            listBox1NtrampoOutros.DisplayMember = "Nome";


            // Associa os eventos de arrastar e soltar para cada ListBox
            listBox1Pier.DragEnter += ListBox_DragEnter;
            listBox1Pier.DragDrop += ListBox_DragDrop;
            listBox1Pier.MouseDown += listBox_MouseDown;

            listBox2ATL.DragEnter += ListBox_DragEnter;
            listBox2ATL.DragDrop += ListBox_DragDrop;
            listBox2ATL.MouseDown += listBox_MouseDown;

            listBox3JFK.DragEnter += ListBox_DragEnter;
            listBox3JFK.DragDrop += ListBox_DragDrop;
            listBox3JFK.MouseDown += listBox_MouseDown;

            listBox4NtrampouFolga.DragEnter += ListBox_DragEnter;
            listBox4NtrampouFolga.DragDrop += ListBox_DragDrop;
            listBox4NtrampouFolga.MouseDown += listBox_MouseDown;

            listBox1NtrampoOutros.DragEnter += ListBox_DragEnter;
            listBox1NtrampoOutros.DragDrop += ListBox_DragDrop;
            listBox1NtrampoOutros.MouseDown += listBox_MouseDown;

        }

        private void loadListBoxes() {
            string paramDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string query = $"SELECT * FROM ColaboradorTrabalho WHERE data = '{paramDate}'";
            using (SQLiteConnection connection = new SQLiteConnection(Form1.connectionString)) {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection)) {
                    using (SQLiteDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) { 
                            int idColaborador = reader.GetInt32(1);
                            var worker = Form1.colaboradores.FirstOrDefault(c => c.Id == idColaborador);
                            if (worker != null) {
                                string localTrabalho = reader.GetString(2);

                                if (localTrabalho == "PIER") {
                                    listBox1Pier.Items.Add(worker);
                                } else if (localTrabalho == "ATL") {
                                    listBox2ATL.Items.Add(worker);
                                } else if (localTrabalho == "JFK") {
                                    listBox3JFK.Items.Add(worker);
                                } else if (localTrabalho == "FOLGA") {
                                    listBox4NtrampouFolga.Items.Add(worker);
                                } else if (localTrabalho == "OUTROS") {
                                    listBox1NtrampoOutros.Items.Add(worker);
                                }
                            }    
                        }
                    }
                }
            }
        }

        // Evento DragEnter para todos os ListBoxes
        private void ListBox_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        // Evento DragDrop para todos os ListBoxes
        private void ListBox_DragDrop(object sender, DragEventArgs e) {
            ListBox listBoxDestino = sender as ListBox;
            Colaborador item = e.Data.GetData(typeof(Colaborador)) as Colaborador;

            // Move o item da ListBox de origem para a ListBox de destino
            listBoxOrigem.Items.Remove(item);
            listBoxDestino.Items.Add(item);
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

        private void btnSalvar_Click(object sender, EventArgs e) {
            //validacoes
            if (listBox1Pier.Items.Count > 1) {
                MessageBox.Show("O pier só deve ter 1 pessoa");
                return;
            };

            //se for passado, redefinir as escalas presente e futuras.

            using (var conexao = new SQLiteConnection(Form1.connectionString)) {
                conexao.Open();
                string paramDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string query1 = $"DELETE FROM ColaboradorTrabalho WHERE data = '{paramDate}'";
                string query2 = "INSERT INTO ColaboradorTrabalho(id_colaborador, local_trabalho, data) " +
                                "VALUES (@idColaborador, @localTrabalho, @data)";
                using (var cmd = new SQLiteCommand(query1, conexao)) {
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = query2;
                    cmd.Parameters.AddWithValue("@idColaborador", (listBox1Pier.Items[0] as Colaborador)?.Id);
                    cmd.Parameters.AddWithValue("@localTrabalho", "PIER");
                    cmd.Parameters.AddWithValue("@data", paramDate);
                    cmd.ExecuteNonQuery();

                    foreach (Colaborador colaboradorTrabalhou in listBox2ATL.Items) {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idColaborador", colaboradorTrabalhou.Id);
                        cmd.Parameters.AddWithValue("@localTrabalho", "ATL");
                        cmd.Parameters.AddWithValue("@data", paramDate);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (Colaborador colaboradorTrabalhou in listBox3JFK.Items) {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idColaborador", colaboradorTrabalhou.Id);
                        cmd.Parameters.AddWithValue("@localTrabalho", "JFK");
                        cmd.Parameters.AddWithValue("@data", paramDate);
                        cmd.ExecuteNonQuery();
                    }
                    foreach (Colaborador colaborador in listBox4NtrampouFolga.Items) {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idColaborador", colaborador.Id);
                        cmd.Parameters.AddWithValue("@localTrabalho", "FOLGA");
                        cmd.Parameters.AddWithValue("@data", paramDate);
                        cmd.ExecuteNonQuery();
                    }
                    foreach (Colaborador colaborador in listBox1NtrampoOutros.Items) {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@idColaborador", colaborador.Id);
                        cmd.Parameters.AddWithValue("@localTrabalho", "OUTROS");
                        cmd.Parameters.AddWithValue("@data", paramDate);
                        cmd.ExecuteNonQuery();
                    }
                }

                DialogResult = DialogResult.OK;
            }
        }
    }
}
