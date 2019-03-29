using LagerSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerSystem.DAO
{
    interface ItemDao
    {
        //Disse metoder burde være public, men det kan man ikkei c#? hmm
        // se https://www.tutorialspoint.com/design_pattern/data_access_object_pattern.htm
        List<Item> GetAllItems();
        List<Item> GetAllMobil();
        List<Item> GetAllPC();
        List<Item> GetAllPCDele();
        void UpdateItem(Item item);
        void DeleteItem(Item item);
        Item GetItem(int id);
    }
}
