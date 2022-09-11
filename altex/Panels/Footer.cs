using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using FontAwesome.Sharp;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace altex.Panels
{
    public class Footer : Panel
    {

        private Label lblFollow;
        private KryptonSeparator separator;

        private IconPictureBox pctFacebook;
        private IconPictureBox pctTwitter;
        private IconPictureBox pctLinkedin;
        private IconPictureBox pctYoutube;

        private PictureBox pctAltex;

        private Label lblAltex1;
        private Label lblAltex2;

        public Footer(Control par)
        {

            this.Parent = par;

            this.Size = new Size(par.Width, 247);
            this.BackColor = Color.FromArgb(42, 45, 48);

            Initialize();

        }

        private void Initialize()
        {
            lblFollow = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 14.25f, FontStyle.Bold),
                Location = new Point(337, 24),
                ForeColor = Color.FromArgb(159, 159, 159),
                Text = "Urmareste-ne"
            };

            separator = new KryptonSeparator
            {
                Parent = this,
                SeparatorStyle = SeparatorStyle.LowProfile,
                Orientation = Orientation.Horizontal,
                Location = new Point(342, 62),
                Size = new Size(30, 3),
                StateCommon =
                {
                    Back =
                    {
                        Color1 = Color.FromArgb(144, 124, 52),
                        Color2 = Color.FromArgb(144, 124, 52)
                    }
                }
            };
            separator.Enabled = false;

            pctFacebook = new IconPictureBox
            {
                Parent = this,
                Location = new Point(338, 85),
                Size = new Size(32, 32),
                IconSize = 33,
                IconChar = IconChar.FacebookSquare,
                IconColor = Color.FromArgb(128, 129, 133),
                IconFont = IconFont.Auto,
                Cursor = Cursors.Hand
            };

            Clone(pctFacebook, out pctTwitter);
            pctTwitter.IconChar = IconChar.TwitterSquare;

            Clone(pctTwitter, out pctLinkedin);
            pctLinkedin.IconChar = IconChar.Linkedin;

            Clone(pctLinkedin, out pctYoutube);
            pctYoutube.IconChar = IconChar.YoutubeSquare;

            pctAltex = new PictureBox
            {
                Parent = this,
                SizeMode = PictureBoxSizeMode.AutoSize,
                Location = new Point(333, 133),
                ImageLocation = Application.StartupPath + @"\images\fundatia-altex.png"
            };

            lblAltex1 = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 9.75f),
                ForeColor = Color.White,
                Location = new Point(338, 177),
                Text =
                    "Cel mai mic pret din Romania! Daca gasesti in alta parte mai ieftin primesti de doua ori diferenta."
            };

            lblAltex2 = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("IBM Plex Sans", 9.75f),
                ForeColor = Color.White,
                Location = new Point(lblAltex1.Location.X, 202),
                Text =
                    "S.C. ALTEX ROMANIA S.R.L. este inregistrata cu numarul 600 / 2006 in registrul de evidenta a prelucrarilor de date cu caracter personal"
            };

            foreach (Control ctr in this.Controls)
            {
                if (ctr is IconPictureBox pct)
                {
                    pct.MouseEnter += PctSocial_MouseEnter;
                    pct.MouseLeave += PctSocial_MouseLeave;
                    pct.Click += PctSocial_Click;
                }
            }
        }

        private void PctSocial_Click(object sender, EventArgs e)
        {
            switch (((IconPictureBox)sender).IconChar)
            {
                case IconChar.FacebookSquare:
                    OpenLink(@"https://www.facebook.com/AltexRomania");
                    break;
                case IconChar.TwitterSquare:
                    OpenLink(@"https://twitter.com/altexro");
                    break;
                case IconChar.Linkedin:
                    OpenLink(@"https://ro.linkedin.com/company/altex-romania");
                    break;
                case IconChar.YoutubeSquare:
                    OpenLink(@"https://www.youtube.com/user/AltexRomania");
                    break;
            }
        }

        private void OpenLink(string link)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = link,
                UseShellExecute = true
            });
        }

        private void PctSocial_MouseLeave(object sender, EventArgs e)
        {
            
            ((IconPictureBox)sender).IconColor = Color.FromArgb(128, 129, 133);
            
        }

        private void PctSocial_MouseEnter(object sender, EventArgs e)
        {

            ((IconPictureBox)sender).IconColor = Color.FromArgb(245, 203, 56);

        }

        private void Clone(IconPictureBox source, out IconPictureBox dest)
        {
            dest = new IconPictureBox
            {
                Parent = source.Parent,
                Location = new Point(source.Location.X + 38, source.Location.Y),
                Size = new Size(source.Width, source.Height),
                IconSize = source.IconSize,
                IconChar = source.IconChar,
                IconFont = source.IconFont,
                IconColor = source.IconColor,
                Cursor = source.Cursor
            };
        }

    }
}
