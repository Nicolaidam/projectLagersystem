using LagerSystem.DAO;
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
        LoginDao loginDao = new LoginDaoImpl();
        public Login()
        {
            InitializeComponent();

            List<String> gg = new List<String>();
            gg = loginDao.getBrugere();
            v1.Text = gg[0];
            v2.Text = gg[1];
            v3.Text = gg[2];
            v4.Text = gg[3];

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

                dbbBrugernavn = loginDao.GetBrugernavn("123456");
                dbbPassword = loginDao.GetPassword("Johnny");
                if ("Johnny".Equals(dbbBrugernavn) && "123456".Equals(dbbPassword))
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

                //dbBrugernavn = getBrugernavn(inputPassword);
                //dbPassword = getPassword(inputBrugernavn);
                dbBrugernavn = loginDao.GetBrugernavn(inputPassword);
                dbPassword = loginDao.GetPassword(inputBrugernavn);

                if (inputBrugernavn.Equals(dbBrugernavn) && inputPassword.Equals(dbPassword))
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
            //LoginDao hej = new LoginDaoImpl();
            morten.Text = loginDao.GetBrugernavn("123456");
        }
    }
}



