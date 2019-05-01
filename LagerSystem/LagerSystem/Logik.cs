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
        IBrugerDao brugerDao = new BrugerDaoImpl();
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
                for (int i = 0; i < h.Count; i++)
                {
                    addItem(h[i]);
                }
            }


        }
        private void addItem(Item item)
        {
            String id = item.Id;


            AlleItems.Add(item);
            if (item is Mobil)
            {
                item.Id = "mo" + item.Id;
                alleMobiler.Add((Mobil)item);

            }
            if (item is PC)
            {
                item.Id = "pc" + item.Id;
                allePC.Add((PC)item);
            }
        }



        //tager imod alt undtagen ID (tanken er at det måske kan genereres i databasen og blive oprettet den vej igennem?)
        internal void addMobil(Mobil m)
        {
            Mobil ii = new Mobil();
            ii.Note = m.Note;
            ii.Lokation = m.Lokation;
            ii.Ejer = m.Ejer;
            ii.Afdeling = m.Afdeling;
            ii.Maerke = m.Maerke;
            ii.Model = m.Model;
            ii.Pris = m.Pris;
            ii.Imei = m.Imei;
            ii.Ram = m.Ram;
            mobilDao.InsertMobil(ii);
            addItem(new Mobil { Note = ii.Note, Lokation = ii.Lokation, Ejer = ii.Ejer, Afdeling = ii.Afdeling, Maerke = ii.Maerke, Model = ii.Model, Pris = ii.Pris, Imei = ii.Imei, Ram = ii.Ram });
        }

        internal void addPc(string note, string lokation, string ejer, string afd, string maerke, string model, string pris, string macA, string ram, string proc, string grafikk)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 1000);
            string id = "" + randomNumber;
            addItem(new PC { Id = id, Note = note, Lokation = lokation, Ejer = ejer, Afdeling = afd, Maerke = maerke, Model = model, Pris = pris, MacAdresse = macA, Ram = ram, Processor = proc, Grafikkort = grafikk });
        }

        internal Boolean verificerBruger(String brugernavn, String password)
        {
            Boolean b = false;

            if (brugerDao.GetPassword(brugernavn).Equals(password) && brugerDao.GetBrugernavn(password).Equals(brugernavn))
            {
                b = true;
            }

            return b;
        }

        internal void OpdaterMobil(string id, string note, string lokation, string ejer, string afdeling, string maerke, string model, string pris, string ram, string imei)
        {

            for (int i = 0; i < alleMobiler.Count; i++)
            {
                if (alleMobiler[i].Id == id)
                {

                    alleMobiler[i].Note = note;
                    alleMobiler[i].Lokation = lokation;
                    alleMobiler[i].Ejer = ejer;
                    alleMobiler[i].Afdeling = afdeling;
                    alleMobiler[i].Maerke = maerke;
                    alleMobiler[i].Model = model;
                    alleMobiler[i].Pris = pris;
                    alleMobiler[i].Ram = ram;
                    alleMobiler[i].Imei = imei;
                    string forhelf = id.Remove(0, 2);
                    mobilDao.UpdateMobil(alleMobiler[i]);
                }
                // evt også søg igennem alle items og slet den der. 
            }


        }

        // denne bruges ikke mere TROR JEG
        internal void OpdaterMobiler()
        {
            for (int i = 0; i < alleMobiler.Count; i++)
            {
                // mobilDao.UpdateMobil(alleMobiler[i]);
            }
        }

        internal void SletMobil(string id, string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8, string text9)
        {
            for (int i = 0; i < alleMobiler.Count; i++)
            {
                if (alleMobiler[i].Id == id)
                {
                    string ids = id.Replace("mo", "");
                    mobilDao.DeleteMobil(Convert.ToInt32(ids));
                    alleMobiler.RemoveAt(i);

                }
            }
        }
    }
}