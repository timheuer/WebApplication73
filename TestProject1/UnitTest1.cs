using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = false });

            var context = await browser.NewContextAsync(new BrowserNewContextOptions()
            {
                Locale = "de-DE"
            });

            var page = await context.NewPageAsync();
            await page.GotoAsync("https://tacticsview.azurewebsites.net");
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await page.ClickAsync("#navlink-consider");
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await page.ScreenshotAsync(new PageScreenshotOptions() { Path = "screenshots/consider-german.png" });
            await page.ClickAsync("#navlink-approved");
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await page.ScreenshotAsync(new PageScreenshotOptions() { Path = "screenshots/approved-german.png" });
        }
    }
}
