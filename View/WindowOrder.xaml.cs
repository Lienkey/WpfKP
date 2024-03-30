using System;
using System.Collections.Generic;
using System.Data;
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
using WpfKP.Model;
using WpfKP.ViewModel;

namespace WpfKP.View
{
    /// <summary>
    /// Логика взаимодействия для WindowOrder.xaml
    /// </summary>
    public partial class WindowOrder : Window
    {

        private OrderViewModel orderViewModel = new OrderViewModel();

        public WindowOrder()
        {
            InitializeComponent();
            lvOrder.ItemsSource = orderViewModel.ListOrder;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewOrder wnOrder = new WindowNewOrder
            {
                Title = "Новый заказ",
                Owner = this
            };
            // формирование кода новой должности
            int maxIdOrder = orderViewModel.MaxId() + 1;
            Order order = new Order
            {
                OrderId = maxIdOrder
            };
            wnOrder.DataContext = order;
            if (wnOrder.ShowDialog() == true)
            {
                orderViewModel.ListOrder.Add(order);
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewOrder wnOrder = new WindowNewOrder
            {
                Title = "Редактирование заказа",
                Owner = this
            };
            Order order = lvOrder.SelectedItem as Order;
            if (order != null)
            {
                Order tempRole = order.ShallowCopy();
                wnOrder.DataContext = tempRole;
            if (wnOrder.ShowDialog() == true)
                {
                    // сохранение данных
                    order.Customer = tempRole.Customer;
                    lvOrder.ItemsSource = null;
                    lvOrder.ItemsSource = orderViewModel.ListOrder;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать заказ для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Order order = (Order)lvOrder.SelectedItem;
            if (order != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по заказу: " +
                order.Customer, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    orderViewModel.ListOrder.Remove(order);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать должность для заказ",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
