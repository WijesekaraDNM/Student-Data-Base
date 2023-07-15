using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IndividualProject.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace IndividualProject.ViewModels
{
    public partial class AddMenuVM:ObservableObject
    {
        [ObservableProperty]
        public string? sID;

        [ObservableProperty]
        public string? fName;

        [ObservableProperty]
        public string? lName;

        [ObservableProperty]
        public int ageAdd;

        public int count { get; set; }

        [ObservableProperty]
        public string? genderAdd;

        [ObservableProperty]
        public DateTime? birthDate;

        [ObservableProperty]
        public DateTime? addmissionDate;

        [ObservableProperty]
        public string? dateofBirthAdd;

        [ObservableProperty]
        public string? dateofAddmissionAdd;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public BitmapImage selectedImage;

        public ObservableCollection<string> genders = new ObservableCollection<string>();

        public ObservableCollection<string> Genders
        {
            get { return genders; }
            set { genders = value; }
        }

        //[ObservableProperty]
        //public ObservableCollection<string> genders;

        public AddMenuVM()
        {
            Genders = new ObservableCollection<string>()
            {
                new string("Male"),
                new string("Female")
            };

        }

        [RelayCommand]
        public void uploadImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                SelectedImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Image is successfully uploded!", "Successful\a",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        public Student newStudent { get; private set; }

        public Action closeAction { get; internal set; }

        [RelayCommand]
        public void insertStudent()
        {

            if (FName!=null&&LName!=null&&AgeAdd!=null&&GenderAdd!=null&&AddmissionDate!=null&&BirthDate!=null)
            {
                DateofBirthAdd = BirthDate.ToString().Substring(0, 10);
                DateofAddmissionAdd = AddmissionDate.ToString().Substring(0, 10);

                string[] arr = DateofAddmissionAdd.Split("/");
                count++;
                SID = "EG/" + arr[2] + "/" +count.ToString();

                newStudent = new Student()
                {
                    StudentID = SID,
                    Image = SelectedImage,
                    FirstName = FName,
                    LastName = LName,
                    Age = AgeAdd,
                    Gender = GenderAdd,
                    DateofAddmission = DateofAddmissionAdd,
                    DateofBirth = DateofBirthAdd,
                    stModules = new List<Module>()                    
                };
                MessageBoxResult result= MessageBox.Show("The student is successfully added!","Successful\a",MessageBoxButton.OK,MessageBoxImage.Information);
                if(result == MessageBoxResult.OK) { closeAction(); }
              
            }
            else
            {
                MessageBox.Show("Enter all neccessary details.", "Error\a",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

    }
}
