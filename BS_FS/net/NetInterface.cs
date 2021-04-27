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
        string Signin(String id,String signid,String flag,String signintime,String daytime,String signouttime);
        string Signout(String id, String signid, String signouttime);
        string Findsign(String id,String signid);
        string AdminLogin(String id, String pwd);
    }
}
