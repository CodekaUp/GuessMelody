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

namespace AA
{
    public partial class fSetting : Form
    {
        public fSetting()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           Victorina.allDirectories = chDirectory.Checked;
           Victorina.gameDuration = Convert.ToInt32(cbGameDuratuion.Text);
           Victorina.musicDuration = Convert.ToInt32(cbMusicDuration.Text);
           Victorina.randomStart = chRandomStart.Checked;
           Victorina.WriteSetting();
           this.Hide();
        }
        void Set()
        {
            chDirectory.Checked = Victorina.allDirectories;
            cbGameDuratuion.Text = Victorina.gameDuration.ToString();
            cbMusicDuration.Text = Victorina.musicDuration.ToString();
            chRandomStart.Checked = Victorina.randomStart;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Set();
            this.Hide();
        }

        private void fSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog(); 
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string[] music_list = Directory.GetFiles(dialog.SelectedPath, "*.mp3", chDirectory.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                Victorina.lastFolder = dialog.SelectedPath;
                listBox1.Items.Clear();
                listBox1.Items.AddRange(music_list);
                Victorina.list.Clear();
                Victorina.list.AddRange(music_list);
            }
        }

        private void fSetting_Load(object sender, EventArgs e)
        {
            Set();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Victorina.list.ToArray());
        }
    }
}
