using CustomControls;
using escalaDelta.Utils;
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace escalaDelta {
    public partial class FormCalendarFolgas : Form {

        List<BoldedDate> feriadosNacionais2024_2034 = new List<BoldedDate>();

        public FormCalendarFolgas() {
            InitializeComponent();

            monthCalendar1.Culture = new System.Globalization.CultureInfo("pt-BR");
            LoadFeriados();
            //this.monthCalendar1.BeginUpdate();
            //PintarFeriados();
            //this.monthCalendar1.EndUpdate();
        }

        private void LoadFeriados() {
            var catFeriado = new BoldedDateCategory("Vacation") { ForeColor = Color.Red };

            for (int year = 2024; year <= 2035; year++) {
                DateTime easterSunday = ObterDomingoDePascoa(year);
                DateTime goodFriday = easterSunday.AddDays(-2);

                feriadosNacionais2024_2034.AddRange(new BoldedDate[] {
                   new BoldedDate{ Value = new DateTime(year, 1, 1),  Category = catFeriado  },// Confraternização Universal" },
                   new BoldedDate{ Value = goodFriday,                Category = catFeriado  },   // Sexta santa
                   new BoldedDate{ Value = new DateTime(year, 4, 21), Category = catFeriado  },// Tiradentes" },
                   new BoldedDate{ Value = new DateTime(year, 5, 1),  Category = catFeriado  },// Dia do Trabalhador" },
                   new BoldedDate{ Value = new DateTime(year, 9, 7),  Category = catFeriado  },// Independência do Brasil" },
                   new BoldedDate{ Value = new DateTime(year, 10, 12),Category = catFeriado  },// Nossa Senhora Aparecida" },
                   new BoldedDate{ Value = new DateTime(year, 11, 2), Category = catFeriado  },// Finados" },
                   new BoldedDate{ Value = new DateTime(year, 11, 15),Category = catFeriado  },// Proclamação da República" },
                   new BoldedDate{ Value = new DateTime(year, 12, 25),Category = catFeriado  }// Natal" }
                });
            }
        }

        //private void PintarFeriados() {
        //    this.monthCalendar1.BoldedDatesCollection.AddRange(feriadosNacionais2024_2034);
        //}

        private void PintarDiasFolgas(DateTime dataFolgaUnica) {
            this.monthCalendar1.BoldedDatesCollection.Clear();

            var cat1 = new BoldedDateCategory("Vacation") { ForeColor = Color.Black, BackColorStart = Color.LightSalmon };

            DateTime dataFolgaStart = dataFolgaUnica;
            DateTime dataFimContador = dataFolgaStart.AddYears(3);

            while (dataFolgaStart <= dataFimContador) {
                this.monthCalendar1.BoldedDatesCollection.Add(new BoldedDate { Category = cat1, Value = dataFolgaStart });
                dataFolgaStart = dataFolgaStart.AddDays(7);
                this.monthCalendar1.BoldedDatesCollection.Add(new BoldedDate { Category = cat1, Value = dataFolgaStart });
                dataFolgaStart = dataFolgaStart.AddDays(1);
                this.monthCalendar1.BoldedDatesCollection.Add(new BoldedDate { Category = cat1, Value = dataFolgaStart });
                dataFolgaStart = dataFolgaStart.AddDays(7);                
            }

        }
        static DateTime ObterDomingoDePascoa(int year) {
            // Algoritmo de computação da data da Páscoa (baseado no algoritmo de Meeus/Jones/Butcher)
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int month = (h + l - 7 * m + 114) / 31;
            int day = ((h + l - 7 * m + 114) % 31) + 1;

            return new DateTime(year, month, day);
        }


        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e) {
            this.monthCalendar1.BeginUpdate();
            PintarDiasFolgas(e.Start);
            //PintarFeriados();
            this.monthCalendar1.EndUpdate();
        }
    }
}
