using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoubanHouseRent
{
    class HouseRent
    {
        public void GetHouse(RichTextBox txtOut, DateTimePicker dtp, Dictionary<string, string> group , List<string> query)
        {
            string resultSet = "";
            foreach (KeyValuePair<string, string> pair in group)
            {
                foreach (string q in query)
                {
                    string url = SetUrl(pair.Value, q);

                    /* HAP Parse Html Page */
                    HapUtility hap = new HapUtility();
                    List<string> topics = hap.Parse(dtp, url);

                    foreach (string t in topics)
                    {
                        resultSet += pair.Key + ": " + q + "---" + t + Environment.NewLine + Environment.NewLine;
                    }
                }
            }
            txtOut.Text = resultSet;
        }

        private string SetUrl(string groupId, string keyword)
        {
            string url = "http://www.douban.com/group/search?cat=1013&q=" + keyword + "&group=" + groupId;

            return url;
        }
    }
}
