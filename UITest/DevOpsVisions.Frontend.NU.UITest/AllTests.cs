using NUnit.Framework;
using System.Threading;
using UnitTestProject1.common;

namespace UnitTestProject1
{
    [TestFixture]
    [TestFixtureSource(typeof(BrowserList), "GetBrowserFromConfig")]
    [Parallelizable]
    public class AllTests : TestBase
    {
        public AllTests(BrowserType browser)
        {
            Initialize(browser);
        }

        [Test]
        public void checkTitle()
        {
            driver.Url = BaseURL;
            HomePage homePage = new HomePage(driver, Browser);
            homePage.Title.Click();
            Assert.True(homePage.Menu.Displayed);
            Assert.True(homePage.Menu.Text.Contains("Change Text"));


        }

        [Test]
        public void closeChangeTextWithoutChanges()
        {
            var newTitle = "@NewTitle";
            driver.Url = BaseURL;
            HomePage homePage = new HomePage(driver, Browser);
            homePage.Title.Click();
            Assert.True(homePage.Menu.Displayed);
            Assert.True(homePage.Menu.Text.Contains("Change Text"));

            homePage.ChangeTextMenuButton.Click();
            Assert.True(homePage.TextToChangeInput.Displayed);

            homePage.TypeText(homePage.TextToChangeInput, newTitle);
            homePage.Title.Click();

            Assert.False(homePage.Title.Text.Equals(newTitle));
        }

        [Test]
        public void newTitleShouldBeDisplayed()
        {
            var newTitle = "@NewTitle";
            driver.Url = BaseURL;
            HomePage homePage = new HomePage(driver, Browser);
            homePage.Title.Click();
            Assert.True(homePage.Menu.Displayed);
            Assert.True(homePage.Menu.Text.Contains("Change Text"));

            homePage.ChangeTextMenuButton.Click();
            Assert.True(homePage.TextToChangeInput.Displayed);

            homePage.TypeText(homePage.TextToChangeInput, newTitle);
            homePage.ChangeButton.Click();

            Assert.True(homePage.Title.Text.Equals(newTitle));
        }

        [Test]
        public void blankTextInputShouldDispayeError()
        {
            var errorText = "Ooops, there is no value. Please enter the text you want to change.";
            driver.Url = BaseURL;
            HomePage homePage = new HomePage(driver, Browser);
            homePage.Title.Click();
            Assert.True(homePage.Menu.Displayed);
            Assert.True(homePage.Menu.Text.Contains("Change Text"));

            homePage.ChangeTextMenuButton.Click();
            Assert.True(homePage.TextToChangeInput.Displayed);

            homePage.TypeText(homePage.TextToChangeInput, "");
            homePage.ChangeButton.Click();
            Thread.Sleep(2000);
            Assert.True(homePage.MessageBody.Text.Equals(errorText));
        }
    }
}