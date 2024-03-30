﻿using System;
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
using stranicaDataset.uchebDataSetTableAdapters;

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
    }
}
