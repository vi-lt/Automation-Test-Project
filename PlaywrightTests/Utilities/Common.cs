using Microsoft.Playwright;
using NUnit.Allure.Attributes;

namespace PlaywrightTests.Utilities
{

    public class Common(IPage Page)
    {
        private readonly IPage _page = Page;

        //Navigate to IPage
        [AllureStep]
        public async Task Navigate(string Url)
        {
            await _page.GotoAsync(Url);
        }

        //Close Browser
        [AllureStep]
        public async Task CloseBrowser()
        {
            await _page.CloseAsync();
        }

        //Action with keyboard
        [AllureStep]
        public async Task PresEnterButton(ILocator locator)
        {
            await locator.PressAsync("Enter");
        }

        //Wait to load
        [AllureStep]
        public async Task WaitToLoadTimeOut(float timeout)
        {
            await _page.WaitForTimeoutAsync(timeout);
        }

        // Get current URL
        [AllureStep]
        public async Task<string> GetCurrentUrl()
        {
            return _page.Url;
        }

        // Compare String
        [AllureStep]
        public void CompareString(string A, string B)
        {
            Assert.AreEqual(A, B, "The strings do not match.");
        }

        // Compare URLs
        [AllureStep]
        public async Task VerifyUrl(string expectedUrl)
        {
            var currentUrl = await GetCurrentUrl();
            CompareString(currentUrl, expectedUrl);
        }
    }
}
