using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfKP.Model;
using WpfKP.ViewModel;

namespace WpfKP.Helper
{
    public class OrderDetailDPO
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }

        public OrderDetailDPO() { }

        public OrderDetailDPO(int orderId, string productName, double unitPrice, double discount)
        {
            this.OrderId = orderId;
            this.ProductName = productName;
            this.UnitPrice = unitPrice;
            this.Discount = discount;
        }

        public OrderDetailDPO CopyFromOrderDetail(OrderDetail od)
        {
            OrderDetailDPO odDPO = new OrderDetailDPO();
            ProductViewModel vmProduct = new ProductViewModel();
            string pName = string.Empty;
            foreach (var r in vmProduct.ListProduct)
            {
                if (r.ProductId == od.ProductId)
                {
                    pName = r.ProductName;
                    break;
                }
            }
            if (pName != string.Empty)
            {
                odDPO.OrderId = od.OrderId;
                odDPO.ProductName = pName;
                odDPO.UnitPrice = od.UnitPrice;
                odDPO.Discount = od.Discount;
            }
            return odDPO;
        }

        public OrderDetailDPO ShallowCopy()
        {
            return (OrderDetailDPO)this.MemberwiseClone();
        }

    }
}
