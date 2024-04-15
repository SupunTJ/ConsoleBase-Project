using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBaseProject
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }

        public List<Module> Modules = new List<Module>();


        public User (string firstName,string lastName, string dateOfBirth, string address, int userID)
        {
            FirstName = firstName;
            LastName = lastName;
            UserID = userID;
            DateOfBirth = dateOfBirth;
            Address = address;
        }

        public string GpaCalculation()
        {         
            double totalCredits = 0;
            double totalGradePoint = 0;
            double sumOfGradePoint = 0;

            foreach (var moduleUser in Modules)
            {
                
                totalGradePoint = moduleUser.GradePoint * moduleUser.CreditValue;
                sumOfGradePoint += totalGradePoint;
                totalCredits += moduleUser.CreditValue;
            }
            double gpa;

            gpa = sumOfGradePoint / totalCredits;

            string formattedGpa = gpa.ToString("0.0000");

            return formattedGpa;
        }
    }
}
