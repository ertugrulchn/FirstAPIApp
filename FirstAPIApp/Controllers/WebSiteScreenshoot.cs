using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPIApp.Controllers
{
    public class WebSiteScreenshoot : Controller
    {
        [HttpGet("WebSiteScreenshot")]
        public async Task GoogleSS(String postUrl)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 1000000000);
            var outputFile = @$"D:\Temp\Screenshoot-{number}.png";
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync(postUrl);
            await page.SetViewportAsync(new ViewPortOptions
            {
                Width = 1920,
                Height = 1080
            });
            await page.ScreenshotAsync(outputFile);
        }
    }
}
