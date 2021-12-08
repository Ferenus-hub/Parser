using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Parser.Core.Default
{
    class DefaultParser : IParser<string[]>
    {
        public string[] Parse(string document)
        {
            var list = new List<string>();
            /*
             * <h2 class="tm-article-snippet__title tm-article-snippet__title_h2">
             *  <a href="/ru/post/594067/" data-article-link="" class="tm-article-snippet__title-link">
             *      <span>От 1FA к Zero-Trust через рынок ИБ</span>
             *  </a>
             * </h2>
            */
            foreach (Match Tag in Regex.Matches(document, @"<h2 class=""tm-article-snippet__title.*?"">(?<text>.*?)</h2>"))
            {
                foreach (Match Href in Regex.Matches(Tag.Groups["text"].Value, @"<a.*?href=(""|')(?<href>.*?)(""|').*?>(?<value>.*?)</a>"))
                {
                    foreach (Match Value in Regex.Matches(Href.Groups["value"].Value, @"<span.*?>(?<value>.*?)</span>"))
                    {
                        list.Add("url = " + Href.Groups["href"].Value + " nameUrl = " + Value.Groups["value"].Value);
                    }
                }
            }

            return list.ToArray();
        }
    }
}
