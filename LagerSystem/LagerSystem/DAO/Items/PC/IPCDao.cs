using LagerSystem.Model.Items_typer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LagerSystem.DAO
{
    interface IPCDao
    {
        List<PC> GetAllPC();
        Boolean UpdatePC(PC pc);
        Boolean DeletePC(int id);
        Boolean InsertPC(PC pc);
        String getHighestID();

    }
}
