using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using FontAwesome.Sharp;
using online_shop.Models;
using online_shop.Services;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Button = System.Windows.Forms.Button;
using Control = System.Windows.Forms.Control;
using Image = System.Drawing.Image;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;

namespace altex.Panels
{
    public class ProductPage : Panel
    {

        private Label lblCategory;
        private Label lblProduct;

        private Label lblProdTitle;

        private PictureBox pctProduct;

        private Label lblPrice;
        private Label lblGreenTax;

        private IconPictureBox pctStock;
        private Label lblStock;

        private IconPictureBox pctLocation;
        private Label lblLocation;

        private PictureBox pctWarranty;
        private Label lblColor;
        private KryptonSeparator separator;

        private Button btnFav;

        private KryptonButton btnAdd;

        public event EventHandler miniClick;

        private Product product;


        private String prodPath;
        private String currentColor;

        private List<PictureBox> pctMinis;

        public Product Product
        {
            get => product;
        }

        public ProductPage(Control par, CategoryServices categories, Product product, String color, int y)
        {
            Parent = par;
            Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height - y);
            Location = new Point(0, y);
            AutoScroll = true;


            prodPath = Application.StartupPath + @"\images\products\" + product.Folder;
            pctMinis = new List<PictureBox>();

            currentColor = color;

            Initialize(product, categories.GetById(product.CategoryId).Name, color);

            this.product = product;


        }

