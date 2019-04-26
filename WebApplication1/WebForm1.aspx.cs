using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string title = Request.Form["title"]; //接受傳入的參數
            string content = Request.Form["content"]; //接受傳入的參數
            string output = "";
            if (title == null || content == null){
            }
            else {
                output = wordpress_restful(content,title);
            }
            
            Response.Write(output);
        }

        protected string wordpress_restful(string _content, string _title = "haha") {
            var web_address = "http://127.0.0.1/testTable/ver2/";
            var user = "admin";
            var password = "admin";
            var boundary = "----WebKitFormBoundary7MA4YWxkTrZu0gW";
            var article_title = _title;
            var article_content = "[mytable]\n\nyear,test3,Computer,Length\n\n1997,Ford,E350,2.34\n\n2000,Mercury,Cougar,2.38\n\n[/mytable]";
            var article_status = "publish";
            var client = new RestClient(web_address + "wp-json/wp/v2/posts") { Authenticator = new HttpBasicAuthenticator(user, password) };
            var request = new RestRequest(Method.POST);

            //article_title = _title;
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("content-type", "multipart/form-data; boundary=" + boundary);
            request.AddParameter("multipart/form-data; boundary=" + boundary + "", "--" + boundary + "\r\nContent-Disposition: form-data; name=\"title\"\r\n\r\n" + article_title + "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"content\"\r\n\r\n" + article_content + "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"status\"\r\n\r\n" + article_status + "\r\n--" + boundary + "--", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            dynamic content_decode = JValue.Parse(response.Content);
            
            return content_decode.link;
            //Console.ReadLine();
        }
    }
}