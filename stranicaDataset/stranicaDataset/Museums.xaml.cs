using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using stranicaDataset.dededeDataSetTableAdapters;

namespace stranicaDataset
{
    public partial class MuseumsPage : Page
    {
        MuseumsTableAdapter museums = new MuseumsTableAdapter();

        public MuseumsPage()
        {
            InitializeComponent();
            ReloadDataGrid();
        }

        private void ReloadDataGrid()
        {
            MuseumsDataGrid.ItemsSource = museums.GetData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TextBox1.Text, out int result))
            {
                museums.InsertQuery(TextBox1.Text,TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text);
                ReloadDataGrid();
            }
            else
            {
                MessageBox.Show("Неверный ввод ID. Пожалуйста, введите допустимое число.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MuseumsDataGrid.SelectedItem is DataRowView dataRowView)
            {
                object id = dataRowView.Row[0];
                if (int.TryParse(id.ToString(), out int idInt))
                {
                    museums.DeleteQuery(idInt);
                    ReloadDataGrid();
                }
                else
                {
                    MessageBox.Show("Неверный ID. Удаление невозможно.");
                }
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (MuseumsDataGrid.SelectedItem is DataRowView dataRowView)
            {
                object id = dataRowView.Row[0];
                if (int.TryParse(id.ToString(), out int idInt))
                {
                    museums.UpdateQuery(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, idInt);
                    ReloadDataGrid();
                }
                else
                {
                    MessageBox.Show("Неверный ID. Обновление невозможно.");
                }
            }
        }
    }
}
