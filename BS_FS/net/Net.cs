using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BS_FS.net 
{
    class Net : NetInterface
    {
        private string homeurl = "http://localhost:8080";
        public String Login(String id, String pwd)
        {
            try
            {
                //地址
                string url = homeurl + "/user/login";
                //json参数
                string jsonParam = "{ \"id\":" + id + ",\"password\":" + pwd + "}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }

        }
        public String Uploadimg(String id, String path,string filename)
        {
            try
            {
                //地址
                string url = homeurl + "/user/uploadimg";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.UploadimgPost(id,url, path,filename);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }


        }
        public String Find(String id)
        {
            try
            {
                //地址
                string url = homeurl + "/user/find";
                //json参数
                string jsonParam = "{ \"id\":" + id + "}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.FindPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }


        }

   
    }
}
