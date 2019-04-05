using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagerSystem.Model.Items_typer;

namespace LagerSystem.DAO
{
    class MobilDaoImpl : IMobilDao
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database1.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public void DeleteMobil(int id)
        {
            throw new NotImplementedException();
        }

        public List<Mobil> GetAllMobil() { 
        
            var liste = new List<Mobil>();
            con.Open();
            String syntax = "SELECT * FROM Mobil";
            cmd = new SqlCommand(syntax, con);
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    String temp1 = dr[0].ToString(); //id
                    String temp2 = dr[1].ToString(); //note
                    String temp3 = dr[2].ToString(); //lokation
                    String temp4 = dr[3].ToString(); //ejer
                    String temp5 = dr[4].ToString(); //afd
                    String temp6 = dr[5].ToString(); //maerke
                    String temp7 = dr[6].ToString(); //model
                    String temp8 = dr[7].ToString(); //pris
                    String temp9 = dr[8].ToString(); //imei
                    String temp10 = dr[9].ToString(); //ram

                    Mobil i = new Mobil();

                    i.Id = temp1;
                    i.Note = temp2;
                    i.Lokation = temp3;
                    i.Ejer = temp4;
                    i.Afdeling = temp5;
                    i.Maerke = temp6;
                    i.Model = temp7;
                    i.Pris = temp8;
                    i.Imei = temp9;
                    i.Ram = temp10;

                    liste.Add(i);

                }
            }
            catch (SqlException)
            {
                //TODO lav fejl medd - evt lav specielt return ved fejl
            }

            con.Close();
            return liste;
        }

        public void InsertMobil(Mobil m) {

            //Evt return true hvis insert kommer igennem
            
            con.Open();
            //ID skal auto incrementes i db
            String syntax = "Insert into Mobil (note, lokation, ejer, afdeling, maerke, model, pris, imei, ram) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9)";
            cmd = new SqlCommand(syntax, con);

            try
            {
                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = m.Note;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = m.Lokation;
                cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = m.Ejer;
                cmd.Parameters.Add("@param4", SqlDbType.VarChar, 50).Value = m.Afdeling;
                cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = m.Maerke;
                cmd.Parameters.Add("@param6", SqlDbType.VarChar, 50).Value = m.Model;
                cmd.Parameters.Add("@param7", SqlDbType.VarChar, 50).Value = m.Pris;
                cmd.Parameters.Add("@param8", SqlDbType.VarChar, 50).Value = m.Imei;
                cmd.Parameters.Add("@param9", SqlDbType.VarChar, 50).Value = m.Ram;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                //TODO lav fejl medd - evt lav specielt return ved fejl
            }

        }

        public void UpdateMobil(Mobil mobil)
        {
            throw new NotImplementedException();
        }

        private static String inStr(String s)
        {
            String ss = "'" + s + "',";
            return ss;
        }
        private static String inStrSlut(String s)
        {
            String ss = "'" + s + "'";
            return ss;
        }

    }
}
