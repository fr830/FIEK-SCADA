namespace FIEK_SCADA
{
    partial class KonfirmoImazh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KonfirmoImazh));
            this.btnAborto = new System.Windows.Forms.Button();
            this.btnKonfirmo = new System.Windows.Forms.Button();
            this.pictureBoxKonfirmoImazh = new System.Windows.Forms.PictureBox();
            this.txtEmertoImazhin = new System.Windows.Forms.TextBox();
            this.lblEmertoImazhin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKonfirmoImazh)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAborto
            // 
            this.btnAborto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAborto.Location = new System.Drawing.Point(526, 368);
            this.btnAborto.Name = "btnAborto";
            this.btnAborto.Size = new System.Drawing.Size(153, 38);
            this.btnAborto.TabIndex = 4;
            this.btnAborto.Text = "Aborto";
            this.btnAborto.UseVisualStyleBackColor = true;
            this.btnAborto.Click += new System.EventHandler(this.myCloseClick);
            // 
            // btnKonfirmo
            // 
            this.btnKonfirmo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKonfirmo.Location = new System.Drawing.Point(331, 368);
            this.btnKonfirmo.Name = "btnKonfirmo";
            this.btnKonfirmo.Size = new System.Drawing.Size(153, 38);
            this.btnKonfirmo.TabIndex = 3;
            this.btnKonfirmo.Text = "Konfirmo Ruajtjen";
            this.btnKonfirmo.UseVisualStyleBackColor = true;
            this.btnKonfirmo.Click += new System.EventHandler(this.myCloseClick);
            // 
            // pictureBoxKonfirmoImazh
            // 
            this.pictureBoxKonfirmoImazh.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxKonfirmoImazh.Name = "pictureBoxKonfirmoImazh";
            this.pictureBoxKonfirmoImazh.Size = new System.Drawing.Size(1071, 300);
            this.pictureBoxKonfirmoImazh.TabIndex = 0;
            this.pictureBoxKonfirmoImazh.TabStop = false;
            // 
            // txtEmertoImazhin
            // 
            this.txtEmertoImazhin.Location = new System.Drawing.Point(491, 335);
            this.txtEmertoImazhin.Name = "txtEmertoImazhin";
            this.txtEmertoImazhin.Size = new System.Drawing.Size(169, 20);
            this.txtEmertoImazhin.TabIndex = 6;
            this.txtEmertoImazhin.TextChanged += new System.EventHandler(this.txtEmertoImazhin_TextChanged);
            this.txtEmertoImazhin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmertoImazhin_KeyPress);
            // 
            // lblEmertoImazhin
            // 
            this.lblEmertoImazhin.AutoSize = true;
            this.lblEmertoImazhin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmertoImazhin.Location = new System.Drawing.Point(363, 336);
            this.lblEmertoImazhin.Name = "lblEmertoImazhin";
            this.lblEmertoImazhin.Size = new System.Drawing.Size(112, 15);
            this.lblEmertoImazhin.TabIndex = 7;
            this.lblEmertoImazhin.Text = "Emerto Imazhin:";
            // 
            // KonfirmoImazh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 423);
            this.Controls.Add(this.lblEmertoImazhin);
            this.Controls.Add(this.txtEmertoImazhin);
            this.Controls.Add(this.btnAborto);
            this.Controls.Add(this.btnKonfirmo);
            this.Controls.Add(this.pictureBoxKonfirmoImazh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KonfirmoImazh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Konfirmo Ruajtjen e Imazhit";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.KonfirmoImazh_HelpButtonClicked);
            this.Load += new System.EventHandler(this.KonfirmoImazh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKonfirmoImazh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxKonfirmoImazh;
        private System.Windows.Forms.Button btnAborto;
        private System.Windows.Forms.Button btnKonfirmo;
        private System.Windows.Forms.TextBox txtEmertoImazhin;
        private System.Windows.Forms.Label lblEmertoImazhin;
    }
}