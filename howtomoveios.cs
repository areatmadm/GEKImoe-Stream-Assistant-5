using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using CefSharp.WinForms;

namespace AreaTM_acbas
{
    public partial class howtomoveios : Form
    {
        string AppleDeviceVersion_0 = "1.1030.20993.0";
        string AppleDeviceVersion_1 = "1.1030.21762.0";
        //Apple 기기 버전별 경로가 달라 부득이하게 지정

        public ChromiumWebBrowser browser;
        public void InitBrowser()
        {
            browser = new ChromiumWebBrowser("https://geki.moe/nolja/iTunes");
            //browser = new ChromiumWebBrowser("chrome://version");
            this.Controls.Add(browser);
            LifespanHandler life = new LifespanHandler();
            browser.LifeSpanHandler = life;

            browser.MenuHandler = new CustomMenuHandler();
            browser.Dock = DockStyle.Fill;
        }

        public howtomoveios()
        {
            InitializeComponent();
            InitBrowser();
        }

        private void howtomoveios_Load(object sender, EventArgs e)
        {
            NOLJA_BlackEdition();
            try { Process.Start(sdvxwin._obs.GetRecordingFolder()); } catch { }
            
            Process newAppleDevice = new Process();
            if (System.IO.File.Exists(@"C:\Program Files\WindowsApps\AppleInc.AppleDevices_" + AppleDeviceVersion_0 + @"_x64__nzyj5cx40ttqa\AppleDevices.exe"))
            {
                newAppleDevice.StartInfo.FileName = @"C:\Program Files\WindowsApps\AppleInc.AppleDevices_" + AppleDeviceVersion_0 + @"_x64__nzyj5cx40ttqa\AppleDevices.exe";
            }
            else if (System.IO.File.Exists(@"C:\Program Files\WindowsApps\AppleInc.AppleDevices_" + AppleDeviceVersion_1 + @"_x64__nzyj5cx40ttqa\AppleDevices.exe"))
            {
                newAppleDevice.StartInfo.FileName = @"C:\Program Files\WindowsApps\AppleInc.AppleDevices_" + AppleDeviceVersion_1 + @"_x64__nzyj5cx40ttqa\AppleDevices.exe";
            }
            try { newAppleDevice.Start(); } catch {  }
        }

        private void NOLJA_BlackEdition()
        {
            this.Font = new Font(sdvxwin.font_5_0_r.Families[0], 12f);
        }

        private void howtomoveios_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process[] processifusenjbtmpcht = Process.GetProcessesByName("AppleDevices");
            if (processifusenjbtmpcht.Length >= 1)
            {
                Process killtask = new Process();
                killtask.StartInfo.FileName = @"C:\Windows\system32\AppleDevices.exe";
                killtask.StartInfo.Arguments = "/f /im AppleDevices.exe";
                try { killtask.Start(); } catch { }
                //C:\Windows\SysWOW64\taskkill.exe /f /im Nolja_OpenUp.exe
            }
        }
    }
}
