using LagerSystem.Model.Items_typer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerSystem.DAO
{
    interface IMobilDao
    {
        List<Mobil> GetAllMobil();
        Boolean UpdateMobil(Mobil mobil);
        Boolean DeleteMobil(int id);
        Boolean InsertMobil(Mobil mobil);
        String getHighestID();

    }
}
