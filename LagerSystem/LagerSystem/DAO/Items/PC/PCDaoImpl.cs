using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagerSystem.Model.Items_typer;

namespace LagerSystem.DAO.Items.PC
{
    class PCDaoImpl : IPCDao
    {
        //Jacob 
        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-91SF1OG\\SQLEXPRESS;Initial Catalog=lagersystem;Integrated Security=True");
        // Nico
         SqlConnection con = new SqlConnection("Data Source=DESKTOP-R6AA641\\SQLEXPRESS;Initial Catalog=lagersystem;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        public bool DeletePC(int id)
        {
            Boolean b = true;
            String id2 = id.ToString();

            String syntax = "DELETE FROM PC WHERE id=@param1";
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

        public List<Model.Items_typer.PC> GetAllPC()
        {
            var hs = new List<Model.Items_typer.PC>();

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

                Model.Items_typer.PC ii = new Model.Items_typer.PC();

                ii.Id = temp1;
                ii.Note = temp2;
                ii.Lokation = temp3;
                ii.Ejer = temp4;
                ii.Afdeling = temp5;
                ii.Maerke = temp6;
                ii.Model = temp7;
                ii.Pris = Int32.Parse(temp8);
                ii.MacAdresse = temp9;
                ii.Ram = Int32.Parse(temp10);
                ii.Processor = temp11;
                ii.Grafikkort = temp12;
                hs.Add(ii);

            }

            con.Close();
            return hs;
        }

        public string getHighestID()
        {
            String ret = "";
            con.Open();
            String syntax = "SELECT MAX(ID) FROM PC";

            cmd = new SqlCommand(syntax, con);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ret = dr[0].ToString(); //id

            }
            con.Close();
            return ret;
        }

        public bool InsertPC(Model.Items_typer.PC pc)
        {
            Boolean b = true;

            String syntax = "INSERT INTO PC (note, lokation, ejer, afdeling, maerke, model, pris, mac, ram, processor, grafikkort) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9,@param10,@param11)";
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

        public bool UpdatePC(Model.Items_typer.PC pc)
        {
            Boolean b = true;


            string iddd = pc.Id.Replace("pc", "");
            String syntax = "UPDATE PC SET note=@param1,lokation=@param2,ejer=@param3," +
                "afdeling=@param4,maerke=@param5,model=@param6,pris=@param7,mac=@param8,ram=@param9,processor=@param10,grafikkort=@param11 WHERE id=" + iddd;
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
    }
}
