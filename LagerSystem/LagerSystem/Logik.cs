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
        private IMobilDao mobilDao = new MobilDaoImpl();
        private IPCDao pcDao = new PCDaoImpl();
        private IPCDeleDao pcDeleDao = new PCDeleDaoImpl();
        private IBrugerDao brugerDao = new BrugerDaoImpl();
        private ObservableCollection<Item> alleItems = new ObservableCollection<Item>();
        private ObservableCollection<Mobil> alleMobiler = new ObservableCollection<Mobil>();
        private ObservableCollection<Item> alleMedAfd = new ObservableCollection<Item>();
        private ObservableCollection<Item> alleSog = new ObservableCollection<Item>();
        private ObservableCollection<PC> allePC = new ObservableCollection<PC>();
        private ObservableCollection<PCDele> allePcDele = new ObservableCollection<PCDele>();
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
        internal ObservableCollection<Item> AlleSog
        {
            get => alleSog;
            set => alleSog = value;
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
                item.Id = "m" + item.Id;
               // alleMobiler.Add((Mobil)item);

            }
            if (item is PC)
            {
                item.Id = "p" + item.Id;
                //allePC.Add((PC)item);
            }
            if (item is PCDele)
            {
                item.Id = "d" + item.Id;
              //  allePcDele.Add((PCDele)item);
            }
            
        }
        internal void GetAlleMobiler()
        {
            alleMobiler.Clear();
            for (int i = 0; i < alleItems.Count; i++)
            {
                if(alleItems[i] is Mobil)
                {
                    alleMobiler.Add((Mobil)alleItems[i]);
                }
            }
        }
        internal void GetAlleMedAfd(int afd)
        {
            alleMedAfd.Clear();
            for (int i = 0; i < alleItems.Count; i++)
            {
                if (Convert.ToInt32(alleItems[i].Afdeling) == afd)
                {
                    alleMedAfd.Add((Item)alleItems[i]);
                }
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

        internal void GetAllePcer()
        {
            allePC.Clear();
            for (int i = 0; i < alleItems.Count; i++)
            {
                if (alleItems[i] is PC)
                {
                    allePC.Add((PC)alleItems[i]);
                }
            }
        }

        internal ObservableCollection<PCDele> AllePCDELE
        {
            get => allePcDele;
            set => allePcDele = value;
        }
        internal void GetAllePCDELE()
        {
            allePcDele.Clear();
            for (int i = 0; i < alleItems.Count; i++)
            {
                if (alleItems[i] is PCDele)
                {
                    allePcDele.Add((PCDele)alleItems[i]);
                }
            }
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

            for (int i = 0; i < alleItems.Count; i++)
            {

                if(alleItems[i].Id == id)
                {
                    Mobil opM = new Mobil();
                    opM.Id = id;
                    opM.Note = note;
                    opM.Lokation = lokation;
                    opM.Afdeling = afdeling;
                    opM.Ejer = ejer;
                    opM.Maerke = maerke;
                    opM.Model = model;
                    opM.Pris = pris;
                    opM.Ram = ram;
                    opM.Imei = imei;
                    alleItems[i] = opM;

                    if (!mobilDao.UpdateMobil((Mobil)alleItems[i]))
                    {
                        string message = "Fejl i databasen";
                        string title = "Fejl";
                        MessageBox.Show(message, title);
                    }
                }
                                  
                }
                // evt også søg igennem alle items og slet den der. 
            }

        internal void OpdaterPc(string id, string text1, string text2, string text3, string text4, string text5, string text6, int v1, int v2, string text7, string text8, string text9)
        {
            for (int i = 0; i < alleItems.Count; i++)
            {

                if (alleItems[i].Id == id)
                {
                    PC opM = new PC();
                    opM.Id = id;
                    opM.Note = text1;
                    opM.Lokation = text2;
                    opM.Afdeling = text3;
                    opM.Ejer = text4;
                    opM.Maerke = text5;
                    opM.Model = text6;
                    opM.Pris = v1;
                    opM.Ram = v2;
                    opM.MacAdresse = text7;
                    opM.Processor = text8;
                    opM.Grafikkort = text9;
                 
                    alleItems[i] = opM;

                    if (!pcDao.UpdatePC((PC)alleItems[i]))
                    {
                        string message = "Fejl i databasen";
                        string title = "Fejl";
                        MessageBox.Show(message, title);
                    }
                }

            }
        }

        internal void Sog(bool mobiler, bool pcer, bool pcdele, string afd, string ejer)
        {
            alleSog.Clear();
            /*  if (mobiler && pcer && pcdele)
              {
                  if(afd.Length > 0)
                  {
                      for(int i = 0; i < alleItems.Count; i++)
                      {
                          if(alleItems[i].Afdeling == afd)
                          {
                              alleSog.Add(alleItems[i]);
                          }

                      }
                  }
                  if (ejer.Length > 0)
                  {
                      for (int i = 0; i < alleItems.Count; i++)
                      {
                          if (alleItems[i].Ejer == "JJJ")
                          {
                              alleSog.Add(alleItems[i]);
                          }

                      }
                  }

              }
              */
            if (mobiler)
            {
                GetAlleMobiler();
                if (afd.Length > 0)
                {
                    for (int i = 0; i < alleMobiler.Count; i++)
                    {
                        if (alleMobiler[i].Afdeling == afd)
                        {
                            alleSog.Add(alleMobiler[i]);
                        }

                    }
                }
                if (ejer.Length > 0)
                {
                    for (int i = 0; i < alleMobiler.Count; i++)
                    {
                        if (alleMobiler[i].Ejer == ejer)
                        {
                            alleSog.Add(alleMobiler[i]);
                        }

                    }
                }
                if (ejer.Length == 0 && afd.Length == 0)
                {
                    for (int i = 0; i < alleMobiler.Count; i++)
                    {
                       alleSog.Add(alleMobiler[i]);
                    }
                }
            }
            if (pcer)
            {
                GetAllePcer();
                if (afd.Length > 0)
                {
                    for (int i = 0; i < allePC.Count; i++)
                    {
                        if (allePC[i].Afdeling == afd)
                        {
                            alleSog.Add(allePC[i]);
                        }

                    }
                }
                if (ejer.Length > 0)
                {
                    for (int i = 0; i < allePC.Count; i++)
                    {
                        if (allePC[i].Ejer == ejer)
                        {
                            alleSog.Add(allePC[i]);
                        }

                    }
                }
                if (ejer.Length == 0 && afd.Length == 0)
                {
                    for (int i = 0; i < allePC.Count; i++)
                    {
                        alleSog.Add(allePC[i]);
                    }
                }
            }
            if (pcdele)
            {
                GetAllePCDELE();
                if (afd.Length > 0)
                {
                    for (int i = 0; i < allePcDele.Count; i++)
                    {
                        if (allePcDele[i].Afdeling == afd)
                        {
                            alleSog.Add(allePcDele[i]);
                        }

                    }
                }
                if (ejer.Length > 0)
                {
                    for (int i = 0; i < allePcDele.Count; i++)
                    {
                        if (allePcDele[i].Ejer == ejer)
                        {
                            alleSog.Add(allePcDele[i]);
                        }

                    }
                }
                if (ejer.Length == 0 && afd.Length == 0)
                {
                    for (int i = 0; i < allePcDele.Count; i++)
                    {
                        alleSog.Add(allePcDele[i]);
                    }
                }
            }
        }

        internal void SletPc(string id) {
            for (int i = 0; i < alleItems.Count; i++)
            {
                if (alleItems[i].Id == id)
                {
                    string ids = id.Replace("p", "");
                    if (!pcDao.DeletePC(Convert.ToInt32(ids)))
                    {
                        string message = "Fejl i databasen";
                        string title = "Fejl";
                        MessageBox.Show(message, title);
                    }

                    alleItems.RemoveAt(i);

                }
            }
        }

        internal void SletPcDel(string id)
        {
            for (int i = 0; i < alleItems.Count; i++)
            {
                if (alleItems[i].Id == id)
                {
                    string ids = id.Replace("d", "");
                    if (!pcDeleDao.DeletePCDele(Convert.ToInt32(ids)))
                    {
                        string message = "Fejl i databasen";
                        string title = "Fejl";
                        MessageBox.Show(message, title);
                    }

                    alleItems.RemoveAt(i);

                }
            }
        }

        internal void OpdaterPcDele(string id, string text1, string text2, string text3, string text4, string text5, string text6, int v)
        {
            for (int i = 0; i < alleItems.Count; i++)
            {

                if (alleItems[i].Id == id)
                {
                    PCDele opM = new PCDele();
                    opM.Id = id;
                    opM.Note = text1;
                    opM.Lokation = text2;
                    opM.Afdeling = text3;
                    opM.Ejer = text4;
                    opM.Maerke = text5;
                    opM.Model = text6;
                    opM.Pris = v;                    

                    alleItems[i] = opM;

                    if (!pcDeleDao.UpdatePCDele((PCDele)alleItems[i]))
                    {
                        string message = "Fejl i databasen";
                        string title = "Fejl";
                        MessageBox.Show(message, title);
                    }
                }

            }
        }
        internal void SletMobil(string id, string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8, string text9)
        {
            for (int i = 0; i < alleItems.Count; i++)
            {
                if (alleItems[i].Id == id)
                {
                    string ids = id.Replace("m", "");
                    if (!mobilDao.DeleteMobil(Convert.ToInt32(ids)))
                    {
                        string message = "Fejl i databasen";
                        string title = "Fejl";
                        MessageBox.Show(message, title);
                    }

                    alleItems.RemoveAt(i);

                }
            }

        }
    }

        
    }
