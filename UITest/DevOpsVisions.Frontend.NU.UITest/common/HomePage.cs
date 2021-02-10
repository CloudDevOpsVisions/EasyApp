using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.common
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver, BrowserType type) : base(driver, type)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "title")]
        public IWebElement Title { get; set; }

        [FindsBy(How = How.Id, Using = "firstNumber")]
        public IWebElement FirstNumber { get; set; }

        [FindsBy(How = How.Id, Using = "secondNumber")]
        public IWebElement SecondNumber { get; set; }

        [FindsBy(How = How.Id, Using = "result")]
        public IWebElement Result { get; set; }

        [FindsBy(How = How.Id, Using = "sumbtn")]
        public IWebElement SumButton { get; set; }

        [FindsBy(How = How.Id, Using = "dividebtn")]
        public IWebElement DivideButton { get; set; }

        [FindsBy(How = How.Id, Using = "subtractbtn")]
        public IWebElement SubtractButton { get; set; }

        [FindsBy(How = How.Id, Using = "menu")]
        public IWebElement Menu { get; set; }

        [FindsBy(How = How.Id, Using = "changeText")]
        public IWebElement TextToChangeInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Change']")]
        public IWebElement ChangeButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Change Text')]")]
        public IWebElement ChangeTextMenuButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Change Color')]")]
        public IWebElement ChangeColorMenuButton { get; set; }

        [FindsBy(How = How.Id, Using = "message-body")]
        public IWebElement MessageBody { get; set; }
      





        public void TypeText(IWebElement inputField, string text )
        {
            inputField.SendKeys(text);
        }


    }
}