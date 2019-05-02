using LagerSystem.DAO;
using LagerSystem.Model.Items_typer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace LagerSystem
{

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        IMobilDao d = new MobilDaoImpl();
        public Login()
        {
            InitializeComponent();
           // d.DeleteMobil(2);
            
            /*
            Mobil m = new Mobil();
            m.Id = "30";
            m.Note = "ssse";
            m.Lokation = "sssse";
            m.Ejer = "fssse";
            m.Afdeling = "sse";
            m.Maerke = "ssse";
            m.Model = "ssse";
            m.Pris = "sse";
            m.Imei = "ss";
            m.Ram = "se";

            d.UpdateMobil(m);
            */
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)

        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //TODO lav verifisering af brugernavn og password
            if (hh.IsChecked == true)
            {
                //MessageBox.Show("DEN ER TRUE!");
                String dbbBrugernavn, dbbPassword;
                
               
                if (Logik.Instance.verificerBruger("admin", "123456"))
                {
                    Main h = new Main();
                    h.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Forkert login");
                }
                

            }
            else
            {

                String inputBrugernavn, inputPassword, dbBrugernavn, dbPassword;

                inputBrugernavn = textboxBrugernavn.Text;
                inputPassword = textboxPassword.Password;

      

                    if (Logik.Instance.verificerBruger(inputBrugernavn, inputPassword))
                    {
                    Main h = new Main();
                    h.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Forkert login");
                }
                
            }


        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
        }
    }
}



