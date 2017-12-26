using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoIRCInstaller
{
    class AdapterInstallation
    {
        const string AdapterInstallerAppTitle = "Infor Risk & Compliance Adapter - InstallShield Wizard";
        readonly InstallationMaster _im = new InstallationMaster();

        public void StartAdapterExe()
        {
            _im.RunExe(AdapterInstallerAppTitle, "[CLASS:Static; INSTANCE:3]", "Welcome to the InstallShield Wizard for Infor Risk & Compliance Adapter", AutoHelper.AdapterInstallerExe);
            var isAdapterInstalled = AutoHelper.IsAdapterInstalled();
            var processes = Process.GetProcesses();
            foreach (var theProcess in processes)
            {
                if (theProcess.MainWindowTitle == AdapterInstallerAppTitle)
                {
                    if (!isAdapterInstalled)
                    {
                        _im.Welcome(AdapterInstallerAppTitle, "", "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:3]", "Welcome to the InstallShield Wizard for Infor Risk & Compliance Adapter", theProcess);
                        _im.SelectLicense(AdapterInstallerAppTitle, "&Next >", "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:1]", "Choose license file location", "[CLASS:Button; INSTANCE:6]");
                        _im.CustomInfirmation(AdapterInstallerAppTitle, "", "[CLASS:Button; INSTANCE:2]", "[CLASS:Static; INSTANCE:5]", "Customer Information", "[CLASS:Edit; INSTANCE:1]",AutoHelper.IrcOwnerName, "[CLASS:Edit; INSTANCE:2]", AutoHelper.IrcCompanyName);
                        _im.SelectFeatures(AdapterInstallerAppTitle, "", "[CLASS:Button; INSTANCE:5]", "[CLASS:Static; INSTANCE:2]", "Select Features", "[CLASS:ISAVIEWCMPTCLASS; INSTANCE:1]",false);
                        _im.WebSiteSelection(AdapterInstallerAppTitle, "", "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:3]", "Web Site Selection");
                        _im.StartCopyingFile(AdapterInstallerAppTitle, "", "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:5]", "Start Copying Files");
                        _im.VirtualFoldersRemovalPopup("Question", "", "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:2]", @"Setup has detected existing Virtual folder(s) with name");
                        _im.Winwait(AdapterInstallerAppTitle, "[CLASS:Static; INSTANCE:4]", "InstallShield Wizard Complete");
                        _im.InstallComplete(AdapterInstallerAppTitle, "", "[CLASS:Button; INSTANCE:4]", "[CLASS:Static; INSTANCE:4]", "InstallShield Wizard Complete");
                    }
                    else
                    {
                       
                    }
                }
            }
        }
    }

    class AdapterActivation
    {
        const string AdapterActivationAppTitle = "Infor Risk & Compliance Adapter Activation Wizard";
        readonly ActivationMaster _am = new ActivationMaster();
       

        public void StartAdapterActivationExe()
        {
            bool isAdaptersInstalled = false;// isServicesActivated();
            _am.RunAdapterActivationExe(AdapterActivationAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:1]", "To continue, click Next . ", AutoHelper.AdapterActivatorExe);

            var processes = Process.GetProcesses();
            foreach (var theProcess in processes)
            {
                if (theProcess.MainWindowTitle == AdapterActivationAppTitle)
                {
                    if (!isAdaptersInstalled)
                    {
                        _am.ADWelcome(AdapterActivationAppTitle, "", "", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:1]", "To continue, click Next . ", theProcess);
                        _am.ADIRCServerdetails(AdapterActivationAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:10]", "Infor Risk && Compliance Server", "[CLASS:WindowsForms10.EDIT.app.0.141b42a_r6_ad1; INSTANCE:2]",AutoHelper.ServerNameWithPort, "[CLASS:WindowsForms10.EDIT.app.0.141b42a_r6_ad1; INSTANCE:1]", AutoHelper.AdapterNameWithPort);
                        _am.ADWinwait(AdapterActivationAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:15]", "Adapter Description");
                       // _am.ADpopup1(AdapterActivationAppTitle,"", "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:2]", "Failed to connect to Infor Risk & Compliance server, please verify Infor Risk & Compliance server machine name specified is valid and Infor Risk & Compliance services are activated on the server");
                        _am.ADAdapterDescription(AdapterActivationAppTitle, "", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:15]", "Adapter Description");
                        _am.ADServiceConfiguration(AdapterActivationAppTitle, "", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:25]", "Infor Risk && Compliance Adapter Service Configuration",
                                "TMAdapterService", "[CLASS:WindowsForms10.EDIT.app.0.141b42a_r6_ad1; INSTANCE:8]",
                                "Infor Risk & Compliance Adapter Service", "[CLASS:WindowsForms10.EDIT.app.0.141b42a_r6_ad1; INSTANCE:7]",
                                "7405", "[CLASS:WindowsForms10.EDIT.app.0.141b42a_r6_ad1; INSTANCE:6]",
                                AutoHelper.AccountLoginUserName, "[CLASS:WindowsForms10.EDIT.app.0.141b42a_r6_ad1; INSTANCE:5]",
                                AutoHelper.AccountLoginUserPassword, "[CLASS:WindowsForms10.EDIT.app.0.141b42a_r6_ad1; INSTANCE:4]",
                                "", ""
                            );
                        Thread.Sleep(5000);
                        _am.ADWinwait(AdapterActivationAppTitle, "[CLASS:Static; INSTANCE:2]", @"Please install Oracle 11g Release 2 client or higher version.");
                        Thread.Sleep(5000);
                        _am.ADOraclePopup(AdapterActivationAppTitle, "OK", "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:2]", "Please install Oracle 11g Release 2 client or higher version.");
                        Thread.Sleep(5000);
                        _am.ADActivate(AdapterActivationAppTitle, "", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:28]", "Activate");
                        Thread.Sleep(5000);
                        _am.ADWinwait(AdapterActivationAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:32]", "Summary of tasks completed");
                        Thread.Sleep(5000);
                        _am.ADActivationComplete(AdapterActivationAppTitle, "", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:32]", "Summary of tasks completed");
                    }
                }
            }
        }
    }
}
