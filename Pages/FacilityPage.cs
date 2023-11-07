using OpenQA.Selenium;

namespace CultureESK.Pages
{
    public class FacilityPage : PageBase
    {
        public FacilityPage(IWebDriver driver) : base(driver) { }

        //Report Page Buttons
        private By StartDateBtn = By.XPath("(//div[@class='dx-dropdowneditor-icon'])[1]");
        private By EndDateBtn = By.XPath("(//div[@class='dx-dropdowneditor-icon'])[2]");
        private By CalendarMonthTitle = By.XPath("//span[@class='dx-button-text' and text()='октябрь 2023 г.']");
        private By January = By.XPath("//span[text()='янв.']");
        private By FirstDayOfJanuary = By.XPath("//span[text()='1']");
        private By ReportBtn = By.XPath("//*[@aria-label='Отчет']");
        private By DownloadExelBtn = By.XPath("//span[@class='dx-button-text' and contains(text(),'Скачать Excel')]");

        //Assert
        private By FacilityNameTitle = By.XPath("//th[text()='Наименование учреждения']");

        public void CheckThatFacilityNameTitle(string text)
        {
            Assert.True(GetText(FacilityNameTitle).Contains(text));
        }

        public void ReportGenerate()
        {
            Click(StartDateBtn);
            Click(CalendarMonthTitle);
            Click(January);
            Click(FirstDayOfJanuary);
            Click(ReportBtn);
        }

        public void DownloadExelReport()
        {
            Click(StartDateBtn);
            Click(CalendarMonthTitle);
            Click(January);
            Click(FirstDayOfJanuary);
            Click(ReportBtn);
            Click(DownloadExelBtn);
        }

    }
}
