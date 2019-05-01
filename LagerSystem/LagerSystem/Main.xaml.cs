using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using LagerSystem.Model;
using System.ComponentModel;
using LagerSystem.Model.Items_typer;
using System.Data;

namespace LagerSystem
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
           
            InitializeComponent();
            aendre.IsEnabled = false;
            fortryd.IsEnabled = false;
            opretknap.IsEnabled = false;
            slet.IsEnabled = false;
            combo.Items.
                Add("Mobil");
            combo.Items.
                Add("PC");
            combo.Items.
                Add("PC-dele");
            combo.Items.
                Add("Andet");
           Logik.Instance.LoadItems();
           dataGridv2.ItemsSource = Logik.Instance.AlleItems;
            dataGridv2.IsReadOnly = true;





        }



        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            opretknap.IsEnabled = true;
            //mobil
            if(combo.SelectedIndex == 0)
            {
                afd.IsEnabled = true;
                maerke.IsEnabled = true;
                ejer.IsEnabled = true;
                lokation.IsEnabled = true;
                model.IsEnabled = true;
                Note.IsEnabled = true;
                Pris.IsEnabled = true;
                ram.IsEnabled = true;
                IMEI.IsEnabled = true;
                mcA.IsEnabled = false;
                grafikkort.IsEnabled = false;
                Processor.IsEnabled = false;
               // MessageBox.Show("Du trykkede på indeks 1");
            }
            //pc
            if (combo.SelectedIndex == 1)
            {
                afd.IsEnabled = true;
                maerke.IsEnabled = true;
                ejer.IsEnabled = true;
                lokation.IsEnabled = true;
                model.IsEnabled = true;
                Note.IsEnabled = true;
                Pris.IsEnabled = true;
                ram.IsEnabled = true;
                IMEI.IsEnabled = false;
                mcA.IsEnabled = true;
                grafikkort.IsEnabled = true;
                Processor.IsEnabled = true;
                // MessageBox.Show("Du trykkede på indeks 1");
            }
            //pc dele
            if (combo.SelectedIndex == 2)
            {
                afd.IsEnabled = true;
                maerke.IsEnabled = true;
                ejer.IsEnabled = true;
                lokation.IsEnabled = true;
                model.IsEnabled = true;
                Note.IsEnabled = true;
                Pris.IsEnabled = true;
                ram.IsEnabled = false;
                IMEI.IsEnabled = false;
                mcA.IsEnabled = false;
                grafikkort.IsEnabled = false;
                Processor.IsEnabled = false;
                // MessageBox.Show("Du trykkede på indeks 1");
            }
            //andet
            if (combo.SelectedIndex == 3)
            {
                afd.IsEnabled = true;
                maerke.IsEnabled = true;
                ejer.IsEnabled = true;
                lokation.IsEnabled = true;
                model.IsEnabled = true;
                Note.IsEnabled = true;
                Pris.IsEnabled = true;
                ram.IsEnabled = false;
                IMEI.IsEnabled = false;
                mcA.IsEnabled = false;
                grafikkort.IsEnabled = false;
                Processor.IsEnabled = false;
                // MessageBox.Show("Du trykkede på indeks 1");
            }


        }

       

            

        private void mobiltjek_Click(object sender, RoutedEventArgs e)
        {
            if (mobiltjek.IsChecked == true)
            {
                MessageBox.Show("Der vises kun mobiler!");
                dataGridv2.ItemsSource = Logik.Instance.AlleMobiler;
            }
            if (mobiltjek.IsChecked == false)
            {
                MessageBox.Show("Alt vises igen!");
                dataGridv2.ItemsSource = Logik.Instance.AlleItems;
            }
           
        }

        private void pcchek_Click(object sender, RoutedEventArgs e)
        {
            if (pcchek.IsChecked == true)
            {
                MessageBox.Show("Der vises kun PC'er!");
                dataGridv2.ItemsSource = Logik.Instance.AllePCs;
            }
            if (pcchek.IsChecked == false)
            {
                MessageBox.Show("Alt vises igen!");
                dataGridv2.ItemsSource = Logik.Instance.AlleItems;
            }
        }

        private void TextBlock_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
           // myDataGrid.se
        }

       
        private void dataGridv2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(Logik.Instance.AlleMobiler[0].Id.Remove(0,2));
            if(dataGridv2.SelectedIndex != -1)
            {
                aendre.IsEnabled = true;
                slet.IsEnabled = true;
                fortryd.IsEnabled = true;
                Item customer = (Item)dataGridv2.SelectedItem;
                if (customer.Id.Contains("m"))
                {
                    Mobil mob = (Mobil)dataGridv2.SelectedItem;
                    IMEI.Text = mob.Imei;
                    ram.Text = mob.Ram;

                }
                MessageBox.Show("Ejer: " + customer.Ejer);
                afd.Text = customer.Afdeling;
                ejer.Text = customer.Ejer;
                maerke.Text = customer.Maerke;
                model.Text = customer.Model;
                Pris.Text = customer.Pris;
                lokation.Text = customer.Lokation;
                Note.Text = customer.Note;
            }
            
        }

        private void opretknap_Click(object sender, RoutedEventArgs e)
        {
            //mobil
            if (combo.SelectedIndex == 0)
            {
                Mobil mo = new Mobil();
                mo.Note = Note.Text;
                mo.Lokation = lokation.Text;
                mo.Ejer = ejer.Text;
                mo.Afdeling = afd.Text;
                mo.Maerke = maerke.Text;
                mo.Model = model.Text;
                mo.Pris = Pris.Text;
                mo.Imei = IMEI.Text;
                mo.Ram = ram.Text;
                Logik.Instance.addMobil(mo);


                //Logik.Instance.addMobil(Note.Text, lokation.Text, ejer.Text, afd.Text, maerke.Text, model.Text, Pris.Text, IMEI.Text, ram.Text);
                MessageBox.Show("Mobil tilføjet!!!");
            }
            //pc
            if (combo.SelectedIndex == 1)
            {
                // Logik.Instance.addPc(Note.Text, lokation.Text, ejer.Text, afd.Text, maerke.Text, model.Text, Pris.Text, mcA.Text, ram.Text, Processor.Text, grafikkort.Text);
                // MessageBox.Show("PC tilføjet!!!");
            }
            //pc dele
            if (combo.SelectedIndex == 2)
            {

            }
            //andet
            if (combo.SelectedIndex == 3)
            {

            }

            opretknap.IsEnabled = false;

    }

        private void fortryd_Click(object sender, RoutedEventArgs e)
        {
            slet.IsEnabled = false;
            aendre.IsEnabled = false;
            fortryd.IsEnabled = false;
            RydTekstFelter();
        }

        private void RydTekstFelter()
        {
            afd.Text = "";
            ejer.Text = "";
            maerke.Text = "";
            model.Text = "";
            Pris.Text = "";
            lokation.Text = "";
            Note.Text = "";
            IMEI.Text = "";
            ram.Text = "";
            grafikkort.Text = "";
            Processor.Text = "";
        }

        private void aendre_Click(object sender, RoutedEventArgs e)
        {
            Item customer = (Item)dataGridv2.SelectedItem;
            if (customer.Id.Contains("m"))
            {
                Mobil mob = (Mobil)dataGridv2.SelectedItem;
                Logik.Instance.OpdaterMobil(mob.Id, Note.Text, lokation.Text, ejer.Text, afd.Text, maerke.Text, model.Text, Pris.Text, ram.Text, IMEI.Text);
               
            }
            dataGridv2.ItemsSource = Logik.Instance.AlleMobiler;
            aendre.IsEnabled = false;
            fortryd.IsEnabled = false;
            slet.IsEnabled = false;
        }
    }
}
