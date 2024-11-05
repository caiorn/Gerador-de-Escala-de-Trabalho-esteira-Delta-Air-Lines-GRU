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

        public FormCalendarFolgas() {
            InitializeComponent();

            monthCalendar1.Culture = new System.Globalization.CultureInfo("pt-BR");
        }

        private void PintarDiasFolgas(DateTime dataFolgaUnica) {
            this.monthCalendar1.BoldedDatesCollection.Clear();

            var cat1 = new BoldedDateCategory("Vacation") { ForeColor = Color.Black, BackColorStart = Color.Salmon };


            DateTime dataFolgaStart = dataFolgaUnica;
            DateTime dataFimContador = dataFolgaStart.AddYears(3);

            this.monthCalendar1.BeginUpdate();
            while (dataFolgaStart <= dataFimContador) {
                this.monthCalendar1.BoldedDatesCollection.Add(new BoldedDate { Category = cat1, Value = dataFolgaStart });
                dataFolgaStart = dataFolgaStart.AddDays(7);
                this.monthCalendar1.BoldedDatesCollection.Add(new BoldedDate { Category = cat1, Value = dataFolgaStart });
                dataFolgaStart = dataFolgaStart.AddDays(1);
                this.monthCalendar1.BoldedDatesCollection.Add(new BoldedDate { Category = cat1, Value = dataFolgaStart });
                dataFolgaStart = dataFolgaStart.AddDays(7);
            }
            this.monthCalendar1.EndUpdate();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e) {
            PintarDiasFolgas(e.Start);
        }
    }
}
