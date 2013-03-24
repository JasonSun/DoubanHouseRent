using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoubanHouseRent
{
    /// <summary>
    /// 
    /// </summary>
    class UrlParameter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetGroup()
        {
            Dictionary<string, string> grpDict = new Dictionary<string, string>();
            grpDict.Add("北京租房", "35417");
            grpDict.Add("豆瓣租房小组", "17261");
            grpDict.Add("北京租房豆瓣", "26926");
            grpDict.Add("北京房子", "42745");
            grpDict.Add("北京租房密探", "232413");
            grpDict.Add("合租信息交流", "88070");
            grpDict.Add("北京无中介租房", "262626");
            grpDict.Add("北京出租房请自觉统一标题格式", "276176");
            grpDict.Add("我想有个家", "61746");
            grpDict.Add("北漂爱合租", "135042");
            grpDict.Add("北漂拼房网", "196357");

            return grpDict;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> GetKeyword(string input)
        { 
            List<string> keyword = new List<string>();
            if (!string.IsNullOrEmpty(input.Trim()))
            {
                // 半角空格替换圆角空格
                input = input.Replace('　', ' ');
                keyword = input.Split(' ').ToList();
            }
            return keyword;
        }
    }
}
