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
using System.Windows.Shapes;

namespace WpfKP.View
{
    /// <summary>
    /// Логика взаимодействия для WindowNewOrderDetail.xaml
    /// </summary>
    public partial class WindowNewOrderDetail : Window
    {
        public WindowNewOrderDetail()
        {
            InitializeComponent();
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
