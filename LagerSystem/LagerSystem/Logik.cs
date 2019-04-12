using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagerSystem.DAO;
using LagerSystem.Model;
using LagerSystem.Model.Items_typer;

namespace LagerSystem
{
    class Logik
    {
        IMobilDao mobilDao = new MobilDaoImpl();
        //ItemDao itemDao = new ItemDaoImpl();

        ObservableCollection<Item> alleItems = new ObservableCollection<Item>();
        ObservableCollection<Mobil> alleMobiler = new ObservableCollection<Mobil>();
        ObservableCollection<PC> allePC = new ObservableCollection<PC>();
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
        internal ObservableCollection<Mobil> AlleMobiler
        {
            get => alleMobiler;
            set => alleMobiler = value;
        }
        internal ObservableCollection<PC> AllePCs { get => allePC; set => allePC = value; }
        internal void LoadItems()
        {
            //List<Item> h = itemDao.GetAllItems();

            //midlertidig metode der kun tager alle mobiler.. Der kommer en ItemDao der giver en liste med ALLE elementer
            List<Mobil> h = mobilDao.GetAllMobil();

             if (h.Count != 0)
              {
                  for(int i = 0; i < h.Count; i++)
                   {
             addItem(h[i]);
                    }
                 }

            //addItem(h[0]);
            //addItem(h[1]);
            //addItem(h[2]);
            //addItem(new Item { Ejer = "Jacob", Id = "qwe", Lokation = "h", Maerke = "kk", Model = "din mor", Note = "hhhhhh", Pris = "123" });
            //addItem(new Mobil { Afdeling = "470", Ejer = "Anders", Id = "qwe", Lokation = "h", Maerke = "kk", Model = "din mor", Note = "hhhhhh", Pris = "123" });
            //addItem(new Item { Afdeling = "30", Ejer = "Brian", Id = "qwe", Lokation = "h", Maerke = "kk", Model = "din mor", Note = "hhhhhh", Pris = "123" });

        }
        internal void addItem(Item item)
        {
            Mobil ii = new Mobil();
            ii.Note = "noteTest";
            ii.Lokation = "noteTest";
            ii.Ejer = "noteTest";
            ii.Afdeling = "noteTest";
            ii.Maerke = "noteTest";
            ii.Model = "noteTest";
            ii.Pris = "noteTest";
            ii.Imei = "noteTest";
            ii.Ram = "noteTest";
            mobilDao.InsertMobil(ii);


            AlleItems.Add(item);
            if (item is Mobil)
            {
                alleMobiler.Add((Mobil)item);
                
            }
            if (item is PC)
            {
                allePC.Add((PC)item);
            }
        }


        //tager imod alt undtagen ID (tanken er at det måske kan genereres i databasen og blive oprettet den vej igennem?)
        internal void addMobil(string note, string lokation, string ejer, string afd, string maerke, string model, string pris, string imei, string ram)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 1000);
            string id = "" + randomNumber;
            addItem(new Mobil { Id = id, Note = note, Lokation = lokation, Ejer = ejer, Afdeling = afd, Maerke = maerke, Model = model, Pris = pris, Imei = imei, Ram = ram });
        }

        internal void addPc(string note, string lokation, string ejer, string afd, string maerke, string model, string pris, string macA, string ram, string proc, string grafikk)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 1000);
            string id = "" + randomNumber;
            addItem(new PC { Id = id, Note = note, Lokation = lokation, Ejer = ejer, Afdeling = afd, Maerke = maerke, Model = model, Pris = pris, MacAdresse = macA, Ram = ram, Processor = proc, Grafikkort = grafikk });
        }
    }
}