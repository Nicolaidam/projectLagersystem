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

        //Jacob 
        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-91SF1OG\\SQLEXPRESS;Initial Catalog=lagersystem;Integrated Security=True");
        // Nico
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-R6AA641\\SQLEXPRESS;Initial Catalog=lagersystem;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public Boolean DeleteMobil(int id)
        {
            Boolean b = true;
            String id2 = id.ToString();
            
            String syntax = "DELETE FROM Mobil WHERE id=@param1";
            cmd = new SqlCommand(syntax, con);
            cmd.Parameters.AddWithValue("@param1", id.ToString());
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException)
            {
                b = false;
            }
            con.Close();
            return b;
        }

        public List<Mobil> GetAllMobil() {

            var hs = new List<Mobil>();
           
                con.Open();
            
            String syntax = "SELECT * FROM Mobil";
            cmd = new SqlCommand(syntax, con);
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

                Mobil ii = new Mobil();

                ii.Id = temp1;
                ii.Note = temp2;
                ii.Lokation = temp3;
                ii.Ejer = temp4;
                ii.Afdeling = temp5;
                ii.Maerke = temp6;
                ii.Model = temp7;
                ii.Pris = Int32.Parse(temp8);
                ii.Imei = temp9;
                ii.Ram = Int32.Parse(temp10);
                hs.Add(ii);

            }

            con.Close();
            return hs;
        }

        public Boolean InsertMobil(Mobil m) {

            Boolean b = true;
            
            String syntax = "INSERT INTO Mobil (note, lokation, ejer, afdeling, maerke, model, pris, imei, ram) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9)";
            cmd = new SqlCommand(syntax, con);


            cmd.Parameters.AddWithValue("@param1", m.Note);
            cmd.Parameters.AddWithValue("@param2", m.Lokation);
            cmd.Parameters.AddWithValue("@param3", m.Ejer);
            cmd.Parameters.AddWithValue("@param4", m.Afdeling);
            cmd.Parameters.AddWithValue("@param5", m.Maerke);
            cmd.Parameters.AddWithValue("@param6", m.Model);
            cmd.Parameters.AddWithValue("@param7", m.Pris);
            cmd.Parameters.AddWithValue("@param8", m.Imei);
            cmd.Parameters.AddWithValue("@param9", m.Ram);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                b = false;
            }
            con.Close();
            return b;
        }

        public Boolean UpdateMobil(Mobil m)
        {
            Boolean b = true;
           

            string iddd = m.Id.Replace("mo", "");        
            String syntax = "UPDATE Mobil SET note=@param1,lokation=@param2,ejer=@param3," +
                "afdeling=@param4,maerke=@param5,model=@param6,pris=@param7,imei=@param8,ram=@param9 WHERE id="+iddd;
            cmd = new SqlCommand(syntax, con);

            
            cmd.Parameters.AddWithValue("@param1", m.Note);
            cmd.Parameters.AddWithValue("@param2", m.Lokation);
            cmd.Parameters.AddWithValue("@param3", m.Ejer);
            cmd.Parameters.AddWithValue("@param4", m.Afdeling);
            cmd.Parameters.AddWithValue("@param5", m.Maerke);
            cmd.Parameters.AddWithValue("@param6", m.Model);
            cmd.Parameters.AddWithValue("@param7", m.Pris);
            cmd.Parameters.AddWithValue("@param8", m.Imei);
            cmd.Parameters.AddWithValue("@param9", m.Ram);


            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
              
                cmd.ExecuteNonQuery();
                
            }
            catch (SqlException)
            {
                b = false;
            }
            con.Close();
            return b;
        }
        public String getHighestID()
        {
            String ret = "";
            con.Open();
            String syntax = "SELECT MAX(ID) FROM Mobil";

            cmd = new SqlCommand(syntax, con);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               ret = dr[0].ToString(); //id

            }
            con.Close();
            return ret;
        }
        
      

    }
}
