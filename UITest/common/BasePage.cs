using OpenQA.Selenium;

namespace UnitTestProject1.common
{
    public class BasePage
    {
        protected BasePage(IWebDriver driver, BrowserType type)
        {
            this.driver = driver;
            this.type = type;
        }

        protected BrowserType type;
        protected IWebDriver driver;
    }
}