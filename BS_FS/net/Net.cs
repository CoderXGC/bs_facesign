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
       // private string homeurl = "http://bs.ylesb.com";
        public String UserLogin(String id, String pwd)
        {
            try
            {
                //地址
                string url = homeurl + "/user/login";
                //json参数
                string jsonParam = "{ \"id\":\"" + id + "\",\"password\":\"" + pwd + "\"}";
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
                string jsonParam = "{ \"id\":\"" + id + "\"}";
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

        public string Signin(String id, String signid, String latetime, String signintime ,String daytime,String signouttime)
        {
            try
            {
                //地址
                string url = homeurl + "/user/signin";
                //json参数
                string jsonParam = "{ \"id\":" + id + ",\"signid\":\"" + signid + "\",\"latetime\":\"" + latetime + "\",\"signintime\":\"" + signintime + "\",\"daytime\":\""+daytime+ "\",\"signouttime\":\"" + signouttime + "\"}";
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

        public string AdminLogin(string id, string pwd)
        {
            try
            {
                //地址
                string url = homeurl + "/admin/login";
                //json参数
                string jsonParam = "{ \"id\":" + id + ",\"password\":\"" + pwd + "\"}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }
        public string AddApply(string applyid, string message, string applytime, string starttime, string endtime, string id,string type,string time)
        {
            try
            {
                //地址
                string url = homeurl + "/user/addapply";
                //json参数
                string jsonParam = "{ \"applyid\":\"" + applyid + "\",\"message\":\"" + message + "\",\"applytime\":\"" + applytime + "\",\"starttime\":\"" + starttime + "\",\"endtime\":\"" + endtime + "\",\"id\":" + id + ",\"type\":\"" + type + "\",\"time\":\"" + time + "\"}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string FindApply(string id)
        {
            try
            {
                //地址
                string url = homeurl + "/user/findapply";
                //json参数
                string jsonParam = "{ \"id\":\"" + id + "\"}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string FinduserallApply(string id)
        {
            try
            {
                //地址
                string url = homeurl + "/user/finduserallapply";
                //json参数
                string jsonParam = "{ \"id\":\"" + id + "\"}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string DelApply(string id, string applyid)
        {
            try
            {
                //地址
                string url = homeurl + "/user/delapply";
                //json参数
                string jsonParam = "{ \"applyid\":\"" + applyid + "\",\"id\":\"" + id + "\"}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string Uppwd(string id, string password)
        {
            try
            {
                //地址
                string url = homeurl + "/user/updatepwd";
                //json参数
                string jsonParam = "{ \"id\":" + id + ",\"password\":\"" + password + "\"}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string FindAllApply(string id)
        {
            try
            {
                //地址
                string url = homeurl + "/admin/findallapply";
                //json参数
                string jsonParam = "";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string UpAudit(string applyid, string status)
        {
            try
            {
                //地址
                string url = homeurl + "/admin/upaudit";
                //json参数
                string jsonParam = "{ \"applyid\":\"" + applyid + "\",\"status\":\"" + status + "\"}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string FindAllSignUser(string id)
        {
            try
            {
                //地址
                string url = homeurl + "/user/findsignall";
                //json参数
                string jsonParam = "{ \"id\":\"" + id + "\"}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string FindAllSign()
        {
            try
            {
                //地址
                string url = homeurl + "/admin/findsignall";
                //json参数
                string jsonParam = "";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string FindAllSigntime(string daytime)
        {
            try
            {
                //地址
                string url = homeurl + "/admin/findsignalltime";
                //json参数
                string jsonParam = "{ \"daytime\":\"" + daytime + "\"}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
           
           
        }

        public string UpdateSignTime(string signintime, string signouttime)
        {
            try
            {
                //地址
                string url = homeurl + "/admin/updatesigntime";
                //json参数
                string jsonParam = "{ \"signintime\":\"" + signintime + "\", \"signouttime\":\"" + signouttime + "\"}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string UpdateUser(string id, string telnum, string email)
        {
            try
            {
                //地址
                string url = homeurl + "/user/updateuser";
                //json参数
                string jsonParam = "{ \"id\":\"" + id + "\", \"telnum\":\"" + telnum + "\", \"email\":\"" + email + "\"}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string AddUser(string id, string name, int did)
        {
            try
            {
                //地址
                string url = homeurl + "/admin/adduser";
                //json参数
                string jsonParam = "{ \"id\":\"" + id + "\", \"name\":\"" + name + "\", \"did\":" + did + "}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string DelUser(string id)
        {
            try
            {
                //地址
                string url = homeurl + "/admin/deluser";
                //json参数
                string jsonParam = "{ \"id\":\"" + id + "\"}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }

        public string FindUser()
        {
            try
            {
                //地址
                string url = homeurl + "/user/findall";
                //json参数
                string jsonParam = "{}";
                //将接口传入，这个HttpUitls的类，有兴趣可以研究下，也可以直接用就可以，不用管如何实现。
                string getJson = HttpUitls.LoginPost(url, jsonParam);

                return getJson;
            }
            catch
            {
                return "{ \"code\":\"1000\",\"message\": \"服务器请求异常，请检查网络。\",\"data\": {\"user_id\": \"null\",\"name\":\"null\" }}";
            }
        }
    }
}
