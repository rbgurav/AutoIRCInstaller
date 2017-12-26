using AutoItX3Lib;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Net.Mail;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;

namespace AutoIRCInstaller
{
    class AutoHelper
    {
        AutoItX3 _robot = new AutoItX3();

        //Constructor()
        public static string InstalltionPath = string.Empty;
        public static string ServicesActivatorExe = string.Empty;
        public static string AdapterActivatorExe = string.Empty;
        public static string UninstallexePath = string.Empty;
        public static string Tmadapterregkeypath = string.Empty;
        public static string InstallersSourcePath = string.Empty;
        public static string LocalCopyPath = string.Empty;
        public static string ServicesInstallerExe = string.Empty;
        public static string AdapterInstallerExe = string.Empty;
        public static string PiInsightPath = string.Empty;
        public static string AiInsightpath = string.Empty;
        public static string ServerName = string.Empty;
        public static string ServerNameWithPort = string.Empty;
        public static string AdapterNameWithPort = string.Empty;
        public static string AccountLoginUserName = string.Empty;
        public static string AccountLoginUserPassword = string.Empty;
        public static string ExeAiInstallerPath = string.Empty;
        public static string ExeActivaterPath = string.Empty;

        public AutoHelper()
        {
            InstalltionPath = GetInstallPath();
            ServicesActivatorExe = @"" + InstalltionPath + @"\BRPublisher\bin\ActivationWizard.exe";
            AdapterActivatorExe = @"" + InstalltionPath + @"\Adapters\TMonitor\bin\TMAdapterActivation.exe";
            UninstallexePath = @"" + InstalltionPath + @"\Adapters\TMonitor\bin\InsightUnInstaller.exe";
            Tmadapterregkeypath = "Software\\Approva\\TMAdapter";
            InstallersSourcePath = @"\\serv02fs01\builds\10.1.6\10.1.6.0005.Signed";
            LocalCopyPath = @"C:\TempBuild";
            ServicesInstallerExe = @"" + LocalCopyPath + @"\Services\setup.exe";
            AdapterInstallerExe = @"" + LocalCopyPath + @"\Adapter\setup.exe";
            PiInsightPath = @"" + LocalCopyPath + @"\PI";
            AiInsightpath = @"" + LocalCopyPath + @"\AI";

            #region Adapter Activation

            ServerName = /*"SERV02239.approvalab.int";*/  /*"SERV02208";*/  "INPUDRGURAV1";
            ServerNameWithPort = /*"SERV02239:80"; *//*"SERV02208:80";*/  "INPUDRGURAV1:80";
            AdapterNameWithPort = /*"SERV02239:80";*/ /*"SERV02208:80";*/  "INPUDRGURAV1:80";
            AccountLoginUserName = /*@"approvalab.int\administrator"; */@"infor\rgurav";
            AccountLoginUserPassword = /*"approva";*/  "Swades 4";
            #endregion

            ExeAiInstallerPath = @"" + InstalltionPath + @"\Adapters\TMonitor\bin\InsightInstaller.exe";
            ExeActivaterPath = @"" + InstalltionPath + @"\Adapters\TMonitor\bin\ProcessModuleActivation.exe";
        }
        private static string _licensePath = @"C:\"; //UI
         
        private const string BiZrightInsallPath = "Software\\Approva\\BizRights";
        public const string IrcUsername = "a";
        public const string IrcPassword = "a";
        public const string IrcConfirmPassword = "a";
        public const string IrcOwnerName = "Raviraj";
        public const string IrcCompanyName = "Infor";
        public const string CoreDB = "CoreDB";
        public const string SqlUserName = "sa";
        public const string SqlPassword = "approva1@";

        public const string DataFilePath = @"C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\";
        public const string LogFilePath = @"C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\";
        public const string FileGroupPath = @"C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\";

        public const string ReportServer = "ReportServer";
        public const string ReportServerManageDir = "Reports";
        public const string ReportServerFolder = "IRC_CoreDB";
        
        public static string LicensePath
        {
            get
            {
                return _licensePath;
            }
        }


