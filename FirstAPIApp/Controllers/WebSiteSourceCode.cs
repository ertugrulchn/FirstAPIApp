using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FirstAPIApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebSiteSourceCode : ControllerBase
    {
        [HttpGet]
        public String Get(String url)
        {
            HttpClient webSite = new HttpClient();
            HttpResponseMessage client = webSite.GetAsync(url).Result;
            var html = client.Content.ReadAsStringAsync().Result;
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            return html;
        }
    }
}
