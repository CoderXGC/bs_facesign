using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_FS
{
    class DataWrite
    {
        public delegate void UpdateUI(int step);//声明一个更新主线程的委托
        public UpdateUI UpdateUIDelegate;

        public delegate void AccomplishTask();//声明一个在完成任务时通知主线程的委托
        public AccomplishTask TaskCallBack;

        public void Write(object lineCount)
        {
            System.IO.StreamWriter writeIO = new StreamWriter("text.txt", false, Encoding.GetEncoding("gb2312"));
            string head = "编号,省,市";
            writeIO.Write(head);
            for (int i = 0; i < (int)lineCount; i++)
            {
                writeIO.WriteLine(i.ToString() + ",湖南,衡阳");
                //写入一条数据，调用更新主线程ui状态的委托
                UpdateUIDelegate(1);
            }
            //任务完成时通知主线程作出相应的处理
            TaskCallBack();
            writeIO.Close();
        }
    }
}
