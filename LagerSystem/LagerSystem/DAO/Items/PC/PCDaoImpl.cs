using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagerSystem.Model.Items_typer;

namespace LagerSystem.DAO.Items
{
    class PCDaoImpl : IPCDao
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-R6AA641\\SQLEXPRESS;Initial Catalog=lagersystem;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public void DeletePC(int id)
        {
            con.Open();
            String syntax = "DELETE FROM PC WHERE id='" + id + "'";
            cmd = new SqlCommand(syntax, con);
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                //TODO lav fejl medd - evt lav specielt return ved fejl
            }
            con.Close();
        }

        public List<PC> GetAllPC()
        {
            var hs = new List<PC>();

            con.Open();

            String syntax = "SELECT * FROM PC";
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
                String temp9 = dr[8].ToString(); //mac
                String temp10 = dr[9].ToString(); //ram
                String temp11 = dr[10].ToString(); //processor
                String temp12 = dr[11].ToString(); //grafikkort

                PC ii = new PC();

                ii.Id = temp1;
                ii.Note = temp2;
                ii.Lokation = temp3;
                ii.Ejer = temp4;
                ii.Afdeling = temp5;
                ii.Maerke = temp6;
                ii.Model = temp7;
                ii.Pris = temp8;
                ii.MacAdresse = temp9;
                ii.Ram = temp10;
                ii.Processor = temp11;
                ii.Grafikkort = temp11;
                hs.Add(ii);

    }

            con.Close();
            return hs;
        }

        public void InsertPC(PC pc)
        {
            //Evt return true hvis insert kommer igennem


            //ID skal auto incrementes i db

            String syntax = "INSERT INTO PC VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9,@param10,@param11)";
            cmd = new SqlCommand(syntax, con);

            cmd.Parameters.AddWithValue("@param1", pc.Note);
            cmd.Parameters.AddWithValue("@param2", pc.Lokation);
            cmd.Parameters.AddWithValue("@param3", pc.Ejer);
            cmd.Parameters.AddWithValue("@param4", pc.Afdeling);
            cmd.Parameters.AddWithValue("@param5", pc.Maerke);
            cmd.Parameters.AddWithValue("@param6", pc.Model);
            cmd.Parameters.AddWithValue("@param7", pc.Pris);
            cmd.Parameters.AddWithValue("@param8", pc.MacAdresse);
            cmd.Parameters.AddWithValue("@param9", pc.Ram);
            cmd.Parameters.AddWithValue("@param10", pc.Processor);
            cmd.Parameters.AddWithValue("@param11", pc.Grafikkort);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdatePC(PC pc)
        {
            con.Open();

            String syntax = "UPDATE PC SET note='@param1',lokation='@param2',ejer='@param3'," +
                "afdeling='@param4',maerke='@param5',model='@param6',pris='@param7',mac='@param8',ram='@param9',processor='@param10',grafikkort='@param11' WHERE id='" + pc.Id + "'";
            cmd = new SqlCommand(syntax, con);

            try
            {
                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 30).Value = pc.Note;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 30).Value = pc.Lokation;
                cmd.Parameters.Add("@param3", SqlDbType.VarChar, 30).Value = pc.Ejer;
                cmd.Parameters.Add("@param4", SqlDbType.VarChar, 30).Value = pc.Afdeling;
                cmd.Parameters.Add("@param5", SqlDbType.VarChar, 30).Value = pc.Maerke;
                cmd.Parameters.Add("@param6", SqlDbType.VarChar, 30).Value = pc.Model;
                cmd.Parameters.Add("@param7", SqlDbType.VarChar, 30).Value = pc.Pris;
                cmd.Parameters.Add("@param8", SqlDbType.VarChar, 30).Value = pc.MacAdresse;
                cmd.Parameters.Add("@param9", SqlDbType.VarChar, 30).Value = pc.Ram;
                cmd.Parameters.Add("@param10", SqlDbType.VarChar, 30).Value = pc.Processor;
                cmd.Parameters.Add("@param10", SqlDbType.VarChar, 30).Value = pc.Grafikkort;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                //TODO lav fejl medd - evt lav specielt return ved fejl
            }
            con.Close();
        }
    }
}
