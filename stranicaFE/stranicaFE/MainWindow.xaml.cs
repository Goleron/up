using stranicaFE;
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

namespace stranicaFE
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ArtifactButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ArtifactPage());
        }

        private void MuseumButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MuseumsPage());
        }
    }
}