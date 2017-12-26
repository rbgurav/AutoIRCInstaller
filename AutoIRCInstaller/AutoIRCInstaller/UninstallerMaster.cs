using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoIRCInstaller
{
    class UninstallerMaster
    {
        #region InsightUnstaller 
        AutoHelper helper = new AutoHelper();
        public void RunInsightUninstaller(string AppTitle, string PanelID, string SelectionMessage, string ExePath, string Arguments)
        {
            helper.RunExe(AppTitle, PanelID, SelectionMessage, ExePath, Arguments);
            helper.Sleep(3000);
        }
        public void Welcome(string AppTitle, string PanelID, string SelectionMessage)
        {
            helper.KeyPress(AppTitle, "", PanelID, PanelID, SelectionMessage, "{ALT}{N}");
        }
        public void Uninstall(string AppTitle, string PanelID, string SelectionMessage)
        {
            helper.KeyPress(AppTitle, "", PanelID, PanelID, SelectionMessage, "{ALT}{N}");
        }
        public void Wait(string AppTitle, string PanelID, string SelectionMessage)
        {
            helper.Wait(AppTitle, PanelID, SelectionMessage);
        }
        public void UninstallComplete(string AppTitle, string PanelID, string controlID, string SelectionMessage)
        {
           // helper.ButtonClick(AppTitle, "&Finish", PanelID, controlID, SelectionMessage);
            helper.KeyPress(AppTitle, "", PanelID, PanelID, SelectionMessage, "{ALT down}{f}");
            helper.Sleep(2000);
        }
        #endregion

        #region ServicesUninstaller

        public void RunServiceExe(string InstallerAppTitle, string _panelId, string _selectionMessage, string _exepath)
        {
            if (File.Exists(_exepath))
            {
                helper.RunExe(InstallerAppTitle, _panelId, _selectionMessage, _exepath, "");
            }
        }

        public void SUWelcome(string AppTitle, string Text, string btnNext, string PanelID, string selectionMessage, string ControlToSelect)
        {
            helper.SelectRadioButton(AppTitle, ControlToSelect);
            helper.KeyPress(AppTitle, Text, btnNext, PanelID, selectionMessage, "{ALT down}{N}");
            helper.Sleep(1000);
        }
        public void SUWarning1(string AppTitle, string Text, string btnNext, string PanelID, string selectionMessage)
        {
            helper.KeyPress(AppTitle, Text, btnNext, PanelID, selectionMessage, "{ENTER}");
            helper.Sleep(1000);
        }
        public void SUWaitPopup(string AppTitle, string PanelID, string SelectionMessage, string popupTitle)
        {
           helper.WaitPopup(AppTitle,PanelID,SelectionMessage,popupTitle);
            helper.Sleep(1000);
        }

        public void SUWait(string AppTitle, string PanelID, string SelectionMessage)
        {
            helper.Wait(AppTitle, PanelID, SelectionMessage);
            helper.Sleep(1000);
        }

        public void SUWarningDBBackup(string AppTitle, string Text, string btnNext, string PanelID, string selectionMessage)
        {
            helper.KeyPress(AppTitle, Text, btnNext, PanelID, selectionMessage, "{TAB}");
            helper.Sleep(100);
            helper.KeyPress(AppTitle, Text, btnNext, PanelID, selectionMessage, "{ENTER}");
        }

        public void SUWarningDBdeleted(string AppTitle, string Text, string btnNext, string PanelID, string selectionMessage)
        {
            helper.KeyPress(AppTitle, Text, btnNext, PanelID, selectionMessage, "{ENTER}");
            helper.Sleep(100);
        }

        public void SUCompleteuninstallation(string AppTitle, string Text, string btnNext, string PanelID, string selectionMessage, string ControlToSelect)
        {
            helper.SelectRadioButton(AppTitle,ControlToSelect);
            helper.Sleep(1000);
            helper.KeyPress(AppTitle, Text, btnNext, PanelID, selectionMessage, "{ENTER}");
            helper.Sleep(3000);
        }

        #endregion

        #region AdapterUninstaller

        public void RunAdapterExe(string InstallerAppTitle, string _panelId, string _selectionMessage, string _exepath)
        {
            if (File.Exists(_exepath))
            {
                helper.RunExe(InstallerAppTitle, _panelId, _selectionMessage, _exepath, "");
            }
        }

        public void AUWelcome(string AppTitle, string Text, string btnNext, string PanelID, string selectionMessage, string ControlToSelect)
        {
            helper.SelectRadioButton(AppTitle, ControlToSelect);
            helper.ButtonClick(AppTitle, Text, PanelID, btnNext, selectionMessage);
            //helper.KeyPress(AppTitle, Text, btnNext, PanelID, selectionMessage, "{ALT}{N}");
        }
        public void AUWarning1(string AppTitle, string Text, string btnNext, string PanelID, string selectionMessage)
        {
           //helper.ButtonClick(AppTitle, Text, PanelID, btnNext, selectionMessage);
            helper.KeyPress(AppTitle, Text, btnNext, PanelID, selectionMessage, "{ENTER}");
           
        }
        public void AUWait(string AppTitle, string PanelID, string SelectionMessage)
        {
            helper.Wait(AppTitle, PanelID, SelectionMessage);
        }

        public void AUWarning2(string AppTitle, string Text, string btnNext, string PanelID, string selectionMessage)
        {
            //if(helper.getfocusText(AppTitle)=="&No")
            //helper.KeyPress(AppTitle, Text, btnNext, PanelID, selectionMessage, "{TAB}");
            helper.Sleep(300);
            helper.ButtonClick(AppTitle, Text, PanelID, btnNext, selectionMessage);
            //helper.KeyPress(AppTitle, Text, btnNext, PanelID, selectionMessage, "{TAB}");
            //helper.Sleep(100);
            //helper.KeyPress(AppTitle, Text, btnNext, PanelID, selectionMessage, "{ENTER}");
        }

        public void AUCompleteuninstallation(string AppTitle, string Text, string btnNext, string PanelID, string selectionMessage)
        {
            helper.ButtonClick(AppTitle, Text, PanelID, btnNext, selectionMessage);
            helper.Sleep(3000);
        }
        #endregion

    }
}
