using System;

namespace online_shop.Models
{
    public class Product : IComparable<Product>
    {
        private int id;
        private String name;
        private int price;
        private String image;
        private String folder;
        private int category_id;
        private int stock;

        public Product(int id, string name, int price, string image, string folder, int categoryId, int stock)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.image = image;
            this.folder = folder;
            category_id = categoryId;
            this.stock = stock;
        }

        public Product(string name, int price, string image, string folder, int categoryId, int stock)
        {
            this.name = name;
            this.price = price;
            this.image = image;
            this.folder = folder;
            category_id = categoryId;
            this.stock = stock;
        }

        public Product()
        {

        }

        public override string ToString()
        {
            string text = "";

            text += "ID: " + id + "\n";
            text += "Name: " + name + "\n";
            text += "Price: " + price + "\n";
            text += "Image: " + image + "\n";
            text += "Folder: " + folder + "\n";
            text += "Category ID: " + category_id + "\n";
            text += "Stock: " + stock + "\n";

            return text;
        }

        public override bool Equals(object obj)
        {
            if (obj is Product p)
            {
                return p.Name == this.name && p.Price == this.price && p.Image == this.image &&
                       p.Folder == this.folder &&
                       p.CategoryId == this.category_id && p.Stock == this.stock;
            }

            return false;
        }

        public int CompareTo(Product other)
        {
            if (this.id > other.id)
                return 1;
            if (this.id < other.id) 
                return -1;
            return 0;
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Price
        {
            get => price;
            set => price = value;
        }

        public string Image
        {
            get => image;
            set => image = value;
        }

        public string Folder
        {
            get => folder;
            set => folder = value;
        }

        public int CategoryId
        {
            get => category_id;
            set => category_id = value;
        }

        public int Stock
        {
            get => stock;
            set => stock = value;
        }
    }
}