using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AA
{
    public partial class fGame : Form
    {
        Random random = new Random();
        int musicDuration = Victorina.musicDuration;
        public fGame()
        {
            InitializeComponent();
        }

        void MakeMusic()
        {
            if (Victorina.list.Count == 0) EndGame();
            else
            {
                musicDuration = Victorina.musicDuration;
                int n = random.Next(0, Victorina.list.Count);
                WMP.URL = Victorina.list[n];
                //WMP.Ctlcontrols.play();
                Victorina.list.RemoveAt(n);
                lbSongs.Text = Victorina.list.Count.ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Start();
            MakeMusic();
        }

        private void fGame_Load(object sender, EventArgs e)
        {
            lbSongs.Text = Victorina.list.Count.ToString();
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Victorina.gameDuration;
            lbMusicDuration.Text = musicDuration.ToString();
        }

        private void fGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            WMP.Ctlcontrols.stop();
        }

        void EndGame()
        {
            timer1.Stop();
            WMP.Ctlcontrols.stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            lbMusicDuration.Text = musicDuration.ToString();
            musicDuration--;
            if (progressBar1.Value == progressBar1.Maximum)
            {
                EndGame();
                return;
            }
            if (musicDuration == 0) MakeMusic();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            GamePause();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            GamePlay();
        }

        void GamePause()
        {
            timer1.Stop();
            WMP.Ctlcontrols.pause();
        }

        void GamePlay()
        {
            timer1.Start();
            WMP.Ctlcontrols.play();
        }

        private void fGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A)
            {
                Fmassage fmassage = new Fmassage();
                fmassage.lbMassage.Text = "Игрок 1";
                GamePause();
                if (fmassage.ShowDialog() == DialogResult.Yes)
                {
                    lbCounter1.Text = Convert.ToString(Convert.ToInt32(lbCounter1.Text)+1);
                    MakeMusic();
                }
            }   GamePlay();

            if (e.KeyData == Keys.L)
            {
                Fmassage fmassage = new Fmassage();
                fmassage.lbMassage.Text = "Игрок 2";
                GamePause();
                if (fmassage.ShowDialog() == DialogResult.Yes)
                {
                    lbCounter2.Text = Convert.ToString(Convert.ToInt32(lbCounter1.Text) + 1);
                    MakeMusic();
                }
            }
            GamePlay();
        }
    }
}
