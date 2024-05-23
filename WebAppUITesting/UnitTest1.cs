using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace WebAppUITesting
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver? driver;
        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5173");
        }
        [TestMethod]
        public void TestMethod1()
        {
            System.Threading.Thread.Sleep(5000); // wait for content to be loaded

            var openWeatherTimes = driver.FindElement(By.ClassName("RemoteTime"));
            var openWeatherTemp = driver.FindElement(By.ClassName("RemoteTemperature"));
            var openWeatherHumidity = driver.FindElement(By.ClassName("RemoteHumidity"));
            var openWeatherWeather = driver.FindElement(By.ClassName("RemoteWeather"));

            Assert.IsTrue(openWeatherTimes != null && !string.IsNullOrEmpty(openWeatherTimes.Text), "Weather time is not loaded or is empty.");
            Assert.IsTrue(openWeatherTemp != null && !string.IsNullOrEmpty(openWeatherTemp.Text), "Weather temperature is not loaded or is empty.");
            Assert.IsTrue(openWeatherHumidity != null && !string.IsNullOrEmpty(openWeatherHumidity.Text), "Weather humidity is not loaded or is empty.");
            Assert.IsTrue(openWeatherWeather != null && !string.IsNullOrEmpty(openWeatherWeather.Text), "Weather condition is not loaded or is empty.");


        }
        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}