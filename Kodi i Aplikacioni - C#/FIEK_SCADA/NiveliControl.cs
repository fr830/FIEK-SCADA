using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace FIEK_SCADA
{
    public partial class NiveliControl : UserControl
    {
        public NiveliControl()
        {
            InitializeComponent();
            this.ForeColor = SystemColors.Highlight;
        }

        protected float percent = 0.0f;

        public float Value
        {
            get
            {
                return percent;
            }
            set
            {                
                if (value < 0)
                    value = 0;
                else if (value > 100)
                    value = 100;

                percent = value;
                
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Brush b = new SolidBrush(this.ForeColor);
           
            LinearGradientBrush lb = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height), Color.FromArgb(255, Color.White), Color.FromArgb(50, Color.White), LinearGradientMode.Vertical);

            // Vizato Vertikaisht nga Posht kah Lart
            int height = (int)((percent / 100) * this.Height);
            e.Graphics.FillRectangle(b, 0, this.Height - height, this.Width, height);
            e.Graphics.FillRectangle(lb, 0, this.Height - height, this.Width, height);

            /* -----------------------------  RASTE TJERA  ------------------------------------*/

            /*      // Vizato Vertikaisht nga Lart kah Posht     
                    int height = (int)((percent / 100) * this.Height);  
                    e.Graphics.FillRectangle(b, 0, 0, this.Width, height);
                    e.Graphics.FillRectangle(lb, 0, 0, this.Width, height);    */

            /*      // Vizato Horizontalisht nga Majtas kah Djathtas     
                    int width = (int)((percent / 100) * this.Width);
                    e.Graphics.FillRectangle(b, 0, 0, width, this.Height);
                    e.Graphics.FillRectangle(lb, 0, 0, width, this.Height);*/

            /*      // Vizato Horizontalisht nga Djathtas kah Majtas
                    int width = (int)((percent / 100) * this.Width);
                    e.Graphics.FillRectangle(b, this.Width - width, 0, width, this.Height);
                    e.Graphics.FillRectangle(lb, this.Width - width, 0, width, this.Height);    */

            /* ---------------------------------------------------------------------------------*/

            b.Dispose();
            lb.Dispose();
        }
    }
}
