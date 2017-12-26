using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using AutoItX3Lib;
using Microsoft.Win32;
using Xamarin.Forms;

namespace AutoIRCInstaller
{
    class ServicesInstallation
    {
        const string ServiceInstallerAppTitle = "Infor Risk & Compliance Services - InstallShield Wizard";
        string Text = string.Empty;
        public bool isServiceInstallation = false;
        public bool isAdapterInstallation = false;


        InstallationMaster IM = new InstallationMaster();

        public void StartServiceExe()
        { 
            IM.isServiceInstallation = true;

            IM.RunExe(ServiceInstallerAppTitle, "[CLASS:Static; INSTANCE:3]", "Welcome to the InstallShield Wizard for Infor Risk & Compliance Services", AutoHelper.ServicesInstallerExe);//[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:4]

            var isServicesInstalled = AutoHelper.IsServicesInstalled();
            var processes = Process.GetProcesses();
            foreach (var theProcess in processes)
            {
                if (theProcess.MainWindowTitle == ServiceInstallerAppTitle)
                {
                    if (!isServicesInstalled)
                    {
                        IM.Welcome(ServiceInstallerAppTitle, Text, "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:3]", "Welcome to the InstallShield Wizard for Infor Risk & Compliance Services", theProcess);
                        IM.SelectLicense(ServiceInstallerAppTitle, "&Next >", "[CLASS:Button; INSTANCE:3]", "[CLASS:Static; INSTANCE:5]", "Choose license file location", "[CLASS:Button; INSTANCE:6]");
                        IM.CustomInfirmation(ServiceInstallerAppTitle, Text, "[CLASS:Button; INSTANCE:2]", "[CLASS:Static; INSTANCE:5]", "Customer Information", "[CLASS:Edit; INSTANCE:1]", "Raviraj", "[CLASS:Edit; INSTANCE:2]", "Infor");
                        IM.SelectFeatures(ServiceInstallerAppTitle, Text, "[CLASS:Button; INSTANCE:4]", "[CLASS:Static; INSTANCE:2]", "Select Features", "[CLASS:ISAVIEWCMPTCLASS; INSTANCE:1]",true);
                        IM.WebSiteSelection(ServiceInstallerAppTitle, Text, "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:3]", "Web Site Selection");
                        IM.StartCopyingFile(ServiceInstallerAppTitle, Text, "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:4]", "Review settings before copying files.");
                        IM.VirtualFoldersRemovalPopup("Question", Text, "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:2]", @"Setup has detected existing Virtual folder(s)");
                        IM.Winwait(ServiceInstallerAppTitle, "[CLASS:Static; INSTANCE:4]", "InstallShield Wizard Complete");
                        IM.InstallComplete(ServiceInstallerAppTitle, Text, "[CLASS:Button; INSTANCE:4]", "[CLASS:Static; INSTANCE:4]", "InstallShield Wizard Complete");
                        
                    }
                    else
                    {
                        //Uninstall Services
                        //after remove btn click shows popup y/n
                        //AutoServicesUninstaller servicesUninstaller = new AutoServicesUninstaller();
                        //servicesUninstaller.StartServicesUninstaller();
                    }
                }
            }
        }

    }

    class ServicesActivation
    {
        const string ServiceActivationAppTitle = "Infor Risk & Compliance Services Activation Wizard";
        string Text = string.Empty;
        
        ActivationMaster AM = new ActivationMaster();

