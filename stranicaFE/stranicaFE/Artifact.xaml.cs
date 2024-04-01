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
            // В конструкторе класса после InitializeComponent();
            ArtifactDgr.LoadingRow += ArtifactDgr_LoadingRow;

            void ArtifactDgr_LoadingRow(object sender, DataGridRowEventArgs e)
            {
                e.Row.MouseEnter += Row_MouseEnter;
            }

                void Row_MouseEnter(object sender, MouseEventArgs e)
{
                    if(sender is DataGridRow row && row.DataContext is Artifacts artifact)
                    {
                        TextBox1.Text = artifact.name;
                        TextBox2.Text = artifact.description;
                        TextBox3.Text = artifact.acquisition_date.ToString();
                        TextBox4.Text = artifact.condition;
                        TextBox5.Text = artifact.cost.ToString();
                     }
                }

            ArtifactDgr.ItemsSource = context.Artifacts.ToList();


        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Artifacts c = new Artifacts();
            c.name = TextBox1.Text;
            c.description = TextBox2.Text;
            DateTime acquisitionDate;
            if (DateTime.TryParse(TextBox3.Text, out acquisitionDate))
            {
                c.acquisition_date = acquisitionDate;
            }
            else
            {
               
                MessageBox.Show("Неверный формат даты.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }
            c.condition = TextBox4.Text;
            decimal cost;
            if (Decimal.TryParse(TextBox5.Text, out cost))
            {
                c.cost = cost;
            }
            else
            {
                MessageBox.Show("Неверный формат стоимости.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            context.Artifacts.Add(c);
            context.SaveChanges();
            ArtifactDgr.ItemsSource = context.Artifacts.ToList();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArtifactDgr.SelectedItem != null)
            {
                try
                {
                    if (ArtifactDgr.SelectedItem != null)
                    {
                        var selected = ArtifactDgr.SelectedItem as Artifacts;

                        selected.name = TextBox1.Text;
                        selected.description = TextBox2.Text;
                        selected.acquisition_date = Convert.ToDateTime(TextBox3.Text);
                        selected.condition = TextBox4.Text;
                        selected.cost = Convert.ToDecimal(TextBox5.Text);

                        context.SaveChanges();
                        ArtifactDgr.ItemsSource = context.Artifacts.ToList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }

                context.SaveChanges();
                ArtifactDgr.ItemsSource = context.Artifacts.ToList();
            }
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
  

    }
}
