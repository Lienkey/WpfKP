using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfKP.Model;

namespace WpfKP.Helper
{
    public class FindProduct
    {
        int id;
        public FindProduct(int id)
        {
            this.id = id;
        }
        public bool ProductPredicate(Product product)
        {
            return product.ProductId == id;
        }

    }
}
