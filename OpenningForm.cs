using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;




namespace Tetris
{
    public partial class OpeningForm : Form
    {
        GameForm game;
        public OpeningForm()
        {
            game = new GameForm(this, 0,false);
            game.Dispose();
            InitializeComponent();




        }

        private void ButtonEasy_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (game.IsDisposed) game = new GameForm(this,1,checkBox1.Checked);
            game.Show();
        }

        private void ButtonNormal_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (game.IsDisposed) game = new GameForm(this, 4, checkBox1.Checked);
            game.Show();
        }

        private void ButtonHard_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (game.IsDisposed) game = new GameForm(this, 7, checkBox1.Checked);
            game.Show();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                ButtonEasy.Text = "困难";
                ButtonNormal.Text = "噩梦";
                ButtonHard.Text = "地狱";
            }
            else
            {
                ButtonEasy.Text = "简单";
                ButtonNormal.Text = "普通";
                ButtonHard.Text = "困难";
            }
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
    }
}
