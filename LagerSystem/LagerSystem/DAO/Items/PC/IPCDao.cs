using LagerSystem.Model.Items_typer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerSystem.DAO.Items
{
    interface IPCDao
    {
        List<PC> GetAllPC();
        void UpdatePC(PC pc);
        void DeletePC(int id);
        void InsertPC(PC pc);
    }
}
