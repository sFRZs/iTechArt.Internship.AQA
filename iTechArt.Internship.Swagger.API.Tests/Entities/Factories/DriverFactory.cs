using System.IO;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace iTechArt.Internship.Swagger.API.Tests.Entities.Factories
{
    public static class DriverFactory
    {
        public static IWebDriver GetDriver()
        {
            IWebDriver webDriver = Configurator.BrowserType.ToLower() switch
            {
                "chrome" => GetChromeDriver(),
                "firefox" => GetFireFoxDriver(),
                "brave" => GetBraveDriver(),
                _ => throw new InvalidDataException("This browser not supported!")
            };
            
            return webDriver;
        }
        private static IWebDriver GetChromeDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--disable-gpu");
            chromeOptions.AddArguments("--disable-extensions");
            chromeOptions.AddArguments("--headless");
            
            new DriverManager().SetUpDriver(new ChromeConfig());

            return new ChromeDriver(chromeOptions);
        }

        private static IWebDriver GetBraveDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.BinaryLocation = @"C:\Program Files (x86)\BraveSoftware\Brave-Browser\Application\brave.exe";
            chromeOptions.AddArguments("--disable-gpu");
            chromeOptions.AddArguments("--disable-extensions");
            chromeOptions.AddArguments("--headless");

            new DriverManager().SetUpDriver(new ChromeConfig());

            return new ChromeDriver(chromeOptions);
        }

        private static IWebDriver GetFireFoxDriver()
        {
            var ffOptions = new FirefoxOptions();
            ffOptions.AddArguments("--disable-gpu");
            ffOptions.AddArguments("--disable-extensions");
            ffOptions.AddArguments("--headless");

            new DriverManager().SetUpDriver(new FirefoxConfig());

            return new FirefoxDriver(ffOptions);
        }
    }
}