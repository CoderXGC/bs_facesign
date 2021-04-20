using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BS_FS.net
{
    class HttpUitls
    {
        public static string Get(string Url)
        {
            //System.GC.Collect();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }

            return retString;
        }
        /*登录判断*/
        public static string LoginPost(string Url, string Data)
        {

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                byte[] bytes = Encoding.UTF8.GetBytes(Data);
                request.ContentType = "application/json;charset=UTF-8";
                request.ContentLength = bytes.Length;
                Stream myResponseStream = request.GetRequestStream();
                myResponseStream.Write(bytes, 0, bytes.Length);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();

                myStreamReader.Close();
                myResponseStream.Close();

                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
                return retString;
            }
            catch {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"0\",\"name\":\"123456\" }}"; ;
            }
        }
        /*上传文件*/
        public static string UploadimgPost(string Id,string Url, string  Path,string Filename)
        {
            try
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                client.Headers.Add("Content-Type", "application/form-data");//注意头部必须是form-data
                string filename = Filename + Id;
                client.QueryString["file"] = filename;
                byte[] fileb = client.UploadFile(new Uri(Url), "POST", Path);
                string res = Encoding.UTF8.GetString(fileb);
                return res;
            }
            catch (Exception ex)
       
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"0\",\"name\":\"123456\" }}"; ;
            }
        }

        /*查找请求*/
        public static string FindPost(string Url, string Data)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                byte[] bytes = Encoding.UTF8.GetBytes(Data);
                request.ContentType = "application/json;charset=UTF-8";
                request.ContentLength = bytes.Length;
                Stream myResponseStream = request.GetRequestStream();
                myResponseStream.Write(bytes, 0, bytes.Length);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();

                myStreamReader.Close();
                myResponseStream.Close();

                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
                return retString;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"0\",\"name\":\"123456\" }}"; ;
            }
        }
    }
}
