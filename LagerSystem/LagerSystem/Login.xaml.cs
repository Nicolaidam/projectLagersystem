using System;
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
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        private String getBrugernavn(String password)
        {
            con.Open();
            String syntax = "SELECT brugernavn FROM Login WHERE password = '" + password + "'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String temp = "0";

            try
            {
                temp = dr[0].ToString();
            }
            catch (System.InvalidOperationException)
            {

            }

            con.Close();
            return temp;
        }

        private String getPassword(String brugernavn)
        {

            con.Open();
            String syntax = "SELECT password FROM Login WHERE brugernavn = '" + brugernavn + "'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String temp = "1";

            try
            {
                temp = dr[0].ToString();
            }
            catch (System.InvalidOperationException)
            {

            }
            con.Close();

            return temp;
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

            String inputBrugernavn, inputPassword, dbBrugernavn, dbPassword;

            inputBrugernavn = textboxBrugernavn.Text;
            inputPassword = textboxPassword.Password;


            dbBrugernavn = getBrugernavn(inputPassword);
            dbPassword = getPassword(inputBrugernavn);


            Console.WriteLine(inputBrugernavn);
            Console.WriteLine(inputPassword);
            Console.WriteLine(dbBrugernavn);
            Console.WriteLine(dbPassword);

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
}
