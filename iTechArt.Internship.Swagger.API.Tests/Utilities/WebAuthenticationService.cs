﻿using System;
using System.Text.RegularExpressions;
using iTechArt.Internship.Swagger.API.Tests.Entities.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities
{
    public class WebAuthenticationService
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public WebAuthenticationService()
        {
            _driver = DriverFactory.GetDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public string GetToken()
        {
            string token = null;
            var regex = new Regex(@".+access_token=");

            _driver.Navigate().GoToUrl(Configurator.LoginUrl);

            try
            {
                var userNameInput = _wait.Until(d => d.FindElement(By.Id("i0116")));
                userNameInput.SendKeys(Configurator.Login);

                var nextButton = _wait.Until(d => d.FindElement(By.Id("idSIButton9")));
                nextButton.Click();

                var passInput = _wait.Until(d => d.FindElement(By.Id("i0118")));
                passInput.SendKeys(Configurator.Password);

                var submitButton = _wait.Until(d => d.FindElement(By.Id("idSIButton9")));
                submitButton.Click();

                var backButton = _wait.Until(d => d.FindElement(By.Id("idBtn_Back")));
                backButton.Click();

                _wait.Until(d => d.Url.Contains("access_token"));
                token = regex.Replace(_driver.Url, "");
            }

            catch (Exception e)
            {
                // ignored
            }

            finally
            {
                _driver.Quit();
            }

            return token;
        }
    }
}