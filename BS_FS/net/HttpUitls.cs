using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        public static string UploadimgPost(string Id,string Url, string  Path,string Filname)
        {
            try
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                client.Headers.Add("Content-Type", "application/form-data");//注意头部必须是form-data
               client.QueryString["id"] = Id;
                byte[] fileb = client.UploadFile(new Uri(Url), "POST", Path);
                string res = Encoding.UTF8.GetString(fileb);
                return res;
            }
            catch (Exception ex)
       
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"0\",\"name\":\"123456\" }}"; ;
            }
        }
        /*测试上传文件判断*/
        public static string UploadimgPostTest(string Id, string Url, string Path, string Filname)
        {

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                byte[] bytes = Encoding.UTF8.GetBytes(Path);
                request.ContentType = "application/form-data;charset=UTF-8";
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
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"0\",\"name\":\"123456\" }}";
            }
        }
        /// <summary>
        /// HttpWebRequest发送文件
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="paramName">文件参数名</param>
        /// <param name="contentType">contentType</param>
        /// <param name="nameValueCollection">其余要附带的参数键值对</param>
        public static String HttpUploadFile(string url, string filePath, string paramName, string contentType, NameValueCollection nameValueCollection)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;
            request.Credentials = CredentialCache.DefaultCredentials;
            Stream requestStream = request.GetRequestStream();
            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nameValueCollection.Keys)
            {
                requestStream.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nameValueCollection[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                requestStream.Write(formitembytes, 0, formitembytes.Length);
            }
            requestStream.Write(boundarybytes, 0, boundarybytes.Length);
            string header = string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n", paramName, filePath, contentType);
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            requestStream.Write(headerbytes, 0, headerbytes.Length);
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                requestStream.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();
            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            requestStream.Write(trailer, 0, trailer.Length);
            requestStream.Close();
            WebResponse webResponse = null;
            try
            {
                webResponse = request.GetResponse();
                Stream responseStream = webResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                string result = streamReader.ReadToEnd();
                return result;
            }
            catch (Exception ex)
            {
                if (webResponse != null)
                {
                    webResponse.Close();
                    webResponse = null;

                }
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"0\",\"name\":\"123456\" }}"; 
            }
            finally
            {
                request = null;
               
            }

        

        }
        public static string HttpPostDataTest(string url, int timeOut, string fileKeyName,
                                    string filePath, NameValueCollection stringDict)
        {
            string responseContent;
            var memStream = new MemoryStream();
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            // 边界符
            var boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
            // 边界符
            var beginBoundary = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            // 最后的结束符
            var endBoundary = Encoding.ASCII.GetBytes("--" + boundary + "--\r\n");

            // 设置属性
            webRequest.Method = "POST";
            webRequest.Timeout = timeOut;
            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;

            // 写入文件
            const string filePartHeader =
                "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
                 "Content-Type: application/octet-stream\r\n\r\n";
            var header = string.Format(filePartHeader, fileKeyName, filePath);
            var headerbytes = Encoding.UTF8.GetBytes(header);

            memStream.Write(beginBoundary, 0, beginBoundary.Length);
            memStream.Write(headerbytes, 0, headerbytes.Length);

            var buffer = new byte[1024];
            int bytesRead; // =0

            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                memStream.Write(buffer, 0, bytesRead);
            }

            // 写入字符串的Key
            var stringKeyHeader = "\r\n--" + boundary +
                                   "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                                   "\r\n\r\n{1}\r\n";

            foreach (byte[] formitembytes in from string key in stringDict.Keys
                                             select string.Format(stringKeyHeader, key, stringDict[key])
                                                 into formitem
                                             select Encoding.UTF8.GetBytes(formitem))
            {
                memStream.Write(formitembytes, 0, formitembytes.Length);
            }

            // 写入最后的结束边界符
            memStream.Write(endBoundary, 0, endBoundary.Length);

            webRequest.ContentLength = memStream.Length;

            var requestStream = webRequest.GetRequestStream();

            memStream.Position = 0;
            var tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();

            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            requestStream.Close();

            var httpWebResponse = (HttpWebResponse)webRequest.GetResponse();

            using (var httpStreamReader = new StreamReader(httpWebResponse.GetResponseStream(),
                                                            Encoding.GetEncoding("utf-8")))
            {
                responseContent = httpStreamReader.ReadToEnd();
            }

            fileStream.Close();
            httpWebResponse.Close();
            webRequest.Abort();

            return responseContent;
        }
        /*添加数据库判断*/
        public static string Addfaceimg(string Url, string Data)
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
        /*查找请求*/
        public static string FindFaceimgPost(string Url, string Data)
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
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"0\",\"name\":\"123456\" }}";
            }
        }
    }
}
