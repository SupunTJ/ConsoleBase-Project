using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBaseProject
{
    public class Module
    {
        public string ModuleID { get; set; }
        public string ModuleName { get; set; }
        public double GradePoint { get; set; }
        public int CreditValue { get; set; }
        public string Grade { get; set; }


        public Module(string moduleID, string moduleName,string grade, int creditValue,double gradePoint) { 

            ModuleID = moduleID;
            ModuleName = moduleName;
            Grade = grade;
            CreditValue = creditValue;
            GradePoint = gradePoint;
        }
    }    
}
