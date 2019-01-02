using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIEK_SCADA
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#5E1F59");  
            this.TransparencyKey = this.BackColor;
            pictureBox1.Image = FIEK_SCADA.Properties.Resources.LoadingBarSplashScreen;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            label1.ForeColor = ColorTranslator.FromHtml("#691065");
        }

        int perqindja = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {   
            if(!(perqindja > 100))
            {
                label1.Text = perqindja.ToString() + "%";
                perqindja++;
            }            
        }
    }
}
