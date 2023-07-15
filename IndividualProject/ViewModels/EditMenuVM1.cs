using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.Windows;
using IndividualProject.Views;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel;
using System.Xml.Linq;

namespace IndividualProject.ViewModels
{
    public partial class EditMenuVM1 : ObservableObject
    {
        [ObservableProperty]
        public string sfName;

        [ObservableProperty]
        public string slName;

        [ObservableProperty]
        public int sage;

        [ObservableProperty]
        public string sgender;

        [ObservableProperty]
        public string sdateofBirth;

        [ObservableProperty]
        public string sdateofAddmission;

        [ObservableProperty]
        public DateTime sbirthDate;

        [ObservableProperty]
        public DateTime saddmissionDate;

        [ObservableProperty]
        public double sgpa;

        [ObservableProperty]
        public string smodules;

        [ObservableProperty]
        public string smodCode;

        [ObservableProperty]
        public string smodName;

        [ObservableProperty]
        public string sresult;

        [ObservableProperty]
        public ObservableCollection<Module> modules;

        [ObservableProperty]
        public BitmapImage sselectedImage;

        public Module currentModule { get;private set; }
        public Student CurrentStudent { get; private set; }

        public Action closeAction {  get; internal set; }

        public Action clearAction {  get; internal set; }

        public ObservableCollection<string> sgenders = new ObservableCollection<string>();

        public ObservableCollection<string> sGenders
        {
            get { return sgenders; }
            set { sgenders = value; }
        }

        public ObservableCollection<string> sresults = new ObservableCollection<string>();

        public ObservableCollection<string> sResults
        {
            get { return sresults; }
            set { sresults = value; }
        }

        public EditMenuVM1(Student cS)
        {
            if(cS!=null)
            {
                SfName = cS.FirstName;
                SlName = cS.LastName;
                Sage = cS.Age;
                Sgender = cS.Gender;
                SdateofBirth = cS.DateofBirth;
                SdateofAddmission = cS.DateofAddmission;
                SselectedImage = cS.Image;
            }
            CurrentStudent = cS;
          

            sGenders = new ObservableCollection<string>()
            {
                new string("Male"),
                new string("Female")
            };

            sResults = new ObservableCollection<string>()
            {
                new string("A+"),
                new string("A"),
                new string("A-"),
                new string("B+"),
                new string("B"),
                new string("B-"),
                new string("C+"),
                new string("C"),
                new string("C-"),
                new string("E")
            };

            Modules = new ObservableCollection<Module>();
            Modules.Add(new Module("EE1302", "Electronics"));
            Modules.Add(new Module("ME1301", "Fluid Mechanics"));
            Modules.Add(new Module("CE1204", "Fluid Mechanics"));
            Modules.Add(new Module("CE1203", "Mechanics of meterials"));
        }

        public EditMenuVM1()
        {

        }

        [RelayCommand]
        public void uploadNewImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                SselectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Successfully uploaded selected Image!", "Successful",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }


        [RelayCommand]
        public void saveStudent()
        {
            if(CurrentStudent!=null) 
            {
                SdateofBirth = SbirthDate.ToString().Substring(0, 10);
                SdateofAddmission = SdateofAddmission.Substring(0, 10);

                CurrentStudent.FirstName = SfName;
                CurrentStudent.LastName = SlName;
                CurrentStudent.Age = Sage;
                CurrentStudent.Image = SselectedImage;
                CurrentStudent.DateofBirth = SdateofBirth;
                CurrentStudent.Gender = Sgender;
                CurrentStudent.DateofAddmission = SdateofAddmission;
            }
            MessageBoxResult result = MessageBox.Show("The student is successfully edited!", "Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            if (result == MessageBoxResult.OK) { closeAction(); }

        }

 

        [RelayCommand]
        public void addModules()
        {
            bool Comment = false;
            for (int i = 0; i < CurrentStudent.stModules.Count; i++)
            {

                if (CurrentStudent.stModules[i].moduleCode == SmodCode)
                {
                    MessageBoxResult result = MessageBox.Show("The result for this module is already added.If you want to edit result, press the OK button.", "Attention", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                    if(result==MessageBoxResult.OK)
                    {
                        if (Sresult == "E")
                        {
                            CurrentStudent.stModules[i].GPV = 0.0;
                        }
                        else if (Sresult == "C-")
                        {
                            CurrentStudent.stModules[i].GPV = 1.7;
                        }
                        else if (Sresult == "C")
                        {
                            CurrentStudent.stModules[i].GPV = 2.0;
                        }
                        else if (Sresult == "C+")
                        {
                            CurrentStudent.stModules[i].GPV = 2.3;
                        }
                        else if (Sresult == "B-")
                        {
                            CurrentStudent.stModules[i].GPV = 2.7;
                        }
                        else if (Sresult == "B")
                        {
                            CurrentStudent.stModules[i].GPV = 3.0;
                        }
                        else if (Sresult == "B+")
                        {
                            CurrentStudent.stModules[i].GPV = 3.3;
                        }
                        else if (Sresult == "A-")
                        {
                            CurrentStudent.stModules[i].GPV = 3.7;
                        }
                        else if (Sresult == "A")
                        {
                            CurrentStudent.stModules[i].GPV = 4.0;
                        }
                        else if (Sresult == "A+")
                        {
                            CurrentStudent.stModules[i].GPV = 4.0;
                        }

                        CurrentStudent.calculateGPA();
                        clearAction();
                    }
                    else if(result==MessageBoxResult.Cancel)
                    {
                        MessageBoxResult result1=MessageBox.Show("Do you want to delete this module?","Question",MessageBoxButton.YesNo,MessageBoxImage.Question);
                        if(result1==MessageBoxResult.Yes)
                        {
                            CurrentStudent.stModules.Remove(CurrentStudent.stModules[i]);
                            MessageBox.Show($"{SmodCode} is successfully deleted!", "Deleted\a", MessageBoxButton.OK, MessageBoxImage.Information);
                            CurrentStudent.calculateGPA();
                            clearAction();
                        }
                        else if(result1 == MessageBoxResult.No)
                        {
                            clearAction();
                        }
                    }
                    Comment = true;
                }

            }

            if (Comment==false)
            {
                currentModule = new Module(SmodCode, SmodName);

                if (Sresult == "E")
                {
                    currentModule.GPV = 0.0;
                }
                else if (Sresult == "C-")
                {
                    currentModule.GPV = 1.7;
                }
                else if (Sresult == "C")
                {
                    currentModule.GPV = 2.0;
                }
                else if (Sresult == "C+")
                {
                    currentModule.GPV = 2.3;
                }
                else if (Sresult == "B-")
                {
                    currentModule.GPV = 2.7;
                }
                else if (Sresult == "B")
                {
                    currentModule.GPV = 3.0;
                }
                else if (Sresult == "B+")
                {
                    currentModule.GPV = 3.3;
                }
                else if (Sresult == "A-")
                {
                    currentModule.GPV = 3.7;
                }
                else if (Sresult == "A")
                {
                    currentModule.GPV = 4.0;
                }
                else if (Sresult == "A+")
                {
                    currentModule.GPV = 4.0;
                }

                //currentModule.numberOfModules = CurrentModules.Count+1;        
                CurrentStudent.stModules.Add(currentModule);

                CurrentStudent.calculateGPA();
                //CurrentStudent.GPA+=(currentGPA)/ Convert.ToDouble(CurrentStudent.stModules.Count);
                clearAction();


            }

        }
   
    }
}