using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace IndividualProject
{
    public class Module
    {
        //public string[] moduleCodes=new string[3] { "1202","1203","1204"};

        //public string[] moduleNames = new string[3] { "Electronics", "Drawing", "English" };

        public string moduleCode { get; set; }
        public string moduleName { get; set; }
        public double modCredit { get; set; }

        public double GPV;


        //public string[] Grades = new string[9] { "C-", "C", "C+", "B-", "B", "B+", "A-", "A", "A+" };

        public Module(string mCode,string mName) 
        {
            moduleCode = mCode;
            moduleName = mName;

            //mCode = mName;

            modCredit = ((int.Parse(moduleCode.Substring(2))) % 1000) / 100;
        }

    }
}
