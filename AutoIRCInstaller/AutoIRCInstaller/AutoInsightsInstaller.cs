using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AutoIRCInstaller
{
    class AutoInsightsInstaller
    {
        AutoHelper helper = new AutoHelper();
        InstallationMaster IM = new InstallationMaster();
        
        const string _InsightInstallerAppTitle = "Infor Risk & Compliance Insight Setup";
        const string _InsightActivatorAppTitle = "Infor Risk & Compliance Insight Activation Wizard";
        
        public void StartPIInsightInstaller()
        {
            string[] PIInsightexe = new string[] { };
            if (Directory.Exists(AutoHelper.PiInsightPath))
            {
                 PIInsightexe = System.IO.Directory.GetFiles(AutoHelper.PiInsightPath, "*.exe", SearchOption.AllDirectories);
            }
            string insightName = "";
            bool isInsightInstalled = false; // IM.isInsightInstalled(insightName);
            string _insightpath = "";

            foreach (var insight in PIInsightexe)
            {
                IM.RunExe(_InsightInstallerAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:3]", "Click Next to Continue, or Cancel to exit Setup", insight);
                var processes = Process.GetProcesses();

                foreach (var theProcess in processes)
                {
                    if (theProcess.MainWindowTitle == _InsightInstallerAppTitle)
                    {
                        if (!isInsightInstalled)
                        {
                            // Pi Insight Installation
                            IM.PIInsightWelcome(_InsightInstallerAppTitle, "", "m_btnNext", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:3]", "Click Next to Continue, or Cancel to exit Setup", theProcess);
                            IM.PIInsightLocationSelection(_InsightInstallerAppTitle, "", "WindowsForms10.BUTTON.app.0.141b42a_r6_ad1", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:7]", "Choose Insight Location", "[CLASS:WindowsForms10.Window.8.app.0.141b42a_r6_ad1; INSTANCE:2]", AutoHelper.PiInsightPath);
                            IM.PISelecInsighttLicense(_InsightInstallerAppTitle, "", "m_btnNext", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:9]", "Choose license file location", "[CLASS:WindowsForms10.EDIT.app.0.141b42a_r6_ad1; INSTANCE:2]", AutoHelper.LicensePath);
                            IM.PIInsightSelection(_InsightInstallerAppTitle, "", "m_btnNext", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:13]", "Infor Risk && Compliance Insights Selection");
                            IM.PIInstallationSummary(_InsightInstallerAppTitle, "", "m_btnNext", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:20]", "Installation Summary");
                            IM.Winwait(_InsightInstallerAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:26]", "Infor Risk && Compliance Insight Activation");
                            IM.PIInsightActivation(_InsightInstallerAppTitle, "", "m_btnNext", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:27]", "Please click on the Next button to start the activation process:");
                            IM.Winwait(_InsightInstallerAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:27]", "Finished Publishing Insight to Infor Risk && Compliance");
                            IM.PIInsightInstallComplete(_InsightInstallerAppTitle, "", "m_btnNext", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:27]", "Finished Publishing Insight to Infor Risk && Compliance");
                        }
                    }
                }
            }
        }

        public void StartAIInsightInstaller()
        {
            string insightName = "";
            bool isInsightInstalled = false;// IM.isInsightInstalled(insightName);
            IM.RunExe(_InsightInstallerAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:4]", "Click Next to Continue, or Cancel to exit Setup", AutoHelper.ExeAiInstallerPath);

            var processes = Process.GetProcesses();
            foreach (var theProcess in processes)
            {
                if (theProcess.MainWindowTitle == _InsightInstallerAppTitle)
                {
                    if (!isInsightInstalled)
                    {
                        // AI Insight Installation
                        IM.AIInsightWelcome(_InsightInstallerAppTitle, "", "m_btnNext", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:4]", "Click Next to Continue, or Cancel to exit Setup", theProcess);
                        helper.Sleep(50);
                        IM.AIInsightLocationSelection(_InsightInstallerAppTitle, "", "WindowsForms10.BUTTON.app.0.141b42a_r6_ad1", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:7]", "Choose Insight Location", "[CLASS:WindowsForms10.EDIT.app.0.141b42a_r6_ad1; INSTANCE:1]", AutoHelper.AiInsightpath);
                        helper.Sleep(50);
                        IM.AISelecInsighttLicense(_InsightInstallerAppTitle, "", "m_btnNext", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:9]", "Choose license file location", "[CLASS:WindowsForms10.EDIT.app.0.141b42a_r6_ad1; INSTANCE:2]", AutoHelper.LicensePath);
                        helper.Sleep(50);
                        IM.AIInsightSelection(_InsightInstallerAppTitle, "", "m_btnNext", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:13]", "Infor Risk && Compliance Insights Selection");
                        helper.Sleep(50);
                        IM.AIInstallationSummary(_InsightInstallerAppTitle, "", "m_btnNext", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:20]", "Installation Summary");
                        helper.Sleep(50);
                        IM.AIInsightActivation(_InsightInstallerAppTitle, "", "m_btnNext", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:24]", "Please wait while Setup installs Insights");
                        helper.Sleep(50);
                        IM.Winwait(_InsightInstallerAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:21]", "Installing Insights on Infor Risk && Compliance : Done.");
                        IM.AIInsightInstallComplete(_InsightInstallerAppTitle, "", "m_btnNext", "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:21]", "Installing Insights on Infor Risk && Compliance : Done.");
                        // AI Insight Activation
                        InsightAIActivation();
                    }
                }
            }
        }

        private void InsightAIActivation()
        {
            IM.RunExe(_InsightActivatorAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:5]", "Welcome to Infor Risk && Compliance Insight Activation Wizard",AutoHelper.ExeActivaterPath);

            var processes = Process.GetProcesses();
            foreach (var theProcess in processes)
            {
                if (theProcess.MainWindowTitle == _InsightActivatorAppTitle)
                {
                    IM.AIAWelcome(_InsightActivatorAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:5]", "Welcome to Infor Risk && Compliance Insight Activation Wizard");
                    IM.AIAInsightSelection(_InsightActivatorAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:10]", "Infor Risk && Compliance Insight");
                    IM.AIAInstallationSummary(_InsightActivatorAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:11]", "Infor Risk && Compliance Insight Name");
                    IM.AIAInsightActivation(_InsightActivatorAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:17]", "Activate");
                    IM.AIAWinwait(_InsightActivatorAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:20]", "Summary of tasks completed");
                    IM.AIAInstallComplete(_InsightActivatorAppTitle, "[CLASS:WindowsForms10.STATIC.app.0.141b42a_r6_ad1; INSTANCE:20]", "Summary of tasks completed");
                }
            }
        }

        public void DeleteTempFolders()
        {
            string[] files = Directory.GetFiles(AutoHelper.LocalCopyPath);
            string[] dirs = Directory.GetDirectories(AutoHelper.LocalCopyPath);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                Directory.Delete(dir, true);
                //DeleteDirectory(dir);
            }

            Directory.Delete(AutoHelper.LocalCopyPath, true);
        }

        #region insightInstallerCode
        //public void StartAutoInsightInstaller()
        //{
        //    CopyInsightstoLocalPath();
        //    IM.RunExe(_InsightInstallerAppTitle,"", "Welcome to Infor Risk & Compliance Insight Setup",_exeInstallerPath);
        //    Welcome();
        //    InsightLocationSelection();
        //    LicenseSelection();
        //    InsightSelection();
        //    InstallationSummary();
        //    InsightInsightInprogress();
        //    FinishInstalltion();
        //    //SendMail();
        //}       

        //private void FinishInstalltion()
        //{
        //    _btnControlNext = "[NAME: m_btnNext]";
        //    _panelID = "[NAME:m_lblDesc]";
        //    _selectioMessage = "Please wait while Setup installs Insights";
        //    Text = "&Finish";
        //    helper.Sleep(1000);
        //    helper.buttonClick(_InsightInstallerAppTitle, Text, _panelID, _btnControlNext, _selectioMessage);
        //}

        //private void InsightInsightInprogress()
        //{
        //    //Set panel id and selection message for next window
        //    _btnControlNext = "[NAME:m_btnNext]";
        //    _panelID = "[NAME:lblBizRights]";

        //    _selectioMessage = "Installing Insights on Infor Risk && Compliance : Done.";

        //    helper.buttonClick(_InsightInstallerAppTitle, Text, _panelID, _btnControlNext, _selectioMessage);
        //    helper.Sleep(2000);

        //    //_btnControlNext = "[NAME: m_btnNext]";
        //    _panelID = "[NAME:m_btnNext]";
        //    _selectioMessage = "&Finish";

        //    helper.Wait(_InsightInstallerAppTitle, _panelID, _selectioMessage);
        //}

        //private void InstallationSummary()
        //{
        //    _panelID = "[NAME: lblTitle]";
        //    _selectioMessage = "Installation Summary";
        //    _btnControlNext = "[NAME:m_btnNext]";

        //    helper.buttonClick(_InsightInstallerAppTitle, "", _panelID, _btnControlNext, _selectioMessage);
        //    helper.Sleep(2000);
        //}

        //private void InsightSelection()
        //{
        //    _selectioMessage = "Infor Risk && Compliance Insights Selection";
        //    _panelID = "[NAME:lblTitle]";
        //    _btnControlNext = "[NAME:m_btnNext]";

        //    helper.buttonClick(_InsightInstallerAppTitle, Text, _panelID, _btnControlNext, _selectioMessage);
        //    helper.Sleep(2000);

        //}

        //private void InsightLocationSelection()
        //{
        //    try
        //    {
        //        _selectioMessage = "Infor Risk & Compliance Insight Installer";
        //        string txtInsightpath = "[NAME:txtInsightPath]";
        //        _panelID = "[NAME:label1]";
        //        _btnControlNext = "[NAME:m_btnNext]";
        //        helper.ControlSetText(_InsightInstallerAppTitle, _localCopyPath, txtInsightpath, _panelID, _selectioMessage);

        //        helper.buttonClick(_InsightInstallerAppTitle, "", _panelID, _btnControlNext, _selectioMessage);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //private void SendMail()
        //{
        //    helper.SendMail("raviraj.gurav@infor.com ,Prashant.Hatte@infor.com, rbgurav@gmail.com", "Raviraj Gurav", "Test mail", "This is body message");
        //}

        //private void LicenseSelection()
        //{

        //    string txtLicensePath = "WindowsForms10.Window.8.app.0.141b42a_r12_ad12";
        //    _panelID = "[NAME:label1]";
        //    _selectioMessage = "Infor Risk & Compliance Insight Installer";
        //    bool isselectedLicense = helper.ControlSetText(_InsightInstallerAppTitle, helper.LicensePath, txtLicensePath, _panelID, _selectioMessage);
        //    // Click next 
        //    _btnControlNext = "[NAME:m_btnNext]";

        //    helper.buttonClick(_InsightInstallerAppTitle, "", _panelID, _btnControlNext, _selectioMessage);
        //}

        //private void Welcome()
        //{
        //    try
        //    {
        //        _btnControlNext = "[NAME:m_btnNext]";
        //        _selectioMessage = "Click Next to Continue, or Cancel to exit Setup";
        //        _panelID = "[NAME:m_lblAction]";
        //        _isclicked = helper.buttonClick(_InsightInstallerAppTitle,Text,_panelID , _btnControlNext, _selectioMessage);
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}

        //private void RunInstaller()
        //{
        //    try
        //    {
        //        _selectioMessage = "Welcome to Infor Risk & Compliance Insight Setup";
        //        _panelID = "WindowsForms10.Window.8.app.0.141b42a_r12_ad1";
        //        helper.RunExe(_exeInstallerPath, _InsightInstallerAppTitle, _panelID, _selectioMessage);
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
        #endregion

    }

    #region Absolute
    //class AutoInsightsActivate
    //{

    //    const string _InsightActivateAppTitle = "Infor Risk & Compliance Insight Activation Wizard";
    //    string _buildInstallPath = @"\\serv02fs01\Builds\10.1.3\10.1.3.0002.Signed";
    //    string _localInstallPath = string.Empty;
    //    string _localCopyPath = @"C:\TempInsights";
    //    string _exeInsightActivatePath = @"\\serv02208\C$\Program Files\Approva\BizRights\Adapters\TMonitor\bin\ProcessModuleActivation.exe";
    //    string _panelID = string.Empty;
    //    string _selectioMessage = string.Empty;
    //    string _btnControlNext = string.Empty;
    //    bool _isclicked = false;
    //    string Text = string.Empty;

    //    AutoHelper helper = new AutoHelper();

    //    public void StartAutoInsightInstaller()
    //    {
    //        RunActivateExe();
    //        Welcome();
    //        InsightSelection();
    //        InsightNameChange();
    //        Activate();
    //        Finish();
    //    }

    //    private void RunActivateExe()
    //    {
    //        _selectioMessage = "This wizard prepares your Infor Risk & Compliance Insights installation for use";
    //        _panelID = "[NAME:lblNote1]";
    //        helper.RunExe(_exeInsightActivatePath, _InsightActivateAppTitle, _panelID, _selectioMessage);
    //    }

    //    private void Welcome()
    //    {
    //        _panelID = "[NAME: lblNote1]";
    //        _selectioMessage = "This wizard prepares your Infor Risk & Compliance Insights installation for use.";
    //        _btnControlNext = "[NAME:btnNext]";
    //        //WelcomeScreen
    //        Text = "&Next";
    //        _isclicked = helper.buttonClick(_InsightActivateAppTitle, Text, _panelID, _btnControlNext, _selectioMessage);
    //    }

    //    private void InsightSelection()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    private void InsightNameChange()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    private void Activate()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    private void Finish()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    string _exeInstallerPath = @"\\serv02208\C$\Program Files\Approva\BizRights\Adapters\TMonitor\bin\InsightInstaller.exe";
    //    AutoInsightsInstaller autoinsightInstaller = new AutoInsightsInstaller();

    //    private void RunInstaller()
    //    {
    //        try
    //        {
    //            _selectioMessage = "Welcome to Infor Risk & Compliance Insight Setup";
    //            _panelID = "WindowsForms10.Window.8.app.0.141b42a_r12_ad1";
    //            // helper.RunExe(_exeInstallerPath, _InsightInstallerAppTitle, _panelID, _selectioMessage);
    //        }
    //        catch (Exception)
    //        {

    //        }
    //    }




    //} 
    #endregion
}