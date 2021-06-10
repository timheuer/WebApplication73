using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
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
            await using var browser = await playwright.Chromium.LaunchAsync();// new BrowserTypeLaunchOptions() { Headless = false });

            var context = await browser.NewContextAsync(new BrowserNewContextOptions()
            {
                Locale = "de-DE"
            });

            var page = await context.NewPageAsync();
            await page.GotoAsync("http://localhost:5000");
            await page.ScreenshotAsync(new PageScreenshotOptions()
            {
                Path = Path.Combine(Environment.GetEnvironmentVariable("WORKSPACE_ROOT") ?? String.Empty, "screenshots/test.png")
            });


            //await page.GotoAsync("https://tacticsview.azurewebsites.net");
            //await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            //await page.ClickAsync("#navlink-consider");
            //await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            //await page.ScreenshotAsync(new PageScreenshotOptions() 
            //{ 
            //    Path = Path.Combine(Environment.GetEnvironmentVariable("WORKSPACE_ROOT") ?? String.Empty, "screenshots/consider-german.png")
            //});
            //await page.ClickAsync("#navlink-approved");
            //await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
            //await page.ScreenshotAsync(new PageScreenshotOptions() 
            //{
            //    Path = Path.Combine(Environment.GetEnvironmentVariable("WORKSPACE_ROOT") ?? String.Empty, "screenshots/approved-german.png") 
            //});
        }
    }
}
