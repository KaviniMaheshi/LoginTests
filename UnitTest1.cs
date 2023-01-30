using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LoginTests
{
    public class UnitTest1
    {
        [Fact]
        // element availability
        public void PageElementAvailable()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com/login/");

            var emailAvailable = driver.FindElement(By.Id("email")).Displayed;
            Assert.True(emailAvailable);            

            var passAvailable = driver.FindElement(By.Id("pass")).Enabled;
            Assert.True(passAvailable);

            var btnLoginAvailable = driver.FindElement(By.Id("loginbutton")).Enabled;
            Assert.True(passAvailable);
        }

        [Fact]
        public void InvalidLogiTest()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com/login/");

            IWebElement emailElement = driver.FindElement(By.Id("email"));
            emailElement.SendKeys("nwmahe.09@gmail.com");

            IWebElement passwordElement = driver.FindElement(By.Id("pass"));
            passwordElement.SendKeys("12345");

            IWebElement btnLoginElement = driver.FindElement(By.Id("loginbutton"));
            btnLoginElement.Click();

            IWebElement messageElement = driver.FindElement(By.ClassName("fsl fwb fcb"));

            Assert.Equal("You've entered an old password", messageElement.Text);
        }

        public void ValidLogiTest()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com/login/");

            IWebElement emailElement = driver.FindElement(By.Id("email"));
            emailElement.SendKeys("nwmahe.09@gmail.com");

            IWebElement passwordElement = driver.FindElement(By.Id("pass"));
            passwordElement.SendKeys("12345");

            IWebElement btnLoginElement = driver.FindElement(By.Id("loginbutton"));
            btnLoginElement.Click();

            IWebElement messageElement = driver.FindElement(By.XPath("//div[@class,\"Password is required\"]"));

            Assert.Equal("You've entered an old password", messageElement.Text);
        }
    }
}
