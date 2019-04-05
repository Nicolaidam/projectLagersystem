using LagerSystem.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerSystem.DAO
{
   interface LoginDao
    {

        //Disse to klasser bruges til at verificere om det er den rigtige bruger.. Kan sikkert gøres smartere
        String GetBrugernavn(String password);
        String GetPassword(String brugernavn);


        void SletBruger(String brugernavn);
        void UpdaterBruger(String brugernavn);

        List<String> getBrugere(); 
    }
}
