using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using UnitTestProject1.common;

namespace UnitTestProject1
{
    public class TestBase
    {
        private IWebDriver _webDriver;
        public EventFiringWebDriver driver;
        public string BaseURL { get; protected set; }
        public string NewBaseURL { get; protected set; }
        public BrowserType Browser { get; protected set; }
        protected WebDriverWait wait;
        private static string pathfolder;
        private static string folderName = "TestResult";
        protected readonly static string appiumFilePath = @"C:\AppiumLog\appiumLog.txt";

        public ILog log = LogManager.GetLogger(typeof(TestBase));


        public void Initialize(BrowserType browser)
        {
            Browser = browser;
            ChromeOptions chromeOptions = new ChromeOptions();
            switch (Browser)
            {
                case BrowserType.Chrome:
                    //ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
                    chromeOptions.AddArgument("--disable-notifications");
                    _webDriver = new ChromeDriver(chromeOptions);
                    WebDriverEventFiring();
                    break;

                case BrowserType.Firefox:
                    FirefoxOptions options = new FirefoxOptions();
                    options.SetLoggingPreference(LogType.Browser, LogLevel.All);
                    _webDriver = new FirefoxDriver();

                    WebDriverEventFiring();
                    break;

                case BrowserType.MobileEmulator:

                    chromeOptions.EnableMobileEmulation("iPhone 6");
                    _webDriver = new ChromeDriver(chromeOptions);
                    WebDriverEventFiring();
                    break;

            }

            if (Browser != BrowserType.MobileChrome)
            {
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            else
            {
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            }

            //BaseURL = "http://localhost:8080/web/home.html";
            BaseURL = "http://localhost:2122/web/home.html";
        }

        [SetUp]
        public void SetupTest()
        {

        }

        [TearDown]
        public void TearDown()
        {

         


        }

        [OneTimeTearDown]
        public void Cleanup()
        {

            driver.Quit();
            driver.Dispose();
        }

        public void WebDriverEventFiring()
        {
            driver = new EventFiringWebDriver(_webDriver);
            driver.ExceptionThrown += firingDriver_ExceptionThrown;
            driver.FindingElement += firingDriver_FindingElement;
            driver.FindElementCompleted += firingDriver_FindElementCompleted;
            driver.ElementClicking += firingDriver_ElementClicking;
            driver.ElementClicked += firingDriver_ElementClicked;
            driver.Navigating += firingDriver_Navigating;
            driver.Navigated += firingDriver_Navigated;
            driver.NavigatingBack += firingDriver_NavigatingBack;
            driver.NavigatedBack += firingDriver_NavigatedBack;
            driver.NavigatingForward += firingDriver_NavigatingForward;
            driver.NavigatedForward += firingDriver_NavigatedForward;

        }


        private void GetScreenShot(IWebDriver webDriver, WebDriverExceptionEventArgs e)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
            var path = Path.Combine(GetFolder(), @"Screenshot\");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            ITakesScreenshot shot = (ITakesScreenshot)e.Driver;
            shot.GetScreenshot().SaveAsFile(path + timestamp + ".png", ScreenshotImageFormat.Png);
            log.Info(e.ThrownException.Message);

        }

        private void firingDriver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {

            //GetScreenShot(e.Driver, e);
            log.Info(e.ThrownException.Message);
        }

        void firingDriver_FindingElement(object sender, FindElementEventArgs e)
        {

            try
            {
                WebDriverWait wait = new WebDriverWait(new SystemClock(), e.Driver, TimeSpan.FromSeconds(3), TimeSpan.FromMilliseconds(100));
                //wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(e.FindMethod));
                wait.Until(ExpectedConditions.ElementIsVisible(e.FindMethod));
                wait.Until(ExpectedConditions.ElementExists(e.FindMethod));
                log.Info(e.FindMethod.ToString());

                log.Info("FindingElement from " + (e.Element == null ? "IWebDriver " : "IWebElement ") + e.FindMethod.ToString());
            }
            catch (Exception exception)
            {
                log.Info(exception.Message);
                log.Info("wait condition is not met");
            }
        }

        void firingDriver_FindElementCompleted(object sender, FindElementEventArgs e)
        {

            log.Info("FindElementCompleted from " + (e.Element == null ? "IWebDriver " : "IWebElement ") + e.FindMethod.ToString());
        }

        void firingDriver_ElementClicking(object sender, WebElementEventArgs e)
        {

            //wait = new WebDriverWait(new SystemClock(), e.Driver, TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(100));
            //wait.Until(ExpectedConditions.ElementToBeClickable(e.Element));           
        }

        private void firingDriver_ElementClicked(object sender, WebElementEventArgs e)
        {

            try
            {
                log.Info(((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState"));
                wait = new WebDriverWait(new SystemClock(), e.Driver, TimeSpan.FromSeconds(3), TimeSpan.FromMilliseconds(100));
                //wait.Until(ExpectedConditions.ElementToBeSelected(e.Element));
                wait.Until(
                   driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                log.Info(((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState"));
                log.Info("Clicked");
            }
            catch (Exception exception)
            {

            }
        }

        void firingDriver_Navigating(object sender, WebDriverNavigationEventArgs e)
        {


            log.Info("Navigating " + e.Url);
            e.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
        }

        void firingDriver_Navigated(object sender, WebDriverNavigationEventArgs e)
        {

            //wait = new WebDriverWait(e.Driver, TimeSpan.FromSeconds(10));
            // wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            log.Info("Navigated " + e.Url);
        }

        void firingDriver_NavigatingBack(object sender, WebDriverNavigationEventArgs e)
        {

            log.Info("Navigating back");
        }

        void firingDriver_NavigatedBack(object sender, WebDriverNavigationEventArgs e)
        {

            log.Info("Navigated back");
        }

        void firingDriver_NavigatingForward(object sender, WebDriverNavigationEventArgs e)
        {

            log.Info("Navigating forward");
        }

        void firingDriver_NavigatedForward(object sender, WebDriverNavigationEventArgs e)
        {

            log.Info("Navigated forward");
        }

        private static string GetFolder()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            path = Path.GetDirectoryName(path);
            DirectoryInfo info = new DirectoryInfo(path);
            path = info?.Parent?.Parent?.Parent?.FullName;
            path = Path.Combine(path, folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            pathfolder = path;
            path = Path.Combine(path, "TestResult.html");
            return path;
        }

    }
}