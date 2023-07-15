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
    /// Interaction logic for EditMenu.xaml
    /// </summary>
    public partial class EditMenu : Window
    {
        public EditMenu(EditMenuVM1 vm)
        {
            InitializeComponent();
            this.DataContext = vm;
            DatePicker1.DisplayDate = DateTime.Now.Date;
            DatePicker2.DisplayDate = DateTime.Now.Date;
            vm.clearAction = () => clearTextBox();
            vm.closeAction = () => Close();
        }

        public void clearTextBox()
        {
            ModuleCode.Clear();
            Result.SelectedItem = null;

        }

    }
}
