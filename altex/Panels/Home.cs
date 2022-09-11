using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using FontAwesome.Sharp;
using online_shop.Exceptions;
using online_shop.Models;
using online_shop.Services;

namespace altex.Panels
{
    public class Home : Panel
    {
        private int imageNumber = 1;
        private Timer timer;

        private PictureBox pctAd;



        private Header pnlHeader;
        private Navbar pnlNavbar;

        private PictureBox pctTruck;
        private PictureBox pctReturn;
        private PictureBox pctMoneyBack;
        private PictureBox pctSafe;

        private Label lblDelivery;
        private Label lblReturn;
        private Label lblMoneyBack;
        private Label lblSafe;

        private Panel pnlContainer;
        private Label lblDeals;


        private PictureBox pctTravel;
        

        private Panel pnlNewsletter;
        private Label lblJoin;

        private IconPictureBox ic1;
        private IconPictureBox ic2;
        private IconPictureBox ic3;

        private Label lblJ1;
        private Label lblJ2;
        private Label lblJ3;

        private KryptonTextBox txtEmail;
        private KryptonButton btnSubscribe;

        private Label lblTos;
        private PictureBox pctNewsletter;

        private Panel pnlBestbuy;
        private PictureBox pctBestbuy;
        private Label lblQuality;
        private Label lblAward;


        private Footer pnlFooter;


