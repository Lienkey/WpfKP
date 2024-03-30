using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfKP.Helper;
using WpfKP.Model;
using WpfKP.ViewModel;

namespace WpfKP.View
{
    /// <summary>
    /// Логика взаимодействия для WindowOrderDetail.xaml
    /// </summary>
    public partial class WindowOrderDetail : Window
    {
        private OrderDetailViewModel vmOrderDetail = new OrderDetailViewModel();
        private ProductViewModel vmProduct;
        private ObservableCollection<OrderDetailDPO> orderDetailDPO;
        private List<Product> products;
        private Product product = new Product();
        public WindowOrderDetail()
        {
            InitializeComponent();
            vmOrderDetail = new OrderDetailViewModel();
            vmProduct = new ProductViewModel();
            products = vmProduct.ListProduct.ToList();

            orderDetailDPO = new ObservableCollection<OrderDetailDPO>();
            foreach (var person in vmOrderDetail.ListOrderDetail)
            {
                OrderDetailDPO od = new OrderDetailDPO();
                od = od.CopyFromOrderDetail(person);
                orderDetailDPO.Add(od);
            }
            lvOrderDetail.ItemsSource = orderDetailDPO;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewOrderDetail wnOrderDetail = new WindowNewOrderDetail
            {
                Title = "Новые детали заказа",
                Owner = this
            };

            int maxIdPerson = vmOrderDetail.MaxId() + 1;
            OrderDetailDPO per = new OrderDetailDPO
            {
                OrderId = maxIdPerson,
            };
            wnOrderDetail.DataContext = per;
            wnOrderDetail.CbProductName.ItemsSource = products;
            if (wnOrderDetail.ShowDialog() == true)
            {
                Product r = (Product)wnOrderDetail.CbProductName.SelectedValue;
                per.ProductName = r.ProductName;
                orderDetailDPO.Add(per);

                OrderDetail p = new OrderDetail();
                p = p.CopyFromOrderDetailDPO(per);
                vmOrderDetail.ListOrderDetail.Add(p);
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewOrderDetail wnOrderDetail = new WindowNewOrderDetail
            {
                Title = "Редактирование данных",
                Owner = this
            };
            OrderDetailDPO perDPO = (OrderDetailDPO)lvOrderDetail.SelectedValue;
            OrderDetailDPO tempPerDPO; 
            if (perDPO != null)
            {
            tempPerDPO = perDPO.ShallowCopy();
                wnOrderDetail.DataContext = tempPerDPO;
                wnOrderDetail.CbProductName.ItemsSource = products;
                wnOrderDetail.CbProductName.Text = tempPerDPO.ProductName;
                if (wnOrderDetail.ShowDialog() == true)
                {

                    Product r = (Product)wnOrderDetail.CbProductName.SelectedValue;
                    perDPO.ProductName = r.ProductName;
                    perDPO.OrderId = tempPerDPO.OrderId;
                    perDPO.UnitPrice = tempPerDPO.UnitPrice;
                    perDPO.Discount = tempPerDPO.Discount;
                    lvOrderDetail.ItemsSource = null;
                    lvOrderDetail.ItemsSource = orderDetailDPO;

                    FindOrderDetail finder = new FindOrderDetail(perDPO.OrderId);
                    List<OrderDetail> listOrderDetail = vmOrderDetail.ListOrderDetail.ToList();
                    OrderDetail p = listOrderDetail.Find(new Predicate<OrderDetail>(finder.OrderDetailPredicate));
                    p = p.CopyFromOrderDetailDPO(perDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо данные по деталям заказа",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            OrderDetailDPO person = (OrderDetailDPO)lvOrderDetail.SelectedItem;
            if (person != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по деталям заказа:\n" + person.OrderId + " "+person.ProductName,
                "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {

                    orderDetailDPO.Remove(person);

                    OrderDetail per = new OrderDetail();
                    per = per.CopyFromOrderDetailDPO(person);
                    vmOrderDetail.ListOrderDetail.Remove(per);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать данные по деталям заказа для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
