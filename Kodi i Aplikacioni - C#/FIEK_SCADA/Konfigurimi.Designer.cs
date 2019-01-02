namespace FIEK_SCADA
{
    partial class Konfigurimi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Konfigurimi));
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblNiveli = new System.Windows.Forms.Label();
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.lblDistancaMax = new System.Windows.Forms.Label();
            this.groupBoxKomunikim = new System.Windows.Forms.GroupBox();
            this.btnKonekto = new System.Windows.Forms.Button();
            this.btnDiskonekto = new System.Windows.Forms.Button();
            this.groupBoxVlerat = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maskTxtTemperatura = new System.Windows.Forms.MaskedTextBox();
            this.maskTxtNiveli = new System.Windows.Forms.MaskedTextBox();
            this.maskTxtDmax = new System.Windows.Forms.MaskedTextBox();
            this.btnShkruaj = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBoxKomunikim.SuspendLayout();
            this.groupBoxVlerat.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPort
            // 
            this.cbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(183, 24);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(127, 23);
            this.cbPort.TabIndex = 0;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(6, 30);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(41, 15);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Porti:";
            // 
            // lblNiveli
            // 
            this.lblNiveli.AutoSize = true;
            this.lblNiveli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNiveli.Location = new System.Drawing.Point(6, 59);
            this.lblNiveli.Name = "lblNiveli";
            this.lblNiveli.Size = new System.Drawing.Size(122, 15);
            this.lblNiveli.TabIndex = 1;
            this.lblNiveli.Text = "Niveli i Deshiruar:";
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperatura.Location = new System.Drawing.Point(5, 95);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(172, 15);
            this.lblTemperatura.TabIndex = 2;
            this.lblTemperatura.Text = "Temperatura e Deshiruar:\r\n";
            // 
            // lblDistancaMax
            // 
            this.lblDistancaMax.AutoSize = true;
            this.lblDistancaMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistancaMax.Location = new System.Drawing.Point(6, 23);
            this.lblDistancaMax.Name = "lblDistancaMax";
            this.lblDistancaMax.Size = new System.Drawing.Size(148, 15);
            this.lblDistancaMax.TabIndex = 0;
            this.lblDistancaMax.Text = "Distanca nga Sensori:";
            // 
            // groupBoxKomunikim
            // 
            this.groupBoxKomunikim.Controls.Add(this.cbPort);
            this.groupBoxKomunikim.Controls.Add(this.btnKonekto);
            this.groupBoxKomunikim.Controls.Add(this.btnDiskonekto);
            this.groupBoxKomunikim.Controls.Add(this.lblPort);
            this.groupBoxKomunikim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxKomunikim.Location = new System.Drawing.Point(12, 14);
            this.groupBoxKomunikim.Name = "groupBoxKomunikim";
            this.groupBoxKomunikim.Size = new System.Drawing.Size(340, 105);
            this.groupBoxKomunikim.TabIndex = 8;
            this.groupBoxKomunikim.TabStop = false;
            this.groupBoxKomunikim.Text = "Te Dhenat per Komunikim :";
            // 
            // btnKonekto
            // 
            this.btnKonekto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKonekto.Location = new System.Drawing.Point(27, 60);
            this.btnKonekto.Name = "btnKonekto";
            this.btnKonekto.Size = new System.Drawing.Size(127, 33);
            this.btnKonekto.TabIndex = 1;
            this.btnKonekto.Text = "Konekto";
            this.btnKonekto.UseVisualStyleBackColor = true;
            this.btnKonekto.Click += new System.EventHandler(this.btnKonekto_Click);
            // 
            // btnDiskonekto
            // 
            this.btnDiskonekto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiskonekto.Location = new System.Drawing.Point(183, 60);
            this.btnDiskonekto.Name = "btnDiskonekto";
            this.btnDiskonekto.Size = new System.Drawing.Size(127, 33);
            this.btnDiskonekto.TabIndex = 2;
            this.btnDiskonekto.Text = "Diskonekto";
            this.btnDiskonekto.UseVisualStyleBackColor = true;
            this.btnDiskonekto.Click += new System.EventHandler(this.btnDiskonekto_Click);
            // 
            // groupBoxVlerat
            // 
            this.groupBoxVlerat.Controls.Add(this.label1);
            this.groupBoxVlerat.Controls.Add(this.label2);
            this.groupBoxVlerat.Controls.Add(this.label3);
            this.groupBoxVlerat.Controls.Add(this.maskTxtTemperatura);
            this.groupBoxVlerat.Controls.Add(this.maskTxtNiveli);
            this.groupBoxVlerat.Controls.Add(this.maskTxtDmax);
            this.groupBoxVlerat.Controls.Add(this.btnShkruaj);
            this.groupBoxVlerat.Controls.Add(this.lblNiveli);
            this.groupBoxVlerat.Controls.Add(this.lblDistancaMax);
            this.groupBoxVlerat.Controls.Add(this.lblTemperatura);
            this.groupBoxVlerat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxVlerat.Location = new System.Drawing.Point(12, 136);
            this.groupBoxVlerat.Name = "groupBoxVlerat";
            this.groupBoxVlerat.Size = new System.Drawing.Size(340, 171);
            this.groupBoxVlerat.TabIndex = 9;
            this.groupBoxVlerat.TabStop = false;
            this.groupBoxVlerat.Text = "Te Dhenat per Vlerat :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "[cm]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "[cm]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "[°C]";
            // 
            // maskTxtTemperatura
            // 
            this.maskTxtTemperatura.Location = new System.Drawing.Point(183, 92);
            this.maskTxtTemperatura.Mask = "000.0 ";
            this.maskTxtTemperatura.Name = "maskTxtTemperatura";
            this.maskTxtTemperatura.Size = new System.Drawing.Size(116, 21);
            this.maskTxtTemperatura.TabIndex = 5;
            this.maskTxtTemperatura.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskTxtNoSpaceAllow_KeyDown);
            this.maskTxtTemperatura.MouseDown += new System.Windows.Forms.MouseEventHandler(this.maskTxtAnyPosCursor_MouseDown);
            // 
            // maskTxtNiveli
            // 
            this.maskTxtNiveli.Location = new System.Drawing.Point(183, 59);
            this.maskTxtNiveli.Mask = "00.0 ";
            this.maskTxtNiveli.Name = "maskTxtNiveli";
            this.maskTxtNiveli.Size = new System.Drawing.Size(115, 21);
            this.maskTxtNiveli.TabIndex = 4;
            this.maskTxtNiveli.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskTxtNoSpaceAllow_KeyDown);
            this.maskTxtNiveli.MouseDown += new System.Windows.Forms.MouseEventHandler(this.maskTxtAnyPosCursor_MouseDown);
            // 
            // maskTxtDmax
            // 
            this.maskTxtDmax.Location = new System.Drawing.Point(183, 23);
            this.maskTxtDmax.Mask = "99";
            this.maskTxtDmax.Name = "maskTxtDmax";
            this.maskTxtDmax.Size = new System.Drawing.Size(115, 21);
            this.maskTxtDmax.TabIndex = 3;
            this.maskTxtDmax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskTxtNoSpaceAllow_KeyDown);
            this.maskTxtDmax.MouseDown += new System.Windows.Forms.MouseEventHandler(this.maskTxtAnyPosCursor_MouseDown);
            // 
            // btnShkruaj
            // 
            this.btnShkruaj.Location = new System.Drawing.Point(183, 128);
            this.btnShkruaj.Name = "btnShkruaj";
            this.btnShkruaj.Size = new System.Drawing.Size(127, 33);
            this.btnShkruaj.TabIndex = 6;
            this.btnShkruaj.Text = "Shkruaj";
            this.btnShkruaj.UseVisualStyleBackColor = true;
            this.btnShkruaj.Click += new System.EventHandler(this.btnShkruaj_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 321);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(363, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(76, 17);
            this.toolStripStatusLabel1.Text = "Diskonektuar";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(185, 17);
            this.toolStripStatusLabel2.Text = "| Statusi i Software-it : I Panjoftur !";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Konfigurimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 343);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBoxVlerat);
            this.Controls.Add(this.groupBoxKomunikim);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Konfigurimi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Konektim dhe Konfigurim";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Konfigurimi_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Konfigurimi_FormClosing);
            this.groupBoxKomunikim.ResumeLayout(false);
            this.groupBoxKomunikim.PerformLayout();
            this.groupBoxVlerat.ResumeLayout(false);
            this.groupBoxVlerat.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblNiveli;
        private System.Windows.Forms.Label lblTemperatura;
        private System.Windows.Forms.Label lblDistancaMax;
        private System.Windows.Forms.GroupBox groupBoxKomunikim;
        private System.Windows.Forms.GroupBox groupBoxVlerat;
        private System.Windows.Forms.Button btnKonekto;
        private System.Windows.Forms.Button btnDiskonekto;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnShkruaj;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MaskedTextBox maskTxtNiveli;
        private System.Windows.Forms.MaskedTextBox maskTxtDmax;
        private System.Windows.Forms.MaskedTextBox maskTxtTemperatura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}