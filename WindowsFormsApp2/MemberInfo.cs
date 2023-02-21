using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class MemberInfo : Form
    {
        public MemberInfo()
        {
            InitializeComponent();
        }

        static Random rnd = new Random();
        
        class Member
        {
            public const int QueNum = 77; //     Const int --
            public long Code;
            public TypeCode Role = TypeCode.Drummer;
            public string[] SongText = new string[50]; //Arr[] string --
        }

        enum TypeCode : long  // Enum long --
        {
            Vocalist = 294564092935,
            Drummer,
            SoundDesigner
        }
        // Var long -- 
        //     Const int -- YES
        //     Arr[] string -- YES
        //     Enum long -- YES
        private void MemberInfo_LoMemberInfo_Load(object sender, EventArgs e)
        {
            var member = new Member();
            var _ = rnd.Next(100) * 214748364723532; //Var long -- 
            member.Code = _;
            member.Role = TypeCode.Vocalist;
            
            textBox1.Text = "ТИП ЗАЯВКИ: " + Convert.ToString(member.Role) + "\r\n";
            textBox1.Text += "КОД ЗАЯВКИ: " + Convert.ToString((long)member.Role) + "\r\n";
            textBox1.Text += "КОД УЧАСТНИКА: " + Convert.ToString(member.Code) + "\r\n";
            textBox1.Text += "НОМЕР УЧАСТНИКА: " + Convert.ToString(Member.QueNum) + "\r\n";
            
            FileStream songDoc = new FileStream(@"D:\RIDER\2022\WindowsFormsApp2\WindowsFormsApp2\Properties\song_text.txt", FileMode.Open);
            using (StreamReader SR = new StreamReader(songDoc))
            {
                string line;
                int i = 0;
                while ((line = SR.ReadLine())!= null)
                {
                    member.SongText[i] = line + '\r' + '\n';
                    i++;
                }
                SR.Close();
                Array.Resize(ref member.SongText, i+1);
            }
            textBox1.Text += String.Empty + "\r\nТЕКСТ ТЕСТОВОЙ ПЕСНИ:\r\n";
            foreach (string elem in member.SongText)
            {
                textBox1.Text += elem;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}