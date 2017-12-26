using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoIRCInstaller
{

    class AutoUninstaller
    {
    }
    class AutoInsightUninstaller
    {
        UninstallerMaster UM = new UninstallerMaster();
        string Uninstallertitle = "Infor Risk & Compliance Insight Setup";

        public void StartInsightUninstaller()
        {
            string log = "";
           
            string[] InstalledPMNames, InstalledPMFriendlyNames;
            GetInstalledPMNames(out InstalledPMNames, out InstalledPMFriendlyNames);
          
            if (InstalledPMNames != null)
            {
                foreach (var ProcessModule in InstalledPMNames)
                {
                    UM.RunInsightUninstaller(Uninstallertitle, "[NAME:label2]", "Infor Risk && Compliance Insight Uninstaller", AutoHelper.UninstallexePath, ProcessModule.Trim());
                    UM.Welcome(Uninstallertitle, "[NAME:label2]", "Infor Risk && Compliance Insight Uninstaller");
                    UM.Uninstall(Uninstallertitle, "[NAME:lblTitle]", "Uninstall");
                    UM.Wait(Uninstallertitle, "[NAME:m_lblProgress]", "Uninstall Progress : 100%");
                    UM.UninstallComplete(Uninstallertitle, "[NAME:m_lblDesc]", "[NAME:m_btnNext]", "Click Finish");
                }
            }
        }

        public static void GetInstalledPMNames(out string[] InstalledPMNames, out string[] InstalledPMFriendlyNames)
        {
            RegistryKey RegKey = null, PMRegKey = null;
            RegistryKey RegKeyProcessModules = null;

            InstalledPMNames = null;
            InstalledPMFriendlyNames = null;

            try
            {
                RegKey = Registry.LocalMachine.OpenSubKey(AutoHelper.Tmadapterregkeypath);

                if (null == RegKey)
                {
                    //throw new Exception("The Process Solutions Adapter is not installed on this machine.");
                }
                else
                {
                    RegKeyProcessModules = RegKey.OpenSubKey("ProcessModules");
                    if (RegKeyProcessModules != null && RegKeyProcessModules.SubKeyCount > 0)
                    {
                        InstalledPMNames = RegKeyProcessModules.GetSubKeyNames();

                        int i = 0;
                        InstalledPMFriendlyNames = new string[RegKeyProcessModules.SubKeyCount];
                        foreach (string SubKeyName in RegKeyProcessModules.GetSubKeyNames())
                        {
                            try
                            {
                                PMRegKey = RegKeyProcessModules.OpenSubKey(SubKeyName);
                                InstalledPMFriendlyNames[i] = PMRegKey.GetValue("Name").ToString();
                                i++;
                            }
                            finally
                            {
                                PMRegKey.Close();
                            }
                        }
                    }
                }
            }
            finally
            {
                if (RegKeyProcessModules != null)
                {
                    RegKeyProcessModules.Close();
                    RegKeyProcessModules = null;
                }

                if (RegKey != null)
                {
                    RegKey.Close();
                    RegKey = null;
                }
            }
        }
    }

    class AutoServicesUninstaller
    {

        UninstallerMaster UM = new UninstallerMaster();
        string Uninstallertitle = "Infor Risk & Compliance Services - InstallShield Wizard";

        public void StartServicesUninstaller()
        {
            //UM.isServiceInstallation = true;

            UM.RunServiceExe(Uninstallertitle, "[CLASS:Static; INSTANCE:10]", "Modify, repair, or remove the program.", AutoHelper.ServicesInstallerExe);//[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:4]
            var processes = Process.GetProcesses();
            foreach (var theProcess in processes)
            {
                if (theProcess.MainWindowTitle == Uninstallertitle)
                {
                    if (AutoHelper.IsServicesInstalled() && !AutoHelper.IsAdapterInstalled())
                    {
                        UM.SUWelcome(Uninstallertitle, "", "[CLASS:Button; INSTANCE:5]", "[CLASS:Static; INSTANCE:10]",
                            "Modify, repair, or remove the program.", "[CLASS:Button; INSTANCE:3]");

                        UM.SUWarning1("Infor Risk & Compliance Services", "", "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:2]",
                            "Wizard will start un-installation of Infor Risk & Compliance Services. Do you want to continue?");

                        UM.SUWaitPopup(Uninstallertitle, "[CLASS:Static; INSTANCE:2]",
                            "Uninstall will remove Infor Risk & Compliance Core database.", "Infor Risk & Compliance Services");

                        UM.SUWarningDBBackup("Infor Risk & Compliance Services", "", "[CLASS:Button; INSTANCE:1]",
                            "[CLASS:Static; INSTANCE:2]",
                            @"Uninstall will remove Infor Risk & Compliance Core database.");

                        UM.SUWaitPopup(Uninstallertitle, "[CLASS:Static; INSTANCE:2]",
                            "Database is backed up with name", "Infor Risk & Compliance Services - InstallShield Wizard");

                        UM.SUWarningDBdeleted("Infor Risk & Compliance Services", "",
                            "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:2]",
                            "Database is backed up with name");

                        UM.SUWait(Uninstallertitle, "[CLASS:Static; INSTANCE:4]", "Maintenance Complete");

                        UM.SUCompleteuninstallation(Uninstallertitle, "", "[CLASS:Button; INSTANCE:4]",
                            "[CLASS:Static; INSTANCE:4]", "Maintenance Complete", "[CLASS:Button; INSTANCE:2]");
                    }
                }
            }
        }

    }

    class AutoAdapterUninstaller
    {
        private UninstallerMaster UM = new UninstallerMaster();
        private string Uninstallertitle = "Infor Risk & Compliance Adapter - InstallShield Wizard";

        public void StartAdapterUninstaller()
        {
            UM.RunAdapterExe(Uninstallertitle, "[CLASS:Static; INSTANCE:10]", "Modify, repair, or remove the program.", AutoHelper.AdapterInstallerExe);//[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:4]
            var isAdapterInstalled = AutoHelper.IsAdapterInstalled();
            var processes = Process.GetProcesses();
            foreach (var theProcess in processes)
            {
                if (theProcess.MainWindowTitle == Uninstallertitle)
                {
                    if (isAdapterInstalled)
                    {
                        UM.AUWelcome(Uninstallertitle, "", "[CLASS:Button; INSTANCE:5]", "[CLASS:Static; INSTANCE:10]",
                            "Modify, repair, or remove the program.", "[CLASS:Button; INSTANCE:3]");

                        UM.AUWarning1("Infor Risk & Compliance Adapter", "", "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:2]",
                            "Wizard will start un-installation of Infor Risk & Compliance Adapter.");


                        UM.AUWarning2("Infor Risk & Compliance Adapter", "&Yes", "[CLASS:Button; INSTANCE:1]", "[CLASS:Static; INSTANCE:2]",
                            @"Uninstalling Infor Risk & Compliance Adapter will lead to loss of rules and violations/exceptions for all activated Insights.");

                        UM.AUWait(Uninstallertitle, "[CLASS:Static; INSTANCE:4]", "Maintenance Complete");

                        UM.AUCompleteuninstallation(Uninstallertitle, "&Finish", "[CLASS:Button; INSTANCE:4]",
                            "[CLASS: Static; INSTANCE: 4]", "Maintenance Complete");
                    }
                }
            }
        }
    }
}
