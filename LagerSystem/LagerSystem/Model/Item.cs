﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerSystem.Model
{
    class Item 
    {
        private String id;
        private String note;
        private String lokation;
        private String ejer;
        private String afdeling;
        private String maerke;
        private String model;
        private int pris;
       

        public String Id {
            get => id;
            set => id = value;
        }
        public string Note
        {
            get => note; set
            {
                note = value;
            }
        }

      

        public string Lokation { get => lokation; set => lokation = value; }
        public string Ejer { get => ejer; set => ejer = value; }
        public string Afdeling { get => afdeling; set => afdeling = value; }
        public string Maerke { get => maerke; set => maerke = value; }
        public string Model { get => model; set => model = value; }
        public int Pris { get => pris; set => pris = value; }
        

        }
}
