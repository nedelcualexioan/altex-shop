using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace altex
{
    public partial class FrmHome : Form
    {
        private KryptonPalette pallete;
        
        public FrmHome()
        {
            InitializeComponent();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }

        private void Initialize()
        {
            pallete = new KryptonPalette(this.components);

            pallete.ButtonSpecs.FormClose.Image = Image.FromFile(Application.StartupPath + @"\images\red.png");
            pallete.ButtonSpecs.FormMax.Image = Image.FromFile(Application.StartupPath + @"\images\yellow.png");

        }
    }
}
