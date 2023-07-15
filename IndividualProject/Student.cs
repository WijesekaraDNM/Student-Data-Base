using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace IndividualProject
{
    public class Student
    {
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string DateofAddmission { get; set; }
        public BitmapImage Image { get; set; }
        public string DateofBirth { get; set; }
        public double TotalGPV { get; set; }
        public double GPVCredits { get; set; }
        public double GPA { get; set; }
        public List<Module> stModules { get; set; }


        public string ImagePath
        {
            get { return $"F:/Academic/3rd sem/sem3/GUI programing/Assignment/Individual project final/IndividualProject/IndividualProject/Images/{Image}"; }
        }

        public Student(string studentID, string firstName, string lastName,int age,string gender,string dateofAddmission, string dateOfBirth, BitmapImage image,double gpa)
        {
            StudentID = studentID ;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            DateofAddmission = dateofAddmission;
            DateofBirth = dateOfBirth;
            Image = image;
            GPA=gpa;

            stModules = new List<Module>(); 
        }

        public Student()
        {
        }

        public void calculateGPA()
        {
            GPA = 0;
            TotalGPV = 0;
            GPVCredits = 0;
            for(int i=0; i<stModules.Count; i++)
            {
                TotalGPV += (stModules[i].modCredit * stModules[i].GPV);
                GPVCredits += (stModules[i].modCredit);
                
            }
            GPA = Math.Round(TotalGPV/GPVCredits,2);
          
        }
    }
}