        #region Public Methods
        public bool ButtonClick(string appTitle, string text, string panelId, string btnControl, string selectionMessage)
        {

            try
            {
                _robot.WinActivate(appTitle);
                if (_robot.ControlGetText(appTitle, text, panelId) == selectionMessage || _robot.ControlGetText(appTitle, text, panelId).Contains(selectionMessage))
                {
                    _robot.ControlFocus(appTitle, text, btnControl);
                    _robot.Send("{ENTER}");
                    Sleep(500);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool KeyPress(string appTitle, string text, string controlId, string panelId, string selectionMessage, string key)
        {
            try
            {
                _robot.WinActivate(appTitle);
                //if (_robot.ControlGetText(appTitle, text, panelId) == selectionMessage || _robot.ControlGetText(appTitle, text, panelId).Contains(selectionMessage))
                //{
                    _robot.WinActivate(appTitle);
                    _robot.ControlFocus(appTitle, text, controlId);
                    Sleep(100);
                    _robot.Send(key);
                    if (key.Contains("{ALT down}"))
                    {
                        Sleep(100);
                        _robot.Send("{ALT up}");
                    }
                    Sleep(500);
                //}
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RunExe(string appTitle, string panelId, string selectionMessage, string exepath, string arguments)
        {
            bool isStarted = false;
            if (File.Exists(exepath))
            {

                ProcessStartInfo info = new ProcessStartInfo(exepath);
                info.UseShellExecute = true;
                info.Verb = "runas";
                if (arguments != string.Empty || arguments != "")
                    info.Arguments = arguments;
                Process.Start(info);
                Wait(appTitle, panelId, selectionMessage);
            }
            return isStarted;
        }

        public bool ControlSetText(string appTitle,
                                   string texttoSet,
                                   string controltoSetText,
                                   string cntrlpnltomatch,
                                   string selectionMessage)
        {
            try
            {
                bool returnvalue = false;
                if (_robot.ControlGetText(appTitle, "", cntrlpnltomatch) == selectionMessage)
                {
                    _robot.ControlFocus(appTitle, "", controltoSetText);
                    _robot.ControlSetText(appTitle, "", controltoSetText, texttoSet);
                    returnvalue = true;
                }
                Sleep(500);
                return returnvalue;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string ControlGetText(string appTitle, string controltoGetText, string cntrlpnltomatch, string selectionMessage)
        {
            try
            {
                _robot.WinActivate(appTitle);
                _robot.ControlFocus(appTitle, "", controltoGetText);
                return _robot.ControlGetText(appTitle, "", controltoGetText);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public void SelectRadioButton(string appTitle, string controltoselect)
        {
            _robot.ControlFocus(appTitle, "", controltoselect);
            _robot.Send("{SPACE}");
            Sleep(500);
        }

        public void CopyFiles(string insightnameSource, string insightnameDestination)
        {
            if (insightnameSource != string.Empty && insightnameDestination != string.Empty && insightnameSource != "" && insightnameDestination != "")
            {
                foreach (string dirPath in Directory.GetDirectories(insightnameSource, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(insightnameSource, insightnameDestination));
                }

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(insightnameSource, "*.*", SearchOption.AllDirectories))
                {
                    File.Copy(newPath, newPath.Replace(insightnameSource, insightnameDestination), true);
                }
            }
        }

        public void Sleep(int miliSeconds)
        {
            _robot.Sleep(miliSeconds);
        }

        public void Wait(string appTitle, string panelId, string selectionMessage)
        {
            bool isStarted = false;
            while (!isStarted)
            {
                Thread.Sleep(1000);
                var processes = Process.GetProcesses();
                foreach (var prServiceInstallExist in processes)
                {
                    if (prServiceInstallExist.MainWindowTitle == appTitle) ///*|| prServiceInstallExist.MainWindowTitle == "Continuous Monitoring Insight Setup"
                    {
                        _robot.ControlFocus(appTitle, "", panelId);
                        if (_robot.ControlGetText(appTitle, "", panelId) == selectionMessage || _robot.ControlGetText(appTitle, "", panelId).Contains(selectionMessage))
                        {
                            isStarted = true;
                            Thread.Sleep(1000);
                            Sleep(500);
                            break;
                        }
                    }
                }
            }
        }

        public void Reg()
        {
            for (int i = 0; i < 75; i++)
            {
                //bool isFinish = true; 
                //while (isFinish)
                //{
                Thread.Sleep(50);
                _robot.ControlFocus("Registry Editor", "", "[CLASS:SysTreeView32; INSTANCE:1]");
                _robot.Send("{F3}");
                Thread.Sleep(300);
                _robot.Send("{TAB}");
                Thread.Sleep(50);
                _robot.Send("{LEFT}");
                Thread.Sleep(50);
                _robot.Send("{DELETE}");
                Thread.Sleep(50);
                _robot.ControlFocus("Confirm Key Delete", "", "[CLASS:Button; INSTANCE:1]");
                _robot.MouseClick("LEFT", 1069, 525, 1, 0);
                Thread.Sleep(50);
                // }                
            }
        }

        public void SendMail(string to, string from, string subject, string bodyMessage)
        {
            try
            {
                MailMessage mail = new MailMessage(from, to);
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "mail.infor.com";
                mail.Subject = subject;
                mail.Body = bodyMessage;
                client.Send(mail);

                #region test
                //SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["SMTPServer"].ToString();//"serv0212.approva.int";
                //MailMessage msg = new MailMessage();
                //msg.To = to;// ConfigurationSettings.AppSettings["EmailTo"].ToString();
                //// msg.To = "Gaus.Sanadi@approva.net;Satish.Karambalkar@approva.net;Rajendra.Karpe@approva.net;sameer.deshmukh@approva.net";
                //msg.Cc = Cc;
                //msg.Subject = subject;

                //string Body = Convert.ToString(bodyMessage);
                ////msg.Body = bodyMessage;
                //msg.Body = Body;
                //msg.From = from;// "transformer@approva.net";
                //// msg.Cc = "Constancio.Fernandes@approva.net;";
                //msg.BodyFormat = MailFormat.Html;

                //SmtpMail.Send(msg); 
                #endregion
            }
            catch (Exception ex)
            {

            }
        }

        public string GetfocusText(string apptitle)
        {
            return _robot.ControlGetFocus(apptitle);
            Sleep(500);
        }

        public static string GetInstallPath()
        {
            RegistryKey regKey = null;
            regKey = Registry.LocalMachine.OpenSubKey(BiZrightInsallPath);
            string iPath = string.Empty;
            if (regKey != null)
            {
                iPath = regKey.GetValue("InstallPath").ToString();
            }
            return iPath;
        }

        public void CopyAllFilesToLocalPath()
        {
            try
            {
                
                // Copy Services and adapter
                string ServicesInstallersSourcePath = InstallersSourcePath + @"\BizRights Services.Release_x64";
                string ServicesInstallersDestinationPath = LocalCopyPath + "Services";
                File.Copy(ServicesInstallersSourcePath, ServicesInstallersDestinationPath, true);

                ////CopyFiles(ServicesInstallersSourcePath, ServicesInstallersDestinationPath);

                string AdapterInstallersSourcePath = InstallersSourcePath + @"\BizRights Adapter.Release_x64";
                string AdapterInstallersDestinationPath = LocalCopyPath + "Adapter";
                File.Copy(AdapterInstallersSourcePath, AdapterInstallersDestinationPath, true);
                CopyFiles(AdapterInstallersSourcePath, AdapterInstallersDestinationPath);

                // Copy Insight Builds
                string insightnameSource = string.Empty;
                string insightnameDestination = string.Empty;

                #region PI Insight Copy
                List<string> piInsightList = new List<string>();

                piInsightList.Add("ION PI");
                piInsightList.Add("SAP PI");
                piInsightList.Add("OFAC");
                piInsightList.Add("PeopleSoft PI");

                piInsightList.Add("Lawson PI\\Lawson S3 9.0");
                piInsightList.Add("Lawson PI\\Lawson S3 10.0");

                piInsightList.Add("Oracle PI\\Oracle 11 PI");
                piInsightList.Add("Oracle PI\\Oracle 12 PI");

                piInsightList.Add("Payroll Insight for Lawson\\Payroll Insight for Lawson 9.x");
                piInsightList.Add("Payroll Insight for Lawson\\Payroll Insight for Lawson 10.x");

                piInsightList.Add("CDM Insights 10.0.3\\ORACLE11 CDM");
                piInsightList.Add("CDM Insights 10.0.3\\ORACLE12 CDM");
                piInsightList.Add("CDM Insights 10.0.3\\PSFT CDM");
                piInsightList.Add("CDM Insights 10.0.3\\SAP CDM");



                string pIbuildpath = @"\\serv02fs01\Builds\Venus";

                foreach (var insight in piInsightList)
                {
                    insightnameSource = pIbuildpath + "\\" + insight;
                    insightnameDestination = PiInsightPath + "\\" + insight;

                    var directory = new DirectoryInfo(insightnameSource);
                    var latestFolder = (from f in directory.GetDirectories()
                                        orderby f.LastWriteTime descending
                                        select f).First();

                    insightnameSource = insightnameSource + "\\" + latestFolder;
                    insightnameDestination = insightnameDestination + "\\" + latestFolder;

                    CopyFiles(insightnameSource, insightnameDestination);

                }
                #endregion

                #region AI,GCCI Insight copy
                List<string> aiInsightList = new List<string>();

                //AI
                aiInsightList.Add("IONAI");
                aiInsightList.Add("ORCLAI");
                aiInsightList.Add("SAPAI");
                aiInsightList.Add("LAWSONAI");

                //GCCI
                aiInsightList.Add("ORCL-GCCI\\OracleFCLPCI");
                aiInsightList.Add("ORCL-GCCI\\OracleO2CPCI");
                aiInsightList.Add("ORCL-GCCI\\OracleP2PPCI");
                aiInsightList.Add("ORCL-GCCI\\OraclePAYROLLPCI");
                aiInsightList.Add("ORCL-GCCI\\ORCLSYSCI");


                foreach (var insight in aiInsightList)
                {
                    insightnameSource = InstallersSourcePath + "\\" + insight;
                    insightnameDestination = AiInsightpath + "\\" + insight;
                    insightnameDestination = insightnameDestination.Replace("\\ORCL-GCCI", "");
                    CopyFiles(insightnameSource, insightnameDestination);
                }
                #endregion


            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool IsServicesInstalled()
        {
            RegistryKey registryKey = null;
            try
            {
                registryKey = Registry.LocalMachine.OpenSubKey("SoftWare\\Approva\\BizRights");
                if (registryKey == null)
                {
                    return false;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                try
                {
                    if (registryKey != null)
                    {
                        registryKey.Close();
                    }
                }
                catch { }
            }
            return true;
        }

        public static bool IsAdapterInstalled()
        {
            RegistryKey registryKey = null;
            try
            {
                registryKey = Registry.LocalMachine.OpenSubKey("SoftWare\\Approva\\TMAdapter");
                if (registryKey == null)
                {
                    return false;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                try
                {
                    if (registryKey != null)
                    {
                        registryKey.Close();
                    }
                }
                catch { }
            }
            return true;
        }

        public static bool IsInsightInstalled(string insightName)
        {
            RegistryKey registryKey = null;
            try
            {
                registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Approva\TMAdapter\ProcessModules\" + insightName + "");
                if (registryKey == null)
                {
                    return false;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                try
                {
                    if (registryKey != null)
                    {
                        registryKey.Close();
                    }
                }
                catch { }
            }
            return true;
        }

        public void WaitPopup(string appTitle, string panelId, string selectionMessage, string PopupTitle)
        {
            bool isStarted = false;
            while (!isStarted)
            {
                Thread.Sleep(1000);
                var processes = Process.GetProcesses();
                foreach (var prServiceInstallExist in processes)
                {
                    if (prServiceInstallExist.MainWindowTitle == appTitle) ///*|| prServiceInstallExist.MainWindowTitle == "Continuous Monitoring Insight Setup"
                    {
                        _robot.ControlFocus(appTitle, "", panelId);
                        if (_robot.ControlGetText(PopupTitle, "", panelId) == selectionMessage || _robot.ControlGetText(PopupTitle, "", panelId).Contains(selectionMessage))
                        {
                            isStarted = true;
                            Thread.Sleep(1000);
                            Sleep(500);
                            break;
                        }
                    }
                }
            }
        }


        #endregion

    }
}
