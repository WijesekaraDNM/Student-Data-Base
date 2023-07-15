using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace IndividualProject.ViewModels
{
    public partial class EditMenuVM : ObservableObject
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
        public string sdoBirth;

        [ObservableProperty]
        public string sdoAddmission;

        [ObservableProperty]
        public double sgpa;

        [ObservableProperty]
        public string stitle;

        [ObservableProperty]
        public string smoduleCode;

        [ObservableProperty]
        public string sresult;

        [ObservableProperty]
        public BitmapImage sselImage;

        public Student student { get; private set; }

        public ObservableCollection<string> sgenders = new ObservableCollection<string>();

        public ObservableCollection<string> sGenders
        {
            get { return sgenders; }
            set { sgenders = value; }
        }

        public ObservableCollection<string> results = new ObservableCollection<string>();


        public ObservableCollection<string> Results
        {
            get { return results; }
            set { results = value; }
        }


        public EditMenuVM(Student S)
        {
            sGenders = new ObservableCollection<string>()
            {
                new string("Male"),
                new string("Female"),
                new string("None")
            };

            Results = new ObservableCollection<string>()
            {
                new string("A+"),
                new string("A"),
                new string("A-"),
                new string("B+"),
                new string("B"),
                new string("B-"),
                new string("C+"),
                new string("C"),
                new string("C-")
            };

            sfName = S.FirstName;
            slName = S.LastName;
            sage = S.Age;
            sgender = S.Gender;
            sdoBirth = S.DateofBirth;
            sdoAddmission = S.DateofAddmission;
            sselImage = S.Image;
        }

        public void uploadImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                sselImage = new BitmapImage(new Uri(dialog.FileName));

                MessageBox.Show("Image successfuly uploded!", "successfull");
            }
        }


        [RelayCommand]
        public void saveStudent()
        {
            student.FirstName = sfName;
            student.LastName = slName;
            student.Age = sage;
            student.Image = sselImage;
            student.DateofBirth = sdoBirth;
            student.Gender = sgender;
            student.DateofAddmission = sdoAddmission;

        }
    }
}
