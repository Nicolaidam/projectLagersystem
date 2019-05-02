using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerSystem.Model.Items_typer
{
    class Mobil : Item
    {
        private String imei;
        private int ram;

        public string Imei { get => imei; set => imei = value; }
        public int Ram { get => ram; set => ram = value; }
    }

}
