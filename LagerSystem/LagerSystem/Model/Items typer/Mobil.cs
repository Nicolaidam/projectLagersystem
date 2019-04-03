using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerSystem.Model.Items_typer
{
    class Mobil : Item
    {
        private String Imei;
        private String Ram;

        public string Imei1 { get => Imei; set => Imei = value; }
        public String Ram1 { get => Ram; set => Ram = value; }
    }

}
