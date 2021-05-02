using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_FS.net
{
    public class JsonBean
    {
        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public string user_id { get; set; }
            public string id { get; set; }
            /// <summary>
            /// 徐广超
            /// </summary>
            public string name { get; set; }
            public string faceimg { get; set; }
            public string url { get; set; }
            public string signintime { get; set; }
            public string signouttime { get; set; }

            public string signid { get; set; }
            public int did { get; set; }
            public string role { get; set; }

            public string telnum { get; set; }
            public string email { get; set; }

        }

        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 请求成功
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }

    }




}
