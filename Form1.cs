using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Savaş_Uçağı_Oyunu
{
    public partial class Form1 : Form
    {

        int solhareket = 0;
        int ucakhareketihizi =10;
        Random rnd = new Random();
        int mermihizi = 25;
        bool ates = false;
        int puan = 0;
      
      

        public Form1()
        {
            InitializeComponent();
            pbDusmanucak1.Top = -500;
            pbDusmanucak2.Top = -900;
            pbDusmanucak3.Top = -1300;
            pbMermi.Top = -100;
            pbMermi.Left = -100;
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timer1.Start();
            }
            if (e.KeyCode == Keys.P)
            {
                timer1.Stop();
            }

            if (e.KeyCode == Keys.Left)
            {
                if (pbUcak.Location.X < 0) { solhareket = 0; } else { solhareket = -10; }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (pbUcak.Location.X > 512)
                {
                    solhareket = 0;
                }
                else
                {
                    solhareket = 10;
                }
            }
            else if (e.KeyCode == Keys.Space)
            {

                if (ates == false)
                {
                    mermihizi = 8;
                    pbMermi.Left = pbUcak.Left + 40;
                    pbMermi.Top = pbUcak.Top;
                    ates = true;
                }
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                solhareket = 0;
            }
            else if (e.KeyCode == Keys.Right)
            {
                solhareket = 0;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            pbUcak.Left += solhareket;
            pbMermi.Top -= mermihizi;
            pbDusmanucak1.Top += ucakhareketihizi;
            pbDusmanucak2.Top += ucakhareketihizi;
            pbDusmanucak3.Top += ucakhareketihizi;
            lblSkor.Text = "" + puan;
      
                if (pbUcak.Bounds.IntersectsWith(pbDusmanucak1.Bounds) || (pbUcak.Bounds.IntersectsWith(pbDusmanucak2.Bounds) ||( pbUcak.Bounds.IntersectsWith(pbDusmanucak3.Bounds))))
            {
                oyunSonu();

            }
            if (ates && pbMermi.Top < 0)
            {
                ates = false;
                mermihizi = 0;
                pbMermi.Top = -100;
                pbMermi.Left = -100;
            }
            Vurulma();
        }

        private void oyunSonu()
        {
            timer1.Enabled = false;
            MessageBox.Show(puan + " Puan Kazandınız....");
            puan = 0;
            lblSkor.Text = "0";
            pbDusmanucak1.Top = -500;
            pbDusmanucak2.Top = -900;
            pbDusmanucak3.Top = -1300;
            pbMermi.Top = -100;
            pbMermi.Left = -100;
            timer1.Enabled = true;
        }

        private void Vurulma()
        {
            if (pbMermi.Bounds.IntersectsWith(pbDusmanucak1.Bounds))
            {
                puan += 1;
                pbDusmanucak1.Top = -500;
                int ranP = rnd.Next(1, 300);
                pbDusmanucak1.Left = ranP;
                ates = false;
                mermihizi = 0;
                pbMermi.Top = -100;
                pbMermi.Left = -100;


            }
            else if (pbMermi.Bounds.IntersectsWith(pbDusmanucak2.Bounds))
            {
                puan += 1;
                pbDusmanucak2.Top = -900;
                int ranP = rnd.Next(1, 400);
                pbDusmanucak2.Left = ranP;
                ates = false;
                mermihizi = 0;
                pbMermi.Top = -100;
                pbMermi.Left = -100;

            }
            else if (pbMermi.Bounds.IntersectsWith(pbDusmanucak3.Bounds))
            {
                puan += 1;
                pbDusmanucak3.Top = -1300;
                int ranP = rnd.Next(1, 500);
                pbDusmanucak3.Left = ranP;
                ates = false;
                mermihizi = 0;
                pbMermi.Top = -100;
                pbMermi.Left = -100;

            }

        }
    }
}



      

