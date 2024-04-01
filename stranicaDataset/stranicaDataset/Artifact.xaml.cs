using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using stranicaDataset.dededeDataSetTableAdapters;

namespace stranicaDataset
{
    /// <summary>
    /// Логика взаимодействия для Artifact.xaml
    /// </summary>
    public partial class ArtifactPage : Page
    {
        ArtifactsTableAdapter artifacts = new ArtifactsTableAdapter();
        public ArtifactPage()
        {
            InitializeComponent();
            ArtifactsDataGrid.ItemsSource = artifacts.GetData();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(TextBox4.Text, out decimal costValue))
            {
                MessageBox.Show("Некорректное значение для стоимости.");
                return;
            }        
            artifacts.InsertQuery(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, Convert.ToDecimal(costValue));
            ArtifactsDataGrid.ItemsSource = artifacts.GetData();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArtifactsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для обновления.");
                return;
            }

            DataRowView selectedRow = ArtifactsDataGrid.SelectedItem as DataRowView;
            int originalArtifactId = Convert.ToInt32(selectedRow.Row[0]);

            if (!decimal.TryParse(TextBox4.Text, out decimal costValue))
            {
                MessageBox.Show("Некорректное значение для стоимости.");
                return;
            }

            if (!int.TryParse(TextBox5.Text, out int museumIdValue))
            {
                MessageBox.Show("Некорректное значение для ID музея.");
                return;
            }

            artifacts.UpdateQuery(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, costValue, museumIdValue);
            ArtifactsDataGrid.ItemsSource = artifacts.GetData();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ArtifactsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для удаления.");
                return;
            }

            DataRowView selectedRow = ArtifactsDataGrid.SelectedItem as DataRowView;
            int artifactId = Convert.ToInt32(selectedRow.Row[0]);

            artifacts.DeleteQuery(artifactId);
            ArtifactsDataGrid.ItemsSource = artifacts.GetData();
        }

    }
}
