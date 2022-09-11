using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using online_shop.Models;
using online_shop.Services;

namespace altex.Panels
{
    public class ProductsView : Panel
    {
        private Header pnlHeader;
        private Navbar pnlNavbar;

        private Panel pnlContainer;

        private Label lblPath;
        private Label lblCategory;
        private Label lblSortBy;
        private KryptonComboBox cmbSortBy;

        public ProductsView(Control par, String category, CategoryServices categories, ProductsServices products)
        {
            this.Parent = par;

            this.Location = new Point(0, 0);
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;

            pnlHeader = new Header(this);
            pnlNavbar = new Navbar(this, categories.GetAll());

            pnlHeader.Location = new Point(0, 0);
            pnlNavbar.Location = new Point(0, pnlHeader.Height);

            int categ = categories.GetByName(category).Id;


            Initialize(category);

            Populate(products.getByCategory(categ));

            cmbSortBy.SelectedValueChanged += (s, e) => CmbSortBy_SelectedValueChanged(s, e, products, categ);
        }

        public void Initialize(String category)
        {

            pnlContainer = new Panel
            {
                Parent = this,
                Location = new Point(0, 360),
                Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height - 400),
                AutoScroll = true
            };

            lblPath = new Label
            {
                Parent = this,
                AutoSize = true,
                ForeColor = Color.FromArgb(198, 24, 70),
                Location = new Point(334, 152),
                Font = new Font("IBM Plex Sans", 9.75f),
                Text = "Acasa / " + category
            };

            lblCategory = new Label
            {
                Parent = this,
                AutoSize = true,
                Location = new Point(414, 223),
                Font = new Font("IBM Plex Sans", 26.25f),
                Text = category
            };

            lblSortBy = new Label
            {
                Parent = this,
                AutoSize = true,
                Location = new Point(418, 300),
                Font = new Font("IBM Plex Sans", 12.75f, FontStyle.Bold),
                Text = "Sorteaza dupa: "
            };

            cmbSortBy = new KryptonComboBox
            {
                Parent = this,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(559, 297),
                StateActive =
                {
                    ComboBox =
                    {
                        Border = { Width = 1 },
                        Content = { Font = new Font("IBM Plex Sans", 12.75f) }
                    }
                },
                Size = new Size(167, 28)
            };


            cmbSortBy.Items.AddRange(new []{"Pret crescator", "Pret descrescator", "Nume"});


        }

        private void CmbSortBy_SelectedValueChanged(object sender, EventArgs e, ProductsServices prods, int catId)
        {
            pnlContainer.Controls.Clear();

            switch (cmbSortBy.SelectedItem)
            {
                case "Nume":
                    Populate(prods.GetCategorySortBy(catId, "name"));
                    break;
                case "Pret crescator":
                    Populate(prods.GetCategorySortBy(catId, "price"));
                    break;
                case "Pret descrescator":
                    Populate(prods.GetCategorySortBy(catId, "price DESC"));
                    break;
            }
        }

        public void Populate(List<Product> products)
        {               

            int x = 422, y = 5;

            foreach (Product p in products)
            {
                Card card = new Card(p)
                {
                    Parent = pnlContainer,
                    Location = new Point(x, y)
                };

                if (x == 1214)
                {
                    x = 422;
                    y += card.Height + 25;
                }
                else
                {
                    x += card.Width + 34;
                }

            }

        }





    }
}
