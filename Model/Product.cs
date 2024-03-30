using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKP.Model
{
    public class Product
    {

        public Product ShallowCopy()
        {
            return (Product)this.MemberwiseClone();
        }

    public int ProductId { get; set; }
    public int CategotyId { get; set; }
    public string ProductName { get; set; }
    public double UnitPrice { get; set; }
    public int UnitInStoke { get; set; }
    public int UnitInOrder { get; set; }

    public Product() { }

    public Product(int productId, int categotyId, string productName, double unitPrice, int unitInStoke, int unitInOrder)
        {
            ProductId = productId;
            CategotyId = categotyId;
            ProductName = productName;
            UnitPrice = unitPrice;
            UnitInStoke = unitInStoke;
            UnitInOrder = unitInOrder;
        }
    }
}
