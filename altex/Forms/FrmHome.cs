using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using altex.Panels;
using ComponentFactory.Krypton.Toolkit;
using online_shop.Services;

namespace altex.Forms
{
    public partial class FrmHome : KryptonForm
    {
        private KryptonPalette palette;

        private Home pnlHome;

        private Header pnlHeader;
        private Navbar pnlNavbar;

        private CategoryServices categoryDb;

        private ProductsServices productsDb;

        private ProductPage pnlProduct;

        private Panel pnlTest;

        private ProductsView pnlCategory;

        private int StartY
        {
            get => pnlNavbar.Location.Y + pnlNavbar.Height;
        }
        
        public FrmHome()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            this.MaximizeBox = false;

            this.components = new Container();

            Initialize();

            categoryDb = new CategoryServices();

            productsDb = new ProductsServices();

            pnlHeader = new Header(this);
            pnlNavbar = new Navbar(this, categoryDb.GetAll());

            pnlHeader.Location = new Point(0, 0);
            pnlNavbar.Location = new Point(0, pnlHeader.Height);

            // pnlHome = new Home(this, categoryDb, productsDb);

           /* pnlProduct = new ProductPage(this, categoryDb,
                productsDb.GetProduct(32), "Silver", StartY);

            pnlProduct.Show();

            pnlProduct.miniClick += PnlProduct_miniClick;*/

            pnlCategory = new ProductsView(this, "Telefoane", categoryDb, productsDb);

            pnlCategory.Show();
        }

        private void PnlProduct_miniClick(object sender, EventArgs e)
        {
            string path = ((PictureBox)sender).ImageLocation.Replace(@"\1.jpg", "");
            

            pnlProduct.ChangeColor(new DirectoryInfo(path).Name);
            
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }



        private void Initialize()
        {
            palette = new KryptonPalette(this.components);

            this.Palette = palette;

            palette.FormStyles.FormCommon.StateCommon.Back.Color1 = Color.FromArgb(250, 252, 252);
            palette.FormStyles.FormCommon.StateCommon.Back.Color2 = Color.FromArgb(250, 252, 252);

            palette.FormStyles.FormCommon.StateCommon.Border.Rounding = 12;
            palette.FormStyles.FormCommon.StateCommon.Border.GraphicsHint = PaletteGraphicsHint.None;

            palette.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 10;
            palette.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = Color.FromArgb(250, 252, 252);
            palette.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = Color.FromArgb(250, 252, 252);
            palette.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new Padding(10, -1, -1, -1);

            palette.ButtonSpecs.FormClose.Image = Image.FromFile(Application.StartupPath + @"\images\red.png");
            palette.ButtonSpecs.FormClose.ImageStates.ImageTracking = Image.FromFile(Application.StartupPath + @"\images\sign-error-icon.png");
            palette.ButtonSpecs.FormClose.ImageStates.ImagePressed = Image.FromFile(Application.StartupPath + @"\images\sign-error-icon.png");

            palette.ButtonSpecs.FormRestore.Image = Image.FromFile(Application.StartupPath + @"\images\yellow.png");

            palette.ButtonSpecs.FormMin.Image = Image.FromFile(Application.StartupPath + @"\images\green.png");
            palette.ButtonSpecs.FormMin.ImageStates.ImageTracking = Image.FromFile(Application.StartupPath + @"\images\green.png");
            palette.ButtonSpecs.FormMin.ImageStates.ImagePressed = Image.FromFile(Application.StartupPath + @"\images\green.png");


            palette.ButtonStyles.ButtonForm.StateNormal.Back.Color1 = Color.FromArgb(250, 252, 252);
            palette.ButtonStyles.ButtonForm.StateNormal.Back.Color2 = Color.FromArgb(250, 252, 252);
            palette.ButtonStyles.ButtonForm.StateNormal.Border.Width = 0;

            palette.ButtonStyles.ButtonForm.StatePressed.Back.Color1 = Color.FromArgb(250, 252, 252);
            palette.ButtonStyles.ButtonForm.StatePressed.Back.Color2 = Color.FromArgb(250, 252, 252);
            palette.ButtonStyles.ButtonForm.StatePressed.Border.Width = 0;

            palette.ButtonStyles.ButtonForm.StateTracking.Back.Color1 = Color.FromArgb(250, 252, 252);
            palette.ButtonStyles.ButtonForm.StateTracking.Back.Color2 = Color.FromArgb(250, 252, 252);
            palette.ButtonStyles.ButtonForm.StateTracking.Border.Width = 0;

            foreach (Control c in this.Controls)
            {
                c.Hide();
            }

            
        }
    }
}
