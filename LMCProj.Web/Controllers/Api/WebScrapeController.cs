using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HtmlAgilityPack;
using ScrapySharp;
using LMCProj.Models.Request;
using ScrapySharp.Network;
using ScrapySharp.Extensions;
using LMCProj.Models.View;
using LMCProj.Models.Response;

namespace LMCProj.Web.Controllers.API
{
    [RoutePrefix("api/links")]
    public class WebScrapeController : ApiController
    {
        // GET api/<controller>
        [Route, HttpGet]
        public HttpResponseMessage GetAll()
        {
            ItemListResponse<LinkScrapingViewModel> resp = new ItemListResponse<LinkScrapingViewModel>();
            HtmlWeb browser = new HtmlWeb();
            //Browser.AllowAutoRedirect = true; // Browser has settings you can access in setup
            //Browser.AllowMetaRedirect = true;
            HtmlDocument PageResult = browser.Load("https://codeburst.io/");

            List<LinkScrapingViewModel> list = new List<LinkScrapingViewModel>();
            int index = 0;
            while (index < 3)
            {
                LinkScrapingViewModel model = new LinkScrapingViewModel();

                HtmlNode TitleNode = PageResult.DocumentNode.CssSelect("div[data-index=" + index + "] > div > a > span").First();
                model.Title = TitleNode.InnerText;
                HtmlNode DescriptionNode = PageResult.DocumentNode.CssSelect("div[data-index=" + index + "] > div.col > a > div > div").First();
                model.Description = DescriptionNode.InnerText;

                HtmlNode ImageNode = PageResult.DocumentNode.CssSelect("div[data-index=" + index + "] > div > a").First();
                string style = ImageNode.Attributes["style"].Value.ToString();
                model.Image = style.Split(';', '&')[2];

                model.Url = ImageNode.Attributes["href"].Value.ToString();

                list.Add(model);
                index++;
            }

            HtmlDocument PageResult2 = browser.Load("https://medium.com/dailyjs");

            index = 0;
            while (index < 3)
            {
                LinkScrapingViewModel model = new LinkScrapingViewModel();

                HtmlNode TitleNode = PageResult2.DocumentNode.CssSelect("div[data-index=" + index + "] > div > a > span").First();
                model.Title = TitleNode.InnerText;
                HtmlNode DescriptionNode = PageResult2.DocumentNode.CssSelect("div[data-index=" + index + "] > div.col > a > div > div").First();
                model.Description = DescriptionNode.InnerText;

                HtmlNode ImageNode = PageResult2.DocumentNode.CssSelect("div[data-index=" + index + "] > div > a").First();
                string style = ImageNode.Attributes["style"].Value.ToString();
                model.Image = style.Split(';', '&')[2];

                model.Url = ImageNode.Attributes["href"].Value.ToString();

                list.Add(model);
                index++;
            }

            resp.Items = list;
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }

        // GET api/<controller>/5
        [Route("getbyid"), HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [Route, HttpPost]
        public HttpResponseMessage Post([FromBody]LinkAddRequest model)
        {
            HtmlWeb site = new HtmlWeb();
            HtmlDocument doc = site.Load(model.Url);
            //HtmlNode[] node = doc.DocumentNode.I

            return Request.CreateResponse(HttpStatusCode.OK, "scraped");
        }

        // PUT api/<controller>/5
        [Route, HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [Route, HttpDelete]
        public void Delete(int id)
        {
        }
    }
}