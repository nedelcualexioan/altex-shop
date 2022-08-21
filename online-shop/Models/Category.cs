using System;

namespace online_shop.Models
{
    public class Category
    {
        private int id;
        private String name;

        public Category(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Category(string name)
        {
            this.name = name;
        }

        public Category()
        {
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

        public override string ToString()
        {
            string text = "";

            text += "ID: " + id + "\n";
            text += "Name: " + name + "\n";

            return text;
        }

        public override bool Equals(object obj)
        {
            if (obj is Category cat)
            {
                return cat.Name.Equals(name);
            }

            return false;
        }
    }
}