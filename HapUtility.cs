using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

//using WinForm = System.Windows.Forms;

namespace DoubanHouseRent
{
    /// <summary>
    /// class for HtmlAgilityPack parsing
    /// </summary>
    class HapUtility
    {
        /// <summary>
        /// 解析html页面
        /// </summary>
        /// <param name="dtp"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public List<string> Parse(DateTimePicker dtp, string url)
        {
            List<string> topics = new List<string>();

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            HtmlNode root = doc.DocumentNode;
            HtmlNode tableNode = root.SelectSingleNode("//div[@class=\"topics\"]/table[@class=\"olt\"]/tbody");
            if (tableNode != null)
            {
                HtmlNodeCollection rows = tableNode.SelectNodes("./tr");
                if (rows != null)
                {
                    foreach (HtmlNode row in rows)
                    {
                        HtmlNodeCollection data = row.SelectNodes("./td[position()<3]");
                        string topic = "";

                        HtmlAttributeCollection attrs = data[1].Attributes;
                        HtmlAttribute dt = attrs["title"];
                        DateTime date = Convert.ToDateTime(dt.Value);

                        if (DateTime.Compare(date, dtp.Value) < 0)
                        {
                            break;
                        }
                        else
                        {
                            string href = data[0].SelectSingleNode("./a").Attributes["href"].Value;
                            topic = data[0].InnerText + " " + date + " " + href;
                            topics.Add(topic);
                        }
                    }
                }
            }
            return topics;
        }
    }
}
