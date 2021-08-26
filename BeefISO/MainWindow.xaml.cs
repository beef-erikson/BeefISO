using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


//********************************************
// ISO Zipper/Unzipper (or any zipped files)
// Designed for use with Hyperspin
//
// Troy Martin - 2021
//********************************************
namespace BeefISO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Browses for folder and set folderResults.Text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new();
            var result = folderBrowserDialog.ShowDialog();

            if (result.ToString() is not null)
            {
                string directory = folderBrowserDialog.SelectedPath;
                folderResults.Text = directory;
                folderResults.TextWrapping = TextWrapping.NoWrap;
                populateList(directory);
            }
           
        }
        
        /// <summary>
        /// Populates list on right side of screen of directory
        /// </summary>
        /// <param name="directory">Directory to read</param>
        private void populateList(string directory)
        {
            int directoryLength = directory.Length;
            string[] files = Directory.GetFiles(directory);

            folderItems.Items.Clear();
            
            foreach (string file in files)
            {
                folderItems.Items.Add(file.Substring(directoryLength + 1));
            }
        }
    }
}
