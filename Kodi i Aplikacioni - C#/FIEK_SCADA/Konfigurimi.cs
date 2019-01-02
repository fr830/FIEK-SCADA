using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Modbus.Data;
using Modbus.Utility;
using Modbus.Device;
using System.Threading;

using System.IO.Ports;

namespace FIEK_SCADA
{
    public partial class Konfigurimi : Form
    {
        public Konfigurimi(Form1 ParentForm)
        {
            InitializeComponent();
            initPorts();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            form1 = ParentForm;

            groupBoxVlerat.Enabled = false;
        }        

        #region "Deklarimet e Variablave"

        private Form1 form1;

        SerialPort porti;
        IModbusMaster masteri;
        Thread thredi1, thredi2;                    
        bool oneTime = false;
        string temperatura_0,
               temperatura_1,
               temperatura_2,
               temperatura_3,
               niveli_0, 
               niveli_1,
               niveli_2,
               distancamax_0,
               distancamax_1;              

        #endregion

        #region "Konfigurimi 'Get Set' Deklarimiet"

        private string niveli;
        private string temperatura;
        private string niveli_SetPoint;
        private string temperatura_SetPoint;
        private string dMax;
        private bool niveli_Arritur;
        private bool temperatura_Arritur;
        private int kohaReale;
        private bool gjendja_Q4_PLC;
        private bool gjendja_M_K = false;                   // Default edhe ne mikrokontroller eshte Clr 
        private bool gjendja_GRAPH_PC = false;              // Default edhe ne mikrokontroller eshte Clr  (BIT 4FH) , I tregon Grafe fillo me shfaq vlera pasi qe jane dhene vlera per niveli,temperature dhe dmax
        private bool gjendja_EMERGJENT_MODE = false;         // Default edhe ne mikrokontroller eshte Clr, clr dmth nuk ka emergjence
        private bool isPortiOpen = false;


        public string Niveli
        {
            get { return niveli; }
            set { niveli = value; }
        }

        public string Temperatura
        {
            get { return temperatura; }
            set { temperatura = value; }
        }

        public string Niveli_SetPoint
        {
            get { return niveli_SetPoint; }
            set { niveli_SetPoint = value; }
        }

        public string Temperatura_SetPoint
        {
            get { return temperatura_SetPoint; }
            set { temperatura_SetPoint = value; }
        }

        public string DMax
        {
            get { return dMax; }
            set { dMax = value; }
        }

        public bool Niveli_Arritur
        {
            get { return niveli_Arritur; }
            set { niveli_Arritur = value; }
        }

        public bool Temperatura_Arritur
        {
            get { return temperatura_Arritur; }
            set { temperatura_Arritur = value; }
        }

        public int KohaReale
        {
            get { return kohaReale; }
            set { kohaReale = value; }
        }

        public bool Gjendja_Q4_PLC
        {
            get { return gjendja_Q4_PLC; }
            set { gjendja_Q4_PLC = value; }
        }

        public bool Gjendja_M_K
        {
            get { return gjendja_M_K; }
            set { gjendja_M_K = value; }
        }

        public bool Gjendja_GRAPH_PC
        {
            get { return gjendja_GRAPH_PC; }
            set { gjendja_GRAPH_PC = value; }
        }

        public bool Gjendja_EMERGJENT_MODE
        {
            get { return gjendja_EMERGJENT_MODE; }
            set { gjendja_EMERGJENT_MODE = value; }
        }        

        public bool IsPortiOpen
        {
            get { return isPortiOpen; }
            set { isPortiOpen = value; }
        }

        #endregion

        #region "Eventet dhe Funksionet"

        private void initPorts()
        {
            string[] Portet = SerialPort.GetPortNames().ToArray();

            foreach(var port in Portet)
            {
                cbPort.Items.Add(port);
            }
        }

        private void Konfigurimi_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Ne kete dritare ju mund te zgjedhni : \n\n- Portin per komunikim serik. \n- Jepni vlerat per distancen nga fundi i kazanit deri te lartesia e sensorit per matjen e distances. \n- Jepni vlerat per nivelin e deshiruar te lengut. \n- Jepni vlerat per temperaturen e deshiruar. \n\nPas dhenies se vlerave ju mund ta mbyllni kete dritare dhe kur te deshironi, me klikimin e butonit 'Konekto/Konfiguro' hapet kjo dritare ne gjendjen si e keni lene me heret.", "Ndihme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
  
