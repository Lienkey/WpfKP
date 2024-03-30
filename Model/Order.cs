using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKP.Model
{
    public class Order
    {
    public int OrderId { get; set; }
    public string Customer { get; set; }
    public string Employee { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShipperDate { get; set; }
    public string ShipName { get; set; }
    public string ShipAddress { get; set; }

    public Order() { }

    public Order(int orderId, string customer, string employee, DateTime orderDate, DateTime shipperDate, string shipName, string shipAddress)
        {
            this.OrderId = orderId;
            this.Customer = customer;
            this.Employee = employee;
            this.OrderDate = orderDate;
            this.ShipperDate = shipperDate;
            this.ShipName = shipName;
            this.ShipAddress = shipAddress;
        }

        public Order ShallowCopy()
        {
            return (Order)this.MemberwiseClone();
        }


    }
}
