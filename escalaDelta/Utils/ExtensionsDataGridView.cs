using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escalaDelta.Utils {
    static class ExtensionsDataGridView {
        public static void configurePropertiesDataGridView(DataGridView dgv) {
            // Oculta a coluna de cabeçalho de linha (seletor)
            dgv.RowHeadersVisible = false;
            // Definir a altura das linhas
            dgv.RowTemplate.Height = 20; // Altere para a altura desejada
            // Dados preencher todo espaço do grid
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Não permitir alterar a altura das linhas
            dgv.AllowUserToResizeRows = false;

            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = true;

            // Definir o estilo de célula para cabeçalhos em negrito
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);


            // Definir o estilo de célula para linhas com cores alternadas
            dgv.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            // Definir a cor da borda do DataGridView
            dgv.GridColor = Color.LightGray;

            // Definir o estilo de borda para células
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        public static void DefinirTamanhoPercentualColunasModeFILL(this DataGridView dataGridView, params (string columnName, int percent)[] colunas) {
            //dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (var coluna in colunas) {
                if (dataGridView.Columns.Contains(coluna.columnName)) {
                    var dgvColumn = dataGridView.Columns[coluna.columnName];
                    dgvColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvColumn.FillWeight = coluna.percent;
                }
            }
        }
    }
}
