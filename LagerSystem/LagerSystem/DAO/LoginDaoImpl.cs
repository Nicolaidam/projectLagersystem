using LagerSystem.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerSystem.DAO
{
    class LoginDaoImpl : LoginDao
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database1.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        //returner fejl hvis ikke brugernavn og password passer ELLER database fejler.
        //Ellers returneres brugernavnet der passer med passworded
        public string GetBrugernavn(string password)
        {
            con.Open();
            String syntax = "SELECT brugernavn FROM Login WHERE password = '" + password + "'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String temp = "fejl";

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

        public List<String> getBrugere()
        {
            //ArrayList liste = new ArrayList();
            List<String> hs = new List<String>();
            String[] arr;
            con.Open();
            String syntax = "SELECT * FROM Login";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //LoginModel h = new LoginModel();
                String temp1 = dr[0].ToString();
                String temp2 = dr[1].ToString();
                //h.Brugernavn = temp1;
                //h.Password = temp2;
                //liste.Add(h);
                hs.Add(temp1);
                hs.Add(temp2);

            }

            con.Close();
            return hs;
        }

        //returner fejl hvis ikke brugernavn og password passer ELLER database fejler. 
        //Ellers returneres passwordet tilhørende til brugernavet
        public string GetPassword(string brugernavn)
        {
            con.Open();
            String syntax = "SELECT password FROM Login WHERE brugernavn = '" + brugernavn + "'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String temp = "fejl";

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
        //Returnerer "fejl" hvis database fejler eller brugernavnet ikke findes
        public void SletBruger(string brugernavn)
        {
            con.Open();
            //String syntax = "DELETE FROM Login WHERE brugernavn = '" + brugernavn + "'";
            
        }

        public void UpdaterBruger(string brugernavn)
        {
            throw new NotImplementedException();
        }


    }
}
    
