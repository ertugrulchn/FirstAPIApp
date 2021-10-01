using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;
using PuppeteerSharp;
using System.IO;

namespace DataExtractionAPP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public String Get()
        {
            HttpClient webSite = new HttpClient();
            HttpResponseMessage client = webSite.GetAsync("http://meraklicoder.com/").Result;
            var html = client.Content.ReadAsStringAsync().Result;
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var sitePath = htmlDocument.DocumentNode.SelectNodes(@"//*[@id=""services""]/div/div[2]/div[1]/div/img");
            return HtmlEntity.DeEntitize(sitePath.First().GetAttributes("src").Last().Value);
        }

        [HttpGet("google")]
        [Obsolete]
        public async Task GoogleSS(String postUrl)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 1000000000);
            var outputFile = @$"D:\Temp\SS-{number}.png";
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
