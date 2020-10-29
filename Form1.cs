using GTA_DEV_RECONNECT.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace GTA_DEV_RECONNECT
{
    public partial class Form1 : Form
    {
        public int a = 1;
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        const int MYACTION_HOTKEY_ID = 1;

        public int currentHotkey = Settings.Default.Hotkey;

        public Form1()
        {
            InitializeComponent();
            toolStripMenuItem1.Text = String.Format("Hotkey ({0})", Settings.Default.HotkeyText);
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 0, currentHotkey);
        }

        public class HotkeysList
        {
            public string Name { get; set; }
            public int Code { get; set; }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            var hotkeys = new List<HotkeysList>{
                new HotkeysList() { Name = "Backspace", Code = 8},
                new HotkeysList() { Name = "Pause/break", Code =  19},
                new HotkeysList() { Name = "Caps lock", Code =  20},
                new HotkeysList() { Name = "Escape", Code =  27},
                new HotkeysList() { Name = "Page up", Code =  33},
                new HotkeysList() { Name = "Page down", Code =  34},
                new HotkeysList() { Name = "End", Code =  35},
                new HotkeysList() { Name = "Home", Code = 36},
                new HotkeysList() { Name = "Left arrow", Code =  37},
                new HotkeysList() { Name = "Up arrow", Code = 38},
                new HotkeysList() { Name = "Right arrow", Code =  39},
                new HotkeysList() { Name = "Down arrow", Code =  40},
                new HotkeysList() { Name = "Insert", Code =  45},
                new HotkeysList() { Name = "Delete", Code =  46},
                new HotkeysList() { Name = "0", Code =  48},
                new HotkeysList() { Name = "1", Code =  49},
                new HotkeysList() { Name = "2", Code =  50},
                new HotkeysList() { Name = "3", Code =  51},
                new HotkeysList() { Name = "4", Code =  52},
                new HotkeysList() { Name = "5", Code =  53},
                new HotkeysList() { Name = "6", Code =  54},
                new HotkeysList() { Name = "7", Code =  55},
                new HotkeysList() { Name = "8", Code =  56},
                new HotkeysList() { Name = "9", Code =  57},
                new HotkeysList() { Name = "A", Code =  65},
                new HotkeysList() { Name = "B", Code =  66},
                new HotkeysList() { Name = "C", Code =  67},
                new HotkeysList() { Name = "D", Code =  68},
                new HotkeysList() { Name = "E", Code =  69},
                new HotkeysList() { Name = "F", Code =  70},
                new HotkeysList() { Name = "G", Code =  71},
                new HotkeysList() { Name = "H", Code =  72},
                new HotkeysList() { Name = "I", Code =  73},
                new HotkeysList() { Name = "J", Code =  74},
                new HotkeysList() { Name = "K", Code =  75},
                new HotkeysList() { Name = "L", Code =  76},
                new HotkeysList() { Name = "M", Code =  77},
                new HotkeysList() { Name = "N", Code =  78},
                new HotkeysList() { Name = "O", Code =  79},
                new HotkeysList() { Name = "P", Code =  80},
                new HotkeysList() { Name = "Q", Code =  81},
                new HotkeysList() { Name = "R", Code =  82},
                new HotkeysList() { Name = "S", Code =  83},
                new HotkeysList() { Name = "T", Code =  84},
                new HotkeysList() { Name = "U", Code =  85},
                new HotkeysList() { Name = "V", Code =  86},
                new HotkeysList() { Name = "W", Code =  87},
                new HotkeysList() { Name = "X", Code =  88},
                new HotkeysList() { Name = "Y", Code =  89},
                new HotkeysList() { Name = "Z", Code =  90},
                new HotkeysList() { Name = "Left window key", Code =  91},
                new HotkeysList() { Name = "Right window key", Code = 92},
                new HotkeysList() { Name = "Select key", Code =  93},
                new HotkeysList() { Name = "Numpad 0", Code = 96},
                new HotkeysList() { Name = "Numpad 1", Code = 97},
                new HotkeysList() { Name = "Numpad 2", Code = 98},
                new HotkeysList() { Name = "Numpad 3", Code = 99},
                new HotkeysList() { Name = "Numpad 4", Code = 100},
                new HotkeysList() { Name = "Numpad 5", Code = 101},
                new HotkeysList() { Name = "Numpad 6", Code = 102},
                new HotkeysList() { Name = "Numpad 7", Code = 103},
                new HotkeysList() { Name = "Numpad 8", Code = 104},
                new HotkeysList() { Name = "Numpad 9", Code = 105},
                new HotkeysList() { Name = "Multiply", Code = 106},
                new HotkeysList() { Name = "Add", Code =  107},
                new HotkeysList() { Name = "Subtract", Code = 109},
                new HotkeysList() { Name = "Decimal point", Code =  110},
                new HotkeysList() { Name = "Divide", Code =  111},
                new HotkeysList() { Name = "F1", Code =  112},
                new HotkeysList() { Name = "F2", Code =  113},
                new HotkeysList() { Name = "F3", Code =  114},
                new HotkeysList() { Name = "F4", Code =  115},
                new HotkeysList() { Name = "F5", Code =  116},
                new HotkeysList() { Name = "F9", Code =  120},
                new HotkeysList() { Name = "F10", Code =  121},
                new HotkeysList() { Name = "F11", Code =  122},
                new HotkeysList() { Name = "F12", Code =  123}
            };

            foreach (var item in hotkeys)
            {
                ToolStripItem newDropDownItem = new ToolStripMenuItem();
                newDropDownItem.Text = item.Name;
                newDropDownItem.Tag = item.Code;

                toolStripMenuItem1.DropDownItems.Add(newDropDownItem);
                newDropDownItem.Click += new EventHandler(MenuItemClickHandler);
            }
        }

        private void MenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            Settings.Default.Hotkey = Convert.ToInt32(clickedItem.Tag.ToString());
            Settings.Default.HotkeyText = clickedItem.Text.ToString();
            Settings.Default.Save();
            Settings.Default.Reload();
            currentHotkey = Settings.Default.Hotkey;
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 0, currentHotkey);
            toolStripMenuItem1.Text = String.Format("Hotkey ({0})", Settings.Default.HotkeyText);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (CloseCancel() == false)
            {
                e.Cancel = true;
            };
        }

        public static bool CloseCancel()
        {
            const string message = "Are you sure that you would like to close the application?";
            const string caption = "AltV Hotkey Reconnect";

            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        protected override void WndProc(ref Message m)
        {

            try
            {
                if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID && (GetAsyncKeyState(currentHotkey) == -32767))
                {
                    Process[] processes = Process.GetProcessesByName("gta5");

                    foreach (Process proc in processes)
                    {
                        SetForegroundWindow(proc.MainWindowHandle);
                        SendKeys.SendWait("{F8}");
                        Thread.Sleep(100);
                        SendKeys.SendWait("reconnect");
                        Thread.Sleep(101);
                        SendKeys.SendWait("{ENTER}");
                        Thread.Sleep(102);
                        SendKeys.SendWait("{F8}");
                    }

                }
                base.WndProc(ref m);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}