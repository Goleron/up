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
    /// Логика взаимодействия для Artifact.xaml
    /// </summary>
    public partial class Artifact : Page
    {
        private ioioEntities context = new ioioEntities();
        public Artifact()
        {
            InitializeComponent();
            ArtifactDgr.ItemsSource = context.Artifacts.ToList();

        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Artifacts c = new Artifacts();
            c.name = TextBox1.Text;
            c.description = TextBox2.Text;
            c.acquisition_date = Convert.ToDateTime (TextBox3.Text);
            c.condition = TextBox4.Text;
            c.cost = Convert.ToDecimal (TextBox5.Text);



            context.Artifacts.Add(c);

            context.SaveChanges();
            ArtifactDgr.ItemsSource = context.Artifacts.ToList();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArtifactDgr.SelectedItem != null)
            {
                context.Artifacts.Remove(ArtifactDgr.SelectedItem as Artifacts);
            }
            context.SaveChanges();
            ArtifactDgr.ItemsSource = context.Artifacts.ToList();
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArtifactDgr.SelectedItem != null)
            {
                var selected = ArtifactDgr.SelectedItem as Artifacts;

                selected.name = TextBox1.Text;
                selected.description = TextBox2.Text;
                selected.acquisition_date = Convert.ToDateTime(TextBox3.Text);
                selected.condition = TextBox4.Text;
                selected.cost = Convert.ToDecimal(TextBox5.Text);
            }
            context.SaveChanges();
            ArtifactDgr.ItemsSource = context.Artifacts.ToList();

        }

    }
}
