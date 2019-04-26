using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string _id = "4x8";
            string time = "15:16.2342";
            List<string> registration_ids = new List<string>() { "4", "8", "15", "16", "23", "42" };
            List<string> company = new List<string>() { "台積電", "宏達電", "日月光", "中正大學", "鴻海", "中油" };
            //建立物件，塞資料
            List<RootObject> jData = new List<RootObject>();
            for (int i = 0; i < company.Count; i++) {
                RootObject root = new RootObject();
                root.id = company[i];
                root.link = time;
                root.dept = registration_ids;
                jData.Add(root);
            }
            //物件序列化
            string strJson = JsonConvert.SerializeObject(jData, Formatting.Indented);
            //輸出結果
            Response.Write(strJson);
        }
    }
}