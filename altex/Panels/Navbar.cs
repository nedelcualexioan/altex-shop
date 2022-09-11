using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using online_shop.Models;

namespace altex.Panels
{
    public class Navbar : Panel
    {
        private KryptonComboBox cmbProducts;
        private Label lblPromo;
        private Label lblSupport;
        private KryptonSeparator sep;
        public Navbar(Control par, List<Category> categories)
        {
            this.Parent = par;

            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, 48);

            this.BackColor = Color.FromArgb(192, 0, 51);

            Initialize();

            PopulateCmb(categories);
        }

        public int productsLeft
        {
            get => cmbProducts.Location.X;
        }

        private void Initialize()
        {
            cmbProducts = new KryptonComboBox
            {
                Parent = this,
                Size = new Size(129,45),
                Location = new Point(337, 0),
                StateActive =
                {
                    ComboBox =
                    {
                        Back = { Color1 = Color.FromArgb(221, 0, 59) },
                        Border =
                        {
                            Color1 = Color.FromArgb(221, 0, 59), 
                            Color2 = Color.FromArgb(221, 0, 59), 
                            Rounding = 5,
                            Width = 8
                        },
                        Content = { Color1 = Color.White, Font = new Font("IBM Plex Sans", 16F)}
                    }
                },
                Text = "Produse",
                DropButtonStyle = ButtonStyle.Gallery
            };
            cmbProducts.KeyDown += CmbProducts_KeyDown;
            cmbProducts.DropDownClosed += CmbProducts_DropDownClosed;
            cmbProducts.DropDown += CmbProducts_DropDown;

            lblPromo = new Label
            {
                Parent = this,
                AutoSize = true,
                Location = new Point(489, 11),
                Font = new Font("IBM Plex Sans", 15.75F),
                Text = "Promotii",
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };

            sep = new KryptonSeparator
            {
                Parent = this,
                SeparatorStyle = SeparatorStyle.LowProfile,
                Size = new Size(3, 48),
                Location = new Point(586, 0),
                StateCommon =
                {
                    Back =
                    {
                        Color1 = Color.FromArgb(221, 0, 59),
                        Color2 = Color.FromArgb(221, 0, 59)
                    }
                }
            };
            sep.Enabled = false;

            lblSupport = new Label
            {
                Parent = this,
                AutoSize = true,
                Location = new Point(596, 11),
                Font = new Font("IBM Plex Sans", 15.75F),
                Text = "Suport clienti",
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
        }

        private void PopulateCmb(List<Category> list)
        {
            this.cmbProducts.Items.AddRange(list.Select(cat => cat.Name).ToArray());
        }

        private void CmbProducts_DropDown(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => cmbProducts.SelectionLength = 0));
        }

        private void CmbProducts_DropDownClosed(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => { cmbProducts.Select(0, 0); }));
        }

        private void CmbProducts_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
