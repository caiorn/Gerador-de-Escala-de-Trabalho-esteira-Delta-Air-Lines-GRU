using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace escalaDelta {
    public partial class Colaborador {

        public int Id { get; set; }
        public string Nome { get; set; }        
        public TimeOnly? Entrada { get; set; }
        public TimeOnly? Saida { get; set; }
        public DateOnly UltimoDiaFolga { get; set; }

        public bool TrabalhaHoje { get; set; } = true;
        public int HorasTrabalho => CalcularHorasTrabalho(); // Propriedade de apenas leitura para calcular as horas de trabalho


        public Colaborador() {

        }
        public Colaborador(string nome, int horasTrabalho) {
            Nome = nome;
            TrabalhaHoje = true;
        }

        // Método para calcular as horas de trabalho
        private int CalcularHorasTrabalho() {
            if (Entrada == null || Saida == null) {
                // Se a hora de entrada ou saída não estiverem definidas, retorna 0
                return 0;
            } else {
                // Calcula a diferença entre a hora de saída e a hora de entrada em horas
                TimeSpan diferenca = TimeSpan.FromHours(Saida.Value.Hour - Entrada.Value.Hour).Add(TimeSpan.FromMinutes(Saida.Value.Minute - Entrada.Value.Minute));
                return (int)diferenca.TotalHours;
            }
        }
    }
}
