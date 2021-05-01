using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_FS.net
{
    public class JsonArrayBean
    {
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

        public Datum[] data { get; set; }
        public class Datum
        {
            public string id { get; set; }
            public string faceimg { get; set; }
            public string applyid { get; set; }
            public string message { get; set; }
            public string applytime { get; set; }
            public string starttime { get; set; }
            public string endtime { get; set; }
            public string status { get; set; }
            public string type { get; set; }
        }
    }
}
