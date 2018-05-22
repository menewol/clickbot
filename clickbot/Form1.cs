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

namespace clickbot
{
    public partial class ClickBot : Form
    {
        const int WM_HOTKEY = 0x0312;
        const int MYACTION_HOTKEY_ID = 0x01;
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        [DllImport("user32.dll", PreserveSig = false)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys key);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY && m.WParam.ToInt32() == 0x01)
            {
                MessageBox.Show("hotkey");
            }
            base.WndProc(ref m);
        }


        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public int ANZAHL = 0;


        public ClickBot()
        {
            InitializeComponent();
            
            //if (!RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 0, Keys.F10))
            //{
               
            //    //throw new Win32Exception(Marshal.GetLastWin32Error());
            //}
            //MessageBox.Show("nofail");
        }

        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string s = "clicked: ";
            DoMouseClick();
            ANZAHL++;
            label1.Text = s + ANZAHL.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(numericUpDown1.Value);
            timer1.Start();
            clickbot.ClickBot.ActiveForm.BackColor = Color.Green;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            ANZAHL = 0;
            label1.Text = "clicked: ";
            clickbot.ClickBot.ActiveForm.BackColor = SystemColors.Control;
        }

        private void ClickBot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                MessageBox.Show("stop");
            }
        }

        private void ClickBot_Load(object sender, EventArgs e)
        {


        }

        private void ClickBot_Activated(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
