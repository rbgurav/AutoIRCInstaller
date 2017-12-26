using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoIRCInstaller
{
    class InstallationMaster
    {
        public bool isServiceInstallation = false;
        public bool isAdapterInstallation = false;

        AutoHelper helper = new AutoHelper();

       
        public void RunExe(string InstallerAppTitle, string _panelId, string _selectionMessage, string _exepath)
        {
            if (File.Exists(_exepath))
            {
                helper.RunExe(InstallerAppTitle, _panelId, _selectionMessage, _exepath,"");

               // helper.Wait(InstallerAppTitle, _panelId, _selectionMessage);
            }
        }

        public void Welcome(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, Process process)
        {
            if (process.MainWindowTitle == InstallerAppTitle)
            {
                //_btnNextControl = "[CLASS:Button; INSTANCE:1]";
                //Text = "&Next >";
                helper.ButtonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
                helper.Sleep(2000);
            }
        }

        public void SelectLicense(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, string btnBrowseControl)
        {
            // btnbrowse button Click
            helper.ButtonClick(InstallerAppTitle, Text, _panelId, btnBrowseControl, _selectionMessage);
            helper.Sleep(1000);

            //License Selection from browseControl
            #region SelectLicenseBrowsePopup
            var browseSelectLicenseTitle = "Choose Folder";
            var pnlSelectLicenseWindowText = "Please choose a license file folder.";
            var pnlSelectLicenseWindowControl = "[CLASS:Static; INSTANCE:1]";
            var txtSelectLicenseWindowControl = "[CLASS:Edit; INSTANCE:1]";
            var btnOkSelectLicenseWindowControl = "[CLASS:Button; INSTANCE:1]";
            // var btnCancelSelectLicenseWindowControl = "[CLASS:Button; INSTANCE:2]";

            //Set License path
            helper.ControlSetText(browseSelectLicenseTitle, AutoHelper.LicensePath, txtSelectLicenseWindowControl, pnlSelectLicenseWindowText, pnlSelectLicenseWindowText);
            helper.Sleep(1000);
            //Click OK button
            helper.ButtonClick(browseSelectLicenseTitle, "", pnlSelectLicenseWindowControl, btnOkSelectLicenseWindowControl, pnlSelectLicenseWindowText);
            helper.Sleep(1000);

            //Click Next Button
            helper.ButtonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);

            helper.Sleep(2000);
            #endregion
        }

        public void CustomInfirmation(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, string txtUserNameControl, string userName, string txtCompanyNameControl, string CompanyName)
        {

            helper.ControlSetText(InstallerAppTitle, CompanyName, txtCompanyNameControl, _panelId, _selectionMessage);
            helper.Sleep(1000);
            helper.ControlSetText(InstallerAppTitle, userName, txtUserNameControl, _panelId, _selectionMessage);
            helper.Sleep(1000);
            helper.ButtonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
            helper.Sleep(2000);
        }

        public void SelectFeatures(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, string selectionListControl, bool isServiceInstallation)
        {

            if (isServiceInstallation)
            {
                for (int i = 0; i <= 13; i++)
                {
                    helper.KeyPress(InstallerAppTitle, Text, selectionListControl, _panelId, _selectionMessage, "{SPACE}");

                    if (i == 6)
                    {
                        helper.Sleep(50);
                        helper.KeyPress(InstallerAppTitle, Text, selectionListControl, _panelId, _selectionMessage, "{DOWN}");
                        helper.KeyPress(InstallerAppTitle, Text, selectionListControl, _panelId, _selectionMessage, "{DOWN}");
                        continue;
                    }
                    helper.KeyPress(InstallerAppTitle, Text, selectionListControl, _panelId, _selectionMessage, "{DOWN}");
                }
            }
            else
            {
                helper.KeyPress(InstallerAppTitle, Text, selectionListControl, _panelId, _selectionMessage, "{SPACE}");
            }

            #region SelectInstallPathBrowsePopup

            // Select Installation path code to be add
            #endregion

            helper.ButtonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);

            helper.Sleep(1000);
        }

        public void WebSiteSelection(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage)
        {

            helper.ButtonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
            helper.Sleep(2000);
        }

        public void SetupStatus(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, string btnyesonQuestion)
        {

            helper.ButtonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
            helper.Sleep(2000);
            helper.ButtonClick("Question", Text, "[CLASS:Static; INSTANCE:2]", btnyesonQuestion, _selectionMessage);
            helper.Sleep(2000);
        }

        public void StartCopyingFile(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage)
        {
            helper.ButtonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
            helper.Sleep(2000);
        }

        public void VirtualFoldersRemovalPopup(string _popupTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage)
        {
            helper.ButtonClick(_popupTitle, Text, _panelId, _btnNextControl, _selectionMessage);
            helper.Sleep(1000);
        }

        public void Winwait(string InstallerAppTitle, string _panelId, string _selectionMessage)
        {
            helper.Wait(InstallerAppTitle, _panelId, _selectionMessage);
            helper.Sleep(500);
        }

        public void InstallComplete(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage)
        {
            helper.ButtonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
            helper.Sleep(5000);
        }

        #region PIInsight

        public void PIInsightWelcome(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, Process process)
        {
            if (process.MainWindowTitle == InstallerAppTitle)
            {
                //_btnNextControl = "[CLASS:Button; INSTANCE:1]";
                //Text = "&Next >";                
                helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
                helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
                helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
                helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");

                helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ENTER}");

                //helper.buttonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
                helper.Sleep(2000);
            }
        }
        public void PIInsightLocationSelection(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, string _controlToSendText, string TexttoSet)
        {
            helper.ControlSetText(InstallerAppTitle, TexttoSet, _controlToSendText, _panelId, _selectionMessage);
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ENTER}");
            //helper.buttonClick(InstallerAppTitle, "", _panelId, _btnNextControl, _selectionMessage);
        }
        public void PISelecInsighttLicense(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, string _controlToSendText, string TexttoSet)
        {
            helper.Sleep(500);
            helper.ControlSetText(InstallerAppTitle, TexttoSet, _controlToSendText, _panelId, _selectionMessage);
            helper.Sleep(50);
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ENTER}");
            //helper.buttonClick(InstallerAppTitle, "", _panelId, _btnNextControl, _selectionMessage);
        }
        public void PIInsightSelection(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage)
        {
            helper.ButtonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
        }
        public void PIInstallationSummary(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage)
        {
            helper.ButtonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
        }
        public void PIInsightActivation(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage)
        {
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{Enter}");
            //helper.buttonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
        }
        public void PIInsightInstallComplete(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage)
        {
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{Enter}");
            //helper.buttonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
        }

        #endregion

        #region AIInsight

        public void AIInsightWelcome(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, Process process)
        {
            if (process.MainWindowTitle == InstallerAppTitle)
            {
                //_btnNextControl = "[CLASS:Button; INSTANCE:1]";
                //Text = "&Next >";                
                helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ALT}{N}");
                helper.Sleep(500);
                //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
                //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
                //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
                //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");

                //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ENTER}");

                //helper.buttonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
                helper.Sleep(2000);
            }
        }
        public void AIInsightLocationSelection(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, string _controlToSendText, string TexttoSet)
        {
            helper.ControlSetText(InstallerAppTitle, TexttoSet, _controlToSendText, _panelId, _selectionMessage);
            helper.Sleep(2000);
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ALT}{N}");
            helper.Sleep(2000);
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ENTER}");
            //helper.buttonClick(InstallerAppTitle, "", _panelId, _btnNextControl, _selectionMessage);
        }
        public void AISelecInsighttLicense(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, string _controlToSendText, string TexttoSet)
        {
            helper.Sleep(2000);
            helper.ControlSetText(InstallerAppTitle, TexttoSet, _controlToSendText, _panelId, _selectionMessage);
            helper.Sleep(50);
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            helper.Sleep(50);
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ALT}{N}");
            helper.Sleep(2000);
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ENTER}");
            //helper.buttonClick(InstallerAppTitle, "", _panelId, _btnNextControl, _selectionMessage);
        }
        public void AIInsightSelection(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage)
        {
            helper.Sleep(2000);
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ALT}{N}");
            helper.Sleep(2000);
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ENTER}");
            //  helper.buttonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
        }
        public void AIInstallationSummary(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage)
        {
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ALT}{N}");
            helper.Sleep(2000);
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ENTER}");
            //helper.buttonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
        }
        public void AIInsightActivation(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage)
        {
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ALT}{N}");
            helper.Sleep(2000);
            // helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            // helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{Enter}");
            //helper.buttonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
        }
        public void AIInsightInstallComplete(string InstallerAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage)
        {
            helper.Sleep(5000);
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            helper.Sleep(1000);
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ALT}{F}");
            helper.Sleep(2000);
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{Enter}");
            //helper.buttonClick(InstallerAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
        }

        #endregion

        #region AI Activation

       public void AIAWelcome(string InstallerAppTitle, string _panelId, string _selectionMessage)
        {
            helper.Sleep(1000);
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ALT}{N}");           
        }
        public void AIAInsightSelection(string InstallerAppTitle, string _panelId, string _selectionMessage)
        {
            helper.Sleep(1000);
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ALT}{N}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{TAB}");
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ENTER}");
        }
        public void AIAInstallationSummary(string InstallerAppTitle, string _panelId, string _selectionMessage)
        {
            //helper.keyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{END}");
            helper.Sleep(1000);
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ALT down}{N}");
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ALT up}");
        }
        public void AIAInsightActivation(string InstallerAppTitle, string _panelId, string _selectionMessage)
        {
            helper.Sleep(1000);
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ALT down}{N}");
        }
        public void AIAWinwait(string InstallerAppTitle, string _panelId, string _selectionMessage)
        {
            helper.Wait(InstallerAppTitle, _panelId, _selectionMessage);
            helper.Sleep(500);
        }
        public void AIAInstallComplete(string InstallerAppTitle, string _panelId, string _selectionMessage)
        {
            helper.Sleep(1000);
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ALT}{F}");
        }

        #endregion


        public void ServicesUnstallation()
        {
            //_selectionMessage = "Welcome";
            //_panelId = "[CLASS:Static; INSTANCE:4]";
            //var rdoModifycontrol = "[CLASS:Button; INSTANCE:1]";
            //var rdoModifyText = "&Modify";
            //var rdoRepaircontrol = "[CLASS:Button; INSTANCE:2]";
            //var rdoRepairText = "R&epair";
            //var rdoRemovecontrol = "[CLASS:Button; INSTANCE:3]";
            //var rdoRemoveText = "&Remove";
            //_btnNextControl = "[CLASS:Button; INSTANCE:5]";
            //_btnNextControlText = "&Next >";
            //_btnCancelControl = "[CLASS:Button; INSTANCE:6]";
            //_btnCancelControlText = "Cancel";

            //string btnPopupYesControl = "[CLASS:Button; INSTANCE:1]";
            //string btnPopupYescontrolText = "&Yes";
            //string btnPopupNoControl = "[CLASS:Button; INSTANCE:2]";
            //string btnPopupNocontrolText = "&No";


            //_selectionMessage = "Maintenance Complete";
            //string rdoYesRestartControl = "[CLASS:Button; INSTANCE:1]";
            //string rdoYesRestartText = "Yes, I want to restart my computer now.";
            //string rdoNoRestartControl = "[CLASS:Button; INSTANCE:2]";
            //string rdoNoRestartText = "No, I will restart my computer later.";

            //_btnNextControl = "[CLASS:Button; INSTANCE:4]";
            //btnPopupNocontrolText = "Finish";

            //_autoServiceInstaller.WinActivate(ServiceInstallerAppTitle);
            //_autoServiceInstaller.ControlFocus(ServiceInstallerAppTitle, "", rdoRemovecontrol);
            //_autoServiceInstaller.Send("{Enter}");
            //Thread.Sleep(1000);
            //_autoServiceInstaller.ControlFocus(ServiceInstallerAppTitle, "", _btnNextControl);
            //_autoServiceInstaller.Send("{Enter}");
        }
    }
}
