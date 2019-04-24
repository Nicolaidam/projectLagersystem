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
            combo.Items.
                Add("Mobil");
            combo.Items.
                Add("PC");
            combo.Items.
                Add("PC-dele");
            combo.Items.
                Add("Andet");
           Logik.Instance.LoadItems();
           myDataGridd.ItemsSource = Logik.Instance.AlleItems;
            myDataGridd.IsReadOnly = true;





        }



        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

        //opret knap
        private void Button_Click(object sender, RoutedEventArgs e)
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
        }

        private void myDataGridd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          

        }

       

        private void mobiltjek_Click(object sender, RoutedEventArgs e)
        {
            if (mobiltjek.IsChecked == true)
            {
                MessageBox.Show("Der vises kun mobiler!");
                myDataGridd.ItemsSource = Logik.Instance.AlleMobiler;
            }
            if (mobiltjek.IsChecked == false)
            {
                MessageBox.Show("Alt vises igen!");
                myDataGridd.ItemsSource = Logik.Instance.AlleItems;
            }
           
        }

        private void pcchek_Click(object sender, RoutedEventArgs e)
        {
            if (pcchek.IsChecked == true)
            {
                MessageBox.Show("Der vises kun PC'er!");
                myDataGridd.ItemsSource = Logik.Instance.AllePCs;
            }
            if (pcchek.IsChecked == false)
            {
                MessageBox.Show("Alt vises igen!");
                myDataGridd.ItemsSource = Logik.Instance.AlleItems;
            }
        }

        private void TextBlock_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
           // myDataGrid.se
        }

        private void myDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            MessageBox.Show("Ændring foretaget!");
            // metoden nedenunder skal indkommenteres når DAO fungerer. Så burde man kunne redigere i et mobil item i DATAgrid og se det blive ændret i DB
            Logik.Instance.OpdaterMobiler();
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            myDataGridd.IsReadOnly = false;
        }
    } }
