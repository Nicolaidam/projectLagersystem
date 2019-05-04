using LagerSystem.Model.Items_typer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerSystem.DAO
{
    interface IPCDeleDao
    {
        List<PCDele> GetAllPCDele();
        Boolean UpdatePCDele(PCDele pcdele);
        Boolean DeletePCDele(int id);
        Boolean InsertPCDele(PCDele pcdele);
        String getHighestID();
    }
}
