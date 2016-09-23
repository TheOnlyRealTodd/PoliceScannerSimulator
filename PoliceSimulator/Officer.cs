using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PoliceSimulator
{
    class Officer
    {
        public string Unit1 => "twenty three paul";
        public string Unit2 => "twenty one paul";
        public string Unit3 => "twenty two paul";
        public string Unit4 => "twenty five edward";
        public string Unit5 => "twenty six edward";
        public string Unit6 => "twenty four paul";
        public string Unit7 => "twenty seven paul";

        public string[] OfficersToPick => new string[]
        {
            Unit1,
            Unit2,
            Unit3,
            Unit4,
            Unit5,
            Unit6,
            Unit7
        };

}

}
