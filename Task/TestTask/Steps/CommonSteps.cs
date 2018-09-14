using System.Diagnostics;
using SpecFlowTask.Browser;
using TechTalk.SpecFlow;

namespace TestTask.Steps
{
    [Binding]
    public class CommonSteps : Browsers
    {
        [BeforeScenario]
        public void BefereScenario()
        {
            KillTestProcess();
            InitialSettings();
            OpenBrowser();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Close();
            Driver.Dispose();
            KillTestProcess();
        }

        public void KillTestProcess()
        {
            KillProcesses("chrome.exe");
            KillProcesses("chromedriver.exe");
        }

        public void KillProcesses(string processName)
        {
            var nunitProcesses = Process.GetProcessesByName(processName);
            foreach (var process in nunitProcesses)
            {
                try
                {
                    process.Kill();
                }
                catch
                {
                    // ignored
                }
            }
        }
    }
}
