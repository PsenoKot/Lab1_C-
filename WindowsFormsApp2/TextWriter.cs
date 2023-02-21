using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace WindowsFormsApp2
{
    public partial class TextWriter : Form
    {
        public TextWriter()
        {
            InitializeComponent();
        }

        private void TextWriter_Load_1(object sender, EventArgs e)
        {
            
        }
        
        private string SongText = "";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SongText = textBox1.Text;
        }
        
        private int timeleft = 299;
        private int wait = 3;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            int minutes;
            int secunds;
            if (timeleft > 0)
            {
                minutes = timeleft / 60;
                secunds = timeleft - minutes*60;
                timelabel.Text = Convert.ToString(minutes) + " : " + Convert.ToString(secunds);
                timeleft-=1;
            }
            else
            {
                timelabel.Text = "TIME`S UP!";
                button1.BackColor = Color.Firebrick;
                button1.Text = "Выход";
                wait -= 1;
                SongText = textBox1.Text;
                SongText = textBox1.Text;
                textBox1.ReadOnly = true;
                SaveSong();
                if (wait == 0){this.Close();}
            }
        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Stop();
            timelabel.Text = "DONE";
            SaveSong();
            this.Close();
        }

        private void SaveSong()
        {
            FileStream fs = new FileStream(@"D:\RIDER\2022\WindowsFormsApp2\WindowsFormsApp2\Properties\song_text.txt", FileMode.Create);
            using (StreamWriter SW = new StreamWriter(fs))
            {
                SW.Write(SongText, Encoding.UTF8);
                SW.Close();
            }
        }

    }
}