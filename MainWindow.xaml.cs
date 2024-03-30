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
using WpfKP.View;

namespace WpfKP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static int IdOrder { get; set; }

        private void BtCategory_Click(object sender, RoutedEventArgs e)
        {
            WindowCategory windowCategory = new WindowCategory();
            windowCategory.Show();
        }

        private void BtProduct_Click(object sender, RoutedEventArgs e)
        {
            WindowProduct windowProduct = new WindowProduct();
            windowProduct.Show();
        }

        private void BtOrder_Click(object sender, RoutedEventArgs e)
        {
            WindowOrder windowOrder = new WindowOrder();
            windowOrder.Show();
        }

        private void BtOrderDetail_Click(object sender, RoutedEventArgs e)
        {
            WindowOrderDetail windowOrderDetail = new WindowOrderDetail();
            windowOrderDetail.Show();
        }
    }
}