        private void Initialize(Product product, String category, String color)
        {
            lblCategory = new Label
            {
                Parent = this,
                AutoSize = true,
                ForeColor = Color.FromArgb(198, 24, 70),
                Location = new Point(334, 0),
                Font = new Font("IBM Plex Sans", 9.75f),
                Text = "Acasa / " + category + " / "
            };

            lblProduct = new Label
            {
                Parent = this,
                AutoSize = true,
                Location = new Point(lblCategory.Location.X + lblCategory.Width - 3, lblCategory.Location.Y),
                Text = product.Name + ", " + color,
                Font = new Font("IBM Plex Sans", 9.75f)
            };
            lblProduct.BringToFront();

            lblProdTitle = new Label
            {
                Parent = this,
                AutoSize = false,
                Size = new Size(1135, 51),
                Location = new Point(329, 51),
                Font = new Font("IBM Plex Sans", 26.25f),
                Text = product.Name + ", " + color
            };

            string path = prodPath + "\\" + color;

            int x = 337, y = 157;

            foreach (String imgPath in Directory.EnumerateFiles(path))
            {
                PictureBox pctMini = new PictureBox
                {
                    Parent = this,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(106, 106),
                    ImageLocation = imgPath,
                    Location = new Point(x, y),
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand
                };
                pctMini.Click += PctMini_Click;

                pctMinis.Add(pctMini);

                y += 112;
            }

            pctProduct = new PictureBox
            {
                Parent = this,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(432, 432),
                Location = new Point(519, 221),
                ImageLocation = path + "\\1.jpg"
            };

            lblPrice = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 26.25f, FontStyle.Bold),
                ForeColor = Color.FromArgb(192, 0, 51),
                Location = new Point(1011, 221),
                Text = product.Price + ",00 lei"
            };

            lblGreenTax = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 9f),
                ForeColor = Color.Gray,
                Location = new Point(1016, 267),
                Text = "Include taxa verde: 0,40 lei."
            };

            pctStock = new IconPictureBox
            {
                Parent = this,
                Size = new Size(18, 18),
                IconSize = 18,
                IconChar = IconChar.Diamond,
                Location = new Point(1019, 297)
            };

            lblStock = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 9.75f),
                Location = new Point(1037, 297)
            };

            pctLocation = new IconPictureBox
            {
                Parent = this,
                IconChar = IconChar.Circle,
                IconFont = IconFont.Solid,
                IconColor = Color.FromArgb(96, 198, 238),
                IconSize = 18,
                Size = new Size(18, 18),
                Location = new Point(1019, 318)
            };

            lblLocation = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 9.75f, FontStyle.Bold),
                Location = new Point(1037, 318),
                Text = "exclusiv online",
                ForeColor = pctLocation.IconColor
            };

            if (product.Stock != 0)
            {
                pctStock.IconColor = Color.FromArgb(49, 157, 16);
                lblStock.ForeColor = Color.FromArgb(49, 157, 16);
                lblStock.Text = "in stoc";
            }
            else
            {
                pctStock.IconColor = Color.FromArgb(255, 122, 53);
                lblStock.ForeColor = Color.FromArgb(255, 122, 53);
                lblStock.Text = "in afara stocului";

                lblLocation.Hide();
                pctLocation.Hide();
            }

            pctWarranty = new PictureBox
            {
                Parent = this,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Location = new Point(1019, 353),
                ImageLocation = Application.StartupPath + @"\images\warranty.png"
            };

            lblColor = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 18F),
                Location = new Point(1013, 411),
                Text = "Culoare"
            };

            separator = new KryptonSeparator
            {
                Parent = this,
                Enabled = false,
                SeparatorStyle = SeparatorStyle.LowProfile,
                Location = new Point(1019, 456),
                Size = new Size(35, 3),
                StateCommon =
                {
                    Back =
                    {
                        Color1 = Color.FromArgb(245, 203, 56),
                        Color2 = Color.FromArgb(245, 203, 56)
                    }
                }
            };

            x = 1019;
            y = 475;
            path = prodPath;

            foreach (String dirPath in Directory.EnumerateDirectories(path))
            {
                PictureBox pctColor = new PictureBox
                {
                    Parent = this,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = new Point(x, y),
                    Size = new Size(54, 54),
                    ImageLocation = dirPath + @"\1.jpg",
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand
                };

                pctColor.Click += PctColor_Click;

                if (x == 1147)
                {
                    x = 1019;
                    y += 62;
                }
                else
                {
                    x += 64;
                }
            }

            btnFav = new Button
            {
                Parent = this,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("IBM Plex Sans", 12F),
                ImageAlign = ContentAlignment.MiddleLeft,
                Image = Image.FromFile(Application.StartupPath + @"\images\heart.png"),
                Text = "   Favorite",
                Size = new Size(112, 32),
                BackColor = Color.FromArgb(246, 249, 255),
                Location = new Point(1019, 679),
                Cursor = Cursors.Hand,
                FlatAppearance = { BorderSize = 0 }
            };

            btnAdd = new KryptonButton
            {
                Parent = this,
                Size = new Size(234, 45),
                Location = new Point(1019, 608),
                StateCommon =
                {
                    Back =
                    {
                        Color1 = Color.FromArgb(188, 0, 59),
                        Color2 = Color.FromArgb(188, 0, 59)
                    },
                    Content =
                    {
                        ShortText =
                        {
                            Font = new Font("IBM Plex Sans", 11.25f, FontStyle.Bold),
                            Color1 = Color.White
                        }
                    }
                },
                OverrideDefault =
                {
                    Back =
                    {
                        Color1 = Color.FromArgb(188, 0, 59),
                        Color2 = Color.FromArgb(188, 0, 59)
                    },
                    Content =
                    {
                        ShortText =
                        {
                            Font = new Font("IBM Plex Sans", 11.25f, FontStyle.Bold),
                            Color1 = Color.White
                        }
                    }
                },
                StateTracking =
                {
                    Back =
                    {
                        Color1 = Color.FromArgb(136, 0, 32),
                        Color2 = Color.FromArgb(136, 0, 32)
                    }
                },
                Text = "Adauga in cos",
                Cursor = Cursors.Hand
            };

        }

        private void PctColor_Click(object sender, EventArgs e)
        {
            if (miniClick != null)
            {
                miniClick(sender, null);
            }
        }

        private void PctMini_Click(object sender, EventArgs e)
        {
            pctProduct.ImageLocation = ((PictureBox)sender).ImageLocation;
        }

        public void ChangeColor(String color)
        {
            lblProduct.Text = lblProduct.Text.Replace(currentColor, color);

            lblProdTitle.Text = lblProdTitle.Text.Replace(currentColor, color);

            pctProduct.ImageLocation = prodPath + "\\" + color + @"\1.jpg";

            int k = 1;

            foreach (PictureBox pct in pctMinis)
            {
                pct.ImageLocation = prodPath + "\\" + color + String.Format(@"\{0}.jpg", k.ToString());

                k++;
            }

            currentColor = color;
        }
    }
}
