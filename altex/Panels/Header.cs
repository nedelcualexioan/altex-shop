using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using FontAwesome.Sharp;

namespace altex.Panels
{
    public class Header : Panel
    {
        private PictureBox pctLogo;

        private Panel pnlSearchbox;
        private KryptonTextBox txtProduct;
        private PictureBox pctSearch;

        private PictureBox pctCart;
        private Label lblCart;

        private IconPictureBox pctAccount;
        private Label lblAccount;

        public Header(Control par)
        {
            par.Controls.Add(this);

            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, 92);

            Initialize();       
        }

        private void Initialize()
        {
            pctLogo = new PictureBox
            {
                Parent = this,
                ImageLocation = Application.StartupPath + @"\images\logo.png",
                Size = new Size(129, 45),
                Left = 337,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            pctLogo.Top = (pctLogo.Parent.Height - pctLogo.Height) / 2;

            pnlSearchbox = new Panel
            {
                Parent = this,
                Left = 503,
                Size = new Size(448, 52),
                BorderStyle = BorderStyle.FixedSingle
            };
            pnlSearchbox.Top = (pnlSearchbox.Parent.Height - pnlSearchbox.Height) / 2;

            txtProduct = new KryptonTextBox
            {
                Parent = pnlSearchbox,
                StateActive =
                {
                    Back = { Color1 = Color.FromArgb(250, 252, 252) },
                    Border =
                    {
                        Color1 = Color.FromArgb(224, 224, 224),
                        Color2 = Color.FromArgb(224, 224, 224),
                        Rounding = 0,
                        Width = 0
                    },
                    Content =
                    {
                        Color1 = Color.Silver, Font = new Font("IBM Plex Sans", 15.75F),
                        Padding = new Padding(15, 0, 10, 0)
                    }
                },
                Location = new Point(0, 10),
                Size = new Size(403, 30),
                Text = "Cauta produsul dorit"
            };

            pctSearch = new PictureBox
            {
                Parent = pnlSearchbox,
                Left = 409,
                Size = new Size(30, 30),
                ImageLocation = Application.StartupPath + @"\images\search.png",
                SizeMode = PictureBoxSizeMode.Zoom
            };
            pctSearch.Top = (pctSearch.Parent.Height - pctSearch.Height) / 2;

            pctCart = new PictureBox
            {
                Parent = this,
                Location = new Point(1380, 33),
                Size = new Size(30, 30),
                ImageLocation = Application.StartupPath + @"\images\shop-cart-icon.png",
                SizeMode = PictureBoxSizeMode.Zoom
            };

            lblCart = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 11.25F),
                Location = new Point(1413, 38),
                Text = "Cosul meu"
            };

            pctAccount = new IconPictureBox
            {
                Parent = this,
                Location = new Point(1525, 33),
                IconSize = 30,
                IconChar = IconChar.User,
                IconFont = IconFont.Regular
            };

            lblAccount = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 11.25f),
                Location = new Point(1557, lblCart.Location.Y),
                Text = "Cont"
            };

            txtProduct.GotFocus += TxtProduct_GotFocus;

            txtProduct.LostFocus += TxtProduct_LostFocus;
        }

        private void TxtProduct_LostFocus(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProduct.Text))
            {
                txtProduct.Text = "Cauta produsul dorit";
            }
        }

        private void TxtProduct_GotFocus(object sender, System.EventArgs e)
        {
            if (txtProduct.Text == "Cauta produsul dorit")
            {
                txtProduct.Text = "";
            }
        }
    }
}