        public void StartServiceActivationExe()
        {
            bool isServicesInstalled = isServicesActivated();
            AM.RunServiceActivationExe(ServiceActivationAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:5]", "Welcome to the Infor Risk && Compliance Services Activation Wizard", AutoHelper.ServicesActivatorExe);

            var processes = Process.GetProcesses();
            foreach (var theProcess in processes)
            {
                if (theProcess.MainWindowTitle == ServiceActivationAppTitle)
                {
                    if (!isServicesInstalled)
                    {
                        AM.Welcome(ServiceActivationAppTitle, Text, "WindowsForms10.BUTTON.app.0.141b42a_r6_ad1", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:5]", "Welcome to the Infor Risk && Compliance Services Activation Wizard", theProcess);
                        AM.AuthenticationServer(ServiceActivationAppTitle, Text, "[CLASS:WindowsForms10.Window.8.app.0.141b42a_r6_ad1; INSTANCE:2]", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:8]", "Authentication Server", "WindowsForms10.COMBOBOX.app.0.141b42a_r6_ad1", "IRC");

                        AM.IRCAdministrator(ServiceActivationAppTitle, Text, "WindowsForms10.BUTTON.app.0.141b42a_r6_ad1", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:20]", "Infor Risk && Compliance Administrator", "[CLASS:WindowsForms10.EDIT.app.0.141b42a_r6_ad1; INSTANCE:6]", AutoHelper.IrcUsername, "[CLASS:WindowsForms10.EDIT.app.0.141b42a_r6_ad1; INSTANCE:5]", AutoHelper.IrcPassword, "[CLASS:WindowsForms10.EDIT.app.0.141b42a_r6_ad1; INSTANCE:4]", AutoHelper.IrcConfirmPassword);

                        AM.IRCServiceAccount(ServiceActivationAppTitle, Text, "[CLASS:WindowsForms10.Window.8.app.0.141b42a_r6_ad1; INSTANCE:5]", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:27]", "Infor Risk && Compliance Service Account", "[NAME:txtServiceAccountUserName]", AutoHelper.AccountLoginUserName, "[NAME:txtServiceAccountPassword]", AutoHelper.AccountLoginUserPassword);
                        AM.Winwait(ServiceActivationAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:30]", "Database Creation - Step 1");

                        AM.DBCreationStep_1(ServiceActivationAppTitle, Text, "WindowsForms10.BUTTON.app.0.141b42a_r6_ad1", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:30]", "Database Creation - Step 1", "[NAME:txtSQLServer]", AutoHelper.ServerName, "[NAME:txtDBName]", AutoHelper.CoreDB, "[NAME:rdoSQLAuth]", "Specify SQL user account and password", "[NAME:txtSQLUser]", AutoHelper.SqlUserName, "[NAME:txtSQLPassword]", AutoHelper.SqlPassword);
                        AM.Winwait(ServiceActivationAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:39]", "Database Creation - Step 2");

                        AM.DBCreationStep_2(ServiceActivationAppTitle, Text, "WindowsForms10.BUTTON.app.0.141b42a_r6_ad1", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:39]", "Database Creation - Step 2", "[NAME:txtDataFilePath]", AutoHelper.DataFilePath, "[NAME:txtLogFilePath]", AutoHelper.LogFilePath, "[NAME:txtFileGroupPath]", AutoHelper.FileGroupPath);
                        AM.Winwait(ServiceActivationAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:45]", "Database Account");

                        AM.DatabaseAccount(ServiceActivationAppTitle, Text, "[CLASS:WindowsForms10.Window.8.app.0.141b42a_r6_ad1; INSTANCE:18]", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:45]", "Database Account", "[NAME:radioButton2]", "Use &SQL user account. This option will configure  to access SQL database using SQL Server Authentication mode.", "[NAME:txtSQLAccessUserName]", AutoHelper.SqlUserName, "[NAME:txtSQLAccessUserPassword]", AutoHelper.SqlPassword);

                        AM.MSSSRSDetails(ServiceActivationAppTitle, Text, "[CLASS:WindowsForms10.Window.8.app.0.141b42a_r6_ad1; INSTANCE:22]", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:49]", "MSSSRS Details",
                            "[NAME:txtServer]", AutoHelper.ServerNameWithPort,
                            "[NAME:txtServerDir]", AutoHelper.ReportServer,
                            "[NAME:txtManagerDir]", AutoHelper.ReportServerManageDir,
                            "[NAME:txtCompDir]", AutoHelper.ReportServerFolder,
                            "[NAME:txtReportSqlServerName]", AutoHelper.ServerName,
                            "[NAME:txtReportSqlServerDBName]", AutoHelper.ReportServer,
                            "[NAME:chkMSSSRSEnable]",
                            "[NAME:chkSSL]"
                            );
                        AM.Winwait(ServiceActivationAppTitle, "[CLASS:Static; INSTANCE:2]", "Infor Risk & Compliance Services Activation cannot continue, folder 'IRC_CoreDB'already exists on the MSSSRS server");
                        AM.ReportServerExist(ServiceActivationAppTitle, Text, "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:2]", "Infor Risk & Compliance Services Activation cannot continue, folder 'IRC_CoreDB'already exists on the MSSSRS server");
                        AM.Activate(ServiceActivationAppTitle, Text, "", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:61]", "Activate");
                        AM.Winwait(ServiceActivationAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:65]", "You have successfully completed the Infor Risk && Compliance Services Activation Wizard.");
                        AM.ActivationCompleted(ServiceActivationAppTitle, "", "WindowsForms10.Window.8.app.0.141b42a_r12_ad129", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:65]", "You have successfully completed the Infor Risk && Compliance Services Activation Wizard.");
                        //InstallComplete();
                    }
                    else
                    {
                      
                    }
                }
            }
        }

        private bool isServicesActivated()
        {
            return false;
        }



        //string _btnNextControl = String.Empty;
        //string _btnNextControlText = String.Empty;
        //private string _btnCancelControl = String.Empty;
        //private string _btnCancelControlText = String.Empty;
        //string _pnlIdenty = "";
        //string _exepath = @"C:\TempBuild1\BizRights Services\Setup.exe";//UI
        //string _processName = "";
        //string _selectionMessage = string.Empty;
        //private string _destinationFolder = @"C:\Program Files\Approva\BizRights"; //UI
        //private string _panelId = String.Empty;
        //string Text = string.Empty;
        //AutoItX3 _autoServiceInstaller = new AutoItX3();
        //AutoHelper helper = new AutoHelper();

        //public void StartServiceExe()
        //{
        //    //var threadRunExe = new Thread(RunServiceExe);
        //    //threadRunExe.Start();
        //    //threadRunExe.Join();
        //    //threadRunExe.Abort();

        //    // CopyFilesToLocalPath();

        //    RunServiceExe();

        //    var isServicesInstalled = isProductInstalled();
        //    var processes = Process.GetProcesses();
        //    foreach (var theProcess in processes)
        //    {
        //        if (theProcess.MainWindowTitle == ServiceInstallerAppTitle)
        //        {
        //            if (!isServicesInstalled)
        //            {
        //                Welcome(theProcess);
        //                SelectLicense();
        //                CustomInfirmation();
        //                SelectFeatures();
        //                WebSiteSelection();
        //                StartCopyingFile();
        //                VirtualFoldersRemovalPopup();

        //                //// SetupStatus();// Copying file in progrogress write Thraed here
        //                //InstallComplete();
        //            }
        //            else
        //            {
        //                //Uninstall Services
        //                //after remove btn click shows popup y/n
        //                var uninstallThead = new Thread(ServicesUnstallation);
        //                uninstallThead.Start();
        //                uninstallThead.Join();
        //            }
        //        }
        //    }
        //}



    }
}
