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
    public partial class fPlay : Form
    {
        fSetting fSetting = new fSetting();
        fGame game = new fGame();
        public fPlay()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            fSetting.ShowDialog();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            game.ShowDialog();
        }

        private void fPlay_Load(object sender, EventArgs e)
        {
            Victorina.ReadSetting();
            Victorina.ReadMusic();
        }
    }
}
