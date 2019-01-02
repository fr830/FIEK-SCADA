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
    public partial class KonfirmoImazh : Form
    {
        public KonfirmoImazh(Form1 ParentForm)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            form1 = ParentForm;

            btnAborto.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnKonfirmo.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnKonfirmo.Enabled = false;
        }

        #region "Deklarimet e Variablave"

        private Form1 form1;
        
        private string emriImazh;

        #endregion

        #region "KonfirmoImazh 'Get Set' Deklarimiet"

        public string EmriImazh
        {
            get { return emriImazh; }
            set { emriImazh = value; }
        }

        #endregion

        #region "Eventet dhe Funksionet"

        private void KonfirmoImazh_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Ne kete dritare ju mund ta shifeni ne teresi, imazhin qe pretendoni ta ruani. \nDuke i dhene ketij imazhi nje emer ju mund ta ruani ate ne databaze, per me shume kliko faqen 'Baza e te Dhenave', ku keni opcione si : \n- Ruajtja e imazhit ne disk. \n- Printimi i imazhit. \n- Ruajtja e te gjitha imazheve ne disk (si tabele). \n- Printimi i te gjithe tabeles. \n- Si dhe exportimi i te gjitha te dhenave ne 'Excel fajll'.", "Ndihme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void myCloseClick(object sender, EventArgs e)
        {
            emriImazh = txtEmertoImazhin.Text;        
            this.Dispose();
        }

        private void KonfirmoImazh_Load(object sender, EventArgs e)
        {
            pictureBoxKonfirmoImazh.Image = form1.Imazh;
            pictureBoxKonfirmoImazh.SizeMode = PictureBoxSizeMode.AutoSize;
            txtEmertoImazhin.Select();                      // Selecto txtEmertoImazhin ne fillim
        }

        private void txtEmertoImazhin_TextChanged(object sender, EventArgs e)
        {         
            if (txtEmertoImazhin.Text != "")
                btnKonfirmo.Enabled = true;
            else
                btnKonfirmo.Enabled = false;
        }

        private void txtEmertoImazhin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)                       // Nese eshte shtypur "Enter" performo shtypjen e btnKonfirmo                         
                btnKonfirmo.PerformClick();
        }

        #endregion        
    }
}
