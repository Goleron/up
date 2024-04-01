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
    public partial class Museum : Page
    {
        private  ioioEntities context = new ioioEntities();
        public Museum()
        {
            InitializeComponent();
            MuseumsDgr.ItemsSource = context.Museums.ToList();

        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Museums c = new Museums();
            c.museum_name = TextBox1.Text;
            c.address = TextBox2.Text;
            c.city = TextBox3.Text;
            c.country = TextBox4.Text;
            c.contact_phone = TextBox5.Text;



            context.Museums.Add(c);

            context.SaveChanges();
            MuseumsDgr.ItemsSource = context.Museums.ToList();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MuseumsDgr.SelectedItem != null)
            {
                context.Museums.Remove(MuseumsDgr.SelectedItem as Museums);
            }
            context.SaveChanges();
            MuseumsDgr.ItemsSource = context.Museums.ToList();
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (MuseumsDgr.SelectedItem != null)
            {
                var selected = MuseumsDgr.SelectedItem as Museums;

                selected.museum_name = TextBox1.Text;
                selected.address = TextBox2.Text;
                selected.city = (TextBox3.Text);
                selected.country = TextBox4.Text;
                selected.contact_phone = (TextBox5.Text);
            }
            context.SaveChanges();
            MuseumsDgr.ItemsSource = context.Museums.ToList();

        }
    }
}
