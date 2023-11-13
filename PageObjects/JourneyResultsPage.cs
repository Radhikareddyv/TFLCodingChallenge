using Microsoft.VisualBasic.FileIO;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TFLCodingChallenge.Utilities;

namespace TFLCodingChallenge.PageObjects
{
    public class JourneyResultsPage : BaseClass
    {
        private IWebDriver driver;
        private ScenarioContext scenarioContext;

        public JourneyResultsPage(IWebDriver driver, ScenarioContext context) : base(driver)
        {
            this.driver = driver;
            this.scenarioContext = context;
        }

        private By _journeyResults = By.XPath("//div[@class='summary-results publictransport not-cycle-hire']");
        private By _options_Departure(string departure) => By.XPath($"//span[contains(text(),'{departure}')]");
        private By _options_Arrival(string arrival) => By.XPath($"//span[contains(text(),'{arrival}')]");
        private readonly By _editJourneyButton = By.CssSelector(".edit-journey");
        private readonly By _clearLocation = By.XPath("//a[text()='Clear From location']");
        private readonly By _departureStation = By.XPath("//input[@id='InputFrom']");
        private readonly By _updateJourneyButton = By.Id("plan-journey-button");

        private By _noResultsfound = By.CssSelector(".field-validation-errors");
        private readonly By _fromJourneyResult = By.XPath("//span[@class='notranslate']");
        private readonly By _journeysummary = By.XPath("//div[@class='summary-row clearfix']");

        public void VerifyJourneyResults()
        {
            Assert.IsTrue(IsElementExist(_journeyResults, 50000));
            var selectedDeparturePoint = ReturnMultipleElements(_fromJourneyResult).First().Text;
            var actualDeparturePoint = scenarioContext.Get<string>("departurePoint");
            Assert.That(actualDeparturePoint.Equals(selectedDeparturePoint));

            var selectedArrivalPoint = ReturnMultipleElements(_fromJourneyResult)[1].Text;
            var actualArrivalPoint = scenarioContext.Get<string>("arrivalPoint");
            Assert.That(actualArrivalPoint.Equals(selectedArrivalPoint));
        }
        
        public void NoSearchResults()
        {
            Assert.IsTrue(IsElementExist(_noResultsfound, 5000));
            string errorMessage = GetElement(_noResultsfound).Text;
            string actualTextMessage = "Journey planner could not find any results to your search. Please try again";
            Assert.IsTrue(errorMessage.Contains(actualTextMessage));
        }

        public void ClickEditJourneyButton()
        {
            ClickElementJS(_editJourneyButton);
        }

        public void FromLocation(string departure)
        {
            ClickElement(GetElement(_clearLocation));
            GetElement(_departureStation).SendKeys(departure);
        }

        public void ClickUpdateJourney()
        {
            ClickElement(GetElement(_updateJourneyButton));
        }

        public void VerifyUpdatedJourney(string updatedLocation)
        {
            var elementText = ReturnMultipleElements(_fromJourneyResult).First().Text;
            Assert.IsTrue(updatedLocation.Contains(elementText));
        }

        public void VerifyArrvingTime()
        {
            var summaryTime = "";
            var journeySummary = ReturnMultipleElements(_journeysummary);
            var updatedTimeText = scenarioContext.Get<string>("updatedTime");
            foreach (var summary in journeySummary)
            {
                if (summary.Text.Contains(updatedTimeText))
                {
                    summaryTime = GetElementLabelText(summary);
                }
            }
            Assert.IsTrue(summaryTime.Contains(updatedTimeText));
        }
    }
}
    
    

