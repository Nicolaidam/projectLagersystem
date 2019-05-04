using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LagerSystem.DAO;
using LagerSystem.DAO.Items.PC;
using LagerSystem.DAO.Items.PCDele;
using LagerSystem.Model;
using LagerSystem.Model.Items_typer;

namespace LagerSystem
{
    class Logik
    {
        IMobilDao mobilDao = new MobilDaoImpl();
        IPCDao pcDao = new PCDaoImpl();
        IPCDeleDao pcDeleDao = new PCDeleDaoImpl();
        IBrugerDao brugerDao = new BrugerDaoImpl();
        ObservableCollection<Item> alleItems = new ObservableCollection<Item>();
        ObservableCollection<Mobil> alleMobiler = new ObservableCollection<Mobil>();
        ObservableCollection<PC> allePC = new ObservableCollection<PC>();
        ObservableCollection<PCDele> allePcDele = new ObservableCollection<PCDele>();
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
            try
            {
                List<Mobil> h = mobilDao.GetAllMobil();
                if (h.Count != 0)
                {
                    for (int i = 0; i < h.Count; i++)
                    {
                        addItem(h[i]);
                    }
                }

                List<PC> pcer = pcDao.GetAllPC();
                if (pcer.Count != 0)
                {
                    for (int i = 0; i < pcer.Count; i++)
                    {
                        addItem(pcer[i]);
                    }
                }

                List<PCDele> pcdele = pcDeleDao.GetAllPCDele();
                if (pcdele.Count != 0)
                {
                    for (int i = 0; i < pcdele.Count; i++)
                    {
                        addItem(pcdele[i]);
                    }
                }
            }
            catch (Exception)
            {
                string message = "Fejl :/";
                string title = "Fejl";
                MessageBox.Show(message, title);
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
            if (item is PCDele)
            {
                item.Id = "pcdel" + item.Id;
                allePcDele.Add((PCDele)item);
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

            String maxID = "";


            if (!mobilDao.InsertMobil(ii))
            {
                string message = "Fejl i databasen";
                string title = "Fejl";
                MessageBox.Show(message, title);
            }
            try
            {
                maxID = mobilDao.getHighestID();
            }
            catch (Exception)
            {
                string message = "Fejl :/";
                string title = "Fejl";
                MessageBox.Show(message, title);
            }
            //int id = Int32.Parse(maxID);
            addItem(new Mobil {Id = maxID, Note = ii.Note, Lokation = ii.Lokation, Ejer = ii.Ejer, Afdeling = ii.Afdeling, Maerke = ii.Maerke, Model = ii.Model, Pris = ii.Pris, Imei = ii.Imei, Ram = ii.Ram });
        }

        internal void addPc(string note, string lokation, string ejer, string afd, string maerke, string model, int pris, string macA, int ram, string proc, string grafikk)
        {
            PC nyPC = new PC();
            nyPC.Note = note;
            nyPC.Lokation = lokation;
            nyPC.Ejer = ejer;
            nyPC.Afdeling = afd;
            nyPC.Maerke = maerke;
            nyPC.Model = model;
            nyPC.Pris = pris;
            nyPC.MacAdresse = macA;
            nyPC.Ram = ram;
            nyPC.Processor = proc;
            nyPC.Grafikkort = grafikk;

            String maxID = "";


            if (!pcDao.InsertPC(nyPC))
            {
                string message = "Fejl i databasen";
                string title = "Fejl";
                MessageBox.Show(message, title);
            }
            try
            {
                maxID = pcDao.getHighestID();
            }
            catch (Exception)
            {
                string message = "Fejl :/";
                string title = "Fejl";
                MessageBox.Show(message, title);
            }
            //int id = Int32.Parse(maxID);
            addItem(new PC { Id = maxID, Note = nyPC.Note, Lokation = nyPC.Lokation, Ejer = nyPC.Ejer, Afdeling = nyPC.Afdeling, Maerke = nyPC.Maerke, Model = nyPC.Model, Pris = nyPC.Pris, MacAdresse = nyPC.MacAdresse, Ram = nyPC.Ram, Grafikkort = nyPC.Grafikkort, Processor=nyPC.Processor });
            
               }

        internal void addPcDel(string note, string lokation, string ejer, string afd, string maerke, string model, int pris)
        {
            PCDele nyPCDel = new PCDele();
            nyPCDel.Note = note;
            nyPCDel.Lokation = lokation;
            nyPCDel.Ejer = ejer;
            nyPCDel.Afdeling = afd;
            nyPCDel.Maerke = maerke;
            nyPCDel.Model = model;
            nyPCDel.Pris = pris;
            
            String maxID = "";


            if (!pcDeleDao.InsertPCDele(nyPCDel))
            {
                string message = "Fejl i databasen";
                string title = "Fejl";
                MessageBox.Show(message, title);
            }
            try
            {
                maxID = pcDeleDao.getHighestID();
            }
            catch (Exception)
            {
                string message = "Fejl :/";
                string title = "Fejl";
                MessageBox.Show(message, title);
            }
            //int id = Int32.Parse(maxID);
            addItem(new PCDele { Id = maxID, Note = nyPCDel.Note, Lokation = nyPCDel.Lokation, Ejer = nyPCDel.Ejer, Afdeling = nyPCDel.Afdeling, Maerke = nyPCDel.Maerke, Model = nyPCDel.Model, Pris = nyPCDel.Pris});

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

        internal void OpdaterMobil(string id, string note, string lokation, string ejer, string afdeling, string maerke, string model, int pris, int ram, string imei)
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

                    if (!mobilDao.UpdateMobil(alleMobiler[i]))
        
                        {
                            string message = "Fejl i databasen";
                            string title = "Fejl";
                            MessageBox.Show(message, title);
                        }
                }
                // evt også søg igennem alle items og slet den der. 
            }


        }

        internal void SletMobil(string id, string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8, string text9)
        {
            for (int i = 0; i < alleMobiler.Count; i++)
            {
                if (alleMobiler[i].Id == id)
                {
                    string ids = id.Replace("mo", "");
                    if (!mobilDao.DeleteMobil(Convert.ToInt32(ids)))
                    {
                        string message = "Fejl i databasen";
                        string title = "Fejl";
                        MessageBox.Show(message, title);
                    }

                    alleMobiler.RemoveAt(i);

                }
            }
        }
    }
}