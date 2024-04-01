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
using tabldataset.uiruruDataSetTableAdapters;

namespace tabldataset
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ArtifactsTableAdapter art = new ArtifactsTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            ArtifactGrd.ItemsSource = art.GetDataBy();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ArtifactGrd.Columns[0].Visibility = Visibility.Collapsed;
            ArtifactGrd.Columns[4].Visibility = Visibility.Collapsed;
            ArtifactGrd.Columns[5].Visibility = Visibility.Collapsed;

        }
    }
}
