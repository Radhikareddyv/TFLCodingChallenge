using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TFLCodingChallenge.PageObjects;
using TFLCodingChallenge.Utilities;

namespace TFLCodingChallenge.StepDefinitions
{
    [Binding]

    public class JourneyPlannerSteps : BasePage
    {
        private readonly ScenarioSettings _scenarioSettings;
       
        public JourneyPlannerSteps(IWebDriver driver, ScenarioSettings scenarioSettings) : base(driver)
        {
            ConfigData = Hooks.GetApplicationConfiguration();
            _scenarioSettings = scenarioSettings;
          
        }
        [Given(@"I navigated to TFL website")]
        public void GivenINavigatedToTFLWebsite()
        {
            HomePage.GoToPage(_scenarioSettings.BaseURL);
            AcceptAllCookies();
        }

        [When(@"I enter a valid departure location (.*)")]
        public void WhenIEnterAValidDepartureLocationLondonWaterlooEastRailStation(string departure)
        {
            HomePage.AddFromLocation(departure);
        }

        [When(@"I click first journey from the journey results")]
        public void WhenIClickFirstJourneyFromTheJourneyResults()
        {
            JourneyResultsPage.GetAllJourneyResults();
        }

        [When(@"I enter a valid arrival location (.*)")]
        public void WhenIEnterAValidArrivalLocationTempleUndergroundStation(string arrival)
        {
            HomePage.AddToLocation(arrival);
        }

        [When(@"I click plan my journey")]
        public void WhenIClickPlanMyJourney()
        {
            HomePage.ClickPlanMyJourney();
        }

        [Then(@"verify the journey results for the valid locations")]
        public void ThenVerifyTheJourneyResultsForTheValidLocations()
        {
            JourneyResultsPage.VerifyResults();
        }

    }
}
