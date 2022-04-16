using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;

namespace SeaBattle
{

    public partial class Sound : Form
    {
        public Sound()
        {
            InitializeComponent();
        }

        public static bool BackgroundS = false;
        public static bool OtherS = false;
        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlay();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            BackgroundS = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            OtherS = true;
        }

        public static void SoundPlay()
        {
            if (Sound.BackgroundS)
            {
                Main.musik.Play();
            }
            else Main.musik.Stop();
        }

        private void Sound_Load(object sender, EventArgs e)
        {
        }
    }
}
