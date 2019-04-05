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
        void UpdateMobil(Mobil mobil);
        void DeleteMobil(int id);
        void InsertMobil(Mobil mobil);
    }
}
