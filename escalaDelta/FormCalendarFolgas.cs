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
            monthCalendar1.ViewStart = new DateTime(dateTimePicker1.Value.Year, 01, 01);
        }

    }
}
