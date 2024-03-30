using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using WpfKP.Model;

namespace WpfKP.ViewModel
{
    public class OrderViewModel
    {
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListOrder)
            {
                if (max < r.OrderId)
                {
                    max = r.OrderId;
                };
            }
            return max;
        }

        public ObservableCollection<Order> ListOrder { get; set; } = new ObservableCollection<Order>();

        public OrderViewModel()
        {
            this.ListOrder.Add(
                new Order
                {
                    OrderId = 1,
                    Customer = "Проскура Алексей Витальевич",
                    Employee = "Соколов Иван Олегович",
                    OrderDate = new DateTime(2024,01,14),
                    ShipperDate = new DateTime(2024, 01, 25),
                    ShipName = "ХК Мастер",
                    ShipAddress = "г. Тимашевск ул. Ленина д. 32"
                });

            this.ListOrder.Add(
                new Order
                {
                    OrderId = 2,
                    Customer = "Воровский Владислав Сергеевич",
                    Employee = "Соколов Иван Олегович",
                    OrderDate = new DateTime(2024, 02, 23),
                    ShipperDate = new DateTime(2024, 03, 08),
                    ShipName = "Кубань инструмент",
                    ShipAddress = "г. Краснодар ул. Северная д. 320"
                });

        }
    }
}
