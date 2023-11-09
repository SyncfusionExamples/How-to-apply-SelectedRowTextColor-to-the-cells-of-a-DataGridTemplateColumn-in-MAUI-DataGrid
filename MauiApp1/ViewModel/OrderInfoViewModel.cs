
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MauiApp1
{
    public class OrderInfoRepository
    {
        public Color SelectedColor = Colors.DeepPink;
        private ObservableCollection<OrderInfo> orderInfo;
        public ObservableCollection<OrderInfo> OrderInfoCollection
        {
            get { return orderInfo; }
            set { this.orderInfo = value; }
        }

        public OrderInfoRepository()
        {
            orderInfo = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
        }

        public void GenerateOrders()
        {
            orderInfo.Add(new OrderInfo(1001, "Jack Parker", "Germany", "ALFKI", "Berlin",13000));
            orderInfo.Add(new OrderInfo(1002, "Maria Anders", "Mexico", "ANATR", "Mexico D.F.",6000));
            orderInfo.Add(new OrderInfo(1003, "Alice Johnson", "Mexico", "ANTON", "Mexico D.F.",15000));
            orderInfo.Add(new OrderInfo(1004, "Thomas Hardy", "UK", "AROUT", "London",8000));    
            orderInfo.Add(new OrderInfo(1005, "Emily Davis", "Sweden", "BERGS", "London",7000));
            orderInfo.Add(new OrderInfo(1006, "Hanna Moos", "Germany", "BLAUS", "Mannheim",7000));
            orderInfo.Add(new OrderInfo(1007, "Andrew Fuller", "France", "BLONP", "Strasbourg",12000));
            orderInfo.Add(new OrderInfo(1008, "Martin King", "Spain", "BOLID", "Madrid",8000));
            orderInfo.Add(new OrderInfo(1009, "Lenny Lin", "France", "BONAP", "Marsiella",18000));
            orderInfo.Add(new OrderInfo(1010, "John Carter", "Canada", "BOTTM", "Lenny Lin",6000));
        }
    }
}
