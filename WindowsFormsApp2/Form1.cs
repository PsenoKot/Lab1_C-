using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TextWriter Form2;
        private MemberInfo Form3;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 = new TextWriter();
            Form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument1.DocumentName = "song_text.txt";
            try
            {
                printDocument1.Print();
            }
            catch (Exception)
            {
                label2.Visible = true;
            }
            Form3 = new MemberInfo();
            this.Hide();
            Form3.Show();
        }

    }
}