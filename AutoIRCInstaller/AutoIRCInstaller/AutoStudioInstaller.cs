using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoIRCInstaller
{
    class AutoStudioInstaller
    {
        #region Studio Auto Installation

        //private void DBconfigMethod()
        //{
        //    x.ControlFocus("Infor Risk & Compliance Studio", "", "WindowsForms10.BUTTON.app.0.141b42a_r6_ad14");
        //    x.Send("{ENTER}");
        //    while (true)
        //    {
        //        Thread.Sleep(1000);
        //        var Processes = Process.GetProcesses();
        //        foreach (var PrDBExit in Processes)
        //        {
        //            if (PrDBExit.MainWindowTitle == "Infor Risk & Compliance Studio")
        //            {
        //                Thread.Sleep(2000);
        //                x.ControlFocus("Infor Risk & Compliance Studio Database Configuration", "", "Button1");
        //                x.Send("{Enter}");
        //            }
        //        }
        //    }
        //}

        //public void Installation()
        //{
        //    var text1 = x.ControlGetText("Infor Risk & Compliance Studio Setup", "", "[CLASS:Static; INSTANCE:3]");
        //    if (text1.Contains("Ready to install Infor Risk & Compliance Studio"))
        //    {
        //        x.ControlFocus(AppTille, "", "[CLASS:Button; INSTANCE:1]");
        //        x.Send("{ENTER}");
        //        while (true)
        //        {
        //            Thread.Sleep(1000);
        //            var isCompleted = x.ControlGetText("Infor Risk & Compliance Studio Setup", "", "[CLASS:Static; INSTANCE:3]");
        //            if (isCompleted.Contains("Completed the Infor Risk & Compliance Studio Setup Wizard"))
        //            {
        //                break;
        //            }
        //        }
        //        //textBlock.Text += Environment.NewLine + "Installation is in progress" + DateTime.Now; ;
        //        //Thread.Sleep(1000);
        //        //x.ControlFocus("Infor Risk & Compliance Studio Setup", "", "[CLASS:Button; INSTANCE:1]");
        //        //x.Send("{ENTER}");
        //        //Thread.Sleep(1000);
        //    }
        //}

        //public void InstallStudioDB()
        //{
        //    // Database management setting

        //    // System.Diagnostics.Process.Start(@"C:\Program Files\Approva Studio\Infor Risk & Compliance Studio\DatabaseManager.exe");
        //    textBox.Text += Environment.NewLine + "Stated Database configuration managaer";
        //    Thread.Sleep(5000);
        //    var Processes = Process.GetProcesses();
        //    //  System.Diagnostics.Process.GetProcessById(18108);
        //    foreach (var prDBmanage in Processes)
        //    {
        //        const string DBinstallerTitle = "Infor Risk & Compliance Studio";
        //        if (prDBmanage.MainWindowTitle == DBinstallerTitle || prDBmanage.MainWindowTitle == "DatabaseManager.exe")
        //        {
        //            var txtDatabaseServer = "WindowsForms10.EDIT.app.0.141b42a_r6_ad14";
        //            var txtDBName = "WindowsForms10.EDIT.app.0.141b42a_r6_ad13";
        //            var rdoIntegretadeAuth = "WindowsForms10.BUTTON.app.0.141b42a_r6_ad12";
        //            var rdosqlAuth = "WindowsForms10.BUTTON.app.0.141b42a_r6_ad11";
        //            var txtUserName = "WindowsForms10.EDIT.app.0.141b42a_r6_ad12";
        //            var txtPassword = "WindowsForms10.EDIT.app.0.141b42a_r6_ad11";
        //            var btnConfigure = "WindowsForms10.BUTTON.app.0.141b42a_r6_ad14";
        //            var btnExit = "WindowsForms10.BUTTON.app.0.141b42a_r6_ad13";

        //            x.WinActivate(DBinstallerTitle);
        //            var DBpaneltext = x.ControlGetText(DBinstallerTitle, "", "WindowsForms10.STATIC.app.0.141b42a_r6_ad11");
        //            if (DBpaneltext.Contains("Database Configuration"))
        //            {
        //                x.ControlSetText(DBinstallerTitle, "", txtDatabaseServer, "INPUDRGURAV1");
        //                Thread.Sleep(1000);
        //                x.ControlSetText(DBinstallerTitle, "", txtDBName, "StudioDB12");
        //                Thread.Sleep(1000);
        //                x.ControlFocus(DBinstallerTitle, "", rdosqlAuth);
        //                x.Send("{ENTER}");
        //                Thread.Sleep(1000);

        //                x.ControlSetText(DBinstallerTitle, "", txtUserName, "sa");
        //                Thread.Sleep(1000);
        //                x.ControlSetText(DBinstallerTitle, "", txtPassword, "approva1@");
        //                Thread.Sleep(1000);
        //                textBox.Text += Environment.NewLine + "values are set";
        //                textBox.Text += Environment.NewLine + "Inside Thread";
        //                var dbcnfigThread = new Thread(DBconfigMethod);
        //                dbcnfigThread.Start();
        //                dbcnfigThread.Join();
        //                dbcnfigThread.Abort();
        //                textBox.Text += Environment.NewLine + "Completed";

        //            }
        //            else
        //            {
        //                textBox.Text += Environment.NewLine + "Database Configuration Panel not found";
        //            }
        //            // 
        //        }
        //    }

        //}

        //private void InstallStudio()
        //{
        //    textBox.Text += Environment.NewLine + "Launching app" + DateTime.Now;
        //    if (File.Exists(@"C:\Users\rgurav\Desktop\IRCStudio-x64.msi"))
        //        System.Diagnostics.Process.Start(@"C:\Users\rgurav\Desktop\IRCStudio-x64.msi");
        //    Thread.Sleep(5000);
        //    var p = Process.GetProcesses(); //GetProcessesByName("Infor Risk & Compliance Studio Setup");

        //    foreach (var theprocess in p)
        //    {

        //        if (theprocess.MainWindowTitle == AppTille)
        //        {
        //            var strMessages = String.Empty;
        //            x.WinActivate(AppTille);
        //            const string panelText = "[CLASS:Static; INSTANCE:3]";
        //            strMessages = x.ControlGetText(AppTille, "", panelText);
        //            const string btnNext = "[CLASS:Button; INSTANCE:1]";

        //            if (strMessages.Contains("Welcome to the Infor Risk & Compliance Studio Setup Wizard"))
        //            {
        //                textBox.Text += Environment.NewLine + "Welcome to the Infor Risk & Compliance Studio Setup Wizard" + DateTime.Now;
        //                Thread.Sleep(1000);
        //                x.ControlFocus(AppTille, "", btnNext);
        //                x.Send("{ENTER}");
        //                Thread.Sleep(1000);
        //            }
        //            strMessages = x.ControlGetText(AppTille, "", panelText);
        //            if (strMessages.Contains("Destination Folder"))
        //            {
        //                textBox.Text += Environment.NewLine + AppTille + DateTime.Now; ;
        //                Thread.Sleep(1000);
        //                x.ControlFocus(AppTille, "", btnNext);
        //                x.Send("{ENTER}");
        //                Thread.Sleep(1000);
        //            }
        //            strMessages = x.ControlGetText(AppTille, "", panelText);
        //            if (strMessages.Contains("Ready to install Infor Risk & Compliance Studio"))
        //            {
        //                textBox.Text += Environment.NewLine + "Ready to install Infor Risk & Compliance Studio" + DateTime.Now;

        //            }
        //            var T2 = new Thread(Installation);
        //            T2.Start();
        //            T2.Join();
        //            T2.Abort();

        //            strMessages = x.ControlGetText(AppTille, "", panelText);
        //            if (strMessages.Contains("Completed the Infor Risk & Compliance Studio Setup Wizard"))
        //            {
        //                textBox.Text += Environment.NewLine + "Completed" + DateTime.Now + DateTime.Now;
        //                Thread.Sleep(1000);
        //                x.ControlFocus(AppTille, "", btnNext);
        //                x.Send("{ENTER}");
        //                Thread.Sleep(1000);
        //            }

        //            textBox.Text += Environment.NewLine + "Exit" + DateTime.Now;
        //        }
        //        else
        //        {
        //            textBox.Text += Environment.NewLine + "Application is not Running" + DateTime.Now;
        //        }
        //    }
        //}

        #endregion 
    }
}
