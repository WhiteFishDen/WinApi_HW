using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApi_HW
{

    public partial class WinApi : Form
    {
        
        public WinApi()
        {
            InitializeComponent();
            comboBox1.Items.AddRange (new string[] {"SimpleBeep", "IconAsterisk", "IconExclamation",
                                                    "IconHand", "IconQuestion", "Ok"});
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NativeMethods.MsgBox(IntPtr.Zero, "Муслимов Денис Валерьевич", "ФИО", 0);
            NativeMethods.MsgBox(IntPtr.Zero, "28", "Age", 0);
            NativeMethods.MsgBox(IntPtr.Zero, "TOP Academy student", "Occupation", 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr ptr = NativeMethods.FindWindow(null, "WinApiForm");
            NativeMethods.SendMessage(ptr, Convert.ToInt32(NativeMethods.GetWindow_Cmd.WM_SETTEXT), (IntPtr)20, textBox1.Text);
            MessageBox.Show("Заголовок изменен!!!");
            NativeMethods.Beep(1000,5000);

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                IntPtr ptr = NativeMethods.FindWindow(null, "WinApiForm");
                NativeMethods.SendMessage(ptr, Convert.ToInt32(NativeMethods.GetWindow_Cmd.WM_CLOSE), (IntPtr)20, "");

            }
            else
            {
                IntPtr ptr = NativeMethods.FindWindow(null,textBox1.Text);
                NativeMethods.SendMessage(ptr, Convert.ToInt32(NativeMethods.GetWindow_Cmd.WM_CLOSE), (IntPtr)20, "");
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await Task.Run(() => ImperialMarch());
            
        }

         void ImperialMarch()
         {
            int a = 750;

            NativeMethods.Beep(392, a);
            NativeMethods.Beep(392, a);
            NativeMethods.Beep(392, a);
            NativeMethods.Beep(311, 563);
            NativeMethods.Beep(466, 188);

            NativeMethods.Beep(392, a);
            NativeMethods.Beep(311, 563);
            NativeMethods.Beep(466, 188);
            NativeMethods.Beep(392, a * 2);

            NativeMethods.Beep(587, a);
            NativeMethods.Beep(587, a);
            NativeMethods.Beep(587, a);
            NativeMethods.Beep(622, 563);
            NativeMethods.Beep(466, 188);

            NativeMethods.Beep(369, a);
            NativeMethods.Beep(311, 563);
            NativeMethods.Beep(466, 188);
            NativeMethods.Beep(392, a * 2);
         }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                NativeMethods.MessageBeep(NativeMethods.OldBeepTypes.SimpleBeep);
            if (comboBox1.SelectedIndex == 1)
                NativeMethods.MessageBeep(NativeMethods.OldBeepTypes.IconAsterisk);
            if (comboBox1.SelectedIndex == 2)
                NativeMethods.MessageBeep(NativeMethods.OldBeepTypes.IconExclamation);
            if (comboBox1.SelectedIndex == 3)
                NativeMethods.MessageBeep(NativeMethods.OldBeepTypes.IconQuestion);
            if (comboBox1.SelectedIndex == 4)
                NativeMethods.MessageBeep(NativeMethods.OldBeepTypes.IconHand);
            if (comboBox1.SelectedIndex == 5)
                NativeMethods.MessageBeep(NativeMethods.OldBeepTypes.Ok);
        }
    }
    internal static class NativeMethods
    {
        [DllImport("User32.dll", EntryPoint = "MessageBox",CharSet = CharSet.Auto)]
        internal static extern int MsgBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);
        [DllImport("User32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindow(string ClassName, string WindowName);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool Beep(int frequency, int duration);
        [DllImport("user32.dll")]
  	    internal static extern bool MessageBeep(OldBeepTypes beepType);
        public enum OldBeepTypes : uint
  	    {
  		SimpleBeep = 0xffffffff,
  		IconAsterisk = 0x00000040,
  		IconExclamation = 0x00000030,
 		IconHand = 0x00000010,
  		IconQuestion = 0x00000020,
		Ok = 0x00000000
 	    };
    public enum GetWindow_Cmd : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6,
            WM_GETTEXT = 0x000D,
            WM_SETTEXT = 0xC,
            WM_CLOSE = 0x0010,
        }
        
    }
}
