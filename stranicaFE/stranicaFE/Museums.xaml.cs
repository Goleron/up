using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// <summary>
    /// Логика взаимодействия для Museums.xaml
    /// </summary>
    public partial class MuseumsPage : Page
    {
        private uchebEntities context = new uchebEntities();
        public MuseumsPage()
        {
            InitializeComponent();
            MuseumsDgr.ItemsSource = context.Museums.ToList();

        }
    }
}
