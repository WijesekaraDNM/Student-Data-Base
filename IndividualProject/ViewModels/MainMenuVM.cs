using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IndividualProject.Views;
using IndividualProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Threading;

namespace IndividualProject.ViewModels
{
    public partial class MainMenuVM : ObservableObject
    {

        [ObservableProperty]
        public ObservableCollection<Student> students;

        [ObservableProperty]
        public Student selectedStudent = null;

        //[ObservableProperty]
        //public Module currentModule;

        //public double currentGPA = 0;

        public int idCount { get; set; }
       
        public MainMenuVM()
        {
            Students = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("../../../Images/4.png", UriKind.Relative));
            Students.Add(new Student("EG/2020/1", "Aseka", "Ruwangi", 34, "Female", "19/12/2020", "01/09/1990", image1,3.14));
            BitmapImage image2 = new BitmapImage(new Uri("../../../Images/9.png", UriKind.Relative));
            Students.Add(new Student("EG/2020/2", "Amandi", "Guera", 23, "Female", "17/10/2020", "12/01/1992", image2,3.89));
            BitmapImage image3 = new BitmapImage(new Uri("../../../Images/3.png", UriKind.Relative));
            Students.Add(new Student("EG/2020/3", "Lakshan", "Sandakan", 26, "Male", "17/07/2020", "12/10/1991", image3,2.95));
            BitmapImage image4 = new BitmapImage(new Uri("../../../Images/1.png", UriKind.Relative));
            Students.Add(new Student("EG/2020/4", "Wimukthi", "Senon", 29, "Male", "13/05/2020", "12/09/1990", image4,3.56));
            idCount = Students.Count();


        }

        [RelayCommand]
        public void addStudent()
        {
            var vm = new AddMenuVM();
            vm.count = idCount;
            AddMenu window=new AddMenu(vm);
            window.ShowDialog();


            if (vm.newStudent!=null)
            {
                Students.Add(vm.newStudent);
                idCount++;
            }
        }

        [RelayCommand]
        public void editStudent()
        {
            if(SelectedStudent!=null)
            {
   
                var vm = new EditMenuVM1(SelectedStudent);
                EditMenu window = new EditMenu(vm);
                window.ShowDialog();

                int index = Students.IndexOf(SelectedStudent);
                Students.RemoveAt(index);
                Students.Insert(index, vm.CurrentStudent);

            }
            else
            {
                MessageBox.Show("Please select the student to be edited.", "Error\a",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        [RelayCommand]

        public void deleteStudent()
        {
            if(SelectedStudent !=null) 
            {
                String name=SelectedStudent.FirstName+" "+SelectedStudent.LastName;
                Students.Remove(SelectedStudent);
                MessageBox.Show($"{name} is successfully deleted!", "Deleted\a",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else 
            {
                MessageBox.Show("Please select the student before deletion.", "Error\a",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        public Action closeAction { get;internal set; }

        [RelayCommand]
        public void Exit()
        {
            closeAction();
        }
    }
}