        private void btnKonekto_Click(object sender, EventArgs e)
        {
            if(cbPort.SelectedIndex != -1)
            {
                porti = new SerialPort(cbPort.SelectedItem.ToString());
                porti.BaudRate = 20833;
                porti.Parity = Parity.None;
                porti.StopBits = StopBits.One;
                porti.DataBits = 8;                                                    

                try
                {
                    porti.Open();
                    masteri = ModbusSerialMaster.CreateRtu(porti);
                    masteri.Transport.WriteTimeout = 100;
                    masteri.Transport.ReadTimeout = 100;
                    thredi1 = new Thread(new ThreadStart(MerrVleratNgaSlave1));
                    thredi2 = new Thread(new ThreadStart(MerrVleratNgaSlave2));                    
                    thredi1.IsBackground = true;
                    thredi2.IsBackground = true;
                    thredi1.Start();
                    thredi2.Start();

                    toolStripStatusLabel1.Text = "Konektuar";
                    toolStripStatusLabel1.ForeColor = Color.Green;
                    cbPort.Enabled = false;
                    isPortiOpen = true;
                    btnKonekto.Enabled = false;                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }               
            }
            else
            {
                MessageBox.Show("Ju Lutem Zgjedhni Portin per Komunikim !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                //cbPort.Focus();
                cbPort.Select();
            }
        }

        private void btnDiskonekto_Click(object sender, EventArgs e)
        {
            try
            {                
                if(porti.IsOpen)
                {
                    if(thredi1.IsAlive)
                    {                        
                        porti.Close();
                        thredi1.Abort();
                        thredi2.Abort();
                        toolStripStatusLabel1.Text = "Diskonektuar";
                        toolStripStatusLabel1.ForeColor = Color.Red;
                        cbPort.Enabled = true;
                        groupBoxVlerat.Enabled = false;
                        btnKonekto.Enabled = true;
                        isPortiOpen = false;
                        toolStripStatusLabel2.Text = "| Statusi i Software-it : I Panjoftur !";              
                    }                    
                }                
            }
            catch(Exception ex)
            {
                MessageBox.Show("E Pamundur per ta Mbyllur Portin !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void maskTxtAnyPosCursor_MouseDown(object sender, EventArgs e)
        {
            MaskedTextBox mtx = (MaskedTextBox)sender;
            
            switch(mtx.Name)
            {
                case "maskTxtDmax": { maskTxtDmax.Select(0, 0); }
                    break;

                case "maskTxtNiveli": { maskTxtNiveli.Select(0, 0); }
                    break;

                case "maskTxtTemperatura": { maskTxtTemperatura.Select(0, 0); }
                    break;

                default:
                    break;
            }             
        }

        private void maskTxtNoSpaceAllow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }
        }   

        private void btnShkruaj_Click(object sender, EventArgs e)
        {
            if (maskTxtNiveli.Text == "" || maskTxtTemperatura.Text == "" || maskTxtDmax.Text == "")
            {
                btnShkruaj.Enabled = false;
                MessageBox.Show("Nuk Lejohen qe Fushat e Vlerave te jene te Zbrazeta \nApo te Leni Vlera Mangu !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnShkruaj.Enabled = true;
            }

            else
            {
                btnShkruaj.Enabled = true;
                niveli = maskTxtNiveli.Text;
                temperatura = maskTxtTemperatura.Text;
                dMax = maskTxtDmax.Text;

                convertForMicroControllerFunction(niveli, temperatura, dMax);

                oneTime = true;
            }            
        }

        // ------------------------------ THREADs ---------------------------------------

        private void MerrVleratNgaSlave1()
        {
            while (true)
            {                
                try
                {
                    ushort[] ReadRegs = masteri.ReadHoldingRegisters(1, 0, 7);      // 20H - 26H
                    manageRegisters(ReadRegs);

                    ReadRegs = masteri.ReadHoldingRegisters(1, 34, 4);
                    manageRegistersTEMPERATURA(ReadRegs);

                    ReadRegs = masteri.ReadHoldingRegisters(1, 45, 3);
                    manageRegistersNIVELI(ReadRegs);


                    bool[] coils = masteri.ReadCoils(1, 72, 6);
                    manageCoils(coils);


                    // ------------------------------------------ Kontrolla e START/STOP me ane te PC dhe START/STOP fizike dhe Emergjenca ---------------------------------------------------

                    if (form1.Kontrolla_PC_START_P3_7)           // Eshte shtypur START_PC   , bone sikur me u kon pushbutton
                    {
                        masteri.WriteSingleCoil(1, 79, true);               // Shkruj true                        
                        if (masteri.ReadCoils(1, 79, 1)[0])                 // Kqyre a u shkrue
                        {
                            Thread.Sleep(500);                              // Qe po leshoje timer2 let hec 300ms
                            if (thredi1.IsAlive)                              // A kan kalue 300ms
                            {
                                masteri.WriteSingleCoil(1, 79, false);      // Po kane kalue, shkruje tash false 
                                if (!masteri.ReadCoils(1, 79, 1)[0])        // Kqyre a u shkrue
                                {         
                                    form1.Kontrolla_PC_START_P3_7 = false;
                                }

                            }                                                           
                        }
                    }

                    if (form1.Kontrolla_PC_STOP_P3_5 && form1.Kontrolla_PINI_EMERGJENT_BIT)              // Eshte shtypur STOP_PC   , bone sikur me u kon pushbutton
                    {
                        masteri.WriteSingleCoil(1, 80, true);                // Shkruj true     80 = 50H    VLERA_E_PINIT_STOP_PC
                        masteri.WriteSingleCoil(1, 77, true);                // Shkruj true     77 = 4DH    PINI_EMERGJENT_BIT
                        if (masteri.ReadCoils(1, 80, 1)[0] && masteri.ReadCoils(1, 77, 1)[0])                    // Kqyre a u shkrue
                        {
                            Thread.Sleep(500);                               // Qe po leshoje timer2 let hec 300ms
                            if (thredi1.IsAlive)                             // A kan kalue 300ms
                            {
                                masteri.WriteSingleCoil(1, 80, false);       // Po kane kalue, shkruje tash false 

                                if (!masteri.ReadCoils(1, 80, 1)[0])         // Kqyre a u shkrue
                                {
                                    form1.Kontrolla_PC_STOP_P3_5 = false;
                                }
                            }
                        }
                    }

                    if (form1.Kontrolla_PC_STOP_P3_5 && !form1.Kontrolla_PINI_EMERGJENT_BIT)              // Eshte shtypur STOP_PC   , bone sikur me u kon pushbutton, dhe shkruje PINI_EMERGJENT_BIT = OFF ne mikrokontroller
                    {
                        masteri.WriteSingleCoil(1, 80, true);                // Shkruj true
                        masteri.WriteSingleCoil(1, 77, false);                // Shkruj false
                        if (masteri.ReadCoils(1, 80, 1)[0] && !masteri.ReadCoils(1, 77, 1)[0])                    // Kqyre a u shkrue
                        {
                            Thread.Sleep(500);                               // Qe po leshoje timer2 let hec 300ms
                            if (thredi1.IsAlive)                             // A kan kalue 300ms
                            {
                                masteri.WriteSingleCoil(1, 80, false);       // Po kane kalue, shkruje tash false 

                                if (!masteri.ReadCoils(1, 80, 1)[0])         // Kqyre a u shkrue
                                {
                                    form1.Kontrolla_PC_STOP_P3_5 = false;
                                }
                            }
                        }
                    }

                    if (form1.Kontrolla_PC_STOP_P3_5)              // Eshte shtypur STOP_PC   , bone sikur me u kon pushbutton
                    {                        
                        masteri.WriteSingleCoil(1, 80, true);                // Shkruj true                    
                        if (masteri.ReadCoils(1, 80, 1)[0])                  // Kqyre a u shkrue
                        {
                            Thread.Sleep(500);                               // Qe po leshoje timer2 let hec 300ms
                            if (thredi1.IsAlive)                             // A kan kalue 300ms
                            {
                                masteri.WriteSingleCoil(1, 80, false);       // Po kane kalue, shkruje tash false 

                                if (!masteri.ReadCoils(1, 80, 1)[0])         // Kqyre a u shkrue
                                {                                    
                                    form1.Kontrolla_PC_STOP_P3_5 = false;
                                }
                            }
                        }
                    }                                     
                    // --------------------------------------------------------------------------------------------------------------------------------------------------------                    
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    if(!porti.IsOpen)
                    {
                        isPortiOpen = false;
                    }
                }
                Thread.Sleep(100);                
            }
        }      

        private void MerrVleratNgaSlave2()
        {
            while (true)
            {
                if (oneTime)
                {
                    try
                    {
                        masteri.WriteSingleRegister(1, 8, ushort.Parse(temperatura_0));       // 30H = 4 dhe 31H = 0
                        masteri.WriteSingleRegister(1, 9, ushort.Parse(temperatura_1));       // 32H = 3 dhe 33H = 0
                        masteri.WriteSingleRegister(1, 10, ushort.Parse(temperatura_2));      // 34H = 2 dhe 35H = 0
                        masteri.WriteSingleRegister(1, 11, ushort.Parse(temperatura_3));      // 36H = 1 dhe 37H = 0


                        masteri.WriteSingleRegister(1, 12, ushort.Parse(niveli_0));           // 38H dhe = 3 dhe 39H = 0
                        masteri.WriteSingleRegister(1, 13, ushort.Parse(niveli_1));           // 3AH dhe = 2 dhe 3BH = 0
                        masteri.WriteSingleRegister(1, 14, ushort.Parse(niveli_2));           // 3CH dhe = 1 dhe 3DH = 0


                        masteri.WriteSingleRegister(1, 15, ushort.Parse(distancamax_0));      // 3EH dhe = 7 dhe 3FH = 0
                        masteri.WriteSingleRegister(1, 16, ushort.Parse(distancamax_1));      // 40H dhe = 3 dhe 41H = 0

                        masteri.WriteSingleCoil(1, 78, true);               // 4EH = True   VARIABLA_RIJEP_VLERAT_NGA_PC

                        if (!masteri.ReadCoils(1, 78, 1)[0])
                        {
                            oneTime = false;
                            MessageBox.Show("Vlerat e Reja jane Shkruar me sukses !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    Thread.Sleep(10);
                }
            }
        }              

        private void manageRegisters(ushort[] Regs)
        {            
            niveli_SetPoint = Regs[0].ToString() + "." + Regs[1].ToString();
            temperatura_SetPoint = Regs[2].ToString() + "." + Regs[3].ToString();
            dMax = Regs[4].ToString();
            int koha1Sec = 250 - Int16.Parse(Regs[5].ToString());
            int koha250Sec = 250 * (250 - Int16.Parse(Regs[6].ToString()));
            int kohaTotal = koha250Sec + koha1Sec;
            kohaReale = Int32.Parse(kohaTotal.ToString());
        }

        private void manageRegistersTEMPERATURA(ushort[] Regs)
        {            
            temperatura = (100 * Int16.Parse(Regs[3].ToString()) + 10 * Int16.Parse(Regs[2].ToString()) + Int16.Parse(Regs[1].ToString())).ToString() + "." + Regs[0].ToString();
        }

        private void manageRegistersNIVELI(ushort[] Regs)
        {          
            niveli = (10 * Int16.Parse(Regs[2].ToString()) + Int16.Parse(Regs[1].ToString())).ToString() + "." + Regs[0].ToString();
        }

        private void manageCoils(bool[] coils)
        {            
            gjendja_Q4_PLC = bool.Parse(coils[0].ToString());                      
            niveli_Arritur = bool.Parse(coils[1].ToString());           // P2.0
            temperatura_Arritur = bool.Parse(coils[2].ToString());      // P2.1
            gjendja_M_K = bool.Parse(coils[3].ToString());        
            gjendja_GRAPH_PC = bool.Parse(coils[4].ToString());
            gjendja_EMERGJENT_MODE = bool.Parse(coils[5].ToString());
        }
     
        // ------------------------------------------------------------------------------

        private void convertForMicroControllerFunction(string N, string T, string D)
        {
            niveli_2 = N.Substring(0, 1);       // 3
            niveli_1 = N.Substring(1, 1);       // 2          
            niveli_0 = N.Substring(3, 1);       // 1
                                                // 12.3
            temperatura_3 = T.Substring(0, 1);  // 4
            temperatura_2 = T.Substring(1, 1);  // 3
            temperatura_1 = T.Substring(2, 1);  // 2       
            temperatura_0 = T.Substring(4, 1);  // 1
                                                // 123.4
            distancamax_1 = D.Substring(0, 1);  // 7    
            distancamax_0 = D.Substring(1, 1);  // 3
                                                // 37                                                
        }
 
        private void timer1_Tick(object sender, EventArgs e)
        {            
            if (gjendja_M_K && isPortiOpen)         // Nese nga pllaka i ju eshte treguar PC qe te kaloje ne gjendje Monitorimi dhe Porti eshte i hapur                
            {
                toolStripStatusLabel2.Text = "| Statusi i Software-it : Monitorim";
                groupBoxVlerat.Enabled = false;
            }                            
            else if(!gjendja_M_K && isPortiOpen)    // Nese nga pllaka i ju eshte treguar PC qe te kaloje ne gjendje Monitorimi dhe Kontrolle dhe Porti eshte i hapur           
            {
                toolStripStatusLabel2.Text = "| Statusi i Software-it : Monitorim dhe Kontrollim";
                groupBoxVlerat.Enabled = true;
            }                
        }

        private void Konfigurimi_FormClosing(object sender, FormClosingEventArgs e)
        {       
            if(isPortiOpen)
            {
                this.Hide();
                e.Cancel = true;            // Mos e mbylle                             
            }  
            else
            {
                oneTime = false;               
                form1.IsPortTrue = false;
                e.Cancel = false;           // Mbylle           
            }
        }

        #endregion        
    }
}
