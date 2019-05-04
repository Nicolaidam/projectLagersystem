using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagerSystem.Model.Items_typer;

namespace LagerSystem.DAO.Items.PCDele
{
    class PCDeleDaoImpl : IPCDeleDao
    {
        //Jacob 
        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-91SF1OG\\SQLEXPRESS;Initial Catalog=lagersystem;Integrated Security=True");
        // Nico
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-R6AA641\\SQLEXPRESS;Initial Catalog=lagersystem;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        public bool DeletePCDele(int id)
        {
            Boolean b = true;
            String id2 = id.ToString();

            String syntax = "DELETE FROM PCDele WHERE id=@param1";
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

        public List<Model.Items_typer.PCDele> GetAllPCDele()
        {
            var hs = new List<Model.Items_typer.PCDele>();

            con.Open();

            String syntax = "SELECT * FROM PCDele";
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


                Model.Items_typer.PCDele ii = new Model.Items_typer.PCDele();

                ii.Id = temp1;
                ii.Note = temp2;
                ii.Lokation = temp3;
                ii.Ejer = temp4;
                ii.Afdeling = temp5;
                ii.Maerke = temp6;
                ii.Model = temp7;
                ii.Pris = Int32.Parse(temp8);
                hs.Add(ii);
            }

            con.Close();
            return hs;
        }

        public string getHighestID()
        {
            String ret = "";
            con.Open();
            String syntax = "SELECT MAX(ID) FROM PCDele";

            cmd = new SqlCommand(syntax, con);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ret = dr[0].ToString(); //id

            }
            con.Close();
            return ret;
        }

        public bool InsertPCDele(Model.Items_typer.PCDele pcdele)
        {
            Boolean b = true;

            String syntax = "INSERT INTO PCDele (note, lokation, ejer, afdeling, maerke, model, pris) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7)";
            cmd = new SqlCommand(syntax, con);


            cmd.Parameters.AddWithValue("@param1", pcdele.Note);
            cmd.Parameters.AddWithValue("@param2", pcdele.Lokation);
            cmd.Parameters.AddWithValue("@param3", pcdele.Ejer);
            cmd.Parameters.AddWithValue("@param4", pcdele.Afdeling);
            cmd.Parameters.AddWithValue("@param5", pcdele.Maerke);
            cmd.Parameters.AddWithValue("@param6", pcdele.Model);
            cmd.Parameters.AddWithValue("@param7", pcdele.Pris);

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

        public bool UpdatePCDele(Model.Items_typer.PCDele pcdele)
        {
            Boolean b = true;


            string iddd = pcdele.Id.Replace("pcDel", "");
            String syntax = "UPDATE PCDele SET note=@param1,lokation=@param2,ejer=@param3," +
                "afdeling=@param4,maerke=@param5,model=@param6,pris=@param7 WHERE id=" + iddd;
            cmd = new SqlCommand(syntax, con);

            cmd.Parameters.AddWithValue("@param1", pcdele.Note);
            cmd.Parameters.AddWithValue("@param2", pcdele.Lokation);
            cmd.Parameters.AddWithValue("@param3", pcdele.Ejer);
            cmd.Parameters.AddWithValue("@param4", pcdele.Afdeling);
            cmd.Parameters.AddWithValue("@param5", pcdele.Maerke);
            cmd.Parameters.AddWithValue("@param6", pcdele.Model);
            cmd.Parameters.AddWithValue("@param7", pcdele.Pris);



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
