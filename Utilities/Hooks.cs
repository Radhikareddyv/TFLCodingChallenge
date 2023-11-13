using BoDi;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace TFLCodingChallenge.Utilities
{
    [Binding]
    public partial class Hooks :Steps
    {
        private IWebDriver _driver;
        public static ConfigData Configuration;
        private bool _driverStartedSuccessfully;
        private readonly ScenarioSettings _scenarioSettings;
        private readonly IObjectContainer _objectContainer;

        public Hooks(IObjectContainer objectContainer, ScenarioSettings scenarioSettings)
        {
            _objectContainer = objectContainer;
            _scenarioSettings = scenarioSettings;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driverStartedSuccessfully = StartDriver();
            _objectContainer.RegisterInstanceAs(_driver);
            string url = GetURLFromConfigFile();
            _scenarioSettings.BaseURL = url;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Configuration = GetApplicationConfiguration();
        }

        private static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("configuration.json")
                .Build();

            return builder;
        }

        public static ConfigData GetApplicationConfiguration()
        {
            var configuration = new ConfigData();

            var iConfig = GetConfig();

            iConfig.Bind(configuration);

            return configuration;
        }

        private string GetURLFromConfigFile()
        {
            string uri = Configuration.Url;
            if (uri == null)
                throw new Exception($"URL returned from configuration.json is null");
            return uri;
        }
    }
}
