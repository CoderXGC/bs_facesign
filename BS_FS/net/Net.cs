using Newtonsoft.Json;
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
    class Net : NetInterface
    {
        private string homeurl = "http://localhost:8080";
        //private string homeurl = "http://bs.ylesb.com";
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

        public string Uploadimgtest(string fileKeyName, string filePath, NameValueCollection stringDict)
        {
            try
            {
                //地址
                string url = homeurl + "/user/uploadimg";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.HttpUploadFile(url, filePath, fileKeyName, "image/jpeg", stringDict);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }

        }

        public string Uploadimgtest1(int Outtime, string fileKeyName, string filePath, NameValueCollection stringDict)
        {
            try
            {
                //地址
                string url = homeurl + "/user/uploadimg";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.HttpPostDataTest(url,Outtime, fileKeyName, filePath, stringDict);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string Addfaceimg(string id, string faceimg)
        {
            try
            {
                //地址
                string url = homeurl + "/user/addfaceimg";
                //json参数
                string jsonParam = "{ \"id\":" + id + ",\"faceimg\":"+"\""+ faceimg + "\"" + "}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.Addfaceimg(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string Findfaceimg(String id)
        {
            try
            {
                //地址
                string url = homeurl + "/user/findfaceimg";
                //json参数
                string jsonParam = "{ \"id\":" + id + "}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.FindFaceimgPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string Signin(String id, String signid, String flag, String signintime ,String daytime,String signouttime)
        {
            try
            {
                //地址
                string url = homeurl + "/user/signin";
                //json参数
                string jsonParam = "{ \"id\":" + id + ",\"signid\":\"" + signid + "\",\"signintime\":\"" + signintime + "\",\"daytime\":\""+daytime+ "\",\"signouttime\":\"" + signouttime + "\"}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.SigninPost(url,jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string Findsign(string id,string signid)
        {
            try
            {
                //地址
                string url = homeurl+"/user/findsign";
                //json参数
                string jsonParam = "{\"id\":"+id+ ",\"signid\":\""+signid+ "\"}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.FindSignPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
           

        }

        public string Signout(string id, string signid, string signouttime)
        {
            try
            {
                //地址
                string url = homeurl + "/user/signout";
                //json参数
                string jsonParam = "{ \"id\":" + id + ",\"signid\":\"" + signid + "\",\"signouttime\":\"" + signouttime + "\"}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.SignoutPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }

        }
    }
}
