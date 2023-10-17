using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainAlgorithms
{
    public partial class Form1 : Form
    {
        public static Form1 gui;
        private int startX, startY;
        private int stopX, stopY;
        Graph gares = new Graph();
        string startStation, stopStation = null;
        int index = 0;
        IDictionary<string, int> posX = new Dictionary<string, int>(), posY = new Dictionary<string,int>();
        public Form1()
        {
            InitializeComponent();
            gui = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initialisationGares();
            textBox1.ReadOnly = true;
        }

        public void WriteStations(string mess)
        {
            textBox1.Text += mess;
        }

        public void WriteStats(string mess)
        {
            textBox2.Text += mess;
        }

        //méthodes boutons
        #region Actions Boutons

        // Bouton DFS
        private void button1_Click(object sender, EventArgs e)
        {
            if (startBox.SelectedItem == null || stopBox.SelectedItem == null)
            {
                MessageBox.Show("Sélectionner les gares de départ et d'arrivée!");
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                algoStart();
                gares.DFS(startStation, stopStation);
            }
        }

        // Bouton IDDFS
        private void button2_Click(object sender, EventArgs e)
        {
            if (startBox.SelectedItem == null || stopBox.SelectedItem == null)
            {
                MessageBox.Show("Sélectionner les gares de départ et d'arrivée!");
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                algoStart();
                gares.IDDFS(startStation, stopStation);
            }
        }

        // Bouton Hill Climbing
        private void button3_Click(object sender, EventArgs e)
        {
            if (startBox.SelectedItem == null || stopBox.SelectedItem == null)
            {
                MessageBox.Show("Sélectionner les gares de départ et d'arrivée!");
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                algoStart();
                gares.HillClimbing(startStation, stopStation);
            }
        }

        // Bouton Greedy Search
        private void button4_Click(object sender, EventArgs e)
        {
            if(startBox.SelectedItem == null || stopBox.SelectedItem == null)
            {
                MessageBox.Show("Sélectionner les gares de départ et d'arrivée!");
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                algoStart();
                gares.GreedySearch(startStation, stopStation);
            }
        }

        // Bouton A*
        private void button5_Click(object sender, EventArgs e)
        {
            if(startBox.SelectedItem == null || stopBox.SelectedItem == null)
            {
                MessageBox.Show("Sélectionner les gares de départ et d'arrivée!");
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                algoStart();
                gares.Astar(startStation, stopStation);
            }
        }

        private void algoStart()
        {
            Graphics g = pictureBox1.CreateGraphics();
            if (startX != 0)
            {
                Pen pen0 = new Pen(Color.Red, 3);
                Rectangle startOld = new Rectangle(startX, startY, 5, 5);
                Rectangle stopOld = new Rectangle(stopX, stopY, 5, 5);
                g.DrawEllipse(pen0, startOld);
                g.DrawEllipse(pen0, stopOld);
            }
            startStation = startBox.SelectedItem.ToString();
            stopStation = stopBox.SelectedItem.ToString();
            Pen pen = new Pen(Color.Blue, 3);
            Rectangle start = new Rectangle(posX[startStation], posY[startStation], 5, 5);
            Rectangle stop = new Rectangle(posX[stopStation], posY[stopStation], 5, 5);
            startX = posX[startStation];
            startY = posY[startStation];
            stopX = posX[stopStation];
            stopY = posY[stopStation];
            g.DrawEllipse(pen, start);
            g.DrawEllipse(pen, stop);
        }
        #endregion 

        //initialisation du GUI
        #region FormsInfo
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 2);
            Pen road = new Pen(Color.Black, 1);
            Font f = new Font("Arial", 7);
            SolidBrush b = new SolidBrush(Color.Black);
            StringFormat sf = new StringFormat();
            Rectangle brg = new Rectangle(posX["Brugge"], posY["Brugge"], 5, 5);
            Rectangle lch = new Rectangle(posX["Lichtervelde"], posY["Lichtervelde"], 5, 5);
            Rectangle krt = new Rectangle(posX["Kortrijk"], posY["Kortrijk"], 5, 5);
            Rectangle dnz = new Rectangle(posX["Deinze"], posY["Deinze"], 5, 5);
            Rectangle gent = new Rectangle(posX["Gent"], posY["Gent"], 5, 5);
            Rectangle trn = new Rectangle(posX["Tournai"], posY["Tournai"], 5, 5);
            Rectangle oud = new Rectangle(posX["Oudenaarde"], posY["Oudenaarde"], 5, 5);
            Rectangle ath = new Rectangle(posX["Ath"], posY["Ath"], 5, 5);
            Rectangle mns = new Rectangle(posX["Mons"], posY["Mons"], 5, 5);
            Rectangle grm = new Rectangle(posX["Grammont"], posY["Grammont"], 5, 5);
            Rectangle trm = new Rectangle(posX["Termonde"], posY["Termonde"], 5, 5);
            Rectangle lok = new Rectangle(posX["Lokeren"], posY["Lokeren"], 5, 5);
            Rectangle eng = new Rectangle(posX["Enghien"], posY["Enghien"], 5, 5);
            Rectangle zot = new Rectangle(posX["Zottegem"], posY["Zottegem"], 5, 5);
            Rectangle dnd = new Rectangle(posX["Denderleew"], posY["Denderleew"], 5, 5);
            Rectangle als = new Rectangle(posX["Aalst"], posY["Aalst"], 5, 5);
            Rectangle anv = new Rectangle(posX["Anvers-Central"], posY["Anvers-Central"], 5, 5);
            Rectangle mal = new Rectangle(posX["Malines"], posY["Malines"], 5, 5);
            Rectangle bxl = new Rectangle(posX["Bruxelles-Midi"], posY["Bruxelles-Midi"], 5, 5);
            Rectangle soi = new Rectangle(posX["Soignies"], posY["Soignies"], 5, 5);
            Rectangle leu = new Rectangle(posX["Leuven"], posY["Leuven"], 5, 5);
            Rectangle her = new Rectangle(posX["Herentals"], posY["Herentals"], 5, 5);
            Rectangle aar = new Rectangle(posX["Aarschot"], posY["Aarschot"], 5, 5);
            Rectangle crl = new Rectangle(posX["Charleroi-Sud"], posY["Charleroi-Sud"], 5, 5);
            Rectangle ott = new Rectangle(posX["Ottignies"], posY["Ottignies"], 5, 5);
            Rectangle nam = new Rectangle(posX["Namur"], posY["Namur"], 5, 5);
            Rectangle hsl = new Rectangle(posX["Hasselt"], posY["Hasselt"], 5, 5);
            Rectangle lan = new Rectangle(posX["Landen"], posY["Landen"], 5, 5);
            Rectangle lgg = new Rectangle(posX["Liège-Guillemins"], posY["Liège-Guillemins"], 5, 5);
            Rectangle lib = new Rectangle(posX["Libramont"], posY["Libramont"], 5, 5);
            Rectangle mrl = new Rectangle(posX["Marloie"], posY["Marloie"], 5, 5);

            e.Graphics.DrawString("Brugge", f, b, posX["Brugge"]-15, posY["Brugge"] - 15, sf);
            e.Graphics.DrawString("Gent", f, b, posX["Gent"]-15, posY["Gent"] - 15, sf);
            e.Graphics.DrawString("Lichtervelde", f, b, posX["Lichtervelde"]-55, posY["Lichtervelde"] - 10, sf);
            e.Graphics.DrawString("Deinze", f, b, posX["Deinze"]-20, posY["Deinze"] - 15, sf);
            e.Graphics.DrawString("Kortrijk", f, b, posX["Kortrijk"] - 35, posY["Kortrijk"] - 10, sf);
            e.Graphics.DrawString("Oudenaarde", f, b, posX["Oudenaarde"] - 20, posY["Oudenaarde"] + 10, sf);
            e.Graphics.DrawString("Tournai", f, b, posX["Tournai"] - 15, posY["Tournai"] +10, sf);
            e.Graphics.DrawString("Zottegem", f, b, posX["Zottegem"] - 15, posY["Zottegem"] - 15, sf);
            e.Graphics.DrawString("Aalst", f, b, posX["Aalst"] - 10, posY["Aalst"] - 15, sf);
            e.Graphics.DrawString("Denderleew", f, b, posX["Denderleew"] - 15, posY["Denderleew"] - 15, sf);
            e.Graphics.DrawString("Grammont", f, b, posX["Grammont"] - 15, posY["Grammont"] - 15, sf);
            e.Graphics.DrawString("Termonde", f, b, posX["Termonde"] - 15, posY["Termonde"] - 15, sf);
            e.Graphics.DrawString("Bruxelles-Midi", f, b, posX["Bruxelles-Midi"] - 15, posY["Bruxelles-Midi"] - 15, sf);
            e.Graphics.DrawString("Malines", f, b, posX["Malines"] - 15, posY["Malines"] - 15, sf);
            e.Graphics.DrawString("Leuven", f, b, posX["Leuven"] - 15, posY["Leuven"] - 15, sf);
            e.Graphics.DrawString("Herentals", f, b, posX["Herentals"] - 15, posY["Herentals"] - 15, sf);
            e.Graphics.DrawString("Hasselt", f, b, posX["Hasselt"] - 5, posY["Hasselt"] - 15, sf);
            e.Graphics.DrawString("Aarschot", f, b, posX["Aarschot"] - 15, posY["Aarschot"] - 15, sf);
            e.Graphics.DrawString("Ottignies", f, b, posX["Ottignies"] +10, posY["Ottignies"]-5, sf);
            e.Graphics.DrawString("Charleroi-Sud", f, b, posX["Charleroi-Sud"] - 20, posY["Charleroi-Sud"] + 10, sf);
            e.Graphics.DrawString("Ath", f, b, posX["Ath"] - 15, posY["Ath"] - 15, sf);
            e.Graphics.DrawString("Enghien", f, b, posX["Enghien"] - 15, posY["Enghien"] + 10, sf);
            e.Graphics.DrawString("Mons", f, b, posX["Mons"] - 15, posY["Mons"] + 10, sf);
            e.Graphics.DrawString("Soignies", f, b, posX["Soignies"] +10, posY["Soignies"]-5, sf);
            e.Graphics.DrawString("Marloie", f, b, posX["Marloie"] + 10, posY["Marloie"] , sf);
            e.Graphics.DrawString("Liège-Guillemins", f, b, posX["Liège-Guillemins"] + 10, posY["Liège-Guillemins"], sf);
            e.Graphics.DrawString("Lokeren", f, b, posX["Lokeren"] - 15, posY["Lokeren"] - 15, sf);
            e.Graphics.DrawString("Anvers-Central", f, b, posX["Anvers-Central"] - 15, posY["Anvers-Central"] - 15, sf);
            e.Graphics.DrawString("Libramont", f, b, posX["Libramont"] - 20, posY["Libramont"] + 10, sf);
            e.Graphics.DrawString("Namur", f, b, posX["Namur"] +10, posY["Namur"], sf);
            e.Graphics.DrawString("Landen", f, b, posX["Landen"] - 15, posY["Landen"] + 10, sf);

            e.Graphics.DrawEllipse(pen, brg);
            e.Graphics.DrawEllipse(pen, lch);
            e.Graphics.DrawEllipse(pen, krt);
            e.Graphics.DrawEllipse(pen, dnz);
            e.Graphics.DrawEllipse(pen, gent);
            e.Graphics.DrawEllipse(pen, trn);
            e.Graphics.DrawEllipse(pen, oud);
            e.Graphics.DrawEllipse(pen, ath);
            e.Graphics.DrawEllipse(pen, mns);
            e.Graphics.DrawEllipse(pen, grm);
            e.Graphics.DrawEllipse(pen, trm);
            e.Graphics.DrawEllipse(pen, lok);
            e.Graphics.DrawEllipse(pen, eng);
            e.Graphics.DrawEllipse(pen, zot);
            e.Graphics.DrawEllipse(pen, dnd);
            e.Graphics.DrawEllipse(pen, als);
            e.Graphics.DrawEllipse(pen, anv);
            e.Graphics.DrawEllipse(pen, mal);
            e.Graphics.DrawEllipse(pen, soi);
            e.Graphics.DrawEllipse(pen, bxl);
            e.Graphics.DrawEllipse(pen, leu);
            e.Graphics.DrawEllipse(pen, ott);
            e.Graphics.DrawEllipse(pen, bxl);
            e.Graphics.DrawEllipse(pen, crl);
            e.Graphics.DrawEllipse(pen, her);
            e.Graphics.DrawEllipse(pen, aar);
            e.Graphics.DrawEllipse(pen, nam);
            e.Graphics.DrawEllipse(pen, hsl);
            e.Graphics.DrawEllipse(pen, lan);
            e.Graphics.DrawEllipse(pen, lgg);
            e.Graphics.DrawEllipse(pen, lib);
            e.Graphics.DrawEllipse(pen, mrl);
            e.Graphics.DrawLine(road, brg.X, brg.Y, gent.X, gent.Y);
            e.Graphics.DrawLine(road, brg.X, brg.Y, lch.X, lch.Y);
            e.Graphics.DrawLine(road, lch.X, lch.Y, krt.X, krt.Y);
            e.Graphics.DrawLine(road, lch.X, lch.Y, dnz.X, dnz.Y);
            e.Graphics.DrawLine(road, dnz.X, dnz.Y, krt.X, krt.Y);
            e.Graphics.DrawLine(road, dnz.X, dnz.Y, gent.X, gent.Y);
            e.Graphics.DrawLine(road, krt.X, krt.Y, trn.X, trn.Y);
            e.Graphics.DrawLine(road, krt.X, krt.Y, oud.X, oud.Y);
            e.Graphics.DrawLine(road, oud.X, oud.Y, gent.X, gent.Y);
            e.Graphics.DrawLine(road, oud.X, oud.Y, zot.X, zot.Y);
            e.Graphics.DrawLine(road, gent.X, gent.Y, lok.X, lok.Y);
            e.Graphics.DrawLine(road, gent.X, gent.Y, trm.X, trm.Y);
            e.Graphics.DrawLine(road, gent.X, gent.Y, als.X, als.Y);
            e.Graphics.DrawLine(road, gent.X, gent.Y, zot.X, zot.Y);
            e.Graphics.DrawLine(road, zot.X, zot.Y, als.X, als.Y);
            e.Graphics.DrawLine(road, zot.X, zot.Y, dnd.X, dnd.Y);
            e.Graphics.DrawLine(road, zot.X, zot.Y, grm.X, grm.Y);
            e.Graphics.DrawLine(road, dnd.X, dnd.Y, als.X, als.Y);
            e.Graphics.DrawLine(road, dnd.X, dnd.Y, grm.X, grm.Y);
            e.Graphics.DrawLine(road, dnd.X, dnd.Y, bxl.X, bxl.Y);
            e.Graphics.DrawLine(road, trm.X, trm.Y, mal.X, mal.Y);
            e.Graphics.DrawLine(road, trm.X, trm.Y, lok.X, lok.Y);
            e.Graphics.DrawLine(road, trm.X, trm.Y, bxl.X, bxl.Y);
            e.Graphics.DrawLine(road, bxl.X, bxl.Y, mal.X, mal.Y);
            e.Graphics.DrawLine(road, bxl.X, bxl.Y, leu.X, leu.Y);
            e.Graphics.DrawLine(road, bxl.X, bxl.Y, soi.X, soi.Y);
            e.Graphics.DrawLine(road, bxl.X, bxl.Y, eng.X, eng.Y);
            e.Graphics.DrawLine(road, bxl.X, bxl.Y, crl.X, crl.Y);
            e.Graphics.DrawLine(road, bxl.X, bxl.Y, ott.X, ott.Y);
            e.Graphics.DrawLine(road, anv.X, anv.Y, mal.X, mal.Y);
            e.Graphics.DrawLine(road, anv.X, anv.Y, lok.X, lok.Y);
            e.Graphics.DrawLine(road, anv.X, anv.Y, her.X, her.Y);
            e.Graphics.DrawLine(road, anv.X, anv.Y, aar.X, aar.Y);
            e.Graphics.DrawLine(road, mal.X, mal.Y, leu.X, leu.Y);
            e.Graphics.DrawLine(road, leu.X, leu.Y, aar.X, aar.Y);
            e.Graphics.DrawLine(road, leu.X, leu.Y, ott.X, ott.Y);
            e.Graphics.DrawLine(road, leu.X, leu.Y, lan.X, lan.Y);
            e.Graphics.DrawLine(road, her.X, her.Y, hsl.X, hsl.Y);
            e.Graphics.DrawLine(road, hsl.X, hsl.Y, aar.X, aar.Y);
            e.Graphics.DrawLine(road, hsl.X, hsl.Y, lgg.X, lgg.Y);
            e.Graphics.DrawLine(road, hsl.X, hsl.Y, lan.X, lan.Y);
            e.Graphics.DrawLine(road, lan.X, lan.Y, lgg.X, lgg.Y);
            e.Graphics.DrawLine(road, ott.X, ott.Y, nam.X, nam.Y);
            e.Graphics.DrawLine(road, ott.X, ott.Y, crl.X, crl.Y);
            e.Graphics.DrawLine(road, crl.X, crl.Y, nam.X, nam.Y);
            e.Graphics.DrawLine(road, crl.X, crl.Y, mns.X, mns.Y);
            e.Graphics.DrawLine(road, crl.X, crl.Y, soi.X, soi.Y);
            e.Graphics.DrawLine(road, mns.X, mns.Y, soi.X, soi.Y);
            e.Graphics.DrawLine(road, mns.X, mns.Y, trn.X, trn.Y);
            e.Graphics.DrawLine(road, trn.X, trn.Y, ath.X, ath.Y);
            e.Graphics.DrawLine(road, ath.X, ath.Y, grm.X, grm.Y);
            e.Graphics.DrawLine(road, ath.X, ath.Y, eng.X, eng.Y);
            e.Graphics.DrawLine(road, ath.X, ath.Y, soi.X, soi.Y);
            e.Graphics.DrawLine(road, grm.X, grm.Y, eng.X, eng.Y);
            e.Graphics.DrawLine(road, nam.X, nam.Y, lgg.X, lgg.Y);
            e.Graphics.DrawLine(road, nam.X, nam.Y, mrl.X, mrl.Y);
            e.Graphics.DrawLine(road, nam.X, nam.Y, lib.X, lib.Y);
            e.Graphics.DrawLine(road, mrl.X, mrl.Y, lgg.X, lgg.Y);
            e.Graphics.DrawLine(road, mrl.X, mrl.Y, lib.X, lib.Y);
        }

        private void initialisationGares()
        {
            string[] station = { "Brugge", "Gent", "Lichtervelde", "Deinze", "Kortrijk", "Oudenaarde", "Tournai",
                                       "Zottegem", "Aalst", "Denderleew", "Grammont", "Termonde","Bruxelles-Midi",
                                       "Malines", "Leuven", "Herentals", "Hasselt", "Aarschot", "Ottignies",
                                       "Charleroi-Sud", "Ath", "Enghien", "Mons", "Soignies", "Marloie",
                                       "Liège-Guillemins", "Lokeren", "Anvers-Central", "Libramont", "Namur", "Landen" };
            int[] coordX = { 170,270,150,230,170,250,200,300,340,350,320,360,430,450,510,550,650,550,460,450,300,350,
                             330,355,650,700,330,440,670,560,600 };
            int[] coordY = { 130,185,190,210,260,250,335,240,215,240,280,190,260,190,240,140,215,210,310,420,330,300,
                             400,360,500,330,150,120,600,400,290 };
            for(int i = 0; i < station.Length; i++)
            {
                posX.Add(station[i],coordX[i]); 
                posY.Add(station[i],coordY[i]);
                startBox.Items.Add(station[i]);
                stopBox.Items.Add(station[i]);
            }

        }
        #endregion
    }
}
