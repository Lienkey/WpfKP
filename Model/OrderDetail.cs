using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfKP.Helper;
using WpfKP.ViewModel;

namespace WpfKP.Model
{
    public class OrderDetail
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }

        public OrderDetail() { }

        public OrderDetail(int productId, int orderId, double unitPrice, double discount)
        {
            ProductId = productId;
            OrderId = orderId;
            UnitPrice = unitPrice;
            Discount = discount;
        }

        public OrderDetail CopyFromOrderDetailDPO(OrderDetailDPO od)
        {
            ProductViewModel vmProduct = new ProductViewModel();
            int productId = 0;
            foreach (var r in vmProduct.ListProduct)
            {
                if (r.ProductName == od.ProductName)
                {
                    productId = r.ProductId;
                    break;
                }
            }
            if (productId != 0)
            {
                this.OrderId = od.OrderId;
                this.ProductId = productId;
                this.UnitPrice = od.UnitPrice;
                this.Discount = od.Discount;
            }
            return this;
        }


    }
}
