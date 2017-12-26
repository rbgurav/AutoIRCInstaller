using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace AutoIRCInstaller
{
    internal class AutoUpgrade
    {
        private AutoItX3 _robot = new AutoItX3();

        public void StartUpgradeInstaller()
        {

            //string UpgradeConsoleTitle = @"C:\tempBuild\x64\UpgradeSetup.exe";
            string UpgradeTitle = "Infor Risk & Compliance Upgrade";
            string Upgrade_exe = @"C:\tempBuild\x64\UpgradeSetup";

            bool isNotreadytoUpgrade = false; // IM.isInsightInstalled(insightName);
            RunExe(UpgradeTitle, "UpgradeTitleHeading",
                "Infor Risk & Compliance Upgrade", @"D:\Program Files\Approva\BizRights\BizRights Upgrade Framework\UpgradeWizard");

            var processes = Process.GetProcesses();
            foreach (var theProcess in processes)
            {
                if (theProcess.MainWindowTitle.Contains(UpgradeTitle))
                {
                    if (!isNotreadytoUpgrade)
                    {
                        Configure(UpgradeTitle, "", "", "", "txtSQLAccessUserName", "sa", "txtSQLAccessUserPassword",
                            "approva1@",
                            "txtLicenseFilePath", @"C:\", "txtBackup", @"C:\tempBuild", "btnGoToNext");
                        //ProcessInUse();
                        //PreRequisitecheck();
                        //EnvironmentCheck();
                        //ApplicableProducts();

                    }
                }
            }

        }

        private bool RunExe(string upgradeTitle, string PanelID, string selectionMessage, string Upgrade_exe)
        {
            bool isStarted = false;
            if (File.Exists(Upgrade_exe))
            {

                ProcessStartInfo info = new ProcessStartInfo(Upgrade_exe);
                info.UseShellExecute = true;
                info.Verb = "runas";
                Process.Start(info);
                Wait(upgradeTitle, PanelID, selectionMessage);
            }
            return isStarted;
        }

        private void Wait(string appTitle, string panelId, string selectionMessage)
        {
            bool isStarted = false;
            while (!isStarted)
            {
                Thread.Sleep(1000);
                var processes = Process.GetProcesses();
                foreach (var prServiceInstallExist in processes)
                {
                    if (prServiceInstallExist.MainWindowTitle == appTitle)
                        ///*|| prServiceInstallExist.MainWindowTitle == "Continuous Monitoring Insight Setup"
                    {
                        _robot.ControlFocus(appTitle, "", panelId);
                        if (_robot.ControlGetText(appTitle, "", panelId) == selectionMessage ||
                            _robot.ControlGetText(appTitle, "", panelId).Contains(selectionMessage))
                        {
                            isStarted = true;
                            Thread.Sleep(1000);
                            break;
                        }
                    }
                }
            }
        }

        private void Configure(string appTitle, string Text,
            string cntrlWinAuth, string cntrlSQLAuth,
            string cntrlUser, string textUser,
            string cntrlPass, string textPass,
            string cntrlLicense, string textlicense,
            string cntrlBackup, string textBackup,
            string btnControl)
        {
            _robot.WinActivate(appTitle);
           // _robot.ControlFocus(appTitle, Text, cntrlSQLAuth);
            _robot.ControlSetText(appTitle, Text, cntrlUser, textUser);
            _robot.ControlSetText(appTitle, Text, cntrlPass, textPass);
            _robot.ControlSetText(appTitle, Text, cntrlLicense, textlicense);
            _robot.ControlSetText(appTitle, Text, cntrlBackup, textBackup);

            _robot.ControlFocus(appTitle, Text, btnControl);
            _robot.ControlClick(appTitle, Text, btnControl, "LEFT", 1);
        }
    }
}
