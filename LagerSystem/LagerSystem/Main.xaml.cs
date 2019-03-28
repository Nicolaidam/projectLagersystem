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
            ObservableCollection<Item> employees = new ObservableCollection<Item>();
            employees.Add(new Item { Afdeling = "670", Ejer = "Jacob", Id = "qwe", Lokation = "h", Maerke = "kk", Model = "din mor", Note = "hhhhhh", Pris = 123});
            employees.Add(new Mobil { Afdeling = "470", Ejer = "Anders", Id = "qwe", Lokation = "h", Maerke = "kk", Model = "din mor", Note = "hhhhhh", Pris = 123 });
            employees.Add(new Item { Afdeling = "30", Ejer = "Brian", Id = "qwe", Lokation = "h", Maerke = "kk", Model = "din mor", Note = "hhhhhh", Pris = 123 });
            myDataGrid.ItemsSource = employees;



           
        }
    } }
