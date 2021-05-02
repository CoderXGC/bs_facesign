using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_FS.net
{
    interface NetInterface
    {
        string UserLogin(String id, String pwd);
        string Uploadimg(String id, String path, string filename);
        string Find(String id);
        string Uploadimgtest(string fileKeyName, string filePath, NameValueCollection stringDict);
        string Uploadimgtest1(int Outtime,string fileKeyName, string filePath, NameValueCollection stringDict);

        string Addfaceimg(String id, String faceimg);
        string Findfaceimg(String id);
        string Signin(String id,String signid,String latetime, String signintime,String daytime,String signouttime);
        string Signout(String id, String signid, String signouttime);
        string Findsign(String id,String signid);
        string AdminLogin(String id, String pwd);
        string AddApply(String applyid, String message, String applytime, String starttime,String endtime, String id,String type,String time);
        string FindApply(String id);
        string FinduserallApply(String id);
        string DelApply(String id,String applyid);
        string Uppwd(String id, String password);
        string FindAllApply(String id);
        string UpAudit(String applyid, String status);
        string FindAllSignUser(String id);
        string FindAllSigntime(String daytime);
        string FindAllSign();
        string UpdateSignTime(String signintime, String signouttime);
        string UpdateUser(String id, String telnum,String email);
        string AddUser(String id, String name, int did);

    }
}
