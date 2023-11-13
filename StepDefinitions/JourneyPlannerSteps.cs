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
        private readonly ScenarioContext scenariocontext;

        public JourneyPlannerSteps(IWebDriver driver, ScenarioSettings scenarioSettings,ScenarioContext context) : base(driver,context)
        {
            ConfigData = Hooks.GetApplicationConfiguration();
            _scenarioSettings = scenarioSettings;
            scenariocontext = context;
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

        [When(@"I enter a valid arrival location (.*)")]
        public void WhenIEnterAValidArrivalLocationTempleUndergroundStation(string arrival)
        {
            HomePage.AddToLocation(arrival);
        }

        [Then(@"Arriving option is disaplayed")]
        public void ThenArrivingOptionIsDisaplayed()
        {
            HomePage.VerifyArrivalOption();
        }

        [Then(@"I edit the Arriving time")]
        public void ThenIEditTheArrivingTime()
        {
            HomePage.EditArrivingTime();
        }

        [When(@"I click plan my journey")]
        public void WhenIClickPlanMyJourney()
        {
            HomePage.ClickPlanMyJourney();
        }

        [Then(@"Journey results are not displayed")]
        public void ThenJourneyResultsAreNotDisplayed()
        {
            HomePage.VerifyTheErrorMessage();
        }

        [When(@"I click change time link")]
        public void WhenIClickChangeTimeLink()
        {
            HomePage.ClickChangeTime();
        }

        [Then(@"verify the journey results for the valid locations")]
        public void ThenVerifyTheJourneyResultsForTheValidLocations()
        {
            JourneyResultsPage.VerifyJourneyResults();
        }

        [Then(@"Verify Arriving time on Journey results page")]
        public void ThenVerifyArrivingTimeOnJourneyResultsPage()
        {
            JourneyResultsPage.VerifyArrvingTime();
        }

        [Then(@"No Search results message displayed")]
        public void ThenNoSearchResultsMessageDisplayed()
        {
            JourneyResultsPage.NoSearchResults();
        }

        [When(@"I click Edit Journey button")]
        public void WhenIClickEditJourneyButton()
        {
            JourneyResultsPage.ClickEditJourneyButton();
        }
        
        [When(@"I edit departure location to (.*)")]
        public void WhenIEditDepartureLocationToBayswaterUndergroundStation(string newLocation)
        {
            JourneyResultsPage.FromLocation(newLocation);
        }

        [When(@"I click Update Journey button")]
        public void WhenIClickUpdateJourneyButton()
        {
            JourneyResultsPage.ClickUpdateJourney();
        }

        [Then(@"I verify the (.*)  is updated")]
        public void ThenIVerifyTheBayswaterUndergroundStationIsUpdated(string updatedLocation)
        {
            JourneyResultsPage.VerifyUpdatedJourney(updatedLocation);
        }
    }
}
