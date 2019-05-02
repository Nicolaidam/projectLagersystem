using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerSystem.Model.Items_typer
{
    class PC : Item
    {
        private String macAdresse;
        private int ram;
        private String processor;
        private String grafikkort;

        public string MacAdresse{ 
            get => macAdresse; 
            set => macAdresse = value; 
        }
        public int Ram{ 
            get => ram; 
            set => ram = value; 
        }
        public string Processor{ 
            get => processor; 
            set => processor = value; 
        }
        public string Grafikkort{ 
            get => grafikkort; 
            set => grafikkort = value; 
        }

    } 
}
