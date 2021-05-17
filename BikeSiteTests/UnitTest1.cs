using System;
using System.Collections.Generic;
using System.Threading;
using HtmlAgilityPack;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace BikeSiteTests
{
    public class Tests
    {
        private IWebDriver driver;
        private string URL;

        [SetUp]
        public void Setup()
        {
            URL = "https://nofluffjobs.com/pl";
            driver = new FirefoxDriver();
        }

        [Test(Description = "Wybranie technologii na C#")]
        public void Test_NoFluffJobs_Technologies()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[1]/div/button")).Click();
            Thread.Sleep(1000);

            IWebElement technologyInput = driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[1]/popover-content/div/div[4]/nfj-filters-wrapper/div/div/nfj-filter-universal-section/nfj-filter-custom-control/section/div/div/div/input"));
            technologyInput.Clear();
            technologyInput.SendKeys("C#");

            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[1]/popover-content/div/div[4]/nfj-filters-wrapper/div/div/nfj-filter-universal-section/nfj-filter-custom-control/section/div/div/div/div/button")).Click();
            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[1]/popover-content/div/div[4]/nfj-filters-wrapper/div/nfj-filters-wrapper-buttons/div/button[2]")).Click();
        }

        [Test(Description = "Wybranie lokalizacji")]
        public void Test_NoFluffJobs_Localization()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[2]/div/button")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[2]/popover-content/div/div[4]/nfj-filters-wrapper/div/div/nfj-filter-universal-section/section[1]/div/nfj-filter-control[1]/button")).Click();
            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[2]/popover-content/div/div[4]/nfj-filters-wrapper/div/div/nfj-filter-universal-section/section[1]/div/nfj-filter-control[5]/button")).Click();
            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[2]/popover-content/div/div[4]/nfj-filters-wrapper/div/div/nfj-filter-universal-section/section[1]/div/nfj-filter-control[7]/button")).Click();
            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[2]/popover-content/div/div[4]/nfj-filters-wrapper/div/nfj-filters-wrapper-buttons/div/button[2]")).Click();

        }


        [Test(Description = "Ustawienie suwaka zarobków na 25.000 PLN")]
        public void Test_NoFluffJobs_Salary()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[3]/div/button/span")).Click();
            Thread.Sleep(1000);

            IWebElement Slider = driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[3]/popover-content/div/div[4]/nfj-filters-wrapper/div/div/nfj-filter-salary/section/div[1]/ngx-slider/span[4]"));
            IWebElement Button = driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[3]/popover-content/div/div[4]/nfj-filters-wrapper/div/div/nfj-filter-salary/section/div[1]/ngx-slider/span[6]"));
            Actions SliderAction = new Actions(driver);
            SliderAction.ClickAndHold(Button)
                .MoveByOffset((-(int)Slider.Size.Width / 2), 0).Release().Perform();

            var labelValue = driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[3]/popover-content/div/div[4]/nfj-filters-wrapper/div/div/nfj-filter-salary/section/div[1]/ngx-slider/span[10]")).Text;

            Assert.IsTrue(labelValue.Equals("25000 PLN"));
        }

        [Test(Description = "Ustawienie doœwiadczenia")]
        public void Test_NoFluffJobs_Experience()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[5]/div/button")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[5]/popover-content/div/div[4]/nfj-filters-wrapper/div/div/nfj-filter-universal-section/section/div/nfj-filter-control[4]/nfj-checkbox/label")).Click();
            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[5]/popover-content/div/div[4]/nfj-filters-wrapper/div/div/nfj-filter-universal-section/section/div/nfj-filter-control[5]/nfj-checkbox/label")).Click();

            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[5]/popover-content/div/div[4]/nfj-filters-wrapper/div/nfj-filters-wrapper-buttons/div/button[2]")).Click();

        }

        [Test(Description = "Wybranie technologii na C#")]
        public void Test_NoFluffJobs_More()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[6]/div/button")).Click();
            Thread.Sleep(1000);

            IWebElement technologyInput = driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[6]/popover-content/div/div[4]/nfj-filters-wrapper/div/div/nfj-filter-more/div/nfj-filter-custom-control/section/div/div/div/input"));
            technologyInput.Clear();
            technologyInput.SendKeys("Multisport");

            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[6]/popover-content/div/div[4]/nfj-filters-wrapper/div/div/nfj-filter-more/div/nfj-filter-custom-control/section/div/div/div/div/button")).Click();
            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-controls-toolbar/div/div/div/nfj-filters/div/nfj-filter-trigger[6]/popover-content/div/div[4]/nfj-filters-wrapper/div/nfj-filters-wrapper-buttons/div/button[2]")).Click();
        }

        [Test(Description = "Wybranie oferty z listy")]
        public void Test_NoFluffJobs_Select_Offer_From_The_List()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-main-content/div/div/div[1]/nfj-postings-search/div/common-main-loader/nfj-postings-list[1]")).Click();
        }

        [Test(Description = "Wys³anie maila z ofert¹ wybran¹ z listy")]
        public void Test_NoFluffJobs_Send_Mail_From_Select_Offer_From_The_List()
        {
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-main-content/div/div/div[1]/nfj-postings-search/div/common-main-loader/nfj-postings-list[1]")).Click();
            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-main-content/div/div/div[1]/nfj-posting-details/common-main-loader/section/div[2]/div[2]/nfj-posting-apply-box/nfj-posting-buttons/nfj-posting-share/button")).Click();
            driver.FindElement(By.XPath("/html/body/nfj-root/nfj-layout/nfj-main-content/div/div/div[1]/nfj-posting-details/common-main-loader/section/div[2]/div[2]/nfj-posting-apply-box/nfj-posting-buttons/nfj-posting-share/div/button[4]")).Click();

            //zmiana iframe na modal
            driver.SwitchTo().Frame("//*[@id=\"mat-dialog-2\"]/nfj-posting-share-email-modal");


            //*[@id="mat-dialog-2"]/nfj-posting-share-email-modal

            //odbiorca
            IWebElement receiverInput = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/nfj-posting-share-email-modal/common-material-modal/div[2]/div/form/div[1]/common-text-field/div/div[1]/input"));
            receiverInput.Clear();
            receiverInput.SendKeys("msobiecki.tests@gmail.com");

            //nadawca
            IWebElement senderInput = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/nfj-posting-share-email-modal/common-material-modal/div[2]/div/form/div[2]/common-text-field/div/div[1]/input"));
            senderInput.Clear();
            senderInput.SendKeys("test@test.com");

            IWebElement sendMessage = driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/mat-dialog-container/nfj-posting-share-email-modal/common-material-modal/div[2]/div/form/div[5]/div[2]/common-action-btn/button"));
            sendMessage.Click();

        }
    }
}