﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_FS.net
{
    class JsonBean
    {
        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public string user_id { get; set; }
            /// <summary>
            /// 徐广超
            /// </summary>
            public string name { get; set; }
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