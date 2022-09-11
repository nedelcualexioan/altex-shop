using System;

namespace online_shop.Models
{
    public class Option : IComparable<Option>
    {
        private int id;
        private String option_name;

        public Option(int id, string optionName)
        {
            this.id = id;
            option_name = optionName;
        }

        public Option(string optionName)
        {
            option_name = optionName;
        }

        public Option()
        {
        }

        public override string ToString()
        {
            string text = "";

            text += "ID: " + id + "\n";
            text += "Option name: " + option_name + "\n";

            return text;
        }

        public override bool Equals(object obj)
        {
            if (obj is Option o)
            {
                return o.OptionName == option_name;
            }

            return false;
        }

        public int CompareTo(Option other)
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

        public string OptionName
        {
            get => option_name;
            set => option_name = value;
        }
    }
}