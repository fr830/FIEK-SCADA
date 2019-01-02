namespace FIEK_SCADA
{
    partial class Inqizo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inqizo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStopVideo = new System.Windows.Forms.Button();
            this.btnRuajVideon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRuajVideo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFshijVideon = new System.Windows.Forms.Button();
            this.btnLuajVideon = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timerNiveli = new System.Windows.Forms.Timer(this.components);
            this.timerTemperatura = new System.Windows.Forms.Timer(this.components);
            this.timerBashke = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelRECORD_ANIMACION = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRECORD_TEXT = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnStatistik = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStopVideo);
            this.groupBox1.Controls.Add(this.btnRuajVideon);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRuajVideo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ruaj Videon";
            // 
            // btnStopVideo
            // 
            this.btnStopVideo.Location = new System.Drawing.Point(157, 53);
            this.btnStopVideo.Name = "btnStopVideo";
            this.btnStopVideo.Size = new System.Drawing.Size(118, 32);
            this.btnStopVideo.TabIndex = 3;
            this.btnStopVideo.Text = "Stop";
            this.btnStopVideo.UseVisualStyleBackColor = true;
            this.btnStopVideo.Click += new System.EventHandler(this.btnStopVideo_Click);
            // 
            // btnRuajVideon
            // 
            this.btnRuajVideon.Location = new System.Drawing.Point(18, 53);
            this.btnRuajVideon.Name = "btnRuajVideon";
            this.btnRuajVideon.Size = new System.Drawing.Size(118, 32);
            this.btnRuajVideon.TabIndex = 2;
            this.btnRuajVideon.Text = "Inqizo Videon";
            this.btnRuajVideon.UseVisualStyleBackColor = true;
            this.btnRuajVideon.Click += new System.EventHandler(this.btnRuajVideon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Emerto Videon:";
            // 
            // txtRuajVideo
            // 
            this.txtRuajVideo.Location = new System.Drawing.Point(124, 22);
            this.txtRuajVideo.Name = "txtRuajVideo";
            this.txtRuajVideo.Size = new System.Drawing.Size(151, 21);
            this.txtRuajVideo.TabIndex = 0;
            this.txtRuajVideo.TextChanged += new System.EventHandler(this.txtRuajVideo_TextChanged);
            this.txtRuajVideo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRuajVideo_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStatistik);
            this.groupBox2.Controls.Add(this.btnFshijVideon);
            this.groupBox2.Controls.Add(this.btnLuajVideon);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 241);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Luaj Videon";
            // 
            // btnFshijVideon
            // 
            this.btnFshijVideon.Location = new System.Drawing.Point(18, 158);
            this.btnFshijVideon.Name = "btnFshijVideon";
            this.btnFshijVideon.Size = new System.Drawing.Size(120, 34);
            this.btnFshijVideon.TabIndex = 4;
            this.btnFshijVideon.Text = "Fshij Videon";
            this.btnFshijVideon.UseVisualStyleBackColor = true;
            this.btnFshijVideon.Click += new System.EventHandler(this.btnFshijVideon_Click);
            // 
            // btnLuajVideon
            // 
            this.btnLuajVideon.Location = new System.Drawing.Point(155, 158);
            this.btnLuajVideon.Name = "btnLuajVideon";
            this.btnLuajVideon.Size = new System.Drawing.Size(120, 34);
            this.btnLuajVideon.TabIndex = 3;
            this.btnLuajVideon.Text = "Luaj Videon";
            this.btnLuajVideon.UseVisualStyleBackColor = true;
            this.btnLuajVideon.Click += new System.EventHandler(this.btnLuajVideon_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(18, 24);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(257, 124);
            this.listBox1.TabIndex = 0;
            // 
            // timerNiveli
            // 
            this.timerNiveli.Interval = 1000;
            this.timerNiveli.Tick += new System.EventHandler(this.timerNiveli_Tick);
            // 
            // timerTemperatura
            // 
            this.timerTemperatura.Interval = 1000;
            this.timerTemperatura.Tick += new System.EventHandler(this.timerTemperatura_Tick);
            // 
            // timerBashke
            // 
            this.timerBashke.Interval = 1000;
            this.timerBashke.Tick += new System.EventHandler(this.timerBashke_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelRECORD_ANIMACION,
            this.toolStripStatusLabelRECORD_TEXT});
            this.statusStrip1.Location = new System.Drawing.Point(0, 365);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(320, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelRECORD_ANIMACION
            // 
            this.toolStripStatusLabelRECORD_ANIMACION.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelRECORD_ANIMACION.BackgroundImage = global::FIEK_SCADA.Properties.Resources.RecordOFF;
            this.toolStripStatusLabelRECORD_ANIMACION.Name = "toolStripStatusLabelRECORD_ANIMACION";
            this.toolStripStatusLabelRECORD_ANIMACION.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabelRECORD_TEXT
            // 
            this.toolStripStatusLabelRECORD_TEXT.Name = "toolStripStatusLabelRECORD_TEXT";
            this.toolStripStatusLabelRECORD_TEXT.Size = new System.Drawing.Size(0, 17);
            // 
            // btnStatistik
            // 
            this.btnStatistik.Location = new System.Drawing.Point(18, 198);
            this.btnStatistik.Name = "btnStatistik";
            this.btnStatistik.Size = new System.Drawing.Size(257, 34);
            this.btnStatistik.TabIndex = 4;
            this.btnStatistik.Text = "Krijo Fajlin per te Dhena Statistikore";
            this.btnStatistik.UseVisualStyleBackColor = true;
            this.btnStatistik.Click += new System.EventHandler(this.btnStatistik_Click);
            // 
            // Inqizo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 387);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Inqizo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inqizo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Inqizo_FormClosing);
            this.Load += new System.EventHandler(this.Inqizo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRuajVideo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnRuajVideon;
        private System.Windows.Forms.Button btnLuajVideon;
        private System.Windows.Forms.Button btnStopVideo;
        private System.Windows.Forms.Timer timerNiveli;
        private System.Windows.Forms.Timer timerTemperatura;
        private System.Windows.Forms.Timer timerBashke;
        private System.Windows.Forms.Button btnFshijVideon;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRECORD_ANIMACION;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRECORD_TEXT;
        private System.Windows.Forms.Button btnStatistik;   
    }
}