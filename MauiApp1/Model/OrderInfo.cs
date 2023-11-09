using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public class OrderInfo
    {
        private int orderID;
        private string customerID;
        private string customer;
        private string shipCity;
        private string shipCountry;
        private double price;

        public int OrderID
        {
            get { return orderID; }
            set { this.orderID = value; }
        }

        public string CustomerID
        {
            get { return customerID; }
            set { this.customerID = value; }
        }

        public string ShipCountry
        {
            get { return shipCountry; }
            set { this.shipCountry = value; }
        }

        public string Customer
        {
            get { return this.customer; }
            set { this.customer = value; }
        }

        public string ShipCity
        {
            get { return shipCity; }
            set { this.shipCity = value; }
        }

        public double  Price
        {
            get { return price; }
            set { this.price = value; }
        }

        public OrderInfo(int orderId, string customer, string country,  string customerId, string shipCity, double price)
        {
            this.OrderID = orderId;
            this.Customer = customer;
            this.ShipCountry = country;
            this.CustomerID = customerId;
            this.ShipCity = shipCity;
            this.Price = price;
        }
    }
}
