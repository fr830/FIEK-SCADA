using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FIEK_SCADA
{
    public partial class Inqizo : Form
    {
        public Inqizo(Form1 ParentForm)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            form1 = ParentForm;
            btnLuajVideon.DialogResult = System.Windows.Forms.DialogResult.OK;          
        }

        #region "Deklarimet e Variablave"

        private Form1 form1;

        private string userNamePC = Environment.UserName;
        private StreamWriter sw;
        private StreamReader sr;
        private string emriVideo;
        private string nameNiveli;
        private string nameTemperatura;
        private string nameBashke;
        private string variabelNdihmese;
        private string filePath;
        private string newContent1;
        private string newContent2;

        #endregion

        #region "Inqizo 'Get Set' Deklarimiet"

        private string[] transmetoKohen;
        private string[] transmetoVleren0;
        private string[] transmetoVleren1;
        private int ciliGrafVideo = 0;
        //private bool kontrolla_E_Video_Grafeve = false;

        public string[] TransmetoKohen
        {
            get { return transmetoKohen; }
            set { transmetoKohen = value; }
        }

        public string[] TransmetoVleren0
        {
            get { return transmetoVleren0; }
            set { transmetoVleren0 = value; }
        }

        public string[] TransmetoVleren1
        {
            get { return transmetoVleren1; }
            set { transmetoVleren1 = value; }
        }

        public int CiliGrafVideo
        {
            get { return ciliGrafVideo; }
            set { ciliGrafVideo = value; }
        }

        //public bool Kontrolla_E_Video_Grafeve
        //{
        //    get { return kontrolla_E_Video_Grafeve; }
        //    set { kontrolla_E_Video_Grafeve = value; }
        //}

        #endregion

        #region "Eventet dhe Funksionet"

        private void Inqizo_Load(object sender, EventArgs e)
        {
            toolStripStatusLabelRECORD_ANIMACION.BackColor = Color.Transparent;
            toolStripStatusLabelRECORD_ANIMACION.Image = FIEK_SCADA.Properties.Resources.RecordOFF;

            btnRuajVideon.Enabled = false;
                  
            toolStripStatusLabelRECORD_TEXT.Text = form1.VideoSender;
            
            variabelNdihmese = form1.VideoSender;

            if (form1.Kontrolla_E_Video_Grafeve)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
            }
            
            string[] fileVideos = Directory.GetFiles(@"Vlerat e Inqizimeve", "*.txt");

            foreach (var name in fileVideos)
            {
                listBox1.Items.Add((name.Split('\\')[1]).Split('.')[0]);
            }
        }

        private void btnRuajVideon_Click(object sender, EventArgs e)
        {
            toolStripStatusLabelRECORD_ANIMACION.Image = FIEK_SCADA.Properties.Resources.RecordAnimacion;

            emriVideo = txtRuajVideo.Text;
            txtRuajVideo.Text = "";

            switch (variabelNdihmese)
            {
                case "Niveli":
                    {
                        nameNiveli = emriVideo + "_Nivel_Graf";
                        timerNiveli.Start();

                        toolStripStatusLabelRECORD_TEXT.Text = String.Format("Duke Inqizuar {0}...", nameNiveli);
                        toolStripStatusLabelRECORD_TEXT.ForeColor = Color.Green;
                    }
                    break;

                case "Temperatura":
                    {
                        nameTemperatura = emriVideo + "_Temperature_Graf";
                        timerTemperatura.Start();

                        toolStripStatusLabelRECORD_TEXT.Text = String.Format("Duke Inqizuar {0}...", nameTemperatura);
                        toolStripStatusLabelRECORD_TEXT.ForeColor = Color.Green;
                    }
                    break;

                case "Bashke":
                    {
                        nameBashke = emriVideo + "_Bashke_Graf";
                        timerBashke.Start();

                        toolStripStatusLabelRECORD_TEXT.Text = String.Format("Duke Inqizuar {0}...", nameBashke);
                        toolStripStatusLabelRECORD_TEXT.ForeColor = Color.Green;
                    }
                    break;

                default:
                    break;
            }

            txtRuajVideo.Text = "";
        }

        private void txtRuajVideo_TextChanged(object sender, EventArgs e)
        {
            if (txtRuajVideo.Text != "")
                btnRuajVideon.Enabled = true;
            else
                btnRuajVideon.Enabled = false;
        }

        private void txtRuajVideo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)                       // Nese eshte shtypur "Enter" performo shtypjen e btnKonfirmo                         
                btnRuajVideon.PerformClick();
            if (e.KeyChar == '.' || e.KeyChar == '\\' || e.KeyChar == '|' || e.KeyChar == '_')
            {
                e.Handled = true;
                MessageBox.Show("Nuk Lejohet Karakteret '.', '\', '|', '_' !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timerNiveli_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(String.Format(@"Vlerat e Inqizimeve\{0}.txt", nameNiveli)))
                {
                    sw = new StreamWriter(String.Format(@"Vlerat e Inqizimeve\{0}.txt", nameNiveli));         // Krijo file-in te zbrazet  
                    sw.WriteLine(String.Format("{0},{1}", form1.KohaVideo.ToString(), form1.VleraVideoNiveli));    // Shkruaje vleren e pare
                }
                else if (emriVideo != "")
                {
                    sw = new StreamWriter(String.Format(@"Vlerat e Inqizimeve\{0}.txt", nameNiveli), true);       // true = Append
                    sw.WriteLine(String.Format("{0},{1}", form1.KohaVideo.ToString(), form1.VleraVideoNiveli));     // Vazhdo me shkruarjen e vlerave
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ka Ndodhur nje Problem Gjate Ruajtjes !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sw.Close();
            }
        }

        private void timerTemperatura_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(String.Format(@"Vlerat e Inqizimeve\{0}.txt", nameTemperatura)))
                {
                    sw = new StreamWriter(String.Format(@"Vlerat e Inqizimeve\{0}.txt", nameTemperatura));         // Krijo file-in te zbrazet  
                    sw.WriteLine(String.Format("{0},{1}", form1.KohaVideo.ToString(), form1.VleraVideoTemperatura));    // Shkruaje vleren e pare
                }
                else if (emriVideo != "")
                {
                    sw = new StreamWriter(String.Format(@"Vlerat e Inqizimeve\{0}.txt", nameTemperatura), true);       // true = Append
                    sw.WriteLine(String.Format("{0},{1}", form1.KohaVideo.ToString(), form1.VleraVideoTemperatura));     // Vazhdo me shkruarjen e vlerave
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ka Ndodhur nje Problem Gjate Ruajtjes !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sw.Close();
            }
        }

        private void timerBashke_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(String.Format(@"Vlerat e Inqizimeve\{0}.txt", nameBashke)))
                {
                    sw = new StreamWriter(String.Format(@"Vlerat e Inqizimeve\{0}.txt", nameBashke));         // Krijo file-in te zbrazet  
                    sw.WriteLine(String.Format("{0},{1}", form1.KohaVideo.ToString(), form1.VleraVideoBashke));    // Shkruaje vleren e pare
                }
                else if (emriVideo != "")
                {
                    sw = new StreamWriter(String.Format(@"Vlerat e Inqizimeve\{0}.txt", nameBashke), true);       // true = Append
                    sw.WriteLine(String.Format("{0},{1}", form1.KohaVideo.ToString(), form1.VleraVideoBashke));     // Vazhdo me shkruarjen e vlerave
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ka Ndodhur nje Problem Gjate Ruajtjes !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sw.Close();
            }
        }

        private void btnStopVideo_Click(object sender, EventArgs e)
        {
            toolStripStatusLabelRECORD_ANIMACION.Image = FIEK_SCADA.Properties.Resources.RecordOFF;
            btnRuajVideon.Enabled = true;

            switch (variabelNdihmese)
            {
                case "Niveli":
                    {
                        timerNiveli.Stop();
                        toolStripStatusLabelRECORD_TEXT.Text = String.Format("Inqizimi i {0} ka Perfunduar", nameNiveli);
                    }
                    break;

                case "Temperatura":
                    {
                        timerTemperatura.Stop();
                        toolStripStatusLabelRECORD_TEXT.Text = String.Format("Inqizimi i {0} ka Perfunduar", nameTemperatura);
                    }
                    break;

                case "Bashke":
                    {
                        timerBashke.Stop();
                        toolStripStatusLabelRECORD_TEXT.Text = String.Format("Inqizimi i {0} ka Perfunduar", nameBashke);
                    }
                    break;

                default:
                    break;
            }
            toolStripStatusLabelRECORD_TEXT.ForeColor = Color.Red;
        }

        private void Inqizo_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnStopVideo.PerformClick();
            e.Cancel = false;        // Mbylle
        }

        private void btnLuajVideon_Click(object sender, EventArgs e)
        {
            string ruajPerkohesisht;
            int numriRreshtave = 0;
            int i = 0;

            if (listBox1.SelectedIndex != -1 && listBox1.SelectedItem.ToString().Contains("_Nivel_Graf"))
            {
                try
                {
                    sr = new StreamReader(String.Format(@"Vlerat e Inqizimeve\{0}.txt", listBox1.SelectedItem.ToString()));
                    if (File.Exists(String.Format(@"Vlerat e Inqizimeve\{0}.txt", listBox1.SelectedItem.ToString())))
                    {
                        numriRreshtave = File.ReadAllLines(String.Format(@"Vlerat e Inqizimeve\{0}.txt", listBox1.SelectedItem.ToString())).Length;
                        transmetoKohen = new string[numriRreshtave];
                        transmetoVleren0 = new string[numriRreshtave];

                        while (!sr.EndOfStream)
                        {
                            ruajPerkohesisht = sr.ReadLine().ToString();
                            transmetoKohen[i] = ruajPerkohesisht.Split(',')[0];
                            transmetoVleren0[i] = ruajPerkohesisht.Split(',')[1];
                            i++;
                        }
                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                ciliGrafVideo = 1;      // Niveli                
            }
            else if (listBox1.SelectedIndex != -1 && listBox1.SelectedItem.ToString().Contains("_Temperature_Graf"))
            {
                try
                {
                    sr = new StreamReader(String.Format(@"Vlerat e Inqizimeve\{0}.txt", listBox1.SelectedItem.ToString()));
                    if (File.Exists(String.Format(@"Vlerat e Inqizimeve\{0}.txt", listBox1.SelectedItem.ToString())))
                    {
                        numriRreshtave = File.ReadAllLines(String.Format(@"Vlerat e Inqizimeve\{0}.txt", listBox1.SelectedItem.ToString())).Length;
                        transmetoKohen = new string[numriRreshtave];
                        transmetoVleren0 = new string[numriRreshtave];

                        while (!sr.EndOfStream)
                        {
                            ruajPerkohesisht = sr.ReadLine().ToString();
                            transmetoKohen[i] = ruajPerkohesisht.Split(',')[0];
                            transmetoVleren0[i] = ruajPerkohesisht.Split(',')[1];
                            i++;
                        }
                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                ciliGrafVideo = 2;      // Temperatura
            }
            else if (listBox1.SelectedIndex != -1 && listBox1.SelectedItem.ToString().Contains("_Bashke_Graf"))
            {
                try
                {
                    sr = new StreamReader(String.Format(@"Vlerat e Inqizimeve\{0}.txt", listBox1.SelectedItem.ToString()));
                    if (File.Exists(String.Format(@"Vlerat e Inqizimeve\{0}.txt", listBox1.SelectedItem.ToString())))
                    {
                        numriRreshtave = File.ReadAllLines(String.Format(@"Vlerat e Inqizimeve\{0}.txt", listBox1.SelectedItem.ToString())).Length;
                        transmetoKohen = new string[numriRreshtave];
                        transmetoVleren0 = new string[numriRreshtave];
                        transmetoVleren1 = new string[numriRreshtave];

                        while (!sr.EndOfStream)
                        {
                            ruajPerkohesisht = sr.ReadLine().ToString();
                            transmetoKohen[i] = ruajPerkohesisht.Split(',')[0];
                            transmetoVleren0[i] = (ruajPerkohesisht.Split(',')[1]).Split('|')[0];
                            transmetoVleren1[i] = ruajPerkohesisht.Split('|')[1];
                            i++;
                        }
                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                ciliGrafVideo = 3;      // Bashke
            }
            else
            {
                MessageBox.Show("Ju Lutem Zgjedheni nje prej Inqizimeve me siper !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            }
        }

        private void btnFshijVideon_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                try
                {
                    DialogResult res = MessageBox.Show(String.Format("A jeni i Sigurt qe Deshironi ta Fshini Inqizimin {0} ?", listBox1.SelectedItem.ToString()), "Njoftim", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (res == System.Windows.Forms.DialogResult.OK)
                    {
                        File.Delete(String.Format(@"Vlerat e Inqizimeve\{0}.txt", listBox1.SelectedItem.ToString()));

                        listBox1.Items.Clear();
                        string[] fileVideos = Directory.GetFiles(@"Vlerat e Inqizimeve", "*.txt");

                        foreach (var name in fileVideos)
                        {
                            listBox1.Items.Add((name.Split('\\')[1]).Split('.')[0]);
                        }

                        MessageBox.Show("Fshirja e Inqizimit eshte Kryer me Sukses !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fshirja e Inqizimit nuk eshte Kryer me Sukses !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ju Lutem Zgjedheni nje prej Inqizimeve me siper !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnStatistik_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                try
                {
                    filePath = String.Format(@"C:\Users\{0}\Desktop\{1}.txt", userNamePC, listBox1.SelectedItem.ToString());
                    if (!File.Exists(filePath))
                    {
                        KrijoFilePerStatistikaFunction();
                        MessageBox.Show(String.Format(@"Krijimi i Fajlit eshte Kryer me Sukses !{0}Fajllit Mund te ju Qaseni ne Lokacionin 'C:\Users\{1}\Desktop\{2}.txt'", "\n", userNamePC, listBox1.SelectedItem.ToString()), "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);                                         
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show(String.Format(@"Nje Fajll me Emrin e njejte veqme Egziston ne Lokacionin 'C:\Users\{1}\Desktop\{2}.txt' {3}A deshironi ta mbishkruani kete Fajll ?", "\n", userNamePC, listBox1.SelectedItem.ToString(), "\n"), "Njoftim", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);                        
                        if(res == System.Windows.Forms.DialogResult.OK)
                        {
                            File.Delete(filePath);
                            KrijoFilePerStatistikaFunction();
                            MessageBox.Show(String.Format(@"Fajli eshte Mbishkruar me Sukses !{0}Fajllit Mund te ju Qaseni ne Lokacionin 'C:\Users\{1}\Desktop\{2}.txt'", "\n", userNamePC, listBox1.SelectedItem.ToString()), "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);                                         
                        }
                    }                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Krijimi i Fajlit nuk eshte Kryer me Sukses !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ju Lutem Zgjedheni nje prej Inqizimeve me siper !", "Njoftim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void KrijoFilePerStatistikaFunction()
        {
            string currentContent = File.ReadAllText(String.Format(@"Vlerat e Inqizimeve\{0}.txt", listBox1.SelectedItem.ToString()));
            if (listBox1.SelectedItem.ToString().Split('_')[1] == "Nivel")
            {
                newContent1 = "Koha [s], Niveli [cm]";
                newContent2 = "----------------------";
            }
            else if (listBox1.SelectedItem.ToString().Split('_')[1] == "Temperature")
            {
                newContent1 = "Koha [s], Temperatura [°C]";
                newContent2 = "---------------------------";
            }
            else if (listBox1.SelectedItem.ToString().Split('_')[1] == "Bashke")
            {
                newContent1 = "Koha [s], Niveli [cm] | Temperatura [°C]";
                newContent2 = "-----------------------------------------";
            }
            File.WriteAllText(filePath, newContent1 + Environment.NewLine + newContent2 + Environment.NewLine + currentContent);            
        }

        #endregion        
    }
}
