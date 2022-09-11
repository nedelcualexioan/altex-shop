using System;

namespace online_shop.Models
{
    public class ProductOptions : IComparable<ProductOptions>
    {
        private int id;
        private int option_id;
        private int product_id;

        public ProductOptions(int id, int optionId, int productId)
        {
            this.id = id;
            option_id = optionId;
            product_id = productId;
        }

        public ProductOptions(int optionId, int productId)
        {
            option_id = optionId;
            product_id = productId;
        }

        public ProductOptions()
        {
        }

        public override string ToString()
        {
            string text = "";

            text += "ID: " + id + "\n";
            text += "Options ID: " + option_id + "\n";
            text += "Product ID: " + product_id + "\n";

            return text;
        }

        public override bool Equals(object obj)
        {
            if (obj is ProductOptions p)
            {
                return p.OptionId == option_id && p.ProductId == product_id;
            }

            return false;
        }

        public int CompareTo(ProductOptions other)
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

        public int OptionId
        {
            get => option_id;
            set => option_id = value;
        }

        public int ProductId
        {
            get => product_id;
            set => product_id = value;
        }
    }
}