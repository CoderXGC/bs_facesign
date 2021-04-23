using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_FS.net
{
    class JsonArrayBean
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
        }
    }
}
