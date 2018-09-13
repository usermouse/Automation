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
    }
}
