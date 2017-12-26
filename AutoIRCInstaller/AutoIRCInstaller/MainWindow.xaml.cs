using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using AutoItX3Lib;


namespace AutoIRCInstaller
{
    /// <summary>
    /// 
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string AppTille = "Infor Risk & Compliance Studio Setup";
        AutoItX3 x = new AutoItX3();
        public MainWindow()
        {
            bool instancecount = false;
            using (Mutex mutex = new Mutex(true, "AutoIRCInstaller", out instancecount))
            {
                if (instancecount)
                {

                   ** AutoInsightUninstaller Au = new AutoInsightUninstaller();
                    Au.StartInsightUninstaller();
                    //AutoUpgrade AU = new AutoUpgrade();
                    //AU.StartUpgradeInstaller();

                    //AutoHelper ah = new AutoHelper();
                    //InitializeComponent();

                    //AutoHelper helper = new AutoHelper();
                    //helper.CopyAllFilesToLocalPath();

                    //AutoAdapterUninstaller autoAdapterUninstaller = new AutoAdapterUninstaller();
                    //autoAdapterUninstaller.StartAdapterUninstaller();

                    //AutoServicesUninstaller SU = new AutoServicesUninstaller();
                    //SU.StartServicesUninstaller();


                    //x.Sleep(3000);



                    ServicesInstallation SI = new ServicesInstallation();
                    SI.StartServiceExe();
                    x.Sleep(5000);

                    x.Sleep(500);
                    ServicesActivation SA = new ServicesActivation();
                    SA.StartServiceActivationExe();
                    x.Sleep(5000);


                    AdapterInstallation AI = new AdapterInstallation();
                    AI.StartAdapterExe();
                    x.Sleep(5000);



                    AdapterActivation AA = new AdapterActivation();
                    AA.StartAdapterActivationExe();
                    x.Sleep(5000);



                    AutoInsightsInstaller ai = new AutoInsightsInstaller();
                    ai.StartAIInsightInstaller();
                    x.Sleep(5000);

                    //helper.SendMail("rbgurav@gmail.com,raviraj.gurav@infor.com", "raviraj.gurav@infor.com", "Auto IRC Installation", "Installation sis completed");




                    AutoInsightsInstaller PI = new AutoInsightsInstaller();
                    PI.StartPIInsightInstaller();

                    //AutoAdapterUninstaller un = new AutoAdapterUninstaller();
                    //un.StartServicesUninstaller();


                    // ah.SendMail("rbgurav@gmail.com", "Raviraj.gurav@infor.com", "Auto IRC Installation", "Installation is Completed");





                    //AutoInsightsInstaller AII = new AutoInsightsInstaller();
                    // AII.StartPIInsightInstaller();
                    // AII.CopyInsightstoLocalPath();            
                    // AII.StartPIInsightInstaller();

                    // IM.CopyFilesToLocalPath();

                    //AdapterInstallation ai = new AdapterInstallation();
                    //ai.StartAdapterExe();            

                    #region Studion Auto Installation

                    //AutoStudioInstaller studioInstaller = new AutoStudioInstaller();

                    //studioInstaller.InstallStudio();
                    //studioInstaller.InstallStudioDB();

                    #endregion

                    #region MyRegion

                    //Boolean Y = p[0].HasExited;

                    //System.Diagnostics.Process.Start(@"C:\SVN\Utilities\BOD writing utility\Utility\BOD writing utility\obj\Debug\BOD writing utility.exe");

                    //string btntext = x.ControlGetText("BOD Writing Utility", "", "WindowsForms10.BUTTON.app.0.141b42a_r9_ad16");

                    //x.WinActivate("BOD Writing Utility");

                    //x.ControlSetText("BOD Writing Utility", "", "WindowsForms10.EDIT.app.0.141b42a_r9_ad15", "INPUDRGURAV1");
                    //x.ControlSetText("BOD Writing Utility", "", "WindowsForms10.EDIT.app.0.141b42a_r9_ad12", "COREDB");
                    //x.ControlSetText("BOD Writing Utility", "", "WindowsForms10.EDIT.app.0.141b42a_r9_ad14", "sa");
                    //x.ControlSetText("BOD Writing Utility", "", "WindowsForms10.EDIT.app.0.141b42a_r9_ad13", "approva1@");


                    //x.ControlFocus("BOD Writing Utility","","WindowsForms10.BUTTON.app.0.141b42a_r9_ad16");
                    //x.Send("{ENTER}");

                    //  x.ControlSetText("BOD Writing Utility", "", "WindowsForms10.EDIT.app.0.141b42a_r9_ad11", @"C:\");
                    //int y = x.ControlFocus("BOD Writing Utility", "Start", "WindowsForms10.BUTTON.app.0.141b42a_r9_ad1");
                    // x.ControlGetFocus("BOD Writing Utility", "Start");
                    // //  x.ControlClick("BOD Writing Utility", "123", "EDIT", "LEFT", 1, 32, 13);

                    // int x1 = x.ControlGetPosX("[CLASS:WindowsForms10.Window.8.app.0.141b42a_r9_ad1]", "", "WindowsForms10.BUTTON.app.0.141b42a_r9_ad16");
                    // int y1 = x.ControlGetPosY("BOD Writing Utility", "Start", "WindowsForms10.BUTTON.app.0.141b42a_r9_ad16");

                    // x.MouseClick("LEFT", x1, y1, 1, -1);
                    //x.ToolTip("MyApp", 389, 568);
                    //x.ControlSetText("BOD Writing Utility","INPUDRGURAV1","TextBox", "txtSpecifySQLServer"); 

                    #endregion
                }
                else
                {
                    MessageBox.Show("AutoIRCInstaller is already running", "AutoIRCInstaller", MessageBoxButton.OK);
                }
            }
            System.Windows.Application.Current.Shutdown();
        }



    }
}
