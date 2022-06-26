using Folder_Organizer.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Folder_Organizer.Controls
{
    /// <summary>
    /// Interaction logic for ClassificationEditControl.xaml
    /// </summary>
    public partial class ClassificationEditControl : UserControl
    {
        public ViewModels.ClassificationEditControl ViewModel { get; set; }
        public ClassificationEditControl()
        {
            InitializeComponent();
            ViewModel = new ViewModels.ClassificationEditControl()
            {
                ClassificationName = "Documents",
                TargetPath = "Documents",
                Extensions = ".docx,.doc"
            };
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Done");
        }
    }
}
