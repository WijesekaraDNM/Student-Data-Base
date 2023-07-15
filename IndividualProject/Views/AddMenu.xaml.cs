using IndividualProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IndividualProject.Views
{
    /// <summary>
    /// Interaction logic for AddMenu.xaml
    /// </summary>
    public partial class AddMenu : Window
    {
        public AddMenu(AddMenuVM vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            vm.closeAction=()=>Close();
            DatePicker1.DisplayDate = DateTime.Now.Date;
            DatePicker2.DisplayDate = DateTime.Now.Date;
        }

       
    }
}
