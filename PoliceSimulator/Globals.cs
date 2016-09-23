using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceSimulator
{
    static class Globals
    {

        public static string[] Streets = System.IO.File.ReadAllLines(@"Streets.txt");
        public static string[] CallTypes = System.IO.File.ReadAllLines(@"CallTypes.txt");
        //public Globals()
        //{
            
        //}

        

    }
}
