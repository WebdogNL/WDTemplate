using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Webdog.Web.Models;

namespace WDTemplate.Models
{
    public enum TagTypes { }
    public enum CategoryTypes { }
    public enum MenuTypes { }
    public enum PageTypes { standaard = 0, homepage = 1 }
    public enum ArticleTypes { standaard = 0, carousel = 1, footer = 3, voorstelling = 7, faq = 4 }
    public enum PageOptions { topmenu = 1, hoofdmenu = 6, nergens = 9, footermenu = 10 }
    public enum EmbedderTypes { }

    public static class HelperExtensions
    {
        // Renders a Razor view, returning the HTML as a string
        public static MvcHtmlString PagePrevNext(this HtmlHelper html, List<WDPage> myPages, int index)
        {
            // <a class="btn btn-primary disabled" href="#"><i class="fa fa-angle-left mr-1"></i> Previous</a>
            // <a class="btn btn-primary" href="#">Next<i class="fa fa-angle-right ml-1"></i></a>

            StringBuilder result = new StringBuilder();

            // terug
            TagBuilder previous = new TagBuilder("a");
            previous.AddCssClass("btn btn-primary btn-secondary btn-leftright");
            previous.InnerHtml = "<i class=\"fa fa-long-arrow-left mr-1\"></i>";
            try
            {
                var previous_page = myPages[index - 1];
                previous.MergeAttribute("href", previous_page.Url);
            }
            catch
            {
                try
                {
                    var previous_page = myPages.Last();
                    previous.MergeAttribute("href", previous_page.Url);
                }
                catch
                {
                    previous.AddCssClass("disabled");
                }
            }
            result.Append(previous.ToString());

            // vooruit
            TagBuilder next = new TagBuilder("a");
            next.AddCssClass("btn btn-primary btn-secondary btn-leftright");
            next.InnerHtml = "<i class=\"fa fa-long-arrow-right ml-1\"></i>";

            try
            {
                var next_page = myPages[index + 1];
                next.MergeAttribute("href", next_page.Url);
            }
            catch
            {
                try
                {
                    var next_page = myPages.First();
                    next.MergeAttribute("href", next_page.Url);
                }
                catch
                {
                    next.AddCssClass("disabled");
                }
            }
            result.Append(next.ToString());

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString PagePrevNext2(this HtmlHelper html, List<WDPage> myPages, int index)
        {
            // <a class="btn btn-primary disabled" href="#"><i class="fa fa-angle-left mr-1"></i> Previous</a>
            // <a class="btn btn-primary" href="#">Next<i class="fa fa-angle-right ml-1"></i></a>

            StringBuilder result = new StringBuilder();

            // terug
            TagBuilder previous = new TagBuilder("a");
            previous.AddCssClass("btn btn-primary");
            previous.InnerHtml = "<i class=\"fa fa-angle-left mr-1\"></i> Previous";
            try
            {
                var previous_page = myPages[index - 1];
                previous.MergeAttribute("href", previous_page.Url);
            }
            catch
            {
                try
                {
                    var previous_page = myPages.Last();
                    previous.MergeAttribute("href", previous_page.Url);
                }
                catch
                {
                    previous.AddCssClass("disabled");
                }
            }
            result.Append(previous.ToString());

            // vooruit
            TagBuilder next = new TagBuilder("a");
            next.AddCssClass("btn btn-primary");
            next.InnerHtml = "Next <i class=\"fa fa-angle-right ml-1\"></i>";

            try
            {
                var next_page = myPages[index + 1];
                next.MergeAttribute("href", next_page.Url);
            }
            catch
            {
                try
                {
                    var next_page = myPages.First();
                    next.MergeAttribute("href", next_page.Url);
                }
                catch
                {
                    next.AddCssClass("disabled");
                }
            }
            result.Append(next.ToString());

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString ArticlePrevNext(this HtmlHelper html, WDPage myPage, string myArticleId, int? myArticleType = null)
        {
            StringBuilder result = new StringBuilder();
            List<WDArticle> myArticles = myPage.Articles.OrderBy(a => a.Order).ToList();
            if (myArticleType != null)
            {
                myArticles = myArticles.Where(x => x.Type == myArticleType).ToList();
            }
            
            var index = myArticles.FindIndex(x => x.Id == myArticleId);

            // terug
            TagBuilder previous = new TagBuilder("a");
            previous.AddCssClass("btn btn-primary btn-secondary btn-leftright");
            previous.InnerHtml = "<i class=\"fa fa-long-arrow-left mr-1\"></i>";
            try
            {
                var previous_item = myArticles[index - 1];
                previous.MergeAttribute("href", previous_item.Url);
            }
            catch
            {
                try
                {
                    var previous_item = myArticles.Last();
                    previous.MergeAttribute("href", previous_item.Url);
                }
                catch
                {
                    previous.AddCssClass("disabled");
                }
            }
            result.Append(previous.ToString());

            // vooruit
            TagBuilder next = new TagBuilder("a");
            next.AddCssClass("btn btn-primary btn-secondary btn-leftright");
            next.InnerHtml = "<i class=\"fa fa-long-arrow-right ml-1\"></i>";

            try
            {
                var next_item = myArticles[index + 1];
                next.MergeAttribute("href", next_item.Url);
            }
            catch
            {
                try
                {
                    var next_item = myArticles.First();
                    next.MergeAttribute("href", next_item.Url);
                }
                catch
                {
                    next.AddCssClass("disabled");
                }
            }
            result.Append(next.ToString());

            return MvcHtmlString.Create(result.ToString());

        }

        public static MvcHtmlString ArticlePrevNext2(this HtmlHelper html, WDPage myPage, string myArticleId)
        {
            StringBuilder result = new StringBuilder();
            List<WDArticle> myArticles = myPage.Articles.OrderBy(a => a.Order).ToList();

            var index = myArticles.FindIndex(x => x.Id == myArticleId);

            // terug
            TagBuilder previous = new TagBuilder("a");
            previous.AddCssClass("btn btn-primary");
            previous.InnerHtml = "<i class=\"fa fa-angle-left mr-1\"></i> Previous";
            try
            {
                var previous_item = myArticles[index - 1];
                previous.MergeAttribute("href", previous_item.Url);
            }
            catch
            {
                try
                {
                    var previous_item = myArticles.Last();
                    previous.MergeAttribute("href", previous_item.Url);
                }
                catch
                {
                    previous.AddCssClass("disabled");
                }
            }
            result.Append(previous.ToString());

            // vooruit
            TagBuilder next = new TagBuilder("a");
            next.AddCssClass("btn btn-primary");
            next.InnerHtml = "Next <i class=\"fa fa-angle-right ml-1\"></i>";

            try
            {
                var next_item = myArticles[index + 1];
                next.MergeAttribute("href", next_item.Url);
            }
            catch
            {
                try
                {
                    var next_item = myArticles.First();
                    next.MergeAttribute("href", next_item.Url);
                }
                catch
                {
                    next.AddCssClass("disabled");
                }
            }
            result.Append(next.ToString());

            return MvcHtmlString.Create(result.ToString());

        }

        public static MvcHtmlString DynamicPrevNext(this HtmlHelper html, List<dynamic> myList, string Id, bool endless = false)
        {
            //<li><a href="#">Vorige</a></li>
            //<li><a href="#">Volgende</a></li>

            StringBuilder Result = new StringBuilder();

            var First = 0;
            var Current = myList.FindIndex(x => x.Id == Id);
            var Last = myList.Count - 1;
            var Total = myList.Count;

            // eerst link naar vorige in tekst
            TagBuilder Previous = new TagBuilder("li");
            Previous.AddCssClass("previous");
            TagBuilder Preva = new TagBuilder("a");
            //TagBuilder PrevIcon = new TagBuilder("span");

            Preva.SetInnerText("Previous");
            if (Current > First)
            {
                var PrevArticle = myList[Current - 1];
                Preva.MergeAttribute("href", PrevArticle.Url);
                Preva.MergeAttribute("title", PrevArticle.Title); //+ " | " + PrevArticle.DisplayDate.ToString("d MMMM yyy"));
                Preva.MergeAttribute("alt", PrevArticle.Title);
            }
            else
            {
                if (endless)
                {
                    var PrevArticle = myList.Last();
                    Preva.MergeAttribute("href", PrevArticle.Url);
                    Preva.MergeAttribute("title", PrevArticle.Title); // + " | " + PrevArticle.DisplayDate.ToString("d MMMM yyy"));
                    Preva.MergeAttribute("alt", PrevArticle.Title);
                }
                else
                {
                    Preva.MergeAttribute("href", "#");
                    Preva.AddCssClass("disabled");
                }
            }
            //PrevIcon.AddCssClass("lnr lnr-arrow-left");
            //Preva.InnerHtml = PrevIcon.ToString();
            Previous.InnerHtml = Preva.ToString();
            Result.Append(Previous);

            // dan Volgende
            TagBuilder Next = new TagBuilder("li");
            Next.AddCssClass("next");

            TagBuilder Nexta = new TagBuilder("a");
            //TagBuilder NextIcon = new TagBuilder("span");

            Nexta.SetInnerText("Next");
            if (Current < Last)
            {
                var NextArticle = myList[Current + 1];
                Nexta.MergeAttribute("href", NextArticle.Url);
                Nexta.MergeAttribute("title", NextArticle.Title); // + " | " + NextArticle.DisplayDate.ToString("d MMMM yyy"));
                Nexta.MergeAttribute("alt", NextArticle.Title);
            }
            else
            {
                if (endless)
                {
                    var NextArticle = myList.First();
                    Nexta.MergeAttribute("href", NextArticle.Url);
                    Nexta.MergeAttribute("title", NextArticle.Title); // + " | " + NextArticle.DisplayDate.ToString("d MMMM yyy"));
                    Nexta.MergeAttribute("alt", NextArticle.Title);
                }
                else
                {
                    Nexta.MergeAttribute("href", "#");
                    Nexta.AddCssClass("disabled");
                }
            }
            //NextIcon.AddCssClass("lnr lnr-arrow-right");
            //Nexta.InnerHtml = NextIcon.ToString();
            Next.InnerHtml = Nexta.ToString();
            Result.Append(Next);

            return MvcHtmlString.Create(Result.ToString());
        }
    }

}