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
        public DateOnly DataBaseFolga1Dia { get; set; }
        public bool FolgaManual { get; set; } //folga compensa
        public bool NaoTrabalhaPorOutrosMotivos { get; set; }
        public int HorasTrabalho => CalcularHorasTrabalho(); // Propriedade de apenas leitura para calcular as horas de trabalho
        public Cargo? Cargo { get; set; }

        public Colaborador() {

        }
        public Colaborador(string nome, int horasTrabalho) {
            Nome = nome;
        }

        public bool Trabalha(DateOnly dataAVerificar) {
            return !(NaoTrabalhaPorOutrosMotivos || FolgaManual || Folga(dataAVerificar));
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

        /// <summary>
        /// Verifica se em determinada data seria folga na escala 6x1 6x2 com base em uma data Inicial.
        /// </summary>
        /// <param name="dataAVerificar"></param>
        /// <param name="ultimaFolgaUnica">Data de uma folga sozinha, sem dobradinha</param>
        /// <returns></returns>
        public bool Folga(DateOnly dataAVerificar) {
            var diferencaDias = Math.Abs(dataAVerificar.DayNumber - DataBaseFolga1Dia.DayNumber);
            // A cada 15 dias ele folgara 1x denovo
            int diasFuturoSobra = diferencaDias % 15;
            //  A folga dobrada dele é no 7º e 8º Dia.
            if (diasFuturoSobra == 0 || diasFuturoSobra == 7 || diasFuturoSobra == 8) {
                //está de folga
                return true;
            } else { return false; }

        }
    }
}
