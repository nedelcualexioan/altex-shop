using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using FontAwesome.Sharp;
using online_shop.Models;

namespace altex.Panels
{
    public class Card : Panel
    {
        private IconPictureBox pctFav;
        private PictureBox pctProduct;
        private Label lblDescription;

        private Label lblPrice;
        private KryptonButton btnAdd;

        public Card(Product p)
        {
            this.Size = new Size(230, 340);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;

            Initialize(p);
        }

        private void Initialize(Product p)
        {
            pctFav = new IconPictureBox
            {
                Parent = this,
                IconChar = IconChar.Heart,
                IconSize = 32,
                Location = new Point(9, 9),
                Size = new Size(32, 32)
            };


            pctProduct = new PictureBox
            {
                Parent = this,
                Top = 39,
                Size = new Size(120, 120),
                ImageLocation = Application.StartupPath + @"\images\" + p.Image,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            pctProduct.Left = (pctProduct.Parent.Width - pctProduct.Width) / 2;


            lblDescription = new Label
            {
                Parent = this,
                AutoSize = false,
                Size = new Size(190, 78),
                Top = 162,
                Font = new Font("IBM Plex Sans", 11F),
                Text = p.Name,
                TextAlign = ContentAlignment.MiddleCenter
            };
            lblDescription.Left = (lblDescription.Parent.Width - lblDescription.Width) / 2;
                

            btnAdd = new KryptonButton
            {
                Parent = this,
                Top = 287,
                Size = new Size(197, 32),
                OverrideDefault =
                {
                    Back =
                    {
                        Color1 = Color.FromArgb(188,0,59),
                        Color2 = Color.FromArgb(188,0,59)
                    },
                    Border =
                    {
                        Rounding = 5,
                        Width = 1
                    },
                    Content =
                    {
                        ShortText =
                        {
                            Color1 = Color.White,
                            Color2 = Color.White,
                            Font = new Font("IBM Plex Sans", 9.75F)
                        }
                    }
                },

                StateCommon =
                {
                    Back =
                    {
                        Color1 = Color.FromArgb(188,0,59),
                        Color2 = Color.FromArgb(188,0,59)
                    },
                    Border =
                    {
                        Rounding = 5,
                        Width = 1
                    },
                    Content =
                    {
                        ShortText =
                        {
                            Color1 = Color.White,
                            Color2 = Color.White,
                            Font = new Font("IBM Plex Sans", 9.75F)
                        }
                    }
                },

                OverrideFocus =
                {
                    Back =
                    {
                        Color1 = Color.FromArgb(136, 0, 32),
                        Color2 = Color.FromArgb(136, 0, 32)
                    },
                    Border =
                    {
                        Rounding = 5,
                        Width = 1
                    },
                    Content =
                    {
                        ShortText =
                        {
                            Color1 = Color.White,
                            Color2 = Color.White,
                            Font = new Font("IBM Plex Sans", 9.75F)
                        }
                    }
                },

                StateTracking =
                {
                    Back =
                    {
                        Color1 = Color.FromArgb(136, 0, 32),
                        Color2 = Color.FromArgb(136, 0, 32)
                    },
                    Border =
                    {
                        Rounding = 5,
                        Width = 1
                    },
                    Content =
                    {
                        ShortText =
                        {
                            Color1 = Color.White,
                            Color2 = Color.White,
                            Font = new Font("IBM Plex Sans", 9.75F)
                        }
                    }
                },
                
                Text = "Adauga in cos",

                Cursor = Cursors.Hand
            };

            btnAdd.Left = (btnAdd.Parent.Width - btnAdd.Width) / 2;


            lblPrice = new Label
            {
                Parent = this,
                AutoSize = true,
                Location = new Point(btnAdd.Location.X, 252),
                Font = new Font("IBM Plex Sans", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(192, 0, 51),
                Text = p.Price.ToString("N0").Replace(",", ".") + ",00 lei",
                TextAlign = ContentAlignment.MiddleCenter
            };
        }
    }
}
