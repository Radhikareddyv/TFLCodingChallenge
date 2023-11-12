using OpenQA.Selenium;
using TFLCodingChallenge.Utilities;

namespace TFLCodingChallenge.PageObjects
{
    public class BasePage : BaseClass
    {
        public ConfigData ConfigData;
        public HomePage HomePage;
        public JourneyResultsPage JourneyResultsPage;

        public BasePage(IWebDriver driver) : base(driver)
        {

            ConfigData = Hooks.GetApplicationConfiguration();
            HomePage = new HomePage(driver);
            JourneyResultsPage = new JourneyResultsPage(driver);
        }

        private readonly By cookieAcceptBtnLocator = By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll");
        public void AcceptAllCookies()
        {
            IWebElement cookieAcceptBtn;
            try
            {
                cookieAcceptBtn = WaitForAndGetElement(cookieAcceptBtnLocator, 0);
                ClickElement(cookieAcceptBtn);
            }
            catch (StaleElementReferenceException)
            {
                cookieAcceptBtn = WaitForAndGetElement(cookieAcceptBtnLocator, 0);
                if (cookieAcceptBtn != null)
                {

                    cookieAcceptBtn.Click();

                }
            }
        }

    }
}
