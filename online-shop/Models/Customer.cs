using System;

namespace online_shop.Models
{
    public class Customer
    {
        private int id;
        private String email;
        private String password;
        private String full_name;
        private String shipping_address;
        private String country;
        private String phone;

        public Customer(int id, string email, string password, string fullName, string shippingAddress, string country, string phone)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            full_name = fullName;
            shipping_address = shippingAddress;
            this.country = country;
            this.phone = phone;
        }

        public Customer(string email, string password, string fullName, string shippingAddress, string country, string phone)
        {
            this.email = email;
            this.password = password;
            full_name = fullName;
            shipping_address = shippingAddress;
            this.country = country;
            this.phone = phone;
        }

        public Customer()
        {
        }

        public override string ToString()
        {
            string text = "";

            text += "ID: " + id + "\n";
            text += "Email: " + email + "\n";
            text += "Password: " + password + "\n";
            text += "Full name: " + full_name + "\n";
            text += "Shipping address: " + shipping_address + "\n";
            text += "Country: " + country + "\n";
            text += "Phone: " + phone + "\n";

            return text;
        }

        public override bool Equals(object obj)
        {
            if (obj is Customer c)
            {
                return c.Email == email && c.Password == password && c.FullName == full_name &&
                       c.ShippingAddress == shipping_address;
            }

            return false;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public string FullName
        {
            get => full_name;
            set => full_name = value;
        }

        public string ShippingAddress
        {
            get => shipping_address;
            set => shipping_address = value;
        }

        public string Country
        {
            get => country;
            set => country = value;
        }

        public string Phone
        {
            get => phone;
            set => phone = value;
        }
    }
}