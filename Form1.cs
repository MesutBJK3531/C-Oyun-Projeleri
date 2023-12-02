using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Oyun_Denemesi
{
    public partial class Form1 : Form
    {
        int boruhizi = 8;
        int gravity = 10;
        int score = 0;


        public Form1()
        {
            
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            
            pbKartal.Top += gravity;

            pbPipeAlt.Left -= boruhizi; 
            pbPipeUst.Left -= boruhizi;
            lblScore.Text="SCORE"+score;

            if (pbPipeAlt.Left < -150)
            {
                pbPipeAlt.Left = 800;
                score++;
            }

            if (pbPipeUst.Left < -180)
            {
                pbPipeUst.Left = 950;
            }

            if (pbKartal.Bounds.IntersectsWith(pbPipeAlt.Bounds) || pbKartal.Bounds.IntersectsWith(pbPipeUst.Bounds) || pbKartal.Bounds.IntersectsWith(pbZemin.Bounds))
            {
                //Çarpışma
                oyunbittimi();
                
                if (score > 5)
                {
                    boruhizi = 15;
                }
                if (pbKartal.Top < -25)
                {
                    oyunbittimi();
                }
            }

            if (gravity < 10)
                gravity++;
        }
         

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
                
            }
            else if(e.KeyCode == Keys.Return)
            {
                gameTimer.Start();
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 1;
            }
        }

           private void oyunbittimi()
          {
               gameTimer.Stop();
               lblScore.Text="GAME OVER!!!";
          }
    }
}
