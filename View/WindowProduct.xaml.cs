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
    /// Логика взаимодействия для WindowProduct.xaml
    /// </summary>
    public partial class WindowProduct : Window
    {
        private ProductViewModel productViewModel = new ProductViewModel();
        public WindowProduct()
        {
            InitializeComponent();
            lvProduct.ItemsSource = productViewModel.ListProduct;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewProduct wnProduct = new WindowNewProduct
            {
                Title = "Новый товар",
                Owner = this
            };
            // формирование кода новой должности
            int maxIdProduct = productViewModel.MaxId() + 1;
            Product product = new Product
            {
                ProductId = maxIdProduct
            };
            wnProduct.DataContext = product;
            if (wnProduct.ShowDialog() == true)
            {
                productViewModel.ListProduct.Add(product);
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewProduct wnProduct = new WindowNewProduct
            {
                Title = "Редактирование товара",
                Owner = this
            };
            Product product = lvProduct.SelectedItem as Product;
            if (product != null)
            {
                Product tempProduct = product.ShallowCopy();
                wnProduct.DataContext = tempProduct;
            if (wnProduct.ShowDialog() == true)
                {
                    // сохранение данных
                    product.ProductName = tempProduct.ProductName;
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = productViewModel.ListProduct;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать товар для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Product product = (Product)lvProduct.SelectedItem;
            if (product != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по товару: " +
                product.ProductName, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    productViewModel.ListProduct.Remove(product);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать товар для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
