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
            Logik logik = Logik.Instance;
            logik.addItem(new Item { Ejer = "Jacob", Id = "qwe", Lokation = "h", Maerke = "kk", Model = "din mor", Note = "hhhhhh", Pris = 123 });
            logik.addItem(new Mobil { Afdeling = "470", Ejer = "Anders", Id = "qwe", Lokation = "h", Maerke = "kk", Model = "din mor", Note = "hhhhhh", Pris = 123 });
            logik.addItem(new Item { Afdeling = "30", Ejer = "Brian", Id = "qwe", Lokation = "h", Maerke = "kk", Model = "din mor", Note = "hhhhhh", Pris = 123 });
            myDataGrid.ItemsSource = logik.AlleItems;
            



        }

        

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                     
        }

        //opret knap
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //lige nu kan der oprettes ny, men ikke med den der combobox, alt oprettes som Item
            MessageBox.Show(combo.Text);
            Logik.Instance.addItem(new Item {Ejer = ejer.Text, Afdeling = afd.Text, Maerke = maerke.Text, Model = model.Text });
        }
    } }
