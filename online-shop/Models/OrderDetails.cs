using System;

namespace online_shop.Models
{
    public class OrderDetails : IComparable<OrderDetails>
    {
        private int id;
        private int order_id;
        private int product_id;
        private int price;
        private int quantity;

        public OrderDetails(int id, int orderId, int productId, int price, int quantity)
        {
            this.id = id;
            order_id = orderId;
            product_id = productId;
            this.price = price;
            this.quantity = quantity;
        }

        public OrderDetails(int orderId, int productId, int price, int quantity)
        {
            order_id = orderId;
            product_id = productId;
            this.price = price;
            this.quantity = quantity;
        }

        public OrderDetails()
        {
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public int OrderId
        {
            get => order_id;
            set => order_id = value;
        }

        public int ProductId
        {
            get => product_id;
            set => product_id = value;
        }

        public int Price
        {
            get => price;
            set => price = value;
        }

        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }

        public override string ToString()
        {
            string text = "";

            text += "ID: " + id + "\n";
            text += "Order ID: " + order_id + "\n";
            text += "Product ID: " + product_id + "\n";
            text += "Price: " + price + "\n";
            text += "Quantity: " + quantity + "\n";

            return text;
        }

        public override bool Equals(object obj)
        {
            if (obj is OrderDetails det)
            {
                return det.OrderId == order_id && det.ProductId == product_id && det.Price == price &&
                       det.Quantity == quantity;
            }

            return false;
        }

        public int CompareTo(OrderDetails other)
        {
            if (this.id > other.id)
                return 1;
            if (this.id < other.id)
                return -1;
            return 0;
        }
    }
}