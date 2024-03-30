using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfKP.Model;

namespace WpfKP.ViewModel
{
    public class ProductViewModel
    {
        public ObservableCollection<Product> ListProduct { get; set; } = new ObservableCollection<Product>();

        public ProductViewModel() 
        {
            this.ListProduct.Add(
                new Product
                {
                    ProductId = 1,
                    CategotyId = 1,
                    ProductName = "Молоток",
                    UnitPrice = 420.00,
                    UnitInStoke = 1,
                    UnitInOrder = 1,
                });

            this.ListProduct.Add(
                new Product
                {
                    ProductId = 2,
                    CategotyId = 1,
                    ProductName = "Ножовка",
                    UnitPrice = 820.00,
                    UnitInStoke = 1,
                    UnitInOrder = 1,
                });

            this.ListProduct.Add(
                new Product
                {
                      ProductId = 3,
                      CategotyId = 1,
                      ProductName = "Бокорезы",
                      UnitPrice = 350.00,
                      UnitInStoke = 1,
                      UnitInOrder = 1,
                });

            this.ListProduct.Add(
                new Product
                {
                    ProductId = 4,
                    CategotyId = 2,
                    ProductName = "Электропила",
                    UnitPrice = 6200.00,
                    UnitInStoke = 1,
                    UnitInOrder = 1,
                });

            this.ListProduct.Add(
                new Product
                {
                    ProductId = 5,
                    CategotyId = 2,
                    ProductName = "Электрошуруповерт",
                    UnitPrice = 13500.00,
                    UnitInStoke = 1,
                    UnitInOrder = 1,
                });

            this.ListProduct.Add(
                new Product
                {
                    ProductId = 6,
                    CategotyId = 2,
                    ProductName = "Электрическая УШМ",
                    UnitPrice = 7500.00,
                    UnitInStoke = 1,
                    UnitInOrder = 1,
                });

            this.ListProduct.Add(
                new Product
                {
                    ProductId = 7,
                    CategotyId = 3,
                    ProductName = "Бензотриммер",
                    UnitPrice = 8500.00,
                    UnitInStoke = 1,
                    UnitInOrder = 1,
                });

            this.ListProduct.Add(
                new Product
                {
                    ProductId = 8,
                    CategotyId = 3,
                    ProductName = "Бензопила",
                    UnitPrice = 7240.00,
                    UnitInStoke = 1,
                    UnitInOrder = 1,
                });

            this.ListProduct.Add(
                new Product
                {
                    ProductId = 9,
                    CategotyId = 4,
                    ProductName = "Бензогенератор",
                    UnitPrice = 82000.00,
                    UnitInStoke = 1,
                    UnitInOrder = 1,
                });

            this.ListProduct.Add(
                new Product
                {
                    ProductId = 10,
                    CategotyId = 4,
                    ProductName = "Пневмогайковёрт",
                    UnitPrice = 14000.00,
                    UnitInStoke = 1,
                    UnitInOrder = 1,
                });

            this.ListProduct.Add(
                new Product
                {
                    ProductId = 11,
                    CategotyId = 4,
                    ProductName = "Пневмостеплер",
                    UnitPrice = 4300.00,
                    UnitInStoke = 1,
                    UnitInOrder = 1,
                });

            this.ListProduct.Add(
                new Product
                {
                    ProductId = 12,
                    CategotyId = 1,
                    ProductName = "Пневмокраскопульт",
                    UnitPrice = 5300.00,
                    UnitInStoke = 1,
                    UnitInOrder = 1,
                });
        }

        /// <summary>
        /// Нахождение максимального Id
        /// </summary>
        /// <returns></returns>
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListProduct)
            {
                if (max < r.ProductId)
                {
                    max = r.ProductId;
                };
            }
            return max;
        }

    }
}
