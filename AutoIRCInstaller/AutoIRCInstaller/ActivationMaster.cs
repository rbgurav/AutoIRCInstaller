using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoIRCInstaller
{
    class ActivationMaster
    {
        AutoHelper helper = new AutoHelper();

        #region ServicesActivation

        public void RunServiceActivationExe(string ServiceActivationAppTitle, string _panelId, string _selectionMessage, string _exepath)
        {
            if (File.Exists(_exepath))
            {
                helper.RunExe(ServiceActivationAppTitle, _panelId, _selectionMessage, _exepath, "");

               // helper.Wait(ServiceActivationAppTitle, _panelId, _selectionMessage);
            }
            helper.Sleep(2000);
        }
        public void Welcome(string ActivationAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, Process process)
        {
            if (process.MainWindowTitle == ActivationAppTitle)
            {
                helper.KeyPress(ActivationAppTitle, Text, _btnNextControl, _panelId, _selectionMessage, "{ALT}{N}");
                //helper.ButtonClick(ActivationAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
            }
        }
        public void AuthenticationServer(string ActivationAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, string ddlAuthenticationControl, string AuthType)
        {

            //dropdown selection
            if (AuthType == "AD")
            {
                if (helper.ControlGetText(ActivationAppTitle, ddlAuthenticationControl, _panelId, _selectionMessage) == "Microsoft Active Directory")
                {
                    helper.ButtonClick(ActivationAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
                }
            }
            if (AuthType == "IRC")
            {
                helper.KeyPress(ActivationAppTitle, Text, ddlAuthenticationControl, _panelId, _selectionMessage, "{DOWN}");
                //if (helper.ControlGetText(ActivationAppTitle, ddlAuthenticationControl, _panelId, _selectionMessage) == "Infor Risk & Compliance Application Security")
                //{
                helper.ButtonClick(ActivationAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
                // }
                helper.Sleep(2000);
            }
        }
        public void IRCAdministrator(string ActivationAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, string controlUsername, string Username, string controlPassword, string Password, string controlConfirmPassword, string ConfirmPassword)

        {
            helper.ControlSetText(ActivationAppTitle, Username, controlUsername, _panelId, _selectionMessage);
            helper.ControlSetText(ActivationAppTitle, Password, controlPassword, _panelId, _selectionMessage);
            helper.ControlSetText(ActivationAppTitle, ConfirmPassword, controlConfirmPassword, _panelId, _selectionMessage);

            helper.ButtonClick(ActivationAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
            helper.Sleep(2000);
        }
        public void IRCServiceAccount(string ActivationAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, string controlUsername, string Username, string controlPassword, string Password)
        {

            helper.ControlSetText(ActivationAppTitle, Username, controlUsername, _panelId, _selectionMessage);
            helper.ControlSetText(ActivationAppTitle, Password, controlPassword, _panelId, _selectionMessage);

            helper.ButtonClick(ActivationAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
            helper.Sleep(2000);
        }
        public void DBCreationStep_1(string ActivationAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, string controlSqlServer, string SQLServer, string controlDBName, string DatabaseName, string controlRadioButton, string radioselectionMessage, string controlSqlUsername, string SQLServerUsername, string controlSqlPass, string SqlPassword)
        {
            //helper.Sleep(5000);
            helper.ControlSetText(ActivationAppTitle, SQLServer, controlSqlServer, _panelId, _selectionMessage);
            helper.ControlSetText(ActivationAppTitle, DatabaseName, controlDBName, _panelId, _selectionMessage);

            helper.SelectRadioButton(ActivationAppTitle, controlRadioButton);

            helper.ControlSetText(ActivationAppTitle, SQLServerUsername, controlSqlUsername, _panelId, _selectionMessage);
            helper.ControlSetText(ActivationAppTitle, SqlPassword, controlSqlPass, _panelId, _selectionMessage);

            helper.ButtonClick(ActivationAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
            helper.Sleep(2000);
        }
        public void DBCreationStep_2(string ActivationAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, string controlDBDir, string DBDirectory, string ControlDBLogDir, string DBLogDir, string ControlDBFileGrp, string DBFileGrp)
        {
            // helper.ControlSetText(ActivationAppTitle, DBDirectory, controlDBDir, _panelId, _selectionMessage);
            // helper.ControlSetText(ActivationAppTitle, DBLogDir, ControlDBLogDir, _panelId, _selectionMessage);
            // helper.ControlSetText(ActivationAppTitle, DBFileGrp, ControlDBFileGrp, _panelId, _selectionMessage);

            helper.ButtonClick(ActivationAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
            helper.Sleep(2000);
        }
        public void DatabaseAccount(string ActivationAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, string controlRadioButton, string radioselectionMessage, string controlSQLUserName, string SQLUsername, string controlSQLPass, string SQLPass)
        {
            helper.SelectRadioButton(ActivationAppTitle, controlRadioButton);

            helper.ControlSetText(ActivationAppTitle, SQLUsername, controlSQLUserName, _panelId, _selectionMessage);
            helper.ControlSetText(ActivationAppTitle, SQLPass, controlSQLPass, _panelId, _selectionMessage);

            helper.ButtonClick(ActivationAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
            helper.Sleep(2000);
        }
        public void MSSSRSDetails(string ActivationAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage,
            string ControlPortNum, string PortNum, string ControlRMVirtualDir, string RMVirtualDir, string ControlRSVirtualDir, string RSVirtualDir,
            string ControlCompanyName, string CompanyName, string ControlSQLServerName, string SqlServerName, string ControlSQLRSDBName, string DBName,
            string ControlchkEnableMSSSRS, string ControlChkUseSSL
            )
        {

            helper.ControlSetText(ActivationAppTitle, PortNum, ControlPortNum, _panelId, _selectionMessage);
            helper.ControlSetText(ActivationAppTitle, RMVirtualDir, ControlRMVirtualDir, _panelId, _selectionMessage);
            helper.ControlSetText(ActivationAppTitle, RSVirtualDir, ControlRSVirtualDir, _panelId, _selectionMessage);
            helper.ControlSetText(ActivationAppTitle, CompanyName, ControlCompanyName, _panelId, _selectionMessage);
            helper.ControlSetText(ActivationAppTitle, SqlServerName, ControlSQLServerName, _panelId, _selectionMessage);
            helper.ControlSetText(ActivationAppTitle, DBName, ControlSQLRSDBName, _panelId, _selectionMessage);

            helper.ButtonClick(ActivationAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
            helper.Sleep(2000);
        }

        public void ReportServerExist(string ActivationAppTitle, string Text, string btnControl, string panelID, string Selectionmessage)
        {
            helper.Sleep(2000);
            helper.KeyPress(ActivationAppTitle, Text, btnControl, panelID, Selectionmessage, "{ENTER}");
            helper.Sleep(2000);
        }

        public void Activate(string ActivationAppTitle, string Text, string btnControl, string panelID, string Selectionmessage)
        {
            helper.KeyPress(ActivationAppTitle, Text, "", panelID, Selectionmessage, "{ALT}{N}");
            helper.Sleep(2000);
        }


        public void ActivationCompleted(string ActivationAppTitle, string Text, string btnControl, string panelID, string Selectionmessage)
        {
            helper.ButtonClick(ActivationAppTitle, Text, panelID, btnControl, Selectionmessage);
            helper.Sleep(2000);
        }
        public void Winwait(string InstallerAppTitle, string _panelId, string _selectionMessage)
        {
            helper.Wait(InstallerAppTitle, _panelId, _selectionMessage);
        }

        #endregion

        #region Adapter Activation
        public void RunAdapterActivationExe(string ServiceActivationAppTitle, string _panelId, string _selectionMessage, string _exepath)
        {
            if (File.Exists(_exepath))
            {
                helper.RunExe(ServiceActivationAppTitle, _panelId, _selectionMessage, _exepath, "");

                helper.Wait(ServiceActivationAppTitle, _panelId, _selectionMessage);
            }
        }

        public void ADWelcome(string ActivationAppTitle, string Text, string _btnNextControl, string _panelId, string _selectionMessage, Process process)
        {
            if (process.MainWindowTitle == ActivationAppTitle)
            {
                helper.ButtonClick(ActivationAppTitle, Text, _panelId, _btnNextControl, _selectionMessage);
                Thread.Sleep(2000);
            }
        }

        public void ADIRCServerdetails(string InstallerAppTitle, string _panelId, string _selectionMessage, string CntrlServer, string TextServer, string CntrlAdapter, string TextAdapter)
        {
            helper.ControlSetText(InstallerAppTitle, TextServer, CntrlServer, _panelId, _selectionMessage);
            helper.ControlSetText(InstallerAppTitle, TextAdapter, CntrlAdapter, _panelId, _selectionMessage);
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ALT down}{N}");
            helper.KeyPress(InstallerAppTitle, "", "", _panelId, _selectionMessage, "{ALT up}");
        }

        public void ADAdapterDescription(string ActivationAppTitle, string Text, string _panelId, string _selectionMessage)
        {
            helper.KeyPress(ActivationAppTitle, Text, "", _panelId, _selectionMessage, "{ALT down}{N}");
            helper.KeyPress(ActivationAppTitle, Text, "", _panelId, _selectionMessage, "{ALT up}");
        }

        public void ADServiceConfiguration(string ActivationAppTitle, string Text, string _panelId, string _selectionMessage,
            string Servicename, string cntrlServicename,
            string SeviceDisplayName, string cntrlServiceDisplayName,
            string ServicePort, string cntrlServicePort,
             string Username, string cntrlUsername,
             string password, string cntrlPassword,
             string ConnectorType, string cntrlConnectorType)
        {
            helper.ControlSetText(ActivationAppTitle, Servicename, cntrlServicename, _panelId, _selectionMessage);
            helper.ControlSetText(ActivationAppTitle, SeviceDisplayName, cntrlServiceDisplayName, _panelId, _selectionMessage);
            helper.ControlSetText(ActivationAppTitle, ServicePort, cntrlServicePort, _panelId, _selectionMessage);
            helper.ControlSetText(ActivationAppTitle, Username, cntrlUsername, _panelId, _selectionMessage);
            helper.ControlSetText(ActivationAppTitle, password, cntrlPassword, _panelId, _selectionMessage);
            // Select Connector type
            helper.KeyPress(ActivationAppTitle, Text, "", _panelId, _selectionMessage, "{ALT down}{N}");
           // helper.keyPress(ActivationAppTitle, Text, "", _panelId, _selectionMessage, "{ALT up}");
        }

        public void ADOraclePopup(string ActivationAppTitle, string Text, string ControlID, string _panelId, string _selectionMessage)
        {
            helper.KeyPress(ActivationAppTitle, Text, ControlID, _panelId, _selectionMessage, "{TAB}");
            helper.KeyPress(ActivationAppTitle, Text, ControlID, _panelId, _selectionMessage, "{ENTER}");
        }

        public void ADActivate(string ActivationAppTitle, string Text, string _panelId, string _selectionMessage)
        {
            helper.KeyPress(ActivationAppTitle, Text, "", _panelId, _selectionMessage, "{ALT}{N}");
        }
        public void ADActivationComplete(string ActivationAppTitle, string Text, string _panelId, string _selectionMessage)
        {
            helper.KeyPress(ActivationAppTitle, Text, "", _panelId, _selectionMessage, "{ALT}{F}");
        }

        public void ADpopup1(string ActivationAppTitle, string Text, string ControlID, string _panelId, string _selectionMessage)
        {
            helper.KeyPress(ActivationAppTitle, Text, ControlID, _panelId, _selectionMessage, "{TAB}");
            helper.KeyPress(ActivationAppTitle, Text, ControlID, _panelId, _selectionMessage, "{ENTER}");
        }
        
        public void ADWinwait(string InstallerAppTitle, string _panelId, string _selectionMessage)
        {
            helper.Wait(InstallerAppTitle, _panelId, _selectionMessage);
        }

        #endregion

    }
}
