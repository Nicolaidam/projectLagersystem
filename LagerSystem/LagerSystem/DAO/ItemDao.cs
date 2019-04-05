using LagerSystem.Model;
using LagerSystem.Model.Items_typer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerSystem.DAO
{
    interface ItemDao
    {
        
        List<Item> GetAllItems();
        
        List<PC> GetAllPC();
        List<PCDele> GetAllPCDele();
       
        void UpdatePC(PC mobil);
        void UpdatePCDele(PCDele PCDel);
       
        void DeletePC(int id);
        void DeletePCdele(int id);
        
        void InsertPC(PC pc);
        void InsertPCdele(PCDele pcdel);
    }
}
