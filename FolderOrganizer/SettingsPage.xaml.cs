using Folder_Organizer.ViewModels;
using FolderOrganizer.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Folder_Organizer
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public ObservableCollection<string> ClassificationNames { get; set; }
        public ClassificationEditControl ClassificationEditControlViewModel { get; set; }

        private List<FolderClassification> defaultFolderClassification { get; set; }
        public SettingsPage()
        {
            InitializeComponent();

            defaultFolderClassification = DefaultFolderClassification.GetDefaults();

            ClassificationNames = new ObservableCollection<string>(defaultFolderClassification.Select(x => x.ClassificationName));
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }

        private void classificationProfile_Click(object sender, RoutedEventArgs e)
        {
            ClassificationNames.Add("Madhu");
        }

        private void classificationsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var menuName = e.AddedItems[0].ToString();
            var classification = defaultFolderClassification.FirstOrDefault(x => x.ClassificationName.Equals(menuName));
            classificationDetail.DataContext = new Controls.ClassificationEditControl()
            {
                ViewModel = new ClassificationEditControl
                {
                    ClassificationName = classification.ClassificationName,
                    Extensions = String.Join(",", classification.FileExtensions),
                    TargetPath = classification.TargetPath
                }
            };
        }

        private void addClassificationButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");
        }
    }
}