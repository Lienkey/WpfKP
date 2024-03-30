using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfKP.Model;

namespace WpfKP.Helper
{
    internal class FindOrderDetail
    {
        int id;

        public FindOrderDetail(int id)
        {
            this.id = id;
        }

        public bool OrderDetailPredicate(OrderDetail obj)
        {
            return obj.OrderId == id;
        }
    }
}
