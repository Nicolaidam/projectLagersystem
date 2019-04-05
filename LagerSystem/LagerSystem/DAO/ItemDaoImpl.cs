using LagerSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerSystem.DAO
{
    
    class ItemDaoImpl : ItemDao
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database1.mdf\";Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
    
        public void DeleteItem(Item item)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetAllItems()
        {
            //ArrayList liste = new ArrayList();
            var hs = new List<Item>();
            con.Open();
            String syntax = "SELECT * FROM Item";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //LoginModel h = new LoginModel();
                String temp1 = dr[0].ToString(); //id
                String temp2 = dr[1].ToString(); //note
                String temp3 = dr[2].ToString(); //lokation
                String temp4 = dr[3].ToString(); //ejer
                String temp5 = dr[4].ToString(); //afd
                String temp6 = dr[5].ToString(); //maerke
                String temp7 = dr[6].ToString(); //model
                String temp8 = dr[7].ToString(); //pris
                Item i = new Item();
                i.Id = temp1;
                i.Note = temp2;
                i.Lokation = temp3;
                i.Ejer = temp4;
                i.Afdeling = temp5;
                i.Maerke = temp6;
                i.Model = temp7;
                i.Pris = temp8;
                //h.Brugernavn = temp1;
                //h.Password = temp2;
                //liste.Add(h);
                hs.Add(i);

            }

            con.Close();
            return hs;
        }

        public List<Item> GetAllMobil()
        {
            throw new NotImplementedException();
        }

        public List<Item> GetAllPC()
        {
            throw new NotImplementedException();
        }

        public List<Item> GetAllPCDele()
        {
            throw new NotImplementedException();
        }

        public Item GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
