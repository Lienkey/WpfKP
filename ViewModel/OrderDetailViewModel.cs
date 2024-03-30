using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfKP.Model;

namespace WpfKP.ViewModel
{
    public class OrderDetailViewModel
    {
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListOrderDetail)
            {
                if (max < r.OrderId)
                {
                    max = r.OrderId;
                };
            }
            return max;
        }


        public ObservableCollection<OrderDetail> ListOrderDetail { get; set; } = new ObservableCollection<OrderDetail>();

        public OrderDetailViewModel()
        {
            this.ListOrderDetail.Add(
                new OrderDetail
                {
                    ProductId = 9,
                    OrderId = 1,
                    UnitPrice = 82000.00,
                    Discount = 8200.00,
                });

            this.ListOrderDetail.Add(
                    new OrderDetail
                {
                    ProductId = 5,
                    OrderId = 1,
                    UnitPrice = 13500.00,
                    Discount = 1350.00,
                });

            this.ListOrderDetail.Add(
                    new OrderDetail
                {
                    ProductId = 6,
                    OrderId = 1,
                    UnitPrice = 7500.00,
                    Discount = 750.00,
                });

            this.ListOrderDetail.Add(
                    new OrderDetail
                    {
                        ProductId = 4,
                        OrderId = 2,
                        UnitPrice = 6200.00,
                        Discount = 620.00,
                    });

            this.ListOrderDetail.Add(
                    new OrderDetail
                    {
                    ProductId = 10,
                    OrderId = 2,
                    UnitPrice = 14000.00,
                    Discount = 1400.00,
                    });

            this.ListOrderDetail.Add(
                    new OrderDetail
                    {
                        ProductId = 12,
                        OrderId = 2,
                        UnitPrice = 5300.00,
                        Discount = 530.00,
                    });
            this.ListOrderDetail.Add(
                    new OrderDetail
                    {
                        ProductId = 9,
                        OrderId = 2,
                        UnitPrice = 82000.00,
                        Discount = 8200.00,
                    });
        }
    }
}