        public Home(Control par, CategoryServices categDb, ProductsServices prodsDb)
        {
            this.Parent = par;

            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.Location = new Point(0, 0);
            this.AutoScroll = true;

            timer = new Timer();

            timer.Enabled = true;
            timer.Interval = 2500;

            timer.Tick += Timer_Tick;

            pnlHeader = new Header(this);
            pnlNavbar = new Navbar(this, categDb.GetAll());
            pnlNavbar.Location = new Point(0, pnlHeader.Height);


            Initialize();

            pnlFooter = new Footer(this);
            pnlFooter.Location = new Point(0, pnlBestbuy.Location.Y + pnlBestbuy.Height);

            LoadNextImage();

            try
            {
                prodsDb.getRandom(10);

                PopulateContainer(prodsDb.getRandom(10));
            }
            catch (NotEnoughObjectsException)
            {
                pnlContainer.Hide();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }

        private void LoadNextImage()
        {
            if (imageNumber == 5)
            {
                imageNumber = 1;
            }

            pctAd.ImageLocation = string.Format(Application.StartupPath + @"\images\ads\{0}.jpg", imageNumber);
            imageNumber++;
        }

        private void Initialize()
        {
            pctAd = new PictureBox
            {
                Parent = this,
                Size = new Size(1260, 360),
                Location = new Point(337, 140),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            pctTruck = new PictureBox
            {
                Parent = this,
                Location = new Point(407, 536),
                Size = new Size(100, 100),
                ImageLocation = Application.StartupPath + @"\images\transport_pana_la_usa.png",
            };

            Clone(pctTruck, out pctReturn);
            pctReturn.ImageLocation += "retur_in_30_de_zile.png";
            pctReturn.Left = 759;

            Clone(pctTruck, out pctMoneyBack);
            pctMoneyBack.ImageLocation += "2x_diferenta.png";
            pctMoneyBack.Left = 1081;

            Clone(pctTruck, out pctSafe);
            pctSafe.ImageLocation += "protejeaza_investitia.png";
            pctSafe.Left = 1447;

            lblDelivery = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 12F),
                Location = new Point(363, 649),
                Text = "Transport la orice produs"
            };

            lblReturn = new Label
            {
                Parent = this,
                AutoSize = true,
                Location = new Point(703, 649),
                Font = new Font("IBM Plex Sans", 12F),
                Text = "Te-ai razgandit? Poti returna\nprodusul in 14 zile",
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblMoneyBack = new Label
            {
                Parent = this,
                AutoSize = true,
                Location = new Point(1023, 649),
                Font = new Font("IBM Plex Sans", 12F),
                Text = "Primesti de 2 ori diferenta la\norice produs",
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblSafe = new Label
            {
                Parent = this,
                AutoSize = true,
                Location = new Point(1399, 649),
                Font = new Font("IBM Plex Sans", 12F),
                Text = "Protejeaza-ti investitia cu\nextragarantie",
                TextAlign = ContentAlignment.MiddleCenter
            };

            pnlContainer = new Panel
            {
                Parent = this,
                Size = new Size(1260, 800),
                Location = new Point(337, 728)
            };

            lblDeals = new Label
            {
                Parent = pnlContainer,
                AutoSize = true,
                Location = new Point(0, 0),
                Font = new Font("IBM Plex Sans", 24F),
                Text = "Top Oferte"
            };

            pctTravel = new PictureBox
            {
                Parent = this,
                Location = new Point(pnlContainer.Location.X, pnlContainer.Location.Y + pnlContainer.Height + 15),
                Size = new Size(pnlContainer.Width, 100),
                ImageLocation = Application.StartupPath + @"\images\ads\altex-travel.png",
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            pnlNewsletter = new Panel
            {
                Parent = this,
                Location = new Point(pctTravel.Location.X, pctTravel.Location.Y + pctTravel.Height + 35),
                Size = new Size(pctTravel.Width, 230),
                BackColor = Color.FromArgb(255, 242, 214)
            };

            lblJoin = new Label
            {
                Parent = pnlNewsletter,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 20.25f),
                Location = new Point(21, 18),
                Text = "Inscrie-te acum si fii primul care afla de cele mai noi promotii"
            };

            ic1 = new IconPictureBox
            {
                Parent = pnlNewsletter,
                IconChar = IconChar.Diamond,
                IconSize = 19,
                Size = new Size(19, 25),
                Location = new Point(27, 69)
            };

            Clone(ic1, out ic2);
            Clone(ic1, out ic3);

            ic2.Top += 26;
            ic3.Top += 52;

            lblJ1 = new Label
            {
                Parent = pnlNewsletter,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 11.25f),
                Location = new Point(63, 67),
                Text = "Inscrie-te acum si fii primul care afla de cele mai noi promotii"
            };

            Clone(lblJ1, out lblJ2);
            Clone(lblJ1, out lblJ3);

            lblJ2.Top += 28;
            lblJ3.Top += 56;

            lblJ2.Text = "Afli primul startul promotiilor si cand se lanseaza produse noi";
            lblJ3.Text = "Beneficiezi de ofertele si serviciile dedicate abonatilor";

            txtEmail = new KryptonTextBox
            {
                Parent = pnlNewsletter,
                Location = new Point(27, 155),
                StateActive =
                {
                    Back = { Color1 = Color.White },
                    Border =
                    {
                        Color1 = Color.FromArgb(245, 203, 56),
                        Color2 = Color.FromArgb(245, 203, 56),
                        GraphicsHint = PaletteGraphicsHint.AntiAlias,
                        Rounding = 20,
                        Width = 1
                    },
                    Content =
                    {
                        Color1 = Color.Silver,
                        Font = new Font("IBM Plex Sans", 14.25f),
                        Padding = new Padding(10, 0, 10, 0)
                    }
                },
                Text = "Introdu adresa de email",
                Size = new Size(374, 39)
            };

            btnSubscribe = new KryptonButton
            {
                Parent = pnlNewsletter,
                Location = new Point(421, 155),
                Size = new Size(140, 39),
                OverrideDefault =
                {
                    Back =
                    {
                        Color1 = Color.FromArgb(245, 203, 56),
                        Color2 = Color.FromArgb(245, 203, 56),
                        ColorAngle = 45
                    },
                    Border =
                    {
                        Color1 = Color.FromArgb(245, 203, 56),
                        Color2 = Color.FromArgb(245, 203, 56),
                        ColorAngle = 45,
                        Rounding = 20,
                        Width = 1,
                        GraphicsHint = PaletteGraphicsHint.AntiAlias
                    },
                    Content =
                    {
                        ShortText =
                        {
                            Color1 = Color.Black,
                            Font = new Font("IBM Plex Sans", 12F)
                        }
                    }
                },
                StateCommon =
                {
                    Back =
                    {
                        Color1 = Color.FromArgb(245, 203, 56),
                        Color2 = Color.FromArgb(245, 203, 56),
                        ColorAngle = 45
                    },
                    Border =
                    {
                        Color1 = Color.FromArgb(245, 203, 56),
                        Color2 = Color.FromArgb(245, 203, 56),
                        ColorAngle = 45,
                        Rounding = 20,
                        Width = 1,
                        GraphicsHint = PaletteGraphicsHint.AntiAlias
                    },
                    Content =
                    {
                        ShortText =
                        {
                            Color1 = Color.Black,
                            Font = new Font("IBM Plex Sans", 12F)
                        }
                    }
                },
                StateTracking =
                {
                    Back =
                    {
                        Color1 = Color.FromArgb(220, 172, 0),
                        Color2 = Color.FromArgb(220, 172, 0),
                        ColorAngle = 135
                    },
                    Border =
                    {
                        Color1 = Color.FromArgb(220, 172, 0),
                        Color2 = Color.FromArgb(220, 172, 0),
                        ColorAngle = 135,
                        Rounding = 20,
                        Width = 1
                    }
                },
                Text = "Aboneaza-te",
                Cursor = Cursors.Hand
            };

            lblTos = new Label
            {
                Parent = pnlNewsletter,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 8.25f),
                Location = new Point(23, 206),
                Text =
                    "Prin abonarea la newsletter confirm ca am peste 16 ani si sunt de acord cu Termenii si conditiile de utilizare a site-ului altex.ro"
            };

            pctNewsletter = new PictureBox
            {
                Parent = pnlNewsletter,
                ImageLocation = Application.StartupPath + @"\images\newsletter.jpg",
                SizeMode = PictureBoxSizeMode.AutoSize,
                Location = new Point(774, 0)
            };

            pctNewsletter.SendToBack();

            pnlBestbuy = new Panel
            {
                Parent = this,
                Size = new Size(this.Width, 112),
                Location = new Point(0, pnlNewsletter.Location.Y + pnlNewsletter.Height + 40),
                BackColor = Color.Black
            };

            pctBestbuy = new PictureBox
            {
                Parent = pnlBestbuy,
                ImageLocation = Application.StartupPath + @"\images\logo-bba.png",
                Size = new Size(95, pnlBestbuy.Height),
                Location = new Point(pnlNewsletter.Location.X, 0),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            lblQuality = new Label
            {
                Parent = pnlBestbuy,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 11.25f, FontStyle.Bold),
                Location = new Point(pctBestbuy.Location.X + 114, 34),
                Text = "Cel mai bun raport calitate-pret",
                ForeColor = Color.FromArgb(245, 203, 56)
            };

            lblAward = new Label
            {
                Parent = pnlBestbuy,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 9.75f),
                ForeColor = Color.White,
                Location = new Point(lblQuality.Location.X + 1, 57),
                Text = "Conform sondajului Best Buy Award 2021/2022 efectuat de organizatia iCertias."
            };


