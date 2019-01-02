using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Modbus.Utility;
using Modbus.Data;
using Modbus.Device;
using System.IO;
using System.IO.Ports;
using AquaControls;
using CMeterControl;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SQLite;
using System.Drawing.Imaging;
using Microsoft.Office.Interop.Excel;
using System.Threading;


namespace FIEK_SCADA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread SplashThread = new Thread(new ThreadStart(SplashScreen));
            SplashThread.Start();                     
            Thread.Sleep(3000);
            InitializeComponent();
            SplashThread.Abort();            
            //this.WindowState = FormWindowState.Maximized;           // Hape programin ne max state            
            this.FormBorderStyle = FormBorderStyle.FixedSingle;       // Mos e lejo rezise of form      
            Form_Konfigurimi = new Konfigurimi(this);      

            if (Form_Konfigurimi.IsPortiOpen)
            {
                timerGraphNiveli.Start();
                timerGraphTemperatura.Start();
                timerGraphBashke.Start();
            }

            initPics();
            initRadioButtons();
            initDatabase();
            InitGraphNiveli();
            InitGraphTemperatura();
            InitGraphBashke();
            AquaGaugeInit();

            toolStripStatusEMERGJENT_show.BackColor = Color.Transparent;
            toolStripStatusEMERGJENT_show.Image = FIEK_SCADA.Properties.Resources.RecordOFF;
            checkBoxNdalAudio.Checked = true;
        }

        #region "Deklarimet e Variablave"

        string usernamePC = Environment.UserName;             // E merr emrin e user-it qe po e perdore qfardo qofte kompjuteri qe ka Windows 
      
        KonfirmoImazh Form_KonfirmoImazh;
        Konfigurimi Form_Konfigurimi;
        Inqizo Form_Inqizo_Niveli, Form_Inqizo_Temperatura, Form_Inqizo_Bashke;        
        ErrorProvider errorInfo = new ErrorProvider();
        SQLiteConnection cn = new SQLiteConnection("Data Source=SQLiteDb.sqlite; Version=3");
        SQLiteCommand cmd = new SQLiteCommand();
        SQLiteDataAdapter da;
        SQLiteDataReader dr;
        System.Data.DataTable dt;
        MemoryStream ms;
        Bitmap dataToImage;
        string query;
        string rowNum = "0";
        int eRow;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(FIEK_SCADA.Properties.Resources.Alarm);
        private System.Windows.Forms.AGaugeLabel gLabel2;       
        bool isRadioTrue = false;
        bool isFinishedPlaying = true;
        bool isPlayingN = false;
        bool isPlayingT = false;
        bool isFocused = false;
        bool isVentilli = false;
        bool isTimer = false;
        bool isInsideVentillTimer = false;
        bool isInsideNxemjaTimer = false;
        int NrZoomNiveli = 0;
        int NrZoomTemperatura = 0;
        int NrZoomBashke = 0;
        int Nsec = 0;
        int Tsec = 0;
        int Bsec = 0;

        #endregion

        #region "From1 'Get Set' Deklarimiet"

        private Image imazh;
        private bool isPortTrue = false; 
        private bool kontrolla_PC_START_P3_7 = false;
        private bool kontrolla_PC_STOP_P3_5 = false;
        private bool kontrolla_PINI_EMERGJENT_BIT = false;
        private string videoSender;
        private string kohaVideo;
        private string vleraVideoNiveli;
        private string vleraVideoTemperatura;
        private string vleraVideoBashke;
        private bool kontrolla_E_Video_Grafeve = false;
        

        public Image Imazh
        {
            get { return imazh; }
            set { imazh = value; }
        }        

        public bool Kontrolla_PC_START_P3_7
        {
            get { return kontrolla_PC_START_P3_7; }
            set { kontrolla_PC_START_P3_7 = value; }
        }

        public bool Kontrolla_PC_STOP_P3_5
        {
            get { return kontrolla_PC_STOP_P3_5; }
            set { kontrolla_PC_STOP_P3_5 = value; }
        }

        public bool Kontrolla_PINI_EMERGJENT_BIT
        {
            get { return kontrolla_PINI_EMERGJENT_BIT; }
            set { kontrolla_PINI_EMERGJENT_BIT = value; }
        }
        
        public bool IsPortTrue
        {
            get { return isPortTrue; }
            set { isPortTrue = value; }
        }

        public string VideoSender
        {
            get { return videoSender; }
            set { videoSender = value; }
        }

        public string KohaVideo
        {
            get { return kohaVideo; }
            set { kohaVideo = value; }      
        }

        public string VleraVideoNiveli
        {
            get { return vleraVideoNiveli; }
            set { vleraVideoNiveli = value; }      
        }

        public string VleraVideoTemperatura
        {
            get { return vleraVideoTemperatura; }
            set { vleraVideoTemperatura = value; }     
        }

        public string VleraVideoBashke
        {
            get { return vleraVideoBashke; }
            set { vleraVideoBashke = value; }     
        }

        public bool Kontrolla_E_Video_Grafeve
        {
            get { return kontrolla_E_Video_Grafeve; }
            set { kontrolla_E_Video_Grafeve = value; }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {            
            RefreshViewFunction();       // kjo metode eshte e mire kur kemi shume imazhe ne databaze dhe programi i ben load ne prapaskene
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form_Konfigurimi.IsPortiOpen = false;                  
            this.Dispose();
        }
        
        private void SplashScreen()
        {
            System.Windows.Forms.Application.Run(new SplashScreen());
        }
        
        #region "Monitorimi dhe Kontrolla"

        private void initPics()
        { 
            pictureBoxKazaniMadhe.Image = FIEK_SCADA.Properties.Resources.Kazani_i_Madhe1;
            pictureBoxKazaniVogel.Image = FIEK_SCADA.Properties.Resources.Kazani_i_Vogel;
            pictureBoxPipeVogel.Image = FIEK_SCADA.Properties.Resources.PipeIVogelOFF;
            PictureBoxTransperancyFunction(pictureBoxKazaniMadhe, pictureBoxPipeVogel, 239, 213);        
            pictureBoxPompa.Image = FIEK_SCADA.Properties.Resources.PompaOFF;
            PictureBoxTransperancyFunction(pictureBoxKazaniVogel, pictureBoxPompa, 225, 14);
            pictureBoxPipeMadheLart.Image = FIEK_SCADA.Properties.Resources.pipeLOFF;
            pictureBoxPipeMadhePoshte.Image = FIEK_SCADA.Properties.Resources.pipePOFF;
            pictureBoxVentilli.Image = FIEK_SCADA.Properties.Resources.VentiliOFF;
            PictureBoxTransperancyFunction(pictureBoxPipeVogel, pictureBoxVentilli, 75, 6);
            pictureBoxNxemjaCoil.Image = FIEK_SCADA.Properties.Resources.NxemjaTOFF;
            pictureBoxNxemjaCoil.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxTransperancyFunction(pictureBoxKazaniMadhe, pictureBoxNxemjaCoil, 0, 200);
            pictureBoxNxemjaKablla.Image = FIEK_SCADA.Properties.Resources.NxemjaKOFF;
            pictureBoxNxemjaKablla.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxPipeTemp.Image = FIEK_SCADA.Properties.Resources.pipeTemp;
            pictureBoxPipeTemp.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxTransperancyFunction(pictureBoxKazaniMadhe, pictureBoxPipeTemp, 23, 75);
            pictureBoxBarometer.Image = FIEK_SCADA.Properties.Resources.barometer;
            pictureBoxBarometer.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxBarometerPipeZhgjatja.Image = FIEK_SCADA.Properties.Resources.barometerPipeZhgjatja;
            pictureBoxBarometerPipeZhgjatja.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxBarometer.BackColor = Color.Transparent;
            pictureBoxBarometer.Parent = aGauge1;
            pictureBoxBarometer.Location = new System.Drawing.Point(0, 0);
            pictureBoxBarometerMadhe.Image = FIEK_SCADA.Properties.Resources.barometer;
            pictureBoxBarometerMadhe.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxBarometerMadhe.BackColor = Color.Transparent;
            pictureBoxBarometerMadhe.Parent = aGauge2;
            pictureBoxBarometerMadhe.Location = new System.Drawing.Point(0, 0);
            pictureBoxSTART.Image = FIEK_SCADA.Properties.Resources.START;
            pictureBoxSTART.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSTOP.Image = FIEK_SCADA.Properties.Resources.STOP;
            pictureBoxSTOP.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxSettings.Image = FIEK_SCADA.Properties.Resources.settings;
            pictureBoxSettings.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxEmergjence.Image = FIEK_SCADA.Properties.Resources.emergency_button_leshuar;
            pictureBoxEmergjence.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCheckNiveli.Image = FIEK_SCADA.Properties.Resources.checkOFF;
            pictureBoxCheckNiveli.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxCheckTemperatura.Image = FIEK_SCADA.Properties.Resources.checkOFF;
            pictureBoxCheckTemperatura.SizeMode = PictureBoxSizeMode.StretchImage;
        }        

        private void PictureBoxTransperancyFunction(PictureBox picBox1, PictureBox picBox2, int x,int y)
        {             
            picBox2.BackColor = Color.Transparent;
            picBox2.Parent = picBox1;
            picBox2.Location = new System.Drawing.Point(x, y);
        }

        private void pictureBoxSTART_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Form_Konfigurimi.Gjendja_M_K)                   // clr = Monitorim dhe Kontroller, setb = Vetum Monitorim
            {
                pictureBoxSTART.Image = FIEK_SCADA.Properties.Resources.START_Shtypur;
                pictureBoxSTART.SizeMode = PictureBoxSizeMode.StretchImage;

                // Kode here ...
                if (Form_Konfigurimi.IsPortiOpen)
                {
                    kontrolla_PC_START_P3_7 = true;
                }
                else
                {
                    DialogResult res = MessageBox.Show("Ju Lutem Zgjedhni Portin per Komunikim !", "Njoftim", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (res == System.Windows.Forms.DialogResult.OK)
                        pictureBoxSettings_MouseUp(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Nuk keni Qasje ne Kontrolle ne Modin e Monitorimit !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBoxSTOP_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Form_Konfigurimi.Gjendja_M_K)                   // clr = Monitorim dhe Kontroller, setb = Vetum Monitorim
            {
                pictureBoxSTOP.Image = FIEK_SCADA.Properties.Resources.STOP_Shtypur;
                pictureBoxSTOP.SizeMode = PictureBoxSizeMode.StretchImage;

                // Kode here ...
                if (Form_Konfigurimi.IsPortiOpen)
                {
                    kontrolla_PC_STOP_P3_5 = true;
                }            
            }
            else
            {
                MessageBox.Show("Nuk keni Qasje ne Kontrolle ne Modin e Monitorimit !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        private void pictureBoxEmergjence_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Form_Konfigurimi.Gjendja_M_K)                   // clr = Monitorim dhe Kontroller, setb = Vetum Monitorim
            {
                pictureBoxEmergjence.Image = FIEK_SCADA.Properties.Resources.emergency_button_shtypur;
                pictureBoxEmergjence.SizeMode = PictureBoxSizeMode.StretchImage;

                // Kode here ...
                if (Form_Konfigurimi.IsPortiOpen)
                {
                    kontrolla_PC_STOP_P3_5 = true;

                    if (!Form_Konfigurimi.Gjendja_EMERGJENT_MODE)
                        kontrolla_PINI_EMERGJENT_BIT = true;
                    else
                        kontrolla_PINI_EMERGJENT_BIT = false;
                }
            }
            else
            {
                MessageBox.Show("Nuk keni Qasje ne Kontrolle ne Modin e Monitorimit !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBoxSTART_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxSTART.Image = FIEK_SCADA.Properties.Resources.START;                   
        }

        private void pictureBoxSTOP_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxSTOP.Image = FIEK_SCADA.Properties.Resources.STOP;            
        }

        private void pictureBoxEmergjence_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxEmergjence.Image = FIEK_SCADA.Properties.Resources.emergency_button_leshuar;
        }

        private void pictureBoxSettings_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxSettings.Image = FIEK_SCADA.Properties.Resources.settings_Duke_Shtypur;
            pictureBoxSettings.Image = FIEK_SCADA.Properties.Resources.settings_Shtypur;

            // Kode here ...
        }

        private void pictureBoxSettings_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxSettings.Image = FIEK_SCADA.Properties.Resources.settings_Duke_Leshuar;
            pictureBoxSettings.Image = FIEK_SCADA.Properties.Resources.settings;
            
            if(!isPortTrue)
            {
                Form_Konfigurimi = new Konfigurimi(this);
                Form_Konfigurimi.Owner = this;
                //if (Form_Konfigurimi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //MessageBox.Show("ok");
                Form_Konfigurimi.Show();
            }
            else
            {
                Form_Konfigurimi.Show();
            }            
        }

        private void timerEMERGJENT_Tick(object sender, EventArgs e)
        {
            if(Form_Konfigurimi.IsPortiOpen && Form_Konfigurimi.Gjendja_GRAPH_PC)
            {
                if (Form_Konfigurimi.Gjendja_EMERGJENT_MODE)
                {
                    toolStripStatusLabelEMERGJENT.Text = "| Modi Emergjent : ON";
                    toolStripStatusEMERGJENT_show.Image = FIEK_SCADA.Properties.Resources.RecordAnimacion;
                }
                else
                {
                    toolStripStatusLabelEMERGJENT.Text = "| Modi Emergjent : OFF";
                    toolStripStatusEMERGJENT_show.Image = FIEK_SCADA.Properties.Resources.RecordOFF;
                }
            }
            else
            {
                toolStripStatusLabelEMERGJENT.Text = "| Modi Emergjent : I Panjoftur !";
                toolStripStatusEMERGJENT_show.Image = FIEK_SCADA.Properties.Resources.RecordOFF;
            }
        }

        private void timerNxemjaAnimacion_Tick(object sender, EventArgs e)
        {
            timerNxemjaAnimacion.Stop();
            pictureBoxNxemjaCoil.Image = FIEK_SCADA.Properties.Resources.NxemjaTON;            
        }

        private void timerVentilliAnimacion_Tick(object sender, EventArgs e)
        {
            timerVentilliAnimacion.Stop();

            if (isVentilli)
                pictureBoxVentilli.Image = FIEK_SCADA.Properties.Resources.VentiliON;
            else
                pictureBoxVentilli.Image = FIEK_SCADA.Properties.Resources.VentiliOFF;
        }

        private void timerSCADA_Tick(object sender, EventArgs e)
        {
            isPortTrue = Form_Konfigurimi.IsPortiOpen;           
            
            if (!Form_Konfigurimi.IsPortiOpen)                          // Sigurohem qe porti eshte i hapur, vazhdojme me kushtet tjera
            {
                initPics();               
           
                toolStripStatusLabel1.Text = "Diskonektuar";
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusM_K.Text = "| Statusi i Software-it : I Panjoftur !";
                toolStripStatusLabelEMERGJENT.Text = "| Modi Emergjent : I Panjoftur !";
                toolStripStatusEMERGJENT_show.Image = FIEK_SCADA.Properties.Resources.RecordOFF;
                lblNiveliDeshiruar.Text = "00.0 [cm]";
                lblTemperaturaDeshiruar.Text = "000.0 [°C]";                
            }                
            else
            {               
                toolStripStatusLabel1.Text = "Konektuar";
                toolStripStatusLabel1.ForeColor = Color.Green;

                if(Form_Konfigurimi.Gjendja_GRAPH_PC)
                {
                    lblNiveliDeshiruar.Text = Form_Konfigurimi.Niveli_SetPoint + " [cm]";
                    lblTemperaturaDeshiruar.Text = Form_Konfigurimi.Temperatura_SetPoint + " [°C]";
                }                

                if (Form_Konfigurimi.Gjendja_M_K)           // Monitorim
                {
                    pictureBoxSTART.Image = FIEK_SCADA.Properties.Resources.START_OFF;
                    pictureBoxSTOP.Image = FIEK_SCADA.Properties.Resources.STOP_OFF;
                    pictureBoxEmergjence.Image = FIEK_SCADA.Properties.Resources.emergency_button_OFF;
                    toolStripStatusM_K.Text = "| Statusi i Software-it : Monitorim";                    
                }
                else                                        // Monitorim dhe Kontrolle
                {
                    pictureBoxSTART.Image = FIEK_SCADA.Properties.Resources.START;
                    pictureBoxSTOP.Image = FIEK_SCADA.Properties.Resources.STOP;
                    pictureBoxEmergjence.Image = FIEK_SCADA.Properties.Resources.emergency_button_leshuar;
                    toolStripStatusM_K.Text = "| Statusi i Software-it : Monitorim dhe Kontrollim";  
                }
                   
                // ------------------------------- Ventilli para se me i dhene vlerat -------------------------------------------------------
                if (!Form_Konfigurimi.Gjendja_GRAPH_PC)
                {
                    pictureBoxVentilli.Image = FIEK_SCADA.Properties.Resources.VentiliON;
                    pictureBoxPipeVogel.Image = FIEK_SCADA.Properties.Resources.PipeIVogel_Animation;
                }                    
                // ------------------------------- Kontrolla e Monitorimit te elementeve te SCADAs ------------------------------------------
                else
                {
                    if (!Form_Konfigurimi.Niveli_Arritur && Form_Konfigurimi.Gjendja_Q4_PLC)            // Nese nuk u arrit niveli, dhe Gjendja_Q4_PLC eshte setb (STOP), atehere dihet se jemi ne pritje dhe pompa eshte joaktive
                    {
                        if (!Form_Konfigurimi.Gjendja_M_K)                   // Monitorim dhe Kontrolle
                        {
                            initPics();             // Qdo gje e fikur                                                      
                        }                            
                        else                                                 // Monitorim
                        {
                            initPics();             // Qdo gje e fikur                          
                            pictureBoxSTART.Image = FIEK_SCADA.Properties.Resources.START_OFF;
                            pictureBoxSTOP.Image = FIEK_SCADA.Properties.Resources.STOP_OFF;
                            pictureBoxEmergjence.Image = FIEK_SCADA.Properties.Resources.emergency_button_OFF;                            
                        }                                                              
                    }
                    else if (!Form_Konfigurimi.Niveli_Arritur && !Form_Konfigurimi.Gjendja_Q4_PLC)       // Nese nuk u arrit niveli, dhe Gjendja_Q4_PLC eshte clr (START), atehere dihet se jemi ne mbushje dhe pompa eshte aktive
                    {
                        pictureBoxPompa.Image = FIEK_SCADA.Properties.Resources.Pompa_Animation;
                        pictureBoxPipeMadheLart.Image = FIEK_SCADA.Properties.Resources.pipeL_Animation;
                        pictureBoxPipeMadhePoshte.Image = FIEK_SCADA.Properties.Resources.pipeP_Animation;

                        pictureBoxPipeVogel.Image = FIEK_SCADA.Properties.Resources.PipeIVogelOFF;
                        pictureBoxNxemjaKablla.Image = FIEK_SCADA.Properties.Resources.NxemjaKOFF;
                        pictureBoxNxemjaCoil.Image = FIEK_SCADA.Properties.Resources.NxemjaTOFF;

                        if (!isInsideVentillTimer)       // Nese nuk eshte duke u egzekutue timerVentilliAnimacion hyn mbrenda
                        {
                            pictureBoxVentilli.Image = FIEK_SCADA.Properties.Resources.VentiliMbyllet_Animation;
                            isVentilli = false;
                            isInsideVentillTimer = true;
                            timerVentilliAnimacion.Start();
                        }                  
                        isInsideNxemjaTimer = false;
                    }
                    else if (Form_Konfigurimi.Niveli_Arritur && !Form_Konfigurimi.Temperatura_Arritur && !Form_Konfigurimi.Gjendja_Q4_PLC)        // Nese u arrit niveli, dhe Gjendja_Q4_PLC eshte clr (START), atehere dihet se jemi ne nxemje dhe pompa eshte joaktive
                    {
                        pictureBoxPompa.Image = FIEK_SCADA.Properties.Resources.PompaOFF;
                        pictureBoxPipeMadheLart.Image = FIEK_SCADA.Properties.Resources.pipeLOFF;
                        pictureBoxPipeMadhePoshte.Image = FIEK_SCADA.Properties.Resources.pipePOFF;                                               
              
                        if (!isInsideNxemjaTimer)
                        {
                            pictureBoxVentilli.Image = FIEK_SCADA.Properties.Resources.VentiliOFF; 
                            pictureBoxNxemjaKablla.Image = FIEK_SCADA.Properties.Resources.NxemjaK_Animation;
                            pictureBoxNxemjaCoil.Image = FIEK_SCADA.Properties.Resources.NxemjaT_Animation;
                            isInsideNxemjaTimer = true;
                            timerNxemjaAnimacion.Start();
                        }                  
                    }
                    else if (Form_Konfigurimi.Niveli_Arritur && Form_Konfigurimi.Temperatura_Arritur && !Form_Konfigurimi.Gjendja_Q4_PLC)        // Nese u arrit niveli, dhe Gjendja_Q4_PLC eshte clr (START) dhe u arrit temperatura, atehere dihet se kemi kryer nxemje dhe po shprazet kofja dhe pompa eshte joaktive
                    {
                        pictureBoxNxemjaKablla.Image = FIEK_SCADA.Properties.Resources.NxemjaKOFF;
                        pictureBoxNxemjaCoil.Image = FIEK_SCADA.Properties.Resources.NxemjaTOFF;

                        pictureBoxPipeVogel.Image = FIEK_SCADA.Properties.Resources.PipeIVogel_Animation;
                        pictureBoxPipeMadheLart.Image = FIEK_SCADA.Properties.Resources.pipeLOFF;
                        pictureBoxPipeMadhePoshte.Image = FIEK_SCADA.Properties.Resources.pipePOFF;
                        pictureBoxPompa.Image = FIEK_SCADA.Properties.Resources.PompaOFF;
         
                        if (isInsideVentillTimer)
                        {
                            pictureBoxVentilli.Image = FIEK_SCADA.Properties.Resources.VentilliHapet_Animation;
                            isVentilli = true;
                            isInsideVentillTimer = false;
                            timerVentilliAnimacion.Start();                            
                        }                    
                        isInsideNxemjaTimer = true;
                    }
                    else if (Form_Konfigurimi.Niveli_Arritur && Form_Konfigurimi.Gjendja_Q4_PLC)                                            // Nese nga PLC kemi zero (dmth ne Pinin P2.2 kemi setb , STOP) atehre jemi ne pauze dhe te gjitha ndalen
                    {             
                        if (!Form_Konfigurimi.Gjendja_M_K)                   // Monitorim dhe Kontrolle
                        {
                            initPics();             // Qdo gje e fikur                                    
                        }                            
                        else                                                 // Monitorim
                        {
                            initPics();             // Qdo gje e fikur                                
                            pictureBoxSTART.Image = FIEK_SCADA.Properties.Resources.START_OFF;
                            pictureBoxSTOP.Image = FIEK_SCADA.Properties.Resources.STOP_OFF;
                            pictureBoxEmergjence.Image = FIEK_SCADA.Properties.Resources.emergency_button_OFF;                            
                        }

                        if(Form_Konfigurimi.Niveli_Arritur)
                            pictureBoxCheckNiveli.Image = FIEK_SCADA.Properties.Resources.checkON;   
                        if(Form_Konfigurimi.Temperatura_Arritur)                        
                            pictureBoxCheckTemperatura.Image = FIEK_SCADA.Properties.Resources.checkON;                         

                        isInsideNxemjaTimer = false;
                        isInsideVentillTimer = true;                 
                    }
                }
            }
        }        

        #region "Aqua Gauges"

        private void AquaGaugeInit()
        {
            aGauge1.MinValue = -55;
            aGauge1.MaxValue = 125;
            aGauge1.NeedleType = NeedleType.Advance;
            aGauge1.ScaleLinesMajorStepValue = 45;
            aGauge1.GaugeRanges.FindByName("GaugeRange1").StartValue = -55;
            aGauge1.GaugeRanges.FindByName("GaugeRange1").EndValue = 0;
            aGauge1.GaugeRanges.FindByName("GaugeRange2").StartValue = 0;
            aGauge1.GaugeRanges.FindByName("GaugeRange2").EndValue = 50;
            aGauge1.GaugeRanges.FindByName("GaugeRange3").StartValue = 50;
            aGauge1.GaugeRanges.FindByName("GaugeRange3").EndValue = 100;
            aGauge1.GaugeRanges.FindByName("GaugeRange4").StartValue = 100;
            aGauge1.GaugeRanges.FindByName("GaugeRange4").EndValue = 125;

            aGauge2.MinValue = -55;
            aGauge2.MaxValue = 125;
            aGauge2.NeedleType = NeedleType.Advance;
            aGauge2.ScaleLinesMajorStepValue = 15;
            aGauge2.GaugeRanges.FindByName("GaugeRange1").StartValue = -55;
            aGauge2.GaugeRanges.FindByName("GaugeRange1").EndValue = 0;
            aGauge2.GaugeRanges.FindByName("GaugeRange2").StartValue = 0;
            aGauge2.GaugeRanges.FindByName("GaugeRange2").EndValue = 50;
            aGauge2.GaugeRanges.FindByName("GaugeRange3").StartValue = 50;
            aGauge2.GaugeRanges.FindByName("GaugeRange3").EndValue = 100;
            aGauge2.GaugeRanges.FindByName("GaugeRange4").StartValue = 100;
            aGauge2.GaugeRanges.FindByName("GaugeRange4").EndValue = 125;

            gLabel2 = aGauge2.GaugeLabels.FindByName("GaugeLabel1");            
        }

        private void AquaGaugeControl()
        {
            if(Form_Konfigurimi.IsPortiOpen && Form_Konfigurimi.Gjendja_GRAPH_PC)
            {
                aGauge2.Value = float.Parse(Form_Konfigurimi.Temperatura);
                gLabel2.Text = aGauge2.Value.ToString("000.0") + "°C";// +"°C";
                aGauge1.Value = aGauge2.Value;
            }
            else
            {
                aGauge1.Value = 0;
                gLabel2.Text = aGauge1.Value.ToString("000.0") + "°C";// +"°C"; 
                aGauge2.Value = 0;
            }
        }

        private void NiveliControl()
        {
            if (Form_Konfigurimi.IsPortiOpen && Form_Konfigurimi.Gjendja_GRAPH_PC)
            {
                niveliControl1.Value = (100 / float.Parse(Form_Konfigurimi.DMax)) * float.Parse(Form_Konfigurimi.Niveli);
                niveliControl2.Value = 100 - niveliControl1.Value;
                axVMeter1.V_min = 0;
                axVMeter1.V_max = double.Parse(Form_Konfigurimi.DMax);
                axVMeter1.Vl = double.Parse(Form_Konfigurimi.Niveli);
            }
            else
            {
                niveliControl1.Value = 0;
                niveliControl2.Value = 100;
                axVMeter1.Vl = 00.0;
            }
        }
       
        private void timerAquaControl_Tick(object sender, EventArgs e)
        {                    
            AquaGaugeControl();
            NiveliControl();
            
            if(Form_Konfigurimi.IsPortiOpen)
            {
                if (Form_Konfigurimi.Niveli_Arritur && !isPlayingN && isFinishedPlaying && !checkBoxNdalAudio.Checked)
                {
                    player.Play();
                    isFinishedPlaying = false;
                    timerAquaAlarmControl.Start();
                }
                else if (!Form_Konfigurimi.Niveli_Arritur)
                    isPlayingN = false;

                if (Form_Konfigurimi.Temperatura_Arritur && !isPlayingT && isFinishedPlaying && !checkBoxNdalAudio.Checked)
                {
                    pictureBoxCheckTemperatura.Image = FIEK_SCADA.Properties.Resources.checkON;
                    player.Play();
                    isFinishedPlaying = false;
                    timerAquaAlarmControl.Start();
                }
                else if (!Form_Konfigurimi.Temperatura_Arritur)
                    isPlayingT = false;


                if (Form_Konfigurimi.Niveli_Arritur)
                    pictureBoxCheckNiveli.Image = FIEK_SCADA.Properties.Resources.checkON;  
                else
                    pictureBoxCheckNiveli.Image = FIEK_SCADA.Properties.Resources.checkOFF;         

                if (Form_Konfigurimi.Temperatura_Arritur)
                    pictureBoxCheckTemperatura.Image = FIEK_SCADA.Properties.Resources.checkON;
                else
                    pictureBoxCheckTemperatura.Image = FIEK_SCADA.Properties.Resources.checkOFF;
            }
            else
            {
                player.Stop();
                pictureBoxCheckNiveli.Image = FIEK_SCADA.Properties.Resources.checkOFF;
                pictureBoxCheckTemperatura.Image = FIEK_SCADA.Properties.Resources.checkOFF;
            }
        }

        private void timerAquaAlarmControl_Tick(object sender, EventArgs e)
        {
            if (Form_Konfigurimi.Niveli_Arritur && !isPlayingN && !checkBoxNdalAudio.Checked)
            {
                isPlayingN = true;
                player.Stop();
            }

            if (Form_Konfigurimi.Temperatura_Arritur && !isPlayingT && !checkBoxNdalAudio.Checked)
            {
                isPlayingT = true;
                player.Stop();                
            }           
     
            timerAquaAlarmControl.Stop();
            isFinishedPlaying = true;
        }

        #endregion

        #endregion

        #region "Grafet dhe Vlerat"

        private void initRadioButtons()
        {
            rBtnGrafet_Ndara.Checked = true;
            rBtnGrafi_Niveli.Checked = true;
        }

        private void InitGraphNiveli()
        {
            chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.Title = "Koha [s]";
            chartNiveli.ChartAreas["ChartAreaNiveli"].AxisY.Title = "Niveli [cm]";
            chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            chartNiveli.ChartAreas["ChartAreaNiveli"].AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold);

            chartNiveli.ChartAreas["ChartAreaNiveli"].AxisY.Interval = 10;

            chartNiveli.Series["Niveli [cm]"].Color = Color.Blue;
            chartNiveli.Series["Niveli [cm]"].ChartType = SeriesChartType.Spline;

            chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.ScaleView.Zoomable = true;
            chartNiveli.ChartAreas["ChartAreaNiveli"].AxisY.ScaleView.Zoomable = true;

            chartNiveli.ChartAreas["ChartAreaNiveli"].CursorX.IsUserEnabled = true;
            chartNiveli.ChartAreas["ChartAreaNiveli"].CursorX.IsUserSelectionEnabled = true;

            chartNiveli.ChartAreas["ChartAreaNiveli"].CursorY.IsUserEnabled = true;
            chartNiveli.ChartAreas["ChartAreaNiveli"].CursorY.IsUserSelectionEnabled = true;

            chartNiveli.ChartAreas["ChartAreaNiveli"].CursorX.AutoScroll = false;
            chartNiveli.ChartAreas["ChartAreaNiveli"].CursorY.AutoScroll = false;

            chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.ScrollBar.Enabled = true;
            chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.IsLabelAutoFit = true;

            chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.Interval = 10;
            chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.ScaleView.Size = 80;
        }

        private void InitGraphTemperatura()
        {
            chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.Title = "Koha [s]";
            chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisY.Title = "Temperatura [°C]";
            chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold);

            chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisY.Interval = 10;

            chartTemperatura.Series["Temperatura [ºC]"].Color = Color.Red;
            chartTemperatura.Series["Temperatura [ºC]"].ChartType = SeriesChartType.Spline;

            chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.ScaleView.Zoomable = true;
            chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisY.ScaleView.Zoomable = true;

            chartTemperatura.ChartAreas["ChartAreaTemperatura"].CursorX.IsUserEnabled = true;
            chartTemperatura.ChartAreas["ChartAreaTemperatura"].CursorX.IsUserSelectionEnabled = true;

            chartTemperatura.ChartAreas["ChartAreaTemperatura"].CursorY.IsUserEnabled = true;
            chartTemperatura.ChartAreas["ChartAreaTemperatura"].CursorY.IsUserSelectionEnabled = true;

            chartTemperatura.ChartAreas["ChartAreaTemperatura"].CursorX.AutoScroll = false;
            chartTemperatura.ChartAreas["ChartAreaTemperatura"].CursorY.AutoScroll = false;

            chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.ScrollBar.Enabled = true;
            chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.IsLabelAutoFit = true;

            chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.Interval = 10;
            chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.ScaleView.Size = 80;
        }

        private void InitGraphBashke()
        {
            chartBashke.ChartAreas["ChartArea1"].AxisX.Title = "Koha [s]";
            chartBashke.ChartAreas["ChartArea1"].AxisY.Title = "Temperatura [°C] \n Koha [cm]";
            chartBashke.ChartAreas["ChartArea1"].AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            chartBashke.ChartAreas["ChartArea1"].AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 11, FontStyle.Bold);

            chartBashke.ChartAreas["ChartArea1"].AxisY.Interval = 5;

            chartBashke.Series["Niveli [cm]"].Color = Color.Blue;
            chartBashke.Series["Niveli [cm]"].ChartType = SeriesChartType.Spline;

            chartBashke.Series["Temperatura [ºC]"].Color = Color.Red;
            chartBashke.Series["Temperatura [ºC]"].ChartType = SeriesChartType.Spline;

            chartBashke.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = true;
            chartBashke.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoomable = true;

            chartBashke.ChartAreas["ChartArea1"].CursorX.IsUserEnabled = true;
            chartBashke.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = true;

            chartBashke.ChartAreas["ChartArea1"].CursorY.IsUserEnabled = true;
            chartBashke.ChartAreas["ChartArea1"].CursorY.IsUserSelectionEnabled = true;

            chartBashke.ChartAreas["ChartArea1"].CursorX.AutoScroll = false;
            chartBashke.ChartAreas["ChartArea1"].CursorY.AutoScroll = false;

            chartBashke.ChartAreas["ChartArea1"].AxisX.ScrollBar.Enabled = true;
            chartBashke.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;

            chartBashke.ChartAreas["ChartArea1"].AxisX.Interval = 10;
            chartBashke.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = 80;
        }        

        private void radioButtonShfaq_CheckedChanged(object sender, EventArgs e)
        {
            if(rBtnGrafet_Ndara.Checked)
            {
                splitContainerGrafetDheVlerat_Grafet.Panel1Collapsed = false;
                splitContainerGrafetDheVlerat_Grafet.Panel2Collapsed = false;
                rBtnGrafi_Niveli.Enabled = true;
                rBtnGrafi_Temperatura.Enabled = true;
                
                chartNiveli.Visible = true;
                chartTemperatura.Visible = true;
                chartBashke.Visible = false;
            }

            if(rBtnGrafet_Perbashket.Checked)
            {
                splitContainerGrafetDheVlerat_Grafet.Panel1Collapsed = false;
                splitContainerGrafetDheVlerat_Grafet.Panel2Collapsed = true;
                rBtnGrafi_Niveli.Enabled = false;
                rBtnGrafi_Temperatura.Enabled = false;
                
                chartNiveli.Visible = false;
                chartTemperatura.Visible = false;
                chartBashke.Visible = true;
            }         
        }

        private void radioButtonKontrollo_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnGrafi_Niveli.Checked)
                isRadioTrue = true;
            if (rBtnGrafi_Temperatura.Checked)
                isRadioTrue = false;
        }
        
        private void myBtnClickEvent(object sender,EventArgs e)
        {
            System.Windows.Forms.Button myBtn = (System.Windows.Forms.Button)sender;

            if(splitContainerGrafetDheVlerat_Grafet.Panel2Collapsed)
            {
                #region "Grafet e Perbashkta Case"

                switch (myBtn.Name)
                {
                    case "btnNdalo": 
                        { 
                            timerGraphBashke.Enabled = false; 
                            timerBashkeVideo.Stop(); 
                        }
                        break;

                    case "btnVazhdo": 
                        { 
                            timerGraphBashke.Enabled = true; 
                            timerBashkeVideo.Start(); 
                        }
                        break;

                    case "btnZvarrit":
                        {
                            if(Form_Konfigurimi.IsPortiOpen)
                                chartBashke.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoom(0, Form_Konfigurimi.KohaReale);
                            else if (!Form_Konfigurimi.IsPortiOpen) { }
                                //chartBashke.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoom(0, Int32.Parse(Form_Inqizo_Bashke.TransmetoKohen[Bsec].ToString()));

                                chartBashke.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = 80;
                        }
                        break;

                    case "btnMbrapaNje":
                        {
                            chartBashke.ChartAreas["ChartArea1"].AxisX.ScaleView.ZoomReset(1);
                            chartBashke.ChartAreas["ChartArea1"].AxisY.ScaleView.ZoomReset(1);
                        }
                        break;

                    case "btnTersia":
                        {
                            chartBashke.ChartAreas["ChartArea1"].AxisX.ScaleView.ZoomReset(NrZoomNiveli);
                            chartBashke.ChartAreas["ChartArea1"].AxisY.ScaleView.ZoomReset(NrZoomNiveli);
                        }
                        break;

                    case "btnRuaj":
                        {
                            chartBashke.SaveImage(String.Format(@"C:\Users\{0}\AppData\Local\Temp\Imazhi i Perkohshum.png", usernamePC), ChartImageFormat.Png);                         // Ruaje foton perkohesisht ne kete lokacion

                            FileStream fs = new FileStream(String.Format(@"C:\Users\{0}\AppData\Local\Temp\Imazhi i Perkohshum.png", usernamePC), FileMode.Open, FileAccess.Read);      // Hape Streamin qe te lexohet ky imazh
                            imazh = Image.FromStream(fs);                                                                                                                               // Ruaje ne variablen "imazh" kete imazh te ruajtur ne lokacionin mesiperm                                                  
                            fs.Close();                                                                                                                                                 // Mbylle Streamin per ta fshire imazhin e perkohshem nga lokacioni i mesiperm

                            System.IO.File.Delete(String.Format(@"C:\Users\{0}\AppData\Local\Temp\Imazhi i Perkohshum.png", usernamePC));                                               // Fshije imazhin e perkohshum nga lokacioni i mesiperm

                            Form_KonfirmoImazh = new KonfirmoImazh(this);

                            if (Form_KonfirmoImazh.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                AddImageToDatabase(imazh);
                        }
                        break;

                    case "btnVideo":
                        {
                            videoSender = "Bashke";
                            Form_Inqizo_Bashke = new Inqizo(this);

                            if (Form_Konfigurimi.IsPortiOpen)
                            {                                     
                                // --------------------------- Kontrolla e Videos ---------------------------
                                if (Form_Konfigurimi.Gjendja_GRAPH_PC)   // Nese porti eshte i hapur dhe gjendja_GRAPH_PC eshte setb atehere beje kontrolla_E_Video_Grafeve = 1; pasi 1 AND 1 = 1                                            
                                    kontrolla_E_Video_Grafeve = true;                                                                
                                // --------------------------------------------------------------------------   

                                kohaVideo = Form_Konfigurimi.KohaReale.ToString();          // Merre kohen e vertete nga microkontrolleri dhe dergoje permes kohaVideo te Inqizo form (atje pastaj ruhet)
                                vleraVideoBashke = String.Format("{0}|{1}", Form_Konfigurimi.Niveli, Form_Konfigurimi.Temperatura);
                                Form_Inqizo_Bashke.Show();
                            }                                                 
                            else
                            {
                                kontrolla_E_Video_Grafeve = false;

                                if (Form_Inqizo_Bashke.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    if (Form_Inqizo_Bashke.CiliGrafVideo == 1)
                                    {
                                        chartNiveli.Series["Niveli [cm]"].Points.Clear();                             
                                        InitGraphNiveli();
                                        timerNiveliVideo.Start();
                                    }
                                    else if (Form_Inqizo_Bashke.CiliGrafVideo == 2)
                                    {                                      
                                        chartTemperatura.Series["Temperatura [ºC]"].Points.Clear();
                                        InitGraphTemperatura();
                                        timerTemperaturaVideo.Start();
                                    }

                                    else if (Form_Inqizo_Bashke.CiliGrafVideo == 3)
                                    {
                                        chartNiveli.Series["Niveli [cm]"].Points.Clear();
                                        chartTemperatura.Series["Temperatura [ºC]"].Points.Clear();
                                        InitGraphBashke();
                                        timerBashkeVideo.Start();
                                    }
                                }                            
                            }                             
                        }
                        break;

                    default:
                        break;
                }

                #endregion
            }
            else
            {
                #region "Grafet e Ndara Case"

                if (isRadioTrue)
                {
                    #region "Grafet e Ndara - Niveli Case"

                    switch (myBtn.Name)
                    {
                        case "btnNdalo": 
                            { 
                                timerGraphNiveli.Enabled = false;
                                timerNiveliVideo.Stop();
                            }
                            break;

                        case "btnVazhdo": 
                            { 
                                timerGraphNiveli.Enabled = true;
                                timerTemperaturaVideo.Start();
                            }
                            break;

                        case "btnZvarrit" :
                            {                                
                                if (Form_Konfigurimi.IsPortiOpen)
                                    chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.ScaleView.Zoom(0, Form_Konfigurimi.KohaReale);
                                else if (!Form_Konfigurimi.IsPortiOpen) { }
                                    //chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.ScaleView.Zoom(0, Int32.Parse(Form_Inqizo_Niveli.TransmetoKohen[Nsec].ToString()));

                                chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.ScaleView.Size = 80;
                            }
                            break;

                        case "btnMbrapaNje" :
                            {
                                chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.ScaleView.ZoomReset(1);
                                chartNiveli.ChartAreas["ChartAreaNiveli"].AxisY.ScaleView.ZoomReset(1);
                            }
                            break;

                        case "btnTersia" :
                            {
                                chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.ScaleView.ZoomReset(NrZoomNiveli);
                                chartNiveli.ChartAreas["ChartAreaNiveli"].AxisY.ScaleView.ZoomReset(NrZoomNiveli);
                            }
                            break;

                        case "btnRuaj" :
                            {
                                chartNiveli.SaveImage(String.Format(@"C:\Users\{0}\AppData\Local\Temp\Imazhi i Perkohshum.png", usernamePC), ChartImageFormat.Png);                         // Ruaje foton perkohesisht ne kete lokacion

                                FileStream fs = new FileStream(String.Format(@"C:\Users\{0}\AppData\Local\Temp\Imazhi i Perkohshum.png", usernamePC), FileMode.Open, FileAccess.Read);      // Hape Streamin qe te lexohet ky imazh
                                imazh = Image.FromStream(fs);                                                                                                                               // Ruaje ne variablen "imazh" kete imazh te ruajtur ne lokacionin mesiperm                                                  
                                fs.Close();                                                                                                                                                 // Mbylle Streamin per ta fshire imazhin e perkohshem nga lokacioni i mesiperm

                                System.IO.File.Delete(String.Format(@"C:\Users\{0}\AppData\Local\Temp\Imazhi i Perkohshum.png", usernamePC));                                               // Fshije imazhin e perkohshum nga lokacioni i mesiperm

                                Form_KonfirmoImazh = new KonfirmoImazh(this);      
          
                                    if (Form_KonfirmoImazh.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                        AddImageToDatabase(imazh);            
                            }
                            break;

                        case "btnVideo":
                            {
                                videoSender = "Niveli";
                                Form_Inqizo_Niveli = new Inqizo(this);

                                if (Form_Konfigurimi.IsPortiOpen)
                                { 
                                    // --------------------------- Kontrolla e Videos ---------------------------
                                    if (Form_Konfigurimi.IsPortiOpen && Form_Konfigurimi.Gjendja_GRAPH_PC)   // Nese porti eshte i hapur dhe gjendja_GRAPH_PC eshte setb atehere beje kontrolla_E_Video_Grafeve = 1; pasi 1 AND 1 = 1                                            
                                        kontrolla_E_Video_Grafeve = true;
                                    // --------------------------------------------------------------------------   

                                    kohaVideo = Form_Konfigurimi.KohaReale.ToString();
                                    VleraVideoNiveli = Form_Konfigurimi.Niveli.ToString();
                                    Form_Inqizo_Niveli.Show();
                                }                               
                                else
                                {
                                    kontrolla_E_Video_Grafeve = false;

                                    if (Form_Inqizo_Niveli.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        if (Form_Inqizo_Niveli.CiliGrafVideo == 1)
                                        {
                                            chartNiveli.Series["Niveli [cm]"].Points.Clear();
                                            InitGraphNiveli();
                                            timerNiveliVideo.Start();
                                        }
                                        else if (Form_Inqizo_Niveli.CiliGrafVideo == 2)
                                        {
                                            chartTemperatura.Series["Temperatura [ºC]"].Points.Clear();
                                            InitGraphTemperatura();
                                            timerTemperaturaVideo.Start();
                                        }

                                        else if (Form_Inqizo_Niveli.CiliGrafVideo == 3)
                                        {
                                            chartNiveli.Series["Niveli [cm]"].Points.Clear();
                                            chartTemperatura.Series["Temperatura [ºC]"].Points.Clear();
                                            InitGraphBashke();
                                            timerBashkeVideo.Start();
                                        }      
                                    }
                                }        
                            }
                            break;

                        default :
                            break;
                    }

                #endregion
                }
                else
                {
                    #region "Grafet e Ndara - Temperatura Case"  

                    switch (myBtn.Name)
                    {
                        case "btnNdalo": 
                            { 
                                timerGraphTemperatura.Enabled = false;
                                timerTemperaturaVideo.Stop();
                            }
                            break;

                        case "btnVazhdo": 
                            { 
                                timerGraphTemperatura.Enabled = true;
                                timerTemperaturaVideo.Start();
                            }
                            break;

                        case "btnZvarrit":
                            {                                
                                if (Form_Konfigurimi.IsPortiOpen)
                                    chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.ScaleView.Zoom(0, Form_Konfigurimi.KohaReale);
                                else if (!Form_Konfigurimi.IsPortiOpen) { }
                                    //chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.ScaleView.Zoom(0, Int32.Parse(Form_Inqizo_Temperatura.TransmetoKohen[Tsec].ToString()));

                                chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.ScaleView.Size = 80;
                            }
                            break;

                        case "btnMbrapaNje":
                            {
                                chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.ScaleView.ZoomReset(1);
                                chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisY.ScaleView.ZoomReset(1);
                            }
                            break;

                        case "btnTersia":
                            {
                                chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.ScaleView.ZoomReset(NrZoomTemperatura);
                                chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisY.ScaleView.ZoomReset(NrZoomTemperatura);
                            }
                            break;

                        case "btnRuaj":
                            {
                                chartTemperatura.SaveImage(String.Format(@"C:\Users\{0}\AppData\Local\Temp\Imazhi i Perkohshum.png", usernamePC), ChartImageFormat.Png);                         // Ruaje foton perkohesisht ne kete lokacion

                                FileStream fs = new FileStream(String.Format(@"C:\Users\{0}\AppData\Local\Temp\Imazhi i Perkohshum.png", usernamePC), FileMode.Open, FileAccess.Read);      // Hape Streamin qe te lexohet ky imazh
                                imazh = Image.FromStream(fs);                                                                                                                               // Ruaje ne variablen "imazh" kete imazh te ruajtur ne lokacionin mesiperm                                                  
                                fs.Close();                                                                                                                                                 // Mbylle Streamin per ta fshire imazhin e perkohshem nga lokacioni i mesiperm

                                System.IO.File.Delete(String.Format(@"C:\Users\{0}\AppData\Local\Temp\Imazhi i Perkohshum.png", usernamePC));                                               // Fshije imazhin e perkohshum nga lokacioni i mesiperm

                                Form_KonfirmoImazh = new KonfirmoImazh(this);

                                if (Form_KonfirmoImazh.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    AddImageToDatabase(imazh);
                            }
                            break;

                        case "btnVideo":
                            {
                                videoSender = "Temperatura";
                                Form_Inqizo_Temperatura = new Inqizo(this);

                                if (Form_Konfigurimi.IsPortiOpen)
                                {                                   
                                    // --------------------------- Kontrolla e Videos ---------------------------
                                    if (Form_Konfigurimi.Gjendja_GRAPH_PC)   // Nese porti eshte i hapur dhe gjendja_GRAPH_PC eshte setb atehere beje kontrolla_E_Video_Grafeve = 1; pasi 1 AND 1 = 1                                            
                                        kontrolla_E_Video_Grafeve = true;                                    
                                    // --------------------------------------------------------------------------                                    
                                    
                                    kohaVideo = Form_Konfigurimi.KohaReale.ToString();
                                    vleraVideoTemperatura = Form_Konfigurimi.Temperatura.ToString();
                                    Form_Inqizo_Temperatura.Show();
                                }                             
                                else
                                {
                                    kontrolla_E_Video_Grafeve = false;                               

                                    if(Form_Inqizo_Temperatura.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        if (Form_Inqizo_Temperatura.CiliGrafVideo == 1)
                                        {
                                            chartNiveli.Series["Niveli [cm]"].Points.Clear();                            
                                            InitGraphNiveli();
                                            timerNiveliVideo.Start();
                                        }
                                        else if (Form_Inqizo_Temperatura.CiliGrafVideo == 2)
                                        {                                        
                                            chartTemperatura.Series["Temperatura [ºC]"].Points.Clear();
                                            InitGraphTemperatura();
                                            timerTemperaturaVideo.Start();
                                        }
                                            
                                        else if (Form_Inqizo_Temperatura.CiliGrafVideo == 3)
                                        {
                                            chartNiveli.Series["Niveli [cm]"].Points.Clear();
                                            chartTemperatura.Series["Temperatura [ºC]"].Points.Clear();
                                            InitGraphBashke();
                                            timerBashkeVideo.Start();
                                        }                                            
                                    }
                                }                                    
                                                                
                            }
                            break;

                        default:
                            break;
                    }

                    #endregion
                }

                #endregion
            }
        }        

        private void chartNiveli_Click(object sender, EventArgs e)
        {
            NrZoomNiveli++;
        }

        private void chartTemperatura_Click(object sender, EventArgs e)
        {
            NrZoomTemperatura++;
        }

        private void chartBashke_Click(object sender, EventArgs e)
        {
            NrZoomBashke++;
        }

        #region "timerat per Grafet"               

        private void timerGraphNiveli_Tick(object sender, EventArgs e)
        {
            try
            {
                chartNiveli.Series["Niveli [cm]"].Points.AddXY(Form_Konfigurimi.KohaReale, Form_Konfigurimi.Niveli);

                if (chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.Maximum > chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.ScaleView.Size)
                    chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.ScaleView.Scroll(chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.Maximum);
            }
            catch(SystemException ex)
            {
                timerGraphNiveli.Stop();
            }
        }

        private void timerGraphTemperatura_Tick(object sender, EventArgs e)
        {                  
            try
            {
                chartTemperatura.Series["Temperatura [ºC]"].Points.AddXY(Form_Konfigurimi.KohaReale, Form_Konfigurimi.Temperatura);

                if (chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.Maximum > chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.ScaleView.Size)
                    chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.ScaleView.Scroll(chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.Maximum);  
            }
            catch(SystemException ex)
            {
                timerGraphTemperatura.Stop();
            }
        }

        private void timerGraphBashke_Tick(object sender, EventArgs e)
        {                    
            try
            {
                chartBashke.Series["Niveli [cm]"].Points.AddXY(Form_Konfigurimi.KohaReale, Form_Konfigurimi.Niveli);
                chartBashke.Series["Temperatura [ºC]"].Points.AddXY(Form_Konfigurimi.KohaReale, Form_Konfigurimi.Temperatura);

                if (chartBashke.ChartAreas["ChartArea1"].AxisX.Maximum > chartBashke.ChartAreas["ChartArea1"].AxisX.ScaleView.Size)
                    chartBashke.ChartAreas["ChartArea1"].AxisX.ScaleView.Scroll(chartBashke.ChartAreas["ChartArea1"].AxisX.Maximum); 
            }
            catch(SystemException ex)
            {
                timerGraphBashke.Stop();
            }
        }

        private void timerGraphMaster_Tick(object sender, EventArgs e)
        {
            if(Form_Konfigurimi.IsPortiOpen && Form_Konfigurimi.Gjendja_GRAPH_PC)
            {
                if(!isTimer)
                {
                    timerGraphNiveli.Start();
                    timerGraphTemperatura.Start();
                    timerGraphBashke.Start();
                }
                isTimer = true;

                try
                {
                    kohaVideo = Form_Konfigurimi.KohaReale.ToString();
                    vleraVideoNiveli = Form_Konfigurimi.Niveli.ToString();
                    vleraVideoTemperatura = Form_Konfigurimi.Temperatura.ToString();
                    vleraVideoBashke = String.Format("{0}|{1}", Form_Konfigurimi.Niveli.ToString(), Form_Konfigurimi.Temperatura.ToString());
                }
                catch(Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }  
        }
        
        private void timerNiveliVideo_Tick(object sender, EventArgs e)
        {           
            try
            {
                chartNiveli.Series["Niveli [cm]"].Points.AddXY(Int32.Parse(Form_Inqizo_Niveli.TransmetoKohen[Nsec].ToString()), Double.Parse(Form_Inqizo_Niveli.TransmetoVleren0[Nsec].ToString()));

                if (chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.Maximum > chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.ScaleView.Size)
                    chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.ScaleView.Scroll(chartNiveli.ChartAreas["ChartAreaNiveli"].AxisX.Maximum);

                Nsec++;
            }
            catch(SystemException ex)
            {
                timerNiveliVideo.Stop();            
            }
            
        }
         
        private void timerTemperaturaVideo_Tick(object sender, EventArgs e)
        {
            try
            {
                chartTemperatura.Series["Temperatura [ºC]"].Points.AddXY(Int32.Parse(Form_Inqizo_Temperatura.TransmetoKohen[Tsec].ToString()), Double.Parse(Form_Inqizo_Temperatura.TransmetoVleren0[Tsec].ToString()));

                if (chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.Maximum > chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.ScaleView.Size)
                    chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.ScaleView.Scroll(chartTemperatura.ChartAreas["ChartAreaTemperatura"].AxisX.Maximum);

                Tsec++;
            }
            catch(SystemException ex)
            {
                timerTemperaturaVideo.Stop();
            }
        }

        private void timerBashkeVideo_Tick(object sender, EventArgs e)
        {
            try
            {
                chartBashke.Series["Niveli [cm]"].Points.AddXY(Int32.Parse(Form_Inqizo_Bashke.TransmetoKohen[Bsec].ToString()), Double.Parse(Form_Inqizo_Bashke.TransmetoVleren0[Bsec].ToString()));
                chartBashke.Series["Temperatura [ºC]"].Points.AddXY(Int32.Parse(Form_Inqizo_Bashke.TransmetoKohen[Bsec].ToString()), Double.Parse(Form_Inqizo_Bashke.TransmetoVleren1[Bsec].ToString()));

                if (chartBashke.ChartAreas["ChartArea1"].AxisX.Maximum > chartBashke.ChartAreas["ChartArea1"].AxisX.ScaleView.Size)
                    chartBashke.ChartAreas["ChartArea1"].AxisX.ScaleView.Scroll(chartBashke.ChartAreas["ChartArea1"].AxisX.Maximum);

                Bsec++;
            }
            catch (SystemException ex)
            {
                timerBashkeVideo.Stop();
            }
        }

        #endregion

        #endregion

        #region "Baza e te Dhenave"

        private void initDatabase()
        {
            dataGridView1.RowHeadersVisible = false;        // E heq kolonen e pare ne dataGridView (te thaten)     
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;          // E mundeson selektimin e gjithe rreshtit me nji klikim         
        }

        private void txtFiltroDatabase_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = String.Format("Emri LIKE '{0}%'", txtFiltroDatabase.Text);
            dataGridView1.DataSource = dv;
        }

        private void RefreshViewFunction()
        {
            toolStripStatusLabel2.ForeColor = Color.Black;
            try
            {
                query = "SELECT * FROM SQLiteDbTb";
                cn.Open();

                cmd = new SQLiteCommand(query, cn);
                da = new SQLiteDataAdapter(cmd);
                dt = new System.Data.DataTable();

                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.RowTemplate.Height = 150;

                da.Fill(dt);
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[0].Width = 30;
                dataGridView1.Columns[1].Width = 65;
                dataGridView1.Columns[3].Width = 240;

                DataGridViewImageColumn image = new DataGridViewImageColumn();
                image = (DataGridViewImageColumn)dataGridView1.Columns[3];
                image.ImageLayout = DataGridViewImageCellLayout.Stretch;
                da.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
                eRow = 0;           // Ne 'Load' dhe kur shtypet 'refresh' vendoes eRow = 0 pasi qe te vendoset ne pictureBox imazhi i pare ne database                                                    
                this.Invoke(new EventHandler(zmadhoImazhinToolStripMenuItem_Click));            // ose  zmadhoImazhinToolStripMenuItem.PerformClick();
                
                toolStripProgressBar1.Maximum = dataGridView1.Rows.Count * dataGridView1.Columns.Count;
            }
        }

        private void AddImageToDatabase(Image imazh)
        {            
            try
            {
                
                cn.Open();
                
                byte[] ImazhBytes = ImageToByteFunction(imazh, ImageFormat.Png);

                query = "INSERT INTO SQLiteDbTb (Data,Emri,Imazhi) VALUES (@Data,@Emri,@Imazhi)";
                cmd = new SQLiteCommand(query, cn);
                cmd.Parameters.AddWithValue("@Data", DateTime.Now.ToString("dd.MM.yyyy"));
                cmd.Parameters.AddWithValue("@Imazhi", ImazhBytes);
                cmd.Parameters.AddWithValue("@Emri", Form_KonfirmoImazh.EmriImazh); 
                cmd.ExecuteNonQuery();
                cn.Close(); 
        
                RefreshViewFunction();
                MessageBox.Show("Imazhi i selektuar eshte shtuar me sukses ne Databaze", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public byte[] ImageToByteFunction(Image image, ImageFormat format)
        {
            ms = new MemoryStream();
            image.Save(ms, format);
            byte[] imageBytes = ms.ToArray();
            ms.Close();

            return imageBytes;
        }

        private void myPrint(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            printDocument1.DefaultPageSettings.Landscape = true;
            printDocument2.DefaultPageSettings.Landscape = false;

            switch (btn.Name)
            {
                case "btnPrintImage":
                    {
                        printDialog1.Document = printDocument1;
                        printPreviewDialog1.Document = printDocument1;
                        printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);                                               
                    }
                    break;

                case "btnPrintTable":
                    {
                        printDialog1.Document = printDocument2;
                        printPreviewDialog1.Document = printDocument2;
                        printDocument2.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument2_PrintPage);
                    }
                    break;

                default:
                    break;
            }

            if (printDialog1.ShowDialog() == DialogResult.OK)
                printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {           
            //Print Image
            e.Graphics.DrawImage(pictureBoxZmadho.Image, 5, 25, pictureBoxZmadho.Image.Width, pictureBoxZmadho.Image.Height);
            
            string textAttach = "Prituar nga Softweri FIEK-SCADA";
            System.Drawing.Font printFont = new System.Drawing.Font("Script MT Bold", 13, FontStyle.Regular);
            StringFormat drawFormat = new StringFormat(StringFormatFlags.DirectionVertical);
            e.Graphics.DrawString(textAttach, printFont, Brushes.Black, (5 + pictureBoxZmadho.Image.Width), 25, drawFormat);
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Print Table   
            Bitmap tableData = dataGridViewToBitmapFunction(dataGridView1);
            e.Graphics.DrawImage(tableData, 190, 25, tableData.Width, tableData.Height);

            string textAttach = "Prituar nga Softweri FIEK-SCADA";
            System.Drawing.Font printFont = new System.Drawing.Font("Script MT Bold", 13, FontStyle.Regular);
            StringFormat drawFormat = new StringFormat(StringFormatFlags.DirectionVertical);
            e.Graphics.DrawString(textAttach, printFont, Brushes.Black, (190 + tableData.Width), 25, drawFormat);
        }

        private void txtExport_Click(object sender, EventArgs e)
        {
            if (!isFocused)
            {
                txtExport.SelectAll();
                isFocused = true;
            }
            errorInfo.Clear();
        }

        private void txtExport_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            txtExport.DeselectAll();                                // Deseleltoje textin kur ta klikon txtExport      
        }

        private void txtExport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)           // Nese shtyp 'enter' te txtExport performo shtypjen e btnExport            
                btnExport.PerformClick();    
        }       

        private void tabPage3_Click(object sender, EventArgs e)
        {
            // Nese e shtyp ne tabPage3 dikun thirre txtExport_Leave() EVENT, qe te deselektohet texti ne txtExport
            this.Invoke(new EventHandler(txtExport_Leave));
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value)
            {
                e.Cancel = true;
            }

            toolStripStatusLabel2.Text = "Njoftim : Nje imazh eshte munduar te shtohet ne databaze ne menyre indirekte (jo permes ketij softweri) por nuk ka pasur sukses. \nFshini ate imazh permes ketij softweri dhe probemi do te menjanohet !";
            toolStripStatusLabel2.ForeColor = Color.Red;
        }

        private void refreshPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Invoke(new EventHandler(txtExport_Leave));
            txtExport.Text = "ExcelFajll1";
            txtFiltroDatabase.Text = "";
            splitContainerDatabase.SplitterDistance = 476;          // Default vlera si ne fillim kur te hapet programi
            RefreshViewFunction();
        }

        private void zgjeroNgushtoImazhinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ts = (ToolStripMenuItem)sender;

            switch(ts.Name)
            {
                case "zgjeroImazhinToolStripMenuItem": splitContainerDatabase.SplitterDistance = 227;           // Vlera per te cilen shihet i tere imazhi ne pictureBoxZmadho 
                    break;

                case "ngushtoImazhinToolStripMenuItem": splitContainerDatabase.SplitterDistance = 476;          // Default vlera si ne fillim kur te hapet programi
                    break;

                default:
                    break;
            }                       
        }
 
        private void txtFiltroDatabase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)           // Nese shtyp 'enter' te txtFiltroDatabase jepi fokus dataGridView1, qe me mujt me zmadhue imazhin e pare te filtruar
            {
                dataGridView1.Focus();                                    
                dataGridView1_KeyDown(sender, new KeyEventArgs(Keys.Enter));
            }
        }

        private void checkBoxAutoSelekto_Click(object sender, EventArgs e)
        {
            dataGridView1.Focus();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)                             // Nese eshte shtypur "Enter" performo 'zmadhoImazhinToolStripMenuItem_Click' pra zmadho imazhin e selektuar, nese jane te selektuara me shume se nje imazh, zmadho imazhin me index me te madh 
            {
                eRow = Int32.Parse(((dataGridView1.SelectedRows[0].ToString()).Split('=')[1]).Split(' ')[0]);      // DataGridViewRow { Index=X }    // Ku X=numeri i rreshtit te selektuar // Ketu e perdorum 2 here split, njehere me hek 'DataGridViewRow { Index=' mbete 'X }' pastaj e hekim ' }' dhe mbete vetem 'X'                                                                                                                                 
                this.Invoke(new EventHandler(zmadhoImazhinToolStripMenuItem_Click));

                if (checkBoxAutoSelekto.Checked)
                    e.SuppressKeyPress = false;                         // Nese dojna me u selektue rreshti nen ate qe klikojm enter
                else
                    e.SuppressKeyPress = true;                          // Nese nuk dojna me u selektue rreshti nen ate qe klikojm enter                
            }

            if (e.KeyCode == Keys.Delete && dataGridView1.SelectedRows.Count == 1)          // Fshij imazhin e selektuar me tastin Delete  
            {
                fshiImazhinNgaDatabazaToolStripMenuItem_Click(fshiImazhinNgaDatabazaToolStripMenuItem, new EventArgs());
            }
            else if (e.KeyCode == Keys.Delete && dataGridView1.SelectedRows.Count > 1)      // Fshij shume imazhe te selektuara me tastin Delete
            {
                fshiImazhinNgaDatabazaToolStripMenuItem_Click(fshiImazhetESelektuaraNgaDatabazaToolStripMenuItem, new EventArgs());
            }
        }

        private void zmadhoImazhinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (eRow >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[eRow];
                    rowNum = row.Cells["ID"].Value.ToString();
                }

                query = String.Format("SELECT Imazhi FROM SQLiteDbTb WHERE ID={0}", rowNum);
                cn.Open();

                cmd = new SQLiteCommand(query, cn);
                da = new SQLiteDataAdapter(cmd);
                SQLiteCommandBuilder cbd = new SQLiteCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds);
                byte[] ap = (byte[])(ds.Tables[0].Rows[0]["Imazhi"]);          // Tables[0] = tabelen me numer 0,1,2... qe gjenden ne database dmth ne rastin e pergjithsum kemi nji tabel pra e shkruajm Tables[0]                                   
                ms = new MemoryStream(ap);

                pictureBoxZmadho.Image = Image.FromStream(ms);
                pictureBoxZmadho.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBoxZmadho.BorderStyle = BorderStyle.Fixed3D;
                ms.Close();

                query = String.Format("SELECT emri FROM SQLiteDbTb WHERE ID={0}", rowNum);
                cmd = new SQLiteCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                    toolStripStatusLabel2.Text = dr["Emri"].ToString();

            }
            catch (ArgumentOutOfRangeException)
            {
                // Kjo Exception ndodhe kur nuk kemi asi te dhene ne databaze, ne thjesht e injorojme kete pasi e dime qka eshte.
                // Ndersa per perdoruesin kjo nuk shfaqet fare.
            }
            catch (IndexOutOfRangeException)
            {
                // Kjo Exception ndodhe kur nuk kemi asi te dhene ne databaze, ne thjesht e injorojme kete pasi e dime qka eshte.
                // Ndersa per perdoruesin kjo nuk shfaqet fare.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);        // Qdo Execption perveq 'ArgumentOutOfRangeException' dhe 'IndexOutOfRangeException' shfaqe ne MessageBox pasi vetem ato dyja nuk qojne pesh per pune normale te programit.
            }
            finally
            {
                cn.Close();
            }
        }

        private void fshiImazhinNgaDatabazaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[eRow];
            rowNum = row.Cells["ID"].Value.ToString();

            ToolStripMenuItem tsm = (ToolStripMenuItem)sender;

            switch (tsm.Name)
            {
                case "fshiImazhinNgaDatabazaToolStripMenuItem":
                    {
                        DialogResult res = MessageBox.Show("A deshironi ta fshini permanent imazhin e selektuar nga databaza ?", "Njoftim", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (res == System.Windows.Forms.DialogResult.OK)
                        {
                            fshiImazhNgaDatabazaFunction(rowNum);                   // Thirre funksionin me e fshie imazhin
                            MessageBox.Show("Imazhi i selektuar eshte fshire me sukses nga Databaza.", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Invoke(new EventHandler(refreshPageToolStripMenuItem_Click));          // Bonja faqes refresh qe te shifet se eshte fshire imazhi nga database                                                             
                        }
                    }
                    break;

                case "fshiImazhetESelektuaraNgaDatabazaToolStripMenuItem":
                    {
                        DialogResult res = MessageBox.Show("A deshironi ti fshini permanent imazhet e selektuar nga databaza ?", "Njoftim", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (res == System.Windows.Forms.DialogResult.OK)
                        {
                            foreach (DataGridViewRow rresht in dataGridView1.Rows)
                            {
                                if (rresht.Selected)
                                {
                                    rowNum = rresht.Cells[0].Value.ToString();
                                    fshiImazhNgaDatabazaFunction(rowNum);           // Thirre funksionin me e fshie imazhin
                                }
                            }
                            MessageBox.Show("Imazhet e selektuara jane fshire me sukses nga Databaza.", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Invoke(new EventHandler(refreshPageToolStripMenuItem_Click));          // Bonja faqes refresh qe te shifet se eshte fshire imazhi nga database                                                             
                        }
                        break;
                    }

                default:
                    break;
            }            
        }

        public void fshiImazhNgaDatabazaFunction(string rowNumber)
        {
            try
            {
                cn.Open();

                // Fshije imazhin nga database
                query = String.Format("DELETE FROM SQLiteDbTb WHERE ID={0}", @rowNumber);
                cmd = new SQLiteCommand(query, cn);
                cmd.Parameters.AddWithValue("@rowNum", rowNumber);
                cmd.ExecuteNonQuery();

                // Resetoje ID numrimin
                query = String.Format("UPDATE sqlite_sequence SET seq=0 WHERE name='SQLiteDbTb'");
                cmd = new SQLiteCommand(query, cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
                toolStripStatusLabel2.Text = "";
                pictureBoxZmadho.Image = null;           // Zbraze pictureBox pas qdo fshirjes se imazheve nga databaza. 
                // NOTE : Nese ka ende imazhe ne database automatikisht mbushet pictureBox me imazhin e ardhshum.
                // Vetem nese eshte fshire imazhi i fundit atehere mbetet pictureBox zbrazet deri sa nuk shtohet nje imazh i ri ne database.                    
            }
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            eRow = e.RowIndex;            
        }

        private void saveTableToDisk_Click(object sender, EventArgs e)
        {
            dataToImage = dataGridViewToBitmapFunction(dataGridView1);

            //Ruaje bitmapin ku te duash
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "*";
            sfd.DefaultExt = "png";
            sfd.ValidateNames = true;
            sfd.Filter = "Png|*.png|Jpeg|*.jpeg|Bitmap|*.bmp";
            if (sfd.ShowDialog() == DialogResult.OK)
                dataToImage.Save(sfd.FileName);
        }

        private Bitmap dataGridViewToBitmapFunction(DataGridView dgv)
        {
            // Ky funksion perdoret per ta kthyer DataGridView-in si foto Bitmap
            //Beje lartesine e DataGridView kompakt (aq sa ka rreshta, qe te humbet pjesa 'grey' e DataGridView) dhe ruaje lartesin e DataGridView ne nje variabel
            int height = dgv.Height;
            dgv.Height = dgv.RowCount * dgv.RowTemplate.Height;

            //Krijo bitmapin dhe vizato ne te DataGridView
            Bitmap tabelaImazh = new Bitmap(dgv.Width, dgv.Height);
            dgv.DrawToBitmap(tabelaImazh, new System.Drawing.Rectangle(0, 0, dgv.Width, dgv.Height));

            //Ktheje lartesine e DataGridView normal
            dgv.Height = height;

            return tabelaImazh;
        }

        private void saveImageToDisk_Click(object sender, EventArgs e)
        {
            dataToImage = (Bitmap)pictureBoxZmadho.Image;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "*";
            sfd.DefaultExt = "png";
            sfd.ValidateNames = true;
            sfd.Filter = "Png|*.png|Jpeg|*.jpeg|Bitmap|*.bmp";
            if (sfd.ShowDialog() == DialogResult.OK) 
                dataToImage.Save(sfd.FileName);
        }

        private void ExportToExcelEvent(object sender, EventArgs e)
        {          
            if (txtExport.Text != "")
            {                          
                ExportDataGridViewToExeclFunction(dataGridView1, txtExport.Text);        // Thirr funksionin per exportim      
                try
                {
                    cn.Open();

                    query = String.Format("SELECT emri FROM SQLiteDbTb WHERE ID={0}", rowNum);
                    cmd = new SQLiteCommand(query, cn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                        toolStripStatusLabel2.Text = dr["Emri"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cn.Close();                    
                }
            }
            else
                errorInfo.SetError(txtExport, "Ju lutem shenoni nje emer per ruajtjen e fajllit, ne hapsiren e dedikuar per emertim!");
        }

        private void ExportDataGridViewToExeclFunction(DataGridView dataGridViewObject, string excelFilename)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Range Range1;

            try       // Performo kete 'try' te jashtem nese perdoruesi nuk e ka Excel-in te instaluen
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                toolStripStatusLabel2.Text = String.Format("Duke Exportuar '{0}.xlsx'... ", txtExport.Text);     
                #region "Kryerja e Punes per Excel"

                try
                {
                    xlApp.Columns.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    xlApp.Columns.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    // Ngjyrose backgroundin e 'cells' te rreshtit te pare
                    Range1 = xlApp.get_Range("A1", "Z1");
                    Range1.Interior.Color = ColorTranslator.ToOle(Color.Gray);

                    //Shkrije 'cells' nga D1 - P1 per qdo rresht
                    for (int i = 1; i <= dataGridView1.RowCount + 1; i++)
                    {
                        Range1 = xlApp.get_Range("D" + i.ToString(), "Z" + i.ToString());
                        Range1.Merge(misValue);
                    }

                    Image temporarilyImage;
                    const int ConstImageSizeWidth = 1071;
                    const int ConstImageSizeHeight = 300;

                    // Vendsoja e rreshtit qe permban emrat e kolonave.
                    for (int i = 0; i < dataGridViewObject.Columns.Count; i++)              // i=0,1,2,3
                    {
                        xlApp.Cells[1, i + 1] = dataGridViewObject.Columns[i].HeaderText;
                    }

                    // Vendosja e vlerave neper rreshta dhe kolona.
                    for (int i = 0; i < dataGridViewObject.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridViewObject.Columns.Count; j++)
                        {
                            if (dataGridViewObject.Rows[i].Cells[j].Value.GetType() == typeof(byte[]))
                            {

                                byte[] a = (byte[])(dataGridViewObject.Rows[i].Cells[j].Value);
                                MemoryStream ms = new MemoryStream(a);
                                temporarilyImage = Image.FromStream(ms);

                                temporarilyImage.Save(String.Format(@"C:\Users\{0}\AppData\Local\Temp\Imazhi i Perkohshum {1}.png", usernamePC, (i + 1).ToString()), ImageFormat.Png);          // Ruaje imazhin ne "C:\Users\usernamePC\AppData\Local\Temp, me emrin "Imazhi i Perkohshum.png" pasi qe qdo windows pc e ka kete directory dhe prej aty lexoje dhe exportoje ne Execl.
                                Range1 = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[i + 2, j + 1];
                                float Left = (float)((double)Range1.Left);
                                float Top = (float)((double)Range1.Top);

                                if (temporarilyImage.Size.Height <= 409 && temporarilyImage.Size.Width <= 255)                        // max RowHeight eshte = 409 dhe max ColumnWidth eshte = 255  
                                {
                                    xlWorkSheet.Shapes.AddPicture(String.Format(@"C:\Users\{0}\AppData\Local\Temp\Imazhi i Perkohshum {1}.png", usernamePC, (i + 1).ToString()), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, temporarilyImage.Size.Width, temporarilyImage.Size.Height);
                                    Range1.RowHeight = temporarilyImage.Size.Height;
                                    Range1.ColumnWidth = temporarilyImage.Size.Width;
                                }
                                else if (temporarilyImage.Size.Height <= 409)
                                {
                                    xlWorkSheet.Shapes.AddPicture(String.Format(@"C:\Users\{0}\AppData\Local\Temp\Imazhi i Perkohshum {1}.png", usernamePC, (i + 1).ToString()), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, temporarilyImage.Size.Width, temporarilyImage.Size.Height);
                                    Range1.RowHeight = temporarilyImage.Size.Height;
                                }
                                else if (temporarilyImage.Size.Width <= 255)
                                {
                                    xlWorkSheet.Shapes.AddPicture(String.Format(@"C:\Users\{0}\AppData\Local\Temp\Imazhi i Perkohshum {1}.png", usernamePC, (i + 1).ToString()), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, temporarilyImage.Size.Width, temporarilyImage.Size.Height);
                                    Range1.ColumnWidth = temporarilyImage.Size.Width;
                                }
                                else
                                {
                                    // Per rastin tone qikjo ndodhe
                                    xlWorkSheet.Shapes.AddPicture(String.Format(@"C:\Users\{0}\AppData\Local\Temp\Imazhi i Perkohshum {1}.png", usernamePC, (i + 1).ToString()), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ConstImageSizeWidth, ConstImageSizeHeight);
                                    Range1.RowHeight = ConstImageSizeHeight;
                                }

                                System.IO.File.Delete(String.Format(@"C:\Users\{0}\AppData\Local\Temp\Imazhi i Perkohshum {1}.png", usernamePC, (i + 1).ToString()));               // Fshije foton qe e kemi krijuar perkohesisht ne temp Folder 

                            }
                            else
                            {
                                xlWorkSheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }

                            toolStripProgressBar1.Increment(10);
                        }
                    }

                    xlApp.Columns.AutoFit();

                    xlApp.ActiveWorkbook.SaveCopyAs(String.Format(@"C:\Users\{0}\Desktop\{1}.xlsx", usernamePC, excelFilename));
                    xlApp.ActiveWorkbook.Saved = true;

                    toolStripStatusLabel2.Text = String.Format(@"Fajlli eshte eksportuar me sukses ne 'C:\Users\{0}\Desktop\{1}.xlsx'", usernamePC, excelFilename);
                    MessageBox.Show(String.Format(@"Fajlli eshte eksportuar me sukses ne 'C:\Users\{0}\Desktop\{1}.xlsx'", usernamePC, excelFilename), "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toolStripProgressBar1.Value = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    xlApp.Quit();
                    xlWorkBook = null;
                    xlApp = null;
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ka Ndodhur nje Problem gjate Exportimit te te Dhenave ! \nJu lutemi siguroheni qe e keni te Instaluar 'Microsoft Excel' ne Kompjuterin tuaj !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion                                                                                                                                                                                                                                                                                           
    }
}
