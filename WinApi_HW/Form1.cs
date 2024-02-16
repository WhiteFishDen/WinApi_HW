using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApi_HW
{
    
    public partial class WinApi : Form
    {
        
        public WinApi()
        {
            InitializeComponent();
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
    }
    internal static class NativeMethods
    {
        [DllImport("User32.dll", EntryPoint = "MessageBox",CharSet = CharSet.Auto)]
        internal static extern int MsgBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);
        [DllImport("User32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindow(string ClassName, string WindowName);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
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
            WM_CLOSE = 0x0010
        }
    }
}
