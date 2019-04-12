﻿using LagerSystem.Model;
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
        //SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|C:|\\|Users|\\|nicol|\\|Source|\\|Repos|\\|Nicolaidam|\\|projectLagersystem\\|LagerSystem|\\Database1.mdf\";Integrated Security=True");
        //SqlConnection con = new SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nicol\Source\Repos\Nicolaidam\projectLagersystem\LagerSystem\LagerSystem\Database1.mdf;Integrated Security=True");
        //String connectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Im awsome\Documents\Visual Studio 2013\Projects\WpfApplication\WpfApplication\BRDS.mdf;Integrated Security=True";
        //SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFileName=C:\\Users\\nicol\\Source\\Repos\\Nicolaidam\\projectLagersystem\\LagerSystem\\LagerSystem\\bin\\Debug\\Database1.mdf\";Integrated Security=True");
        //SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database1.mdf\";Integrated Security=True");
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database1.mdf\";Integrated Security=True");
        //SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\nicol\\Source\\Repos\\Nicolaidam\\projectLagersystem\\LagerSystem\\LagerSystem\\Database1.mdf;Integrated Security=True");

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

        public void OpreBruger(String brugernavn, String password)
        {
            String syntax = "INSERT INTO Login (brugernavn, password) VALUES(@param1,@param2)";
            cmd = new SqlCommand(syntax, con);


            cmd.Parameters.AddWithValue("@param1", brugernavn);
            cmd.Parameters.AddWithValue("@param2", password);

            /*

            cmd.Parameters.Add("@param2", SqlDbType.VarChar, 30).Value = m.Lokation;
                cmd.Parameters.Add("@param3", SqlDbType.VarChar, 30).Value = m.Ejer;
                cmd.Parameters.Add("@param4", SqlDbType.VarChar, 30).Value = m.Afdeling;
                cmd.Parameters.Add("@param5", SqlDbType.VarChar, 30).Value = m.Maerke;
                cmd.Parameters.Add("@param6", SqlDbType.VarChar, 30).Value = m.Model;
                cmd.Parameters.Add("@param7", SqlDbType.VarChar, 30).Value = m.Pris;
                cmd.Parameters.Add("@param8", SqlDbType.VarChar, 30).Value = m.Imei;
                cmd.Parameters.Add("@param9", SqlDbType.VarChar, 30).Value = m.Ram;
                */

            //cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        
    }
}
    
