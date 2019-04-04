﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagerSystem.Model;
using LagerSystem.Model.Items_typer;

namespace LagerSystem
{
    class Logik
    {

        ObservableCollection<Item> alleItems = new ObservableCollection<Item>();
        ObservableCollection<Mobil> alleMobiler = new ObservableCollection<Mobil>();
        private static Logik instance;

        private Logik() { }

        public static Logik Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logik();
                }
                return instance;
            }
        }

        internal ObservableCollection<Item> AlleItems { get => alleItems; set => alleItems = value; }
        internal ObservableCollection<Mobil> AlleMobiler {
            get => alleMobiler;
            set => alleMobiler = value; 
}
        internal void LoadItems() {
            addItem(new Item { Ejer = "Jacob", Id = "qwe", Lokation = "h", Maerke = "kk", Model = "din mor", Note = "hhhhhh", Pris = "123" });
            addItem(new Mobil { Afdeling = "470", Ejer = "Anders", Id = "qwe", Lokation = "h", Maerke = "kk", Model = "din mor", Note = "hhhhhh", Pris = "123" });
            addItem(new Item { Afdeling = "30", Ejer = "Brian", Id = "qwe", Lokation = "h", Maerke = "kk", Model = "din mor", Note = "hhhhhh", Pris = "123" });

}
       internal void addItem(Item item)
        {
            AlleItems.Add(item);
            if(item is Mobil)
            {
                alleMobiler.Add((Mobil)item);
            }
        }

     
        //tager imod alt undtagen ID (tanken er at det måske kan genereres i databasen og blive oprettet den vej igennem?)
        internal void addMobil(string note, string lokation, string ejer, string afd, string maerke, string model, string pris, string imei, string ram)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 1000);
            string id = "" + randomNumber;
            addItem(new Mobil { Id = id, Note = note, Lokation = lokation , Ejer = ejer, Afdeling = afd, Maerke = maerke, Model = model, Pris = pris, Imei1 = imei, Ram1 = ram });
        }
        internal void addPc(string note, string lokation, string ejer, string afd, string maerke, string model, string pris, string macA, string ram, string proc, string grafikk)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 1000);
            string id = "" + randomNumber;
            addItem(new PC { Id = id, Note = note, Lokation = lokation , Ejer = ejer, Afdeling = afd, Maerke = maerke, Model = model, Pris = pris, Imei1 = imei, Ram1 = ram });
        }
    }
}
