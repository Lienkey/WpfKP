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
    /// Логика взаимодействия для WindowCategory.xaml
    /// </summary>
    public partial class WindowCategory : Window
    {
        private CategoryViewModel categoryViewModel = new CategoryViewModel();
        public WindowCategory()
        {
            InitializeComponent();
            
            lvCategory.ItemsSource = categoryViewModel.ListCategory;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewCategory wnCategory = new WindowNewCategory
            {
                Title = "Новая категория",
                Owner = this
            };
            // формирование кода новой категории
            int maxIdCategory = categoryViewModel.MaxId() + 1;
            Category category = new Category
            {
                CategoryId = maxIdCategory
            };
            wnCategory.DataContext = category;
            if (wnCategory.ShowDialog() == true)
            {
                categoryViewModel.ListCategory.Add(category);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewCategory wnCategory = new WindowNewCategory
            {
                Title = "Редактирование категории",
                Owner = this
            };
            Category category = lvCategory.SelectedItem as Category;
            if (category != null)
            {
                Category tempCategory = category.ShallowCopy();
                wnCategory.DataContext = tempCategory;
            if (wnCategory.ShowDialog() == true)
                {
                    // сохранение данных
                    category.CategoryName = tempCategory.CategoryName;
                    lvCategory.ItemsSource = null;
                    lvCategory.ItemsSource = categoryViewModel.ListCategory;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать категорию для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Category category = (Category)lvCategory.SelectedItem;
            if (category != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по категории: " +
                category.CategoryName, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    categoryViewModel.ListCategory.Remove(category);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать должность для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
