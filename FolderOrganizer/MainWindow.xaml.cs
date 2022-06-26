using FolderOrganizer.Core;
using System.Diagnostics;
using System.Windows;
using System.Windows.Forms;

namespace Folder_Organizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FolderOrganizer.Core.FolderOrganizer _folderOrganizer;
        public MainWindow()
        {
            InitializeComponent();
            //         selectedFolderPath.Text = System.Environment.ExpandEnvironmentVariables("%userprofile%/downloads/");
            _NavigationFrame.Navigate(new HomePage());
        }

        //private void organizeFolder_Click(object sender, RoutedEventArgs e)
        //{
        //    //            System.Windows.MessageBox.Show(this, "Organizing Folder.. Please Wait...");
        //    statusMessage.Content = "Organizing Folder.. Please Wait...";
        //    _folderOrganizer = new FolderOrganizer.Core.FolderOrganizer(selectedFolderPath.Text, DefaultFolderClassification.GetDefaults());

        //    _folderOrganizer.Organize();
        //    statusMessage.Content = "Awesome! Your folder is now organized.";
        //    //            System.Windows.MessageBox.Show(this, "Folder Organized");

        //    Process.Start(selectedFolderPath.Text);
        //}

        //private void selectFolder_Click(object sender, RoutedEventArgs e)
        //{
        //    FolderBrowserDialog dlg = new FolderBrowserDialog();
        //    dlg.ShowNewFolderButton = true;
        //    DialogResult result = dlg.ShowDialog();
        //    if (result == System.Windows.Forms.DialogResult.OK)
        //    {
        //        selectedFolderPath.Text = dlg.SelectedPath;
        //    }
        //}

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new SettingsPage());
        }
    }
}
