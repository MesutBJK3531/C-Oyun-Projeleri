using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        List<int> liste = new List<int>();
        Random rnd = new Random();
        int siradakiOyuncu = 0;
        int puan1 = 0;
        int puan2 = 0;
        bool pas1 = false;
        bool pas2 = false;

        public Form1()
        {
            InitializeComponent();
        }

        private string KartAdiBul(int kart)
        {
            //0-KARO  1=KUPA  2=MAÇA  3 = SİNEK
            int sayi = kart;

            int grup = sayi / 13;
            int sira = sayi % 13 + 1;

            string kartAdi = "";

            if (grup == 0) kartAdi = "Karo" + sira;
            else if (grup == 1) kartAdi = "Kupa" + sira;
            else if (grup == 2) kartAdi = "Maca" + sira;
            else if (grup == 3) kartAdi = "Sinek" + sira;

            return kartAdi;
        }

        private int KartDegeriniBul(int kart)
        {
            return kart % 13 + 1;
        }

        private void btnKartCek_Click(object sender, EventArgs e)
        {
            pas1 = pas2 = false;

            if (liste.Count <= 0)
            {
                MessageBox.Show("Kart kalmadı");
                return;
            }

            string kartAdi = KartAdiBul(liste[0]);//çektiim ilk sıradaki

            //pictureBox2.Image = (Image)Properties.Resources.ResourceManager.GetObject(kartAdi);

            PictureBox pb = new PictureBox();
            pb.Size = pictureBox1.Size;

            pb.Image = (Image)Properties.Resources.ResourceManager.GetObject(kartAdi);
            
            
            
            
            pb.Visible = true;

            int deger = KartDegeriniBul(liste[0]);


            if (siradakiOyuncu == 0)
            {
                pb.Location = new Point(pnlOyuncu1.Controls.Count * 20, 0);
                pnlOyuncu1.Controls.Add(pb);

                puan1 += deger;
                lblPuan1.Text = puan1.ToString();
            }
            else
            {
                pb.Location = new Point(pnlOyuncu2.Controls.Count * 20, 0);
                pnlOyuncu2.Controls.Add(pb);
                puan2 += deger;
                lblPuan2.Text = puan2.ToString();
            }

            pb.BringToFront();

            liste.RemoveAt(0);//çektiğim kartı listeden sil

            lblDesteSayisi.Text = liste.Count.ToString();

            if (liste.Count <= 0)
                pictureBox1.Image = null;


            if (OyunBittiMi())
            {
                OyunBitir();
                pnlSkor.Visible = true;
            }
            else SiradakiOyuncuDegistir();
        }

        private void SiradakiOyuncuDegistir()
        {
            siradakiOyuncu = (siradakiOyuncu + 1) % 2;

            if (siradakiOyuncu == 0)
            {
                lblSiraSizde.Left = pnlOyuncu1.Left;
                pnlButonlar.Left = pnlOyuncu1.Left;
            }
            else
            {
                lblSiraSizde.Left = pnlOyuncu2.Left;
                pnlButonlar.Left = pnlOyuncu2.Left;
            }
        }

        private bool OyunBittiMi()
        {
            if (puan1 >= 21 || puan2 >= 21) return true;
            if (pas1 && pas2) return true;
 
            return false;
        }

        private void OyunBitir()
        {
            pnlButonlar.Visible = false;
            lblSiraSizde.Visible = false;

            if (puan1 > puan2 && puan1 <= 21 || puan2 > 21)
               lblKazandi.Text= "1. Oyuncu Kazandı!";
            else if (puan2 > puan1 && puan2 <= 21 || puan1 > 21)
                lblKazandi.Text="2.Oyuncu Kazandı!";
            else
                lblKazandi.Text="Oyun Berabere Bitti!";
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            liste.Clear();

            for (int i = 0; i < 52; i++)
                liste.Add(i);


            for (int i = 0; i < 52; i++)
            {
                int rasgele = rnd.Next(52);
                int kart1 = liste[0];
                liste[0] = liste[rasgele];
                liste[rasgele] = kart1;

            }

            lblDesteSayisi.Text = liste.Count.ToString();

            pictureBox1.Image = Properties.Resources.KartArka;

            pnlButonlar.Visible = true;
            lblSiraSizde.Visible = true;

            pnlOyuncu1.Controls.Clear();
            pnlOyuncu2.Controls.Clear();
            puan1 = 0;
            puan2 = 0;
            pas1 = false;
            pas2 = false;
            lblPuan1.Text = "0";
            lblPuan2.Text = "0";
            pnlSkor.Visible = false;

            siradakiOyuncu = 1;
            SiradakiOyuncuDegistir();

        }

        private void btnPas_Click(object sender, EventArgs e)
        {
            if (siradakiOyuncu == 0)
                pas1 = true;
            else 
                pas2 = true;

            if (OyunBittiMi())
            {
                OyunBitir();
                pnlSkor.Visible = true;
            }
            else SiradakiOyuncuDegistir();
        }
    }
}