            txtEmail.GotFocus += TxtEmail_GotFocus;
            txtEmail.LostFocus += TxtEmail_LostFocus;

        }

        private void PopulateContainer(List<Product> products)
        {
            int x = 0, y = 80, k = 1;

            foreach (Product p in products)
            {
                Card card = new Card(p)
                {
                    Parent = pnlContainer,
                    Location = new Point(x, y)
                };

                x += card.Width + 27;

                if (k == 5)
                {
                    x = 0;
                    y += card.Height + 20;

                    k = 1;
                }
                else
                {
                    k++;
                }
            }
        }

        private void TxtEmail_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Introdu adresa de email";
            }
        }

        private void TxtEmail_GotFocus(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Introdu adresa de email")
            {
                txtEmail.Text = "";
            }
        }

        private void Clone(Label source, out Label dest)
        {
            dest = new Label
            {
                Parent = source.Parent,
                AutoSize = source.AutoSize,
                Font = new Font(source.Font.FontFamily, source.Font.Size),
                Location = new Point(source.Location.X, source.Location.Y)
            };
        }

        private void Clone(IconPictureBox source, out IconPictureBox dest)
        {
            dest = new IconPictureBox
            {
                Parent = source.Parent,
                IconChar = source.IconChar,
                IconSize = source.IconSize,
                Size = new Size(source.Width, source.Height),
                Location = new Point(source.Location.X, source.Location.Y)
            };
        }

        private void Clone(PictureBox source, out PictureBox destination)
        {
            destination = new PictureBox
            {
                Parent = this,
                Location = new Point(source.Location.X, source.Location.Y),
                Size = new Size(source.Width, source.Height),
                ImageLocation = Application.StartupPath + @"\images\",
                SizeMode = source.SizeMode
            };
        }
    }
}
