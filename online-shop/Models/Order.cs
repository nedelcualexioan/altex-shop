using System;

namespace online_shop.Models
{
    public class Order
    {
        private int id;
        private int customer_id;
        private int ammount;
        private String shipping_address;
        private DateTime order_date;
        private String order_status;

        public Order(int id, int customerId, int ammount, string shippingAddress, DateTime orderDate, string orderStatus)
        {
            this.id = id;
            customer_id = customerId;
            this.ammount = ammount;
            shipping_address = shippingAddress;
            order_date = orderDate;
            order_status = orderStatus;
        }

        public Order(int customerId, int ammount, string shippingAddress, DateTime orderDate, string orderStatus)
        {
            customer_id = customerId;
            this.ammount = ammount;
            shipping_address = shippingAddress;
            order_date = orderDate;
            order_status = orderStatus;
        }

        public Order()
        {
        }

        public override string ToString()
        {
            string text = "";

            text += "ID: " + id + "\n";
            text += "Customer ID: " + customer_id + "\n";
            text += "Ammount: " + ammount + "\n";
            text += "Shipping address: " + shipping_address + "\n";
            text += "Order date: " + order_date + "\n";
            text += "Order status: " + order_status + "\n";

            return text;
        }

        public override bool Equals(object obj)
        {
            if (obj is Order o)
            {
                return o.CustomerId == customer_id && o.Ammount == ammount && o.ShippingAddress == shipping_address &&
                       o.OrderDate == order_date && o.OrderStatus == order_status;
            }

            return false;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int CustomerId
        {
            get => customer_id;
            set => customer_id = value;
        }

        public int Ammount
        {
            get => ammount;
            set => ammount = value;
        }

        public string ShippingAddress
        {
            get => shipping_address;
            set => shipping_address = value;
        }

        public DateTime OrderDate
        {
            get => order_date;
            set => order_date = value;
        }

        public string OrderStatus
        {
            get => order_status;
            set => order_status = value;
        }
    }
}