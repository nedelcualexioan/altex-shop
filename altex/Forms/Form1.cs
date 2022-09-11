using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using altex.Panels;
using online_shop.Repositories;

namespace altex.Forms
{
    public partial class Form1 : Form
    {
        private Card card;

        public Form1()
        {
            InitializeComponent();

            ProductRepository repo = new ProductRepository();

            card = new Card(repo.getById(2));

            card.Parent = this;

            card.Location = new Point(10, 10);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